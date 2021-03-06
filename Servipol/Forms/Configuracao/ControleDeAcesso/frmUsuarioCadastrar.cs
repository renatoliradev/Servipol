using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Windows.Forms;

namespace Servipol.Forms.Configuração.Controle_de_Acesso
{
    public partial class frmUsuarioCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades

        readonly ConexaoBD BD = new ConexaoBD();
        public string TipoChamada { get; set; }
        public int IdUsuario { get; set; }
        public int IdUsuarioRecemCadastrado { get; set; }
        public bool LoginJaCadastrado { get; set; }

        #endregion

        public frmUsuarioCadastrar(string _tipoChamada, int _idUsuario)
        {
            InitializeComponent();

            TipoChamada = _tipoChamada;
            IdUsuario = _idUsuario;
        }

        private void frmUsuarioCadastrar_Load(object sender, EventArgs e)
        {
            VerificaTipoChamada();

            tBoxNome.Select();
        }

        public void VerificaTipoChamada()
        {
            if (TipoChamada == "Incluir")
            {
                tabDadosRegistro.Parent = null;

                gbNovaSenha.Enabled = true;
                gbNovaSenha.Visible = true;

                gbAlterarSenha.Enabled = false;
                gbAlterarSenha.Visible = false;

                chkBoxRegistroAtivo.Checked = true;
                chkBoxRegistroAtivo.Enabled = false;
            }
            else if (TipoChamada == "Editar")
            {
                gbNovaSenha.Enabled = false;
                gbNovaSenha.Visible = false;

                gbAlterarSenha.Enabled = true;
                gbAlterarSenha.Visible = true;

                CarregaUsuario();

                tBoxNome.SelectAll();
            }
        }

        public void CarregaUsuario()
        {
            try
            {
                BD.Conectar();
                string ativo = string.Empty;

                NpgsqlCommand com = new NpgsqlCommand($"SELECT u.login, u.nome, u.ativo, uc.nome AS usuario_cadastro, u.data_cadastro, ua.nome AS usuario_alteracao, u.data_alteracao, ue.nome AS usuario_exclusao, u.data_exclusao FROM usuario AS u INNER JOIN usuario AS uc ON(uc.id_usuario = u.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = u.id_usuario_alteracao) LEFT OUTER JOIN usuario AS ue ON(ue.id_usuario = u.id_usuario_exclusao) WHERE u.id_usuario = {IdUsuario}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tBoxNome.Text = dr["nome"].ToString();
                        tBoxLogin.Text = dr["login"].ToString();
                        ativo = dr["ativo"].ToString();

                        //Dados do Registro
                        tBoxUsuarioCadastro.Text = dr["usuario_cadastro"].ToString();
                        tBoxDataCadastro.Text = dr["data_cadastro"].ToString();
                        tBoxUsuarioAlteracao.Text = dr["usuario_alteracao"].ToString();
                        tBoxDataAlteracao.Text = dr["data_alteracao"].ToString();
                        tBoxUsuarioDesativacao.Text = dr["usuario_exclusao"].ToString();
                        tBoxDataDesativacao.Text = dr["data_exclusao"].ToString();
                    }

                    if (ativo == "S")
                    {
                        chkBoxRegistroAtivo.Checked = true;
                    }
                    else
                    {
                        chkBoxRegistroAtivo.Checked = false;
                    }
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Erro na função CarregaUsuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private bool ValidaCampos()
        {
            VerificaLoginExistente();

            if (string.IsNullOrEmpty(tBoxNome.Text))
            {
                XtraMessageBox.Show("Informe o [Nome] do usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxNome.Select();
                return false;
            }
            else if (string.IsNullOrEmpty(tBoxLogin.Text))
            {
                XtraMessageBox.Show("Informe o [Login] do usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxLogin.Select();
                return false;
            }
            else if (TipoChamada == "Incluir" && string.IsNullOrEmpty(tBoxCriarSenha.Text))
            {
                XtraMessageBox.Show("Informe uma [Senha] para o novo usuário", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxCriarSenha.Select();
                return false;
            }
            else if (TipoChamada == "Incluir" && tBoxCriarSenha.Text != tBoxCriarRepeticaoSenha.Text)
            {
                XtraMessageBox.Show("Senha não confere com repetição!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxCriarSenha.Clear();
                tBoxCriarRepeticaoSenha.Clear();
                tBoxCriarSenha.Select();
                return false;
            }
            else if (TipoChamada == "Editar" && chkBoxAlterarSenha.Checked && string.IsNullOrEmpty(tBoxNovaSenha.Text))
            {
                XtraMessageBox.Show("Informe a nova [Senha] para o novo usuário", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxNovaSenha.Select();
                return false;
            }
            else if (TipoChamada == "Editar" && tBoxNovaSenha.Text != tBoxRepeticaoNovaSenha.Text)
            {
                XtraMessageBox.Show("Nova senha não confere com repetição!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxNovaSenha.Clear();
                tBoxRepeticaoNovaSenha.Clear();
                tBoxNovaSenha.Select();
                return false;
            }
            else if (LoginJaCadastrado)
            {
                XtraMessageBox.Show("Já existe um usuário ativo com o Login [" + tBoxLogin.Text.ToUpper().Trim() + "]\n\nInforme outro Login para finalizar o cadastro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxLogin.Clear();
                tBoxLogin.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void VerificaLoginExistente()
        {
            try
            {
                BD.Conectar();
                string usuario = string.Empty;

                NpgsqlCommand com = new NpgsqlCommand($"SELECT login FROM usuario WHERE login = '{tBoxLogin.Text.ToUpper().Trim()}' AND ativo = 'S'", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario = dr["login"].ToString();
                    }
                    if (!string.IsNullOrEmpty(usuario))
                    {
                        LoginJaCadastrado = true;
                    }
                    else
                    {
                        LoginJaCadastrado = false;
                    }
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
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
                    if (TipoChamada == "Editar" && chkBoxAlterarSenha.Checked && tBoxNovaSenha.Text == tBoxRepeticaoNovaSenha.Text)
                    {
                        BD.Conectar();

                        string sqlCommand = $"UPDATE usuario SET nome = '{tBoxNome.Text.ToUpper().Trim()}', login = '{tBoxLogin.Text.ToUpper().Trim()}', senha = UPPER(MD5('{tBoxNovaSenha.Text.ToUpper()}')), id_usuario_alteracao = {SessaoSistema.UserId}, data_alteracao = CURRENT_TIMESTAMP WHERE id_usuario = {IdUsuario}";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        XtraMessageBox.Show("Cadastro alterado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ((frmUsuarioConsultar)this.Owner).AtualizaDG();
                        this.Close();
                        this.Dispose();
                    }
                    else if (TipoChamada == "Editar" && chkBoxAlterarSenha.Checked == false)
                    {
                        BD.Conectar();

                        #region Conversão Situação
                        string registro_ativo = chkBoxRegistroAtivo.Checked ? "S" : "N";
                        #endregion

                        string sqlCommand = $"UPDATE usuario SET nome = '{tBoxNome.Text.ToUpper().Trim()}', login = '{tBoxLogin.Text.ToUpper().Trim()}', ativo = '{registro_ativo}', id_usuario_alteracao = {SessaoSistema.UserId}, data_alteracao = CURRENT_TIMESTAMP WHERE id_usuario = {IdUsuario}";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        XtraMessageBox.Show("Cadastro alterado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ((frmUsuarioConsultar)this.Owner).AtualizaDG();
                        this.Close();
                        this.Dispose();
                    }
                    else if (TipoChamada == "Incluir")
                    {
                        BD.Conectar();

                        string sqlCommand = $"INSERT INTO usuario VALUES (nextval('seq_usuario'), '{tBoxNome.Text.ToUpper().Trim()}', '{tBoxLogin.Text.ToUpper().Trim()}', UPPER(MD5('{tBoxCriarSenha.Text.ToUpper()}')), 'N', 'S', {SessaoSistema.UserId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL)";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        XtraMessageBox.Show("Cadastro realizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ((frmUsuarioConsultar)this.Owner).AtualizaDG();
                        this.Close();

                        NpgsqlCommand com = new NpgsqlCommand($"SELECT id_usuario FROM usuario WHERE nome = '{tBoxNome.Text.ToUpper().Trim()}' AND login = '{tBoxLogin.Text.ToUpper().Trim()}'", BD.ObjetoConexao);
                        using (NpgsqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                IdUsuarioRecemCadastrado = int.Parse(dr["id_usuario"].ToString());
                            }
                        }

                        frmUsuarioPerfil frmUsuarioPerfil = new frmUsuarioPerfil("frmIncluirUsuario", tBoxLogin.Text.ToUpper(), IdUsuarioRecemCadastrado);
                        frmUsuarioPerfil.ShowInTaskbar = false;
                        frmUsuarioPerfil.ShowDialog();
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro na chamada btnConfirmar_Click", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void frmUsuarioCadastrar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F12:
                    btnConfirmar_Click(sender, e);
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}