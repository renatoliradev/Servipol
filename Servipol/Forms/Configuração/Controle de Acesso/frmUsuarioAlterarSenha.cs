using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Windows.Forms;

namespace Servipol.Forms.Configuração.Controle_de_Acesso
{
    public partial class frmUsuarioAlterarSenha : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        static ConexaoBD BD = new ConexaoBD();

        private static string UsuarioLogado = string.Empty;
        #endregion

        public frmUsuarioAlterarSenha(string usuario)
        {
            InitializeComponent();

            UsuarioLogado = usuario;
        }

        private void frmUsuarioAlterarSenha_Load(object sender, EventArgs e)
        {
            tBoxUsuario.Text = UsuarioLogado;
        }

        #region Button
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();

                if (tBoxSenha.Text == string.Empty)
                {
                    XtraMessageBox.Show("Informar a [Nova Senha].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tBoxSenha.Text = string.Empty;
                    tBoxRepeticaoSenha.Text = string.Empty;
                    gbNovaSenha.Focus();
                    tBoxSenha.Select();
                }
                else if (tBoxSenha.Text.ToUpper().Trim() != tBoxRepeticaoSenha.Text.ToUpper().Trim())
                {
                    XtraMessageBox.Show("Nova senha não confere com repetição", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tBoxSenha.Text = string.Empty;
                    tBoxRepeticaoSenha.Text = string.Empty;
                    gbNovaSenha.Focus();
                    tBoxSenha.Select();
                }
                else
                {
                    NpgsqlCommand update1 = new NpgsqlCommand($"UPDATE usuarios SET senha = UPPER(MD5('{tBoxSenha.Text.ToUpper().Trim()}')) WHERE id_usuario = {SessaoSistema.UsuarioId}", BD.ObjetoConexao);
                    update1.ExecuteNonQuery();

                    XtraMessageBox.Show("Senha alterada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao tentar alterar senha de usuário.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        #endregion

        #region Methods

        private void tBoxSenha_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    gbRepeticaoSenha.Focus();
                    tBoxRepeticaoSenha.Select();
                    break;
            }
        }

        private void tBoxRepeticaoSenha_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnConfirmar_Click(sender, e);
                    break;
            }
        }

        private void frmUsuarioAlterarSenha_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F12:
                    {
                        btnConfirmar_Click(sender, e);
                    }
                    break;
                case Keys.Escape:
                    {
                        btnCancelar_Click(sender, e);
                    }
                    break;
            }
        }

        #endregion
    }
}