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

            string tipoBusca = string.Empty;

            if (cBoxTipoBusca.SelectedIndex == 0)
            {
                tipoBusca = "nome ILIKE '%" + tBoxTextoConsulta.Text.ToUpper().Trim() + "%'";
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT u.id_usuario, u.login, CASE WHEN u.ativo = 'S' THEN u.nome ELSE '>>>>> [REGISTRO EXCLUÍDO] <<<<< | ' || u.nome END AS nome, uc.nome AS usuario_cadastro, u.data_cadastro, CASE WHEN u.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM usuario AS u INNER JOIN usuario AS uc ON(uc.id_usuario = u.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = u.id_usuario_exclusao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = u.id_usuario_alteracao) WHERE '{tipoBusca}' AND u.ativo = '{situacaoTraduzida}' ORDER BY 1 ASC", BD.ObjetoConexao);
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

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

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

                if (XtraMessageBox.Show($"Deseja realmente resetar a senha do usuário [{loginUserSelecionado}] ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    BD.Conectar();
                    string sqlCommand = $"UPDATE usuario SET senha = UPPER(MD5('123456')), altera_senha_prox_login = 'S' WHERE id_usuario = {idUserSelecionado}";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    XtraMessageBox.Show("Nova senha temporária: 123456", "Senha resetada com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string idUsuarioSelecionadoGrid = dGridUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                frmUsuarioPerfil frmUsuarioPerfil = new frmUsuarioPerfil("frmUsuariosEditarPermissoes", int.Parse(idUsuarioSelecionadoGrid));
                frmUsuarioPerfil.ShowInTaskbar = false;
                frmUsuarioPerfil.ShowDialog();
            }
            catch { }
        }

        private void btnImprimirConsulta_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}