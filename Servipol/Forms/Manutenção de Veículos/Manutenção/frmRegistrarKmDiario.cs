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
        #region Instâncias
        readonly ConexaoBD BD = new ConexaoBD();

        private static string data = string.Empty;
        private static string veiculo = string.Empty;
        private static string km_veiculo = string.Empty;
        private static string km_ja_registrado = "0";
        private static decimal ultimo_km = 0;
        private static string CDV_km_ultimo_registrado = string.Empty;
        #endregion

        public frmRegistrarKmDiario()
        {
            InitializeComponent();
        }

        private void frmRegistrarKmDiario_Load(object sender, EventArgs e)
        {
            cBoxVeiculo.SelectedIndex = -1;
            tBoxKmAtual.Clear();

            carregaVeiculo();

            cBoxVeiculo.Select();
        }

        #region Buttons

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Methods

        public void carregaVeiculo()
        {
            try
            {
                BD.Conectar();

                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = "SELECT v.id_veiculo, CAST(CASE WHEN tv.descricao = 'CARRO' THEN v.descricao_veiculo || ' ' || v.placa ELSE tv.descricao || ' ' || v.codigo_veiculo END AS VARCHAR) AS veiculo FROM veiculos AS v JOIN tipo_veiculo AS tv ON(tv.id = v.tipo_veiculo) WHERE v.ativo = 'S' ORDER BY  v.tipo_veiculo DESC, v.codigo_veiculo ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxVeiculo.ValueMember = "id_veiculo";
                cBoxVeiculo.DisplayMember = "veiculo";
                cBoxVeiculo.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
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

                    NpgsqlCommand com = new NpgsqlCommand($"SELECT v.descricao_veiculo, v.placa FROM veiculos AS v WHERE v.id = {cBoxVeiculo.SelectedValue}", BD.ObjetoConexao);
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

                    NpgsqlCommand com2 = new NpgsqlCommand($"SELECT MAX(id_km_diario) AS id_km_diario FROM km_diario WHERE id_veiculo = {cBoxVeiculo.SelectedValue}", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr2 = com2.ExecuteReader())
                    {
                        while (dr2.Read())
                        {
                            CDV_id_km_diario = dr2["id_km_diario"].ToString();
                        }
                    }

                    if (CDV_id_km_diario != string.Empty)
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
            catch (Exception err) { XtraMessageBox.Show(err.Message); }
            finally
            {
                BD.Desconectar();
            }
        }

        #endregion

    }
}