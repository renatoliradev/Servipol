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
    public partial class frmRegistrarKmDiario : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        private static string km_ja_registrado = "0";
        private static string CDV_km_ultimo_registrado = string.Empty;
        #endregion

        public frmRegistrarKmDiario()
        {
            InitializeComponent();
        }

        private void frmRegistrarKmDiario_Load(object sender, EventArgs e)
        {
            BD.Conectar();
            carregaVeiculo();
            tBoxKmAtual.Clear();
            cBoxVeiculo.SelectedIndex = -1;
            cBoxVeiculo.Select();
        }

        #region Methods

        public void carregaVeiculo()
        {
            try
            {
                BD.Conectar();

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

        public void carregaDadosVeiculo()
        {
            try
            {
                if (cBoxVeiculo.SelectedIndex != -1)
                {

                    #region DECLARACAO DE VARIAVEIS
                    string CDV_numero_cf = string.Empty, CDV_descricao_veiculo = string.Empty, CDV_placa = string.Empty, CDV_data_ultimo_registrado = string.Empty, CDV_data_ultimo_abastecimento = string.Empty, CDV_hora_ultimo_abastecimento = string.Empty, CDV_combustivel = string.Empty, CDV_id_km_diario = string.Empty;
                    #endregion

                    NpgsqlCommand com = new NpgsqlCommand($"SELECT v.descricao, v.placa FROM veiculo AS v WHERE v.id_veiculo = {cBoxVeiculo.SelectedValue}", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CDV_descricao_veiculo = dr["descricao"].ToString();
                            CDV_placa = dr["placa"].ToString();
                        }
                        labelDescricao.Text = CDV_descricao_veiculo;
                        labelPlaca.Text = CDV_placa;
                    }

                    NpgsqlCommand com2 = new NpgsqlCommand($"SELECT MAX(id_km_diario) AS id_km_diario FROM km_diario WHERE id_veiculo = {cBoxVeiculo.SelectedValue}", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr2 = com2.ExecuteReader())
                    {
                        while (dr2.Read())
                        {
                            CDV_id_km_diario = dr2["id_km_diario"].ToString();
                        }
                    }

                    if (!string.IsNullOrEmpty(CDV_id_km_diario))
                    {
                        NpgsqlCommand com3 = new NpgsqlCommand($"SELECT km_veiculo, TO_CHAR(data_km_diario, 'dd/MM/yyyy') AS data_km_diario FROM km_diario WHERE id_km_diario = {CDV_id_km_diario}", BD.ObjetoConexao);
                        using (NpgsqlDataReader dr3 = com3.ExecuteReader())
                        {
                            while (dr3.Read())
                            {
                                CDV_km_ultimo_registrado = dr3["km_veiculo"].ToString();
                                CDV_data_ultimo_registrado = dr3["data_km_diario"].ToString();
                            }
                            labelUltimoKM.Text = CDV_data_ultimo_registrado + " - KM: " + CDV_km_ultimo_registrado;
                        }
                    }

                    //VERIFICA SE O KM DO DIA JÁ FOI REGISTRADO
                    NpgsqlCommand com4 = new NpgsqlCommand($"SELECT 1 AS km_ja_registrado FROM km_diario WHERE id_veiculo = {cBoxVeiculo.SelectedValue} AND data_km_diario = CURRENT_DATE", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr4 = com4.ExecuteReader())
                    {
                        while (dr4.Read())
                        {
                            km_ja_registrado = dr4["km_ja_registrado"].ToString();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message);
            }
        }

        private void cBoxVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelDescricao.Text = string.Empty;
            labelPlaca.Text = string.Empty;
            labelUltimoKM.Text = string.Empty;
            carregaDadosVeiculo();
        }

        private void tBoxKmAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            //restringe campo para poder digitar apenas numeros
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void tBoxKmAtual_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnConfirmar_Click(sender, e);
                    break;
            }
        }

        private void cBoxVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBoxKmAtual.Select();
                    break;
            }
        }

        private bool ValidaCampos()
        {
            if (cBoxVeiculo.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Selecione o veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxVeiculo.Select();
                return false;
            }
            else if (string.IsNullOrEmpty(tBoxKmAtual.Text))
            {
                XtraMessageBox.Show("Informe o KM do veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxKmAtual.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LimparCampos()
        {
            cBoxVeiculo.SelectedIndex = -1;
            tBoxKmAtual.Clear();

            cBoxVeiculo.Select();
        }

        private void frmRegistrarKmDiario_FormClosing(object sender, FormClosingEventArgs e)
        {
            BD.Desconectar();
        }

        #endregion

        #region Buttons

        private void btnFechar_Click(object sender, EventArgs e)
        {
            frmProxTrocaOleoRevisao frmProxTrocaOleoRevisao = new frmProxTrocaOleoRevisao();
            frmProxTrocaOleoRevisao.Owner = this.Owner;
            frmProxTrocaOleoRevisao.ShowDialog();
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidaCampos())
                {
                    return;
                }
                else
                {
                    if (km_ja_registrado == "1")
                    {
                        string sqlCommand1 = $"DELETE FROM km_diario WHERE id_veiculo = {cBoxVeiculo.SelectedValue} AND data_km_diario = CURRENT_DATE";
                        NpgsqlCommand command1 = new NpgsqlCommand(sqlCommand1, BD.ObjetoConexao);
                        command1.ExecuteNonQuery();
                    }

                    string sqlCommand = $"INSERT INTO km_diario VALUES (nextval('seq_km_diario'), {cBoxVeiculo.SelectedValue}, {tBoxKmAtual.Text}, CURRENT_DATE, {SessaoSistema.UsuarioId}, CURRENT_TIMESTAMP)";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    XtraMessageBox.Show("Registro Efetuado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao registrar Km Diário.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
    }
}