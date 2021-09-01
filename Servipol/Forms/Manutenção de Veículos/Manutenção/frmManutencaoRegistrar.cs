using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servipol.Entidades.Classes;
using Npgsql;

namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    public partial class frmManutencaoRegistrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public string TipoVeiculo { get; set; }
        #endregion

        public frmManutencaoRegistrar()
        {
            InitializeComponent();
        }

        private void frmManutencaoRegistrar_Load(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();

                CarregaVeiculo();
                CarregaFuncionario();
                CarregaLocalManutencao();

            }
            finally
            {
                
            }
        }

        #region Methods

        public void CarregaFuncionario()
        {
            try
            {
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = "SELECT id_funcionario, CAST(CASE WHEN id_funcionario_cargo = 1 THEN codigo_ase || ' - ' || qra_ase ELSE nome END AS VARCHAR) AS nome FROM funcionario WHERE ativo = 'S' ORDER BY id_funcionario_cargo, codigo_ase ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxFuncionario.ValueMember = "id_funcionario";
                cBoxFuncionario.DisplayMember = "nome";
                cBoxFuncionario.DataSource = dt;
            }
            finally
            {
                cBoxFuncionario.SelectedIndex = -1;
            }
        }

        public void CarregaVeiculo()
        {
            try
            {
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT v.id_veiculo, CAST(CASE WHEN vt.descricao = 'CARRO' THEN v.descricao || ' ' || v.placa ELSE vt.descricao || ' ' || v.codigo END AS VARCHAR) AS veiculo FROM veiculo AS v JOIN veiculo_tipo AS vt ON(vt.id_veiculo_tipo = v.tipo) WHERE v.ativo = 'S' AND tipo != 3 ORDER BY  v.tipo DESC, v.codigo ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxVeiculo.ValueMember = "id_veiculo";
                cBoxVeiculo.DisplayMember = "veiculo";
                cBoxVeiculo.DataSource = dt;
            }
            finally
            {
                cBoxVeiculo.SelectedIndex = -1;
            }
        }

        public void CarregaDadosVeiculo()
        {
            try
            {
                if (cBoxVeiculo.SelectedIndex != -1)
                {
                    #region DECLARACAO DE VARIAVEIS
                    string CDV_descricao_veiculo = string.Empty, CDV_placa = string.Empty, CDV_km_ultima_troca_oleo_motor = string.Empty, CDV_data_ultima_troca_oleo_motor = string.Empty, CDV_km_diario = string.Empty, CDV_veiculo_tipo = string.Empty;
                    #endregion

                    NpgsqlCommand com = new NpgsqlCommand($"SELECT v.descricao, v.placa, v.tipo FROM veiculo AS v WHERE v.id_veiculo = {cBoxVeiculo.SelectedValue}", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CDV_descricao_veiculo = dr["descricao"].ToString();
                            CDV_placa = dr["placa"].ToString();
                            CDV_veiculo_tipo = dr["tipo"].ToString();
                        }
                        labelDescricao.Text = CDV_descricao_veiculo;
                        labelPlaca.Text = CDV_placa;

                        switch (CDV_veiculo_tipo)
                        {
                            case "1":
                                TipoVeiculo = "CARRO";
                                break;
                            case "2":
                                TipoVeiculo = "MOTO";
                                break;
                        }
                    }

                    NpgsqlCommand com2 = new NpgsqlCommand($"SELECT MAX(km_veiculo) AS ultimo_km_troca_oleo, MAX(TO_CHAR(data_manutencao, 'DD/MM/YYYY')) AS data_ultima_troca FROM manutencao WHERE id_tipo_manutencao = 1 AND id_veiculo = {cBoxVeiculo.SelectedValue} AND registro_excluido = 'N'", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr2 = com2.ExecuteReader())
                    {
                        while (dr2.Read())
                        {
                            CDV_km_ultima_troca_oleo_motor = dr2["ultimo_km_troca_oleo"].ToString();
                            CDV_data_ultima_troca_oleo_motor = dr2["data_ultima_troca"].ToString();
                        }
                        labelDataUltimaTrocaOleo.Text = CDV_data_ultima_troca_oleo_motor;
                        labelUltimoKM.Text = CDV_km_ultima_troca_oleo_motor;
                    }

                    NpgsqlCommand com3 = new NpgsqlCommand($"SELECT km_veiculo FROM km_diario WHERE id_veiculo = {cBoxVeiculo.SelectedValue} AND data_km_diario = CURRENT_DATE", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr3 = com3.ExecuteReader())
                    {
                        while (dr3.Read())
                        {
                            CDV_km_diario = dr3["km_veiculo"].ToString();
                        }
                        labelDataUltimaTrocaOleo.Text = CDV_data_ultima_troca_oleo_motor;
                    }

                    if (!string.IsNullOrEmpty(CDV_km_diario))
                    {
                        tBoxKmAtual.Text = CDV_km_diario;
                    }
                    else
                    {
                        tBoxKmAtual.Text = string.Empty;
                    }
                    tBoxKmAtual.SelectAll();
                }
            }
            catch { }
        }

        public void CarregaTipoManutencao()
        {
            try
            {
                if (TipoVeiculo == "MOTO")
                {
                    NpgsqlCommand com = new NpgsqlCommand();
                    com.Connection = BD.ObjetoConexao;
                    com.CommandText = $"SELECT id_manutencao_tipo, descricao, ordem FROM manutencao_tipo WHERE ativo = 'S' AND aplicacao_moto = 'S' ORDER BY 3 ASC";
                    NpgsqlDataReader dr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cBoxTipoManutencao.ValueMember = "id_manutencao_tipo";
                    cBoxTipoManutencao.DisplayMember = "descricao";
                    cBoxTipoManutencao.DataSource = dt;
                }
                else if (TipoVeiculo == "CARRO")
                {
                    NpgsqlCommand com = new NpgsqlCommand();
                    com.Connection = BD.ObjetoConexao;
                    com.CommandText = $"SELECT id_manutencao_tipo, descricao, ordem FROM manutencao_tipo WHERE ativo = 'S' AND aplicacao_carro = 'S' ORDER BY 3 ASC";
                    NpgsqlDataReader dr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cBoxTipoManutencao.ValueMember = "id_manutencao_tipo";
                    cBoxTipoManutencao.DisplayMember = "descricao";
                    cBoxTipoManutencao.DataSource = dt;
                }
            }
            finally
            {
                cBoxTipoManutencao.SelectedIndex = -1;
            }
        }

        public void VerificaTipoManutencao()
        {
            try
            {
                #region Variáveis
                string exige_km_troca_oleo = string.Empty, validade_km_troca_oleo_carro = string.Empty, validade_km_troca_oleo_moto = string.Empty;
                #endregion

                NpgsqlCommand com = new NpgsqlCommand($"SELECT mt.exige_km_validade_oleo, mt.km_validade_oleo_carro, mt.km_validade_oleo_moto FROM manutencao_tipo AS mt WHERE mt.id_manutencao_tipo = {cBoxTipoManutencao.SelectedValue}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        exige_km_troca_oleo = dr["exige_km_validade_oleo"].ToString();
                        validade_km_troca_oleo_carro = dr["km_validade_oleo_carro"].ToString();
                        validade_km_troca_oleo_moto = dr["km_validade_oleo_moto"].ToString();
                    }
                    if (exige_km_troca_oleo == "S")
                    {
                        cBoxKmValidadeOleo.Enabled = true;

                        if (TipoVeiculo == "CARRO")
                        {
                            cBoxKmValidadeOleo.SelectedItem = validade_km_troca_oleo_carro;
                        }
                        else if (TipoVeiculo == "MOTO")
                        {
                            cBoxKmValidadeOleo.SelectedItem = validade_km_troca_oleo_moto;
                        }
                    }
                    else
                    {
                        cBoxKmValidadeOleo.SelectedIndex = -1;
                        cBoxKmValidadeOleo.Enabled = false;
                    }
                }
            }
            finally
            { }
        }

        public void CarregaLocalManutencao()
        {
            try
            {
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id_manutencao_local, descricao FROM manutencao_local WHERE posto_combustivel = 'N' AND ativo = 'S' ORDER BY 2 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxLocalManutencao.ValueMember = "id_manutencao_local";
                cBoxLocalManutencao.DisplayMember = "descricao";
                cBoxLocalManutencao.DataSource = dt;
            }
            finally
            {
                cBoxLocalManutencao.SelectedIndex = -1;
            }
        }


        #endregion

        #region Buttons

        private void btnCancelarRegistro_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void cBoxTipoManutencao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxTipoManutencao.SelectedIndex != -1)
            {
                VerificaTipoManutencao();
            }
        }

        private void cBoxVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cBoxVeiculo.SelectedIndex != -1)
                {
                    labelDataUltimaTrocaOleo.Text = null;
                    labelUltimoKM.Text = null;
                    CarregaDadosVeiculo();
                    CarregaTipoManutencao();
                }
            }
            finally
            {
                tBoxKmAtual.Focus();
            }
        }
    }
}