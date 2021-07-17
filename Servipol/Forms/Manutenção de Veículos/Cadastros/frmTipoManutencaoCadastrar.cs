using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmTipoManutencaoCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region INSTANCIAS
        readonly ConexaoBD BD = new ConexaoBD();

        private static string auxTipoChamada = string.Empty;
        private static int auxIdTipoManutencao = 0;
        #endregion


        public frmTipoManutencaoCadastrar(string tipoChamada, int idTipoManutencao)
        {
            InitializeComponent();

            auxTipoChamada = tipoChamada;
            auxIdTipoManutencao = idTipoManutencao;
        }

        private void frmTipoManutencaoCadastrar_Load(object sender, EventArgs e)
        {
            if (auxTipoChamada == "Editar")
            {
                carregaDadosTipoManutencao();
                btnConfirmaInclusao.Text = "Confirmar Edição";
                this.Text = "Editar Tipo de Manutenção";
            }
            gbDenominacao.Focus();
            tBoxDenominacao.Select();
        }

        #region Methods

        public void carregaDadosTipoManutencao()
        {
            string tipoManutencaoParecida = string.Empty;
            try
            {
                BD.Conectar();

                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT descricao, aplicacao_carro, aplicacao_moto FROM manutencao_tipo WHERE id_tipo_manutencao = {auxIdTipoManutencao}", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);

                tBoxDenominacao.DataBindings.Clear();
                auxChkBoxCarro.DataBindings.Clear();
                auxChkBoxMoto.DataBindings.Clear();

                tBoxDenominacao.DataBindings.Add(new Binding("Text", dp, "descricao"));
                auxChkBoxCarro.DataBindings.Add(new Binding("Text", dp, "aplicacao_carro"));
                auxChkBoxMoto.DataBindings.Add(new Binding("Text", dp, "aplicacao_moto"));

                if (auxChkBoxCarro.Text == "S")
                {
                    chkBoxCarro.Checked = true;
                }
                else
                {
                    chkBoxCarro.Checked = false;
                }

                if (auxChkBoxMoto.Text == "S")
                {
                    chkBoxMoto.Checked = true;
                }
                else
                {
                    chkBoxMoto.Checked = false;
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha ao carregar dados do tipo de manutenção.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        #endregion

        #region Buttons 

        private void btnCancelarCadastro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmaInclusao_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();

                #region Tipo Chamada: EDITAR
                if (auxTipoChamada == "Editar")
                {
                    string aplicacaoCarro = string.Empty;
                    string aplicacaoMoto = string.Empty;

                    if (chkBoxCarro.Checked)
                        aplicacaoCarro = "S";
                    else
                        aplicacaoCarro = "N";

                    if (chkBoxMoto.Checked)
                        aplicacaoMoto = "S";
                    else
                        aplicacaoMoto = "N";

                    if (tBoxDenominacao.Text == string.Empty)
                    {
                        XtraMessageBox.Show("Campo [Descrição do Serviço] não pode ficar em branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (chkBoxCarro.Checked == false && chkBoxMoto.Checked == false)
                    {
                        XtraMessageBox.Show("O serviço deve ser aplicável para pelo menos 1 (um) tipo de veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        //if (XtraMessageBox.Show("Confirmar Alterações ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        // {

                        string sqlCommand = $"UPDATE manutencao_tipo SET descricao = '{tBoxDenominacao.Text.ToUpper().Trim()}', aplicacao_carro = '{aplicacaoCarro}', aplicacao_moto = '{aplicacaoMoto}' WHERE id_manutencao_tipo = {auxIdTipoManutencao}";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        XtraMessageBox.Show("Registro Alterado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (auxTipoChamada == "ManutencaoVeiculo")
                        {
                            //((frmRegistrarManutencao)this.Owner).atualizaCamposDepoisDeAdd();
                            this.Close();
                        }
                        else if (auxTipoChamada == "TipoManutencao")
                        {
                            //((frmTipoManutencao)this.Owner).atualizaDG();
                            this.Close();
                        }
                        else if (auxTipoChamada == "Editar")
                        {
                            //((frmTipoManutencao)this.Owner).atualizaDG();
                            this.Close();
                        }
                    }
                    // }
                }
                #endregion

                #region Tipo Chamada: INCLUIR
                else
                {
                    string aplicacaoCarro = string.Empty;
                    string aplicacaoMoto = string.Empty;

                    if (chkBoxCarro.Checked)
                        aplicacaoCarro = "S";
                    else
                        aplicacaoCarro = "N";

                    if (chkBoxMoto.Checked)
                        aplicacaoMoto = "S";
                    else
                        aplicacaoMoto = "N";
                    if (tBoxDenominacao.Text == string.Empty)
                    {
                        XtraMessageBox.Show("Campo [Descrição do Serviço] não pode ficar em branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (chkBoxCarro.Checked == false && chkBoxMoto.Checked == false)
                    {
                        XtraMessageBox.Show("O serviço deve ser aplicável para pelo menos 1 (um) tipo de veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        //if (XtraMessageBox.Show("Confirmar inclusão ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        //{
                        string sqlCommand = $"INSERT INTO manutencao_tipo VALUES (nextval('seq_chave_primaria'), '{tBoxDenominacao.Text.ToUpper().Trim()}', (SELECT MAX(ordem + 1) FROM manutencao_tipo), '{aplicacaoCarro}', '{aplicacaoMoto}', {SessaoSistema.UsuarioId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL, 'OUTROS', 'S')";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        XtraMessageBox.Show("Tipo de Manutenção Cadastrado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (auxTipoChamada == "ManutencaoVeiculo")
                        {
                            //((frmRegistrarManutencao)this.Owner).atualizaCamposDepoisDeAdd();
                            this.Close();
                        }
                        else if (auxTipoChamada == "TipoManutencao")
                        {
                            //((frmTipoManutencao)this.Owner).atualizaDG();
                            this.Close();
                        }
                        else if (auxTipoChamada == "Editar")
                        {
                            //((frmTipoManutencao)this.Owner).atualizaDG();
                            this.Close();
                        }
                        //}
                    }
                }

                #endregion
            }
            finally
            {
                BD.Desconectar();
            }
        }

        #endregion
    }
}