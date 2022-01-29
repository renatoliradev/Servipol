using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace Servipol.Forms.Configuração.Controle_de_Acesso
{
    public partial class frmUsuarioPerfilConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();
        #endregion

        public frmUsuarioPerfilConsultar()
        {
            InitializeComponent();
        }

        private void frmUsuarioPerfilConsultar_Load(object sender, EventArgs e)
        {
            VerificaPermissao();

            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
        }

        #region Buttons

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string situacaoTraduzida = string.Empty;
            string tipoBusca = string.Empty;

            switch (cBoxSituacao.SelectedIndex)
            {
                case 0:
                    situacaoTraduzida = "S";
                    break;
                case 1:
                    situacaoTraduzida = "N";
                    break;
                default:
                    situacaoTraduzida = "S";
                    break;
            }

            switch (cBoxTipoBusca.SelectedIndex)
            {
                case 0:
                    tipoBusca = "1=1";
                    break;
                case 1:
                    tipoBusca = $"cpp.descricao ILIKE '%{tBoxTextoConsulta.Text.ToUpper().Trim()}%'";
                    break;
                default:
                    tipoBusca = "1=1";
                    break;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT cpp.id_controle_permissao_perfil, CASE WHEN cpp.ativo = 'S' THEN cpp.descricao ELSE '>>>>> [REGISTRO EXCLUÍDO] <<<<< | ' || cpp.descricao END AS descricao, uc.nome AS usuario_cadastro, cpp.data_cadastro, CASE WHEN cpp.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM controle_permissao_perfil AS cpp INNER JOIN usuario AS uc ON(uc.id_usuario = cpp.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = cpp.id_usuario_exclusao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = cpp.id_usuario_alteracao) WHERE cpp.ativo = '{situacaoTraduzida}' AND {tipoBusca} ORDER BY 1 ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridUsuarioPerfil.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmUsuarioPerfil frmUsuarioPerfil = new frmUsuarioPerfil("Incluir", null, 0);
            frmUsuarioPerfil.Owner = this;
            frmUsuarioPerfil.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string idRegistroSelecionadoGrid = dGridUsuarioPerfil.SelectedRows[0].Cells[0].Value.ToString();
                frmUsuarioPerfil frmUsuarioPerfil = new frmUsuarioPerfil("Editar", null, int.Parse(idRegistroSelecionadoGrid));
                frmUsuarioPerfil.Owner = this;
                frmUsuarioPerfil.ShowDialog();
            }
            catch { }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();
                string idRegistroSelecionadoGrid = dGridUsuarioPerfil.SelectedRows[0].Cells[0].Value.ToString();

                if (XtraMessageBox.Show("Deseja excluir o perfil selecionado ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string sqlCommand = $"UPDATE controle_permissao_perfil SET ativo = 'N', id_usuario_exclusao = {SessaoSistema.UserId}, data_exclusao = CURRENT_TIMESTAMP WHERE id_controle_permissao_perfil = {idRegistroSelecionadoGrid}";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    XtraMessageBox.Show("Perfil excluído com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AtualizaDG();
                }

            }
            catch { }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnImprimirConsulta_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Methods

        private void cBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);

            if (cBoxSituacao.SelectedIndex == 1)
            {
                btnExcluir.Visible = false;
                btnExcluir.Enabled = false;

                btnEditar.Visible = false;
                btnEditar.Enabled = false;
            }
            else
            {
                btnExcluir.Visible = true;
                btnExcluir.Enabled = true;

                btnEditar.Visible = true;
                btnEditar.Enabled = true;
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

        public void VerificaPermissao()
        {
            if (SessaoSistema.UserPermission.Substring(3, 1) == "S") { btnIncluir.Enabled = true; } else { btnIncluir.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(4, 1) == "S") { btnEditar.Enabled = true; } else { btnEditar.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(5, 1) == "S") { btnExcluir.Enabled = true; } else { btnExcluir.Enabled = false; }
        }

        public void CarregaTabelaUsuarioPerfil()
        {
            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT cpp.id_controle_permissao_perfil, CASE WHEN cpp.ativo = 'S' THEN cpp.descricao ELSE '>>>>> [REGISTRO EXCLUÍDO] <<<<< | ' || cpp.descricao END AS descricao, uc.nome AS usuario_cadastro, cpp.data_cadastro, CASE WHEN cpp.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM controle_permissao_perfil AS cpp INNER JOIN usuario AS uc ON(uc.id_usuario = cpp.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = cpp.id_usuario_exclusao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = cpp.id_usuario_alteracao) WHERE cpp.ativo = 'S' ORDER BY 1 ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridUsuarioPerfil.DataSource = dp;
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
            CarregaTabelaUsuarioPerfil();
        }

        private void dGridLocalManutencao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        private void frmUsuarioPerfilConsultar_KeyDown(object sender, KeyEventArgs e)
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
            if (SessaoSistema.UserPermission.Substring(3, 1) == "S" && e.KeyCode == Keys.F4) 
            {
                btnIncluir_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                btnImprimirConsulta_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(5, 1) == "S" && cBoxSituacao.SelectedIndex == 0 && e.KeyCode == Keys.Delete)
            {
                btnExcluir_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(4, 1) == "S" && cBoxSituacao.SelectedIndex == 0 && e.KeyCode == Keys.F3)
            {
                btnEditar_Click(sender, e);
            }
        }

        private void dGridUsuarioPerfil_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        #endregion
    }
}