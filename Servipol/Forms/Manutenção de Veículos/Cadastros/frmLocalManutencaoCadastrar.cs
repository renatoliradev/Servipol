using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmLocalManutencaoCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        readonly ConexaoBD BD = new ConexaoBD();

        private static string auxTipoChamada = string.Empty;
        private static int auxidLocalManutencao = 0;
        #endregion

        public frmLocalManutencaoCadastrar(string tipoChamada, int idLocalManutencao)
        {
            InitializeComponent();

            auxTipoChamada = tipoChamada;
            auxidLocalManutencao = idLocalManutencao;
        }

        private void frmLocalManutencaoCadastrar_Load(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();
                if (auxTipoChamada == "Editar")
                {
                    #region DECLARACAO DE VARIAVEIS
                    string descricao = string.Empty, postoCombustivel = string.Empty;
                    #endregion

                    NpgsqlCommand com = new NpgsqlCommand($"SELECT descricao, posto_combustivel FROM manutencao_local WHERE id_manutencao_local = {auxidLocalManutencao}", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            descricao = dr["descricao"].ToString();
                            postoCombustivel = dr["posto_combustivel"].ToString();
                        }
                        tBoxDenominacao.Text = descricao;

                        if (postoCombustivel == "S")
                        {
                            chkBoxPostoCombustivel.Checked = true;
                        }
                        else
                        {
                            chkBoxPostoCombustivel.Checked = false;
                        }
                    }

                    this.Text = "Editar Local de Manutenção";
                }
                else
                {
                    tBoxDenominacao.Clear();
                    chkBoxPostoCombustivel.Checked = false;
                    tBoxDenominacao.Select();
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }

        #region Methods



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
                if (auxTipoChamada == "Editar")
                {
                    if (tBoxDenominacao.Text == string.Empty)
                    {
                        XtraMessageBox.Show("Campo [Denominação] não pode ficar em branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tBoxDenominacao.Select();
                    }
                    else
                    {
                        if (XtraMessageBox.Show("Confirma alteração ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            string postoCombustivel = string.Empty;
                            if (chkBoxPostoCombustivel.Checked)
                            {
                                postoCombustivel = "S";
                            }
                            else
                            {
                                postoCombustivel = "N";
                            }

                            string sqlCommand = $"UPDATE manutencao_local SET descricao = '{tBoxDenominacao.Text.ToUpper().Trim()}', posto_combustivel = '{postoCombustivel}' WHERE id_manutencao_local = {auxidLocalManutencao}";
                            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                            command.ExecuteNonQuery();

                            XtraMessageBox.Show("Local de Manutenção Alterado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //((frmLocalManutencao)this.Owner).atualizaDG();
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (tBoxDenominacao.Text == string.Empty)
                    {
                        XtraMessageBox.Show("Campo [Denominação] não pode ficar em branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tBoxDenominacao.Select();
                    }
                    else
                    {
                        if (XtraMessageBox.Show("Confirma inclusão ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            string postoCombustivel = string.Empty;
                            if (chkBoxPostoCombustivel.Checked)
                            {
                                postoCombustivel = "S";
                            }
                            else
                            {
                                postoCombustivel = "N";
                            }

                            string sqlCommand = $"INSERT INTO manutencao_local VALUES (nextval('seq_chave_primaria'), '{tBoxDenominacao.Text.ToUpper().Trim()}', {SessaoSistema.UsuarioId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL, 'S', '{postoCombustivel}')";
                            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                            command.ExecuteNonQuery();

                            XtraMessageBox.Show("Local de Manutenção Cadastrado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //((frmLocalManutencao)this.Owner).atualizaDG();
                                this.Close();
                        }
                    }
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }

        #endregion

    }
}