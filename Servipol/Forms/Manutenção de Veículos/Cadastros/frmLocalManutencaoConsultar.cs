using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmLocalManutencaoConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();
        #endregion

        public frmLocalManutencaoConsultar()
        {
            InitializeComponent();
        }

        private void frmLocalManutencaoConsultar_Load(object sender, EventArgs e)
        {
            VerificaPermissao();

            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
        }

        #region Methods

        public void CarregaTabelaLocalManutencao()
        {
            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT ml.id_manutencao_local, CASE WHEN ml.ativo = 'S' THEN ml.descricao ELSE '>>>>> [REGISTRO INATIVO] <<<<< | ' || ml.descricao END AS descricao, uc.nome AS usuario_cadastro, ml.data_cadastro, CASE WHEN ml.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM manutencao_local AS ml INNER JOIN usuario AS uc ON(uc.id_usuario = ml.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = ml.id_usuario_desativacao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = ml.id_usuario_alteracao) WHERE ml.ativo = 'S' ORDER BY 1 ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridLocalManutencao.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void VerificaPermissao()
        {
            if (SessaoSistema.UserPermission.Substring(25, 1) == "S") { btnIncluir.Enabled = true; } else { btnIncluir.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(26, 1) == "S") { btnEditar.Enabled = true; } else { btnEditar.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(27, 1) == "S") { btnInativar.Enabled = true; } else { btnInativar.Enabled = false; }
        }

        private void cBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);

            if (cBoxSituacao.SelectedIndex == 1)
            {
                btnInativar.Visible = false;
                btnInativar.Enabled = false;
            }
            else
            {
                btnInativar.Visible = true;
                btnInativar.Enabled = true;
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

        private void dGridLocalManutencao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        public void AtualizaDG()
        {
            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
            CarregaTabelaLocalManutencao();
        }

        private void tBoxTextoConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnConsultar_Click(sender, e);
                    break;
            }
        }

        private void frmLocalManutencaoConsultar_KeyDown(object sender, KeyEventArgs e)
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
                btnInativar_Click(sender, e);
            }
        }

        private void frmLocalManutencaoConsultar_Activated(object sender, EventArgs e)
        {
            dGridLocalManutencao.Sort(dGridLocalManutencao.Columns["descricao"], ListSortDirection.Ascending);
        }

        #endregion

        #region Buttons

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmLocalManutencaoCadastrar frmLocalManutencaoCadastrar = new frmLocalManutencaoCadastrar("Incluir", 0);
            frmLocalManutencaoCadastrar.Owner = this;
            frmLocalManutencaoCadastrar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string idRegistroSelecionadoGrid = dGridLocalManutencao.SelectedRows[0].Cells[0].Value.ToString();
                frmLocalManutencaoCadastrar frmLocalManutencaoCadastrar = new frmLocalManutencaoCadastrar("Editar", int.Parse(idRegistroSelecionadoGrid));
                frmLocalManutencaoCadastrar.Owner = this;
                frmLocalManutencaoCadastrar.ShowDialog();
            }
            catch
            {
                XtraMessageBox.Show("Primeiro selecione o registro que deseja editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();
                string idRegistroSelecionadoGrid = dGridLocalManutencao.SelectedRows[0].Cells[0].Value.ToString();

                if (XtraMessageBox.Show("Deseja inativar o local de manutenção selecionado ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string sqlCommand = $"UPDATE manutencao_local SET ativo = 'N', id_usuario_desativacao = {SessaoSistema.UserId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_manutencao_local = {idRegistroSelecionadoGrid}";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    XtraMessageBox.Show("Local de manutenção inativado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AtualizaDG();
                }

            }
            catch
            {
                XtraMessageBox.Show("Primeiro selecione o registro que deseja inativar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnImprimirConsulta_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
                    tipoBusca = $"ml.descricao ILIKE '%{tBoxTextoConsulta.Text.ToUpper().Trim()}%'";
                    break;
                default:
                    tipoBusca = "1=1";
                    break;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT ml.id_manutencao_local, CASE WHEN ml.ativo = 'S' THEN ml.descricao ELSE '>>>>> [REGISTRO INATIVO] <<<<< | ' || ml.descricao END AS descricao, uc.nome AS usuario_cadastro, ml.data_cadastro, CASE WHEN ml.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM manutencao_local AS ml INNER JOIN usuario AS uc ON(uc.id_usuario = ml.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = ml.id_usuario_desativacao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = ml.id_usuario_alteracao) WHERE ml.ativo = '{situacaoTraduzida}' AND {tipoBusca} ORDER BY 1 ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridLocalManutencao.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        #endregion

    }
}