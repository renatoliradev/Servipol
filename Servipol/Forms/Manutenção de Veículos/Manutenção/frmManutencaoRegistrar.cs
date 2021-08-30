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


            }
            finally
            {
                BD.Desconectar();
            }
        }

        #region Methods

        public void CarregaFuncionario()
        {
            try
            {
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = "SELECT id AS id_funcionario, CAST(CASE WHEN id_tipo_funcionario = 1 THEN codigo || ' - ' || qra ELSE nome END AS VARCHAR) AS qra FROM funcionarios WHERE ativo = 'S' ORDER BY id_tipo_funcionario, codigo ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxFuncionario.ValueMember = "id_funcionario";
                cBoxFuncionario.DisplayMember = "qra";
                cBoxFuncionario.DataSource = dt;
            }
            finally
            {
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
            }
        }

        public void CarregaDadosVeiculo()
        {
            try
            {
                if (cBoxVeiculo.SelectedIndex != -1)
                {
                    #region DECLARACAO DE VARIAVEIS
                    string CDV_descricao_veiculo = string.Empty, CDV_placa = string.Empty, CDV_km_ultima_troca_oleo_motor = string.Empty, CDV_data_ultima_troca_oleo_motor = string.Empty, CDV_km_diario = string.Empty;
                    #endregion

                    NpgsqlCommand com = new NpgsqlCommand("SELECT v.descricao_veiculo, v.placa FROM veiculos AS v WHERE v.id = " + cBoxVeiculo.SelectedValue + "", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CDV_descricao_veiculo = dr["descricao_veiculo"].ToString();
                            CDV_placa = dr["placa"].ToString();
                        }
                        labelDescricao.Text = CDV_descricao_veiculo;
                        labelPlaca.Text = CDV_placa;
                    }

                    NpgsqlCommand com2 = new NpgsqlCommand("SELECT MAX(km_veiculo) AS ultimo_km_troca_oleo, MAX(TO_CHAR(data_manutencao, 'DD/MM/YYYY')) AS data_ultima_troca FROM manutencao_veiculo WHERE id_tipo_manutencao = 1 AND id_veiculo = " + cBoxVeiculo.SelectedValue + " AND registro_excluido = 'N'", BD.ObjetoConexao);
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

                    NpgsqlCommand com3 = new NpgsqlCommand("SELECT km_veiculo FROM km_diario WHERE id_veiculo = " + cBoxVeiculo.SelectedValue + " AND data_km_diario = 'today'", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr3 = com3.ExecuteReader())
                    {
                        while (dr3.Read())
                        {
                            CDV_km_diario = dr3["km_veiculo"].ToString();
                        }
                        labelDataUltimaTrocaOleo.Text = CDV_data_ultima_troca_oleo_motor;
                    }

                    if (CDV_km_diario != string.Empty)
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
                if (auxTipoVeiculoSelecionado.Text == "MOTO")
                {
                    NpgsqlCommand com = new NpgsqlCommand();
                    com.Connection = BD.ObjetoConexao;
                    com.CommandText = "SELECT id_tipo_manutencao, descricao_manutencao, ordem FROM tipo_manutencao WHERE ativo = 'S' AND aplicacao_moto = 'S' ORDER BY 3 ASC";
                    NpgsqlDataReader dr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cBoxTipoManutencao.ValueMember = "id_tipo_manutencao";
                    cBoxTipoManutencao.DisplayMember = "descricao_manutencao";
                    cBoxTipoManutencao.DataSource = dt;
                }
                else if (auxTipoVeiculoSelecionado.Text == "CARRO")
                {
                    NpgsqlCommand com = new NpgsqlCommand();
                    com.Connection = BD.ObjetoConexao;
                    com.CommandText = "SELECT id_tipo_manutencao, descricao_manutencao, ordem FROM tipo_manutencao WHERE ativo = 'S' AND aplicacao_carro = 'S' ORDER BY 3 ASC";
                    NpgsqlDataReader dr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cBoxTipoManutencao.ValueMember = "id_tipo_manutencao";
                    cBoxTipoManutencao.DisplayMember = "descricao_manutencao";
                    cBoxTipoManutencao.DataSource = dt;
                }
            }
            finally
            {
            }
        }

        public void CarregaLocalManutencao()
        {
            try
            {
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = "SELECT id_local_manutencao, descricao FROM local_manutencao WHERE posto_combustivel = 'N' AND ativo = 'S' ORDER BY 2 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxLocalManutencao.ValueMember = "id_local_manutencao";
                cBoxLocalManutencao.DisplayMember = "descricao";
                cBoxLocalManutencao.DataSource = dt;
            }
            finally
            {
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
    }
}