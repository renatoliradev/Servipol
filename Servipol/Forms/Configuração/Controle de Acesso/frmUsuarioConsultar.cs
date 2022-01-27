using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if (cBoxSituacao.SelectedItem.ToString() == "Ativos")
            {
                btnExcluir.Visible = true;
                btnExcluir.Enabled = true;
                situacaoTraduzida = "S";
                btnExcluir.Text = "[Del] - Inativar";
            }
            else
            {
                btnExcluir.Visible = false;
                btnExcluir.Enabled = false;
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

        #endregion

        #region Buttons

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string situacaoTraduzida;

            if (cBoxSituacao.SelectedIndex == 0)
            {
                btnExcluir.Visible = true;
                btnExcluir.Enabled = true;
                situacaoTraduzida = "S";
                btnExcluir.Text = "[Del] - Inativar";
            }
            else
            {
                btnExcluir.Visible = false;
                btnExcluir.Enabled = false;
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

                if (XtraMessageBox.Show("Deseja desativar o usuário selecionado ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string sqlCommand = $"UPDATE usuario SET ativo = 'N', id_usuario_desativacao = {SessaoSistema.UsuarioId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_usuario = {idUserSelecionado}";
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

                if (XtraMessageBox.Show($"Deseja realmente resetar a senha do usuário [{loginUserSelecionado}] ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    BD.Conectar();
                    string sqlCommand = $"UPDATE usuario SET senha = UPPER(MD5('123456')) WHERE id_usuario = {idUserSelecionado}";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    XtraMessageBox.Show("Nova senha: 123456", "Senha resetada com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

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
                case Keys.F4:
                    btnIncluir_Click(sender, e);
                    break;
                case Keys.F3:
                    btnEditar_Click(sender, e);
                    break;
                case Keys.F5:
                    btnConsultar_Click(sender, e);
                    break;
                case Keys.F6:
                    btnResetarSenha_Click(sender, e);
                    break;
                case Keys.F7:
                    btnPermissoes_Click(sender, e);
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                btnImprimirConsulta_Click(sender, e);
            }
            if (cBoxSituacao.SelectedIndex == 0 && e.KeyCode == Keys.Delete)
            {
                btnExcluir_Click(sender, e);
            }
        }

        private void dGridUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar_Click(sender, e);
        }
    }
}