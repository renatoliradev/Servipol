using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmVeiculosCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public string TipoChamada { get; set; }
        public int IdVeiculo { get; set; }
        #endregion

        public frmVeiculosCadastrar(string tipoChamada, int idVeiculo)
        {
            InitializeComponent();

            TipoChamada = tipoChamada;
            IdVeiculo = idVeiculo;
        }

        private void frmVeiculosCadastrar_Load(object sender, EventArgs e)
        {

        }

        #region Methods

        public void verificaTipoChamada()
        {
            try
            {
                BD.Conectar();
                if (TipoChamada == "Incluir")
                {
                    this.Text = "Incluir Veículo";

                    cBoxTipoVeiculo.SelectedIndex = -1;
                    cBoxCombustivel.SelectedIndex = -1;
                    tBoxDescricaoVeiculo.Clear();
                    tBoxPlacaVeiculo.Clear();
                    tBoxDescricaoVeiculo.Focus();
                    chkBoxRegistroAtivo.Checked = true;
                    chkBoxRegistroAtivo.Enabled = false;
                }
                else if (TipoChamada == "Editar")
                {
                    this.Text = "Editar Veículo";

                    #region DECLARACAO DE VARIAVEIS
                    string tipo_veiculo = string.Empty, codigo_veiculo = string.Empty, descricao_veiculo = string.Empty, placa = string.Empty, combustivel = string.Empty, faz_revisao = string.Empty, registro_ativo = string.Empty;
                    #endregion

                    NpgsqlCommand com = new NpgsqlCommand($"SELECT v.tipo_veiculo, v.codigo_veiculo, v.descricao_veiculo, v.placa, v.combustivel, v.faz_revisao FROM veiculos AS v WHERE v.id_veiculo = {IdVeiculo}", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tipo_veiculo = dr["tipo_veiculo"].ToString();
                            codigo_veiculo = dr["codigo_veiculo"].ToString();
                            descricao_veiculo = dr["descricao_veiculo"].ToString();
                            placa = dr["placa"].ToString();
                            combustivel = dr["combustivel"].ToString();
                            faz_revisao = dr["faz_revisao"].ToString();
                            registro_ativo = dr["ativo"].ToString();
                        }

                        cBoxTipoVeiculo.SelectedValue = tipo_veiculo;

                        switch (tipo_veiculo)
                        {
                            case "1":
                                carregaCodigoCarro();
                                // cBoxCodigoVeiculo.SelectedValue = codigo_veiculo;
                                break;
                            case "2":
                                carregaCodigoMoto();
                                //cBoxCodigoVeiculo.SelectedValue = codigo_veiculo;
                                break;
                        }

                        #region Identifica Tipo da Placa
                        if (placa.Contains("-"))
                        {
                            rBtnPlacaAntiga.Checked = true;
                        }
                        else
                        {
                            rBtnPlacaMercosul.Checked = true;
                        }
                        #endregion

                        #region Conversão Situação
                        if (registro_ativo == "S")
                        {
                            chkBoxRegistroAtivo.Checked = true;
                        }
                        else
                        {
                            chkBoxRegistroAtivo.Checked = false;
                        }
                        #endregion

                        tBoxDescricaoVeiculo.Text = descricao_veiculo;
                        tBoxPlacaVeiculo.Text = placa;
                        cBoxCombustivel.SelectedItem = combustivel;
                        cBoxFazRevisao.SelectedItem = faz_revisao;
                    }
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaTipoVeiculo()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id_veiculo_tipo, descricao FROM veiculo_tipo WHERE ativo = 'S' ORDER BY 2 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxTipoVeiculo.ValueMember = "id_veiculo_tipo";
                cBoxTipoVeiculo.DisplayMember = "descricao";
                cBoxTipoVeiculo.DataSource = dt;

                if (cBoxTipoVeiculo.SelectedValue.ToString() == "1")
                {
                    CarregaCodigoCarro();
                }
                else if (cBoxTipoVeiculo.SelectedValue.ToString() == "2")
                {
                    CarregaCodigoMoto();
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha na função carregaTipoVeiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaCodigoCarro()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id FROM codigocarro WHERE id_veiculo = {IdVeiculo} OR id_veiculo IS NULL ORDER BY 1 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                // cBoxCodigoVeiculo.ValueMember = "id";
                // cBoxCodigoVeiculo.DisplayMember = "id";
                // cBoxCodigoVeiculo.DataSource = dt;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha na função carregaCodigoCarro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaCodigoMoto()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id FROM codigomoto WHERE id_veiculo = {IdVeiculo} OR  id_veiculo IS NULL ORDER BY 1 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                // cBoxCodigoVeiculo.ValueMember = "id";
                //cBoxCodigoVeiculo.DisplayMember = "id";
                //cBoxCodigoVeiculo.DataSource = dt;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha na função carregaCodigoMoto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }


        private void rBtnPlacaMercosul_CheckedChanged(object sender, EventArgs e)
        {
            tBoxPlacaVeiculo.Clear();
            tBoxPlacaVeiculo.Mask = "LLL0L00";
            tBoxPlacaVeiculo.Select();
        }

        private void rBtnPlacaAntiga_CheckedChanged(object sender, EventArgs e)
        {
            tBoxPlacaVeiculo.Clear();
            tBoxPlacaVeiculo.Mask = "LLL-0000";
            tBoxPlacaVeiculo.Select();
        }

        private void tBoxPlacaVeiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        #endregion

        #region Buttons

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}