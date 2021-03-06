using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Servipol.Forms.Configuração.Controle_de_Acesso
{
    public partial class frmUsuarioConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades

        readonly ConexaoBD BD = new ConexaoBD();

        #endregion

        public frmUsuarioConsultar()
        {
            InitializeComponent();
        }

        private void frmUsuarioConsultar_Load(object sender, EventArgs e)
        {
            VerificaPermissao();

            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
        }

        #region Methods

        public void carregaTabelaUsuarios()
        {
            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter("SELECT u.id_usuario, u.login, CASE WHEN u.ativo = 'S' THEN u.nome ELSE '>>>>> [REGISTRO EXCLUÍDO] <<<<< | ' || u.nome END AS nome, uc.nome AS usuario_cadastro, u.data_cadastro, CASE WHEN u.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM usuario AS u INNER JOIN usuario AS uc ON(uc.id_usuario = u.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = u.id_usuario_exclusao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = u.id_usuario_alteracao) WHERE u.ativo = 'S' ORDER BY 1 ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);

                dGridUsuarios.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void VerificaPermissao()
        {
            if (SessaoSistema.UserPermission.Substring(7, 1) == "S") { btnIncluir.Enabled = true; } else { btnIncluir.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(8, 1) == "S") { btnEditar.Enabled = true; } else { btnEditar.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(9, 1) == "S") { btnExcluir.Enabled = true; } else { btnExcluir.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(10, 1) == "S") { btnResetarSenha.Enabled = true; } else { btnResetarSenha.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(11, 1) == "S") { btnPermissoes.Enabled = true; } else { btnPermissoes.Enabled = false; }
        }

        public void AtualizaDG()
        {
            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
            carregaTabelaUsuarios();
        }

        private void cBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string situacaoTraduzida;

            if (SessaoSistema.UserPermission.Substring(9, 1) == "S" && cBoxSituacao.SelectedIndex == 0)
            {
                btnExcluir.Enabled = true;
            }
            else
            {
                btnExcluir.Enabled = false;
            }

            if (cBoxSituacao.SelectedIndex == 0)
            {
                situacaoTraduzida = "S";
            }
            else
            {
                situacaoTraduzida = "N";
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT u.id_usuario, u.login, CASE WHEN u.ativo = 'S' THEN u.nome ELSE '>>>>> [REGISTRO EXCLUÍDO] <<<<< | ' || u.nome END AS nome, uc.nome AS usuario_cadastro, u.data_cadastro, CASE WHEN u.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM usuario AS u INNER JOIN usuario AS uc ON(uc.id_usuario = u.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = u.id_usuario_exclusao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = u.id_usuario_alteracao) WHERE u.ativo = '{situacaoTraduzida}' ORDER BY 1 ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridUsuarios.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void cBoxTipoBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxTipoBusca.SelectedIndex != 0)
            {
                tBoxTextoConsulta.Enabled = true;
                tBoxTextoConsulta.Clear();
                tBoxTextoConsulta.Select();
            }
            else
            {
                tBoxTextoConsulta.Enabled = false;
                tBoxTextoConsulta.Clear();
                btnConsultar_Click(sender, e);
            }
        }

        private void frmUsuarioConsultar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    btnConsultar_Click(sender, e);
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
            if (SessaoSistema.UserPermission.Substring(7, 1) == "S" && e.KeyCode == Keys.F4)
            {
                btnIncluir_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(8, 1) == "S" && e.KeyCode == Keys.F3)
            {
                btnEditar_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(9, 1) == "S" && cBoxSituacao.SelectedIndex == 0 && e.KeyCode == Keys.Delete)
            {
                btnExcluir_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                btnImprimirConsulta_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(10, 1) == "S" && e.KeyCode == Keys.F6)
            {
                btnResetarSenha_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(11, 1) == "S" && e.KeyCode == Keys.F7)
            {
                btnPermissoes_Click(sender, e);
            }
        }

        private void dGridUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SessaoSistema.UserPermission.Substring(8, 1) == "S")
            {
                btnEditar_Click(sender, e);
            }
        }

        #endregion

        #region Buttons

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string situacaoTraduzida;

            if (SessaoSistema.UserPermission.Substring(9, 1) == "S" && cBoxSituacao.SelectedIndex == 0)
            {
                btnExcluir.Enabled = true;
            }
            else
            {
                btnExcluir.Enabled = false;
            }

            if (cBoxSituacao.SelectedIndex == 0)
            {
                situacaoTraduzida = "S";
            }
            else
            {
                situacaoTraduzida = "N";
            }

            string tipoBusca = string.Empty;

            switch (cBoxTipoBusca.SelectedIndex)
            {
                case 0:
                    tipoBusca = "1=1";
                    break;
                case 1:
                    tipoBusca = $"u.nome ILIKE '%{tBoxTextoConsulta.Text.ToUpper().Trim()}%'";
                    break;
                default:
                    tipoBusca = "1=1";
                    break;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT u.id_usuario, u.login, CASE WHEN u.ativo = 'S' THEN u.nome ELSE '>>>>> [REGISTRO EXCLUÍDO] <<<<< | ' || u.nome END AS nome, uc.nome AS usuario_cadastro, u.data_cadastro, CASE WHEN u.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM usuario AS u INNER JOIN usuario AS uc ON(uc.id_usuario = u.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = u.id_usuario_exclusao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = u.id_usuario_alteracao) WHERE {tipoBusca} AND u.ativo = '{situacaoTraduzida}' ORDER BY 1 ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridUsuarios.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmUsuarioCadastrar frmUsuarioCadastrar = new frmUsuarioCadastrar("Incluir", 0);
            frmUsuarioCadastrar.Owner = this;
            frmUsuarioCadastrar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string idRegistroSelecionadoGrid = dGridUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                frmUsuarioCadastrar frmUsuarioCadastrar = new frmUsuarioCadastrar("Editar", int.Parse(idRegistroSelecionadoGrid));
                frmUsuarioCadastrar.Owner = this;
                frmUsuarioCadastrar.ShowDialog();
            }
            catch
            {
                XtraMessageBox.Show("Primeiro selecione o registro que deseja editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();

                string idUserSelecionado = dGridUsuarios.SelectedRows[0].Cells[0].Value.ToString();

                if (XtraMessageBox.Show("Deseja desativar o usuário selecionado ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string sqlCommand = $"UPDATE usuario SET ativo = 'N', id_usuario_exclusao = {SessaoSistema.UserId}, data_exclusao = CURRENT_TIMESTAMP WHERE id_usuario = {idUserSelecionado}";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    btnConsultar_Click(sender, e);
                    XtraMessageBox.Show("Usuário desativado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizaDG();
                }
            }
            catch { }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnResetarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                string idUserSelecionado = dGridUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                string loginUserSelecionado = dGridUsuarios.SelectedRows[0].Cells["login"].Value.ToString();

                if (XtraMessageBox.Show($"Deseja realmente resetar a senha do usuário [{loginUserSelecionado}] ?\n\n A nova senha será: 123456", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    BD.Conectar();
                    string sqlCommand = $"UPDATE usuario SET senha = UPPER(MD5('123456')) WHERE id_usuario = {idUserSelecionado}";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    XtraMessageBox.Show("Senha resetada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Não foi possível resetar a senha, tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnPermissoes_Click(object sender, EventArgs e)
        {
            try
            {
                string idUsuarioSelecionado = dGridUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                string loginUsuarioSelecionado = dGridUsuarios.SelectedRows[0].Cells[1].Value.ToString();

                frmUsuarioPerfil frmUsuarioPerfil = new frmUsuarioPerfil("frmUsuariosEditarPermissoes", loginUsuarioSelecionado, int.Parse(idUsuarioSelecionado));
                frmUsuarioPerfil.ShowInTaskbar = false;
                frmUsuarioPerfil.ShowDialog();
            }
            catch
            {
                XtraMessageBox.Show("Primeiro selecione o registro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimirConsulta_Click(object sender, EventArgs e)
        {
            var dadosRelatorio = from DataGridViewRow linha in dGridUsuarios.Rows
                                 select new
                                 {
                                     Login = linha.Cells["login"].Value,
                                     Nome = linha.Cells["nome"].Value,
                                     UsuarioCadastro = linha.Cells["usuario_cadastro"].Value,
                                     DataCadastro = linha.Cells["data_cadastro"].Value,
                                     Ativo = linha.Cells["ativo"].Value
                                 };

            Relatorios.frmRelatorio.ShowReport("Servipol.Forms.Relatorios.RelacaoDeUsuarios.rdlc", true, new Dictionary<string, object>() { { "DataSetUsuarios", dadosRelatorio.AsEnumerable() } });
        }

        #endregion

    }
}