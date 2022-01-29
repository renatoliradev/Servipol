using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Servipol.Forms.Cadastros.Funcionários
{
    public partial class frmFuncionariosConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        readonly ConexaoBD BD = new ConexaoBD();
        #endregion

        public frmFuncionariosConsultar()
        {
            InitializeComponent();
        }

        private void frmFuncionariosConsultar_Load(object sender, EventArgs e)
        {
            VerificaPermissao();

            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
            CarregaTabelaFuncionarios();
            dGridFuncionarios.Select();
        }

        #region Methods

        public void CarregaTabelaFuncionarios()
        {
            try
            {
                cBoxSituacao.SelectedIndex = 0;
                cBoxTipoBusca.SelectedIndex = 0;
                tBoxTextoConsulta.Clear();

                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT f.id_funcionario, fc.descricao AS descricao_funcionario_cargo, f.tipo_sanguineo, f.codigo_ase, f.nome, f.data_admissao, f.telefone_1, f.telefone_2, f.telefone_3, telefone_4, CASE WHEN f.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM funcionario AS f INNER JOIN funcionario_cargo AS fc ON(f.id_funcionario_cargo = fc.id_funcionario_cargo) WHERE f.ativo = 'S'", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);

                dGridFuncionarios.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void VerificaPermissao()
        {
            if (SessaoSistema.UserPermission.Substring(17, 1) == "S") { btnIncluir.Enabled = true; } else { btnIncluir.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(18, 1) == "S") { btnEditar.Enabled = true; } else { btnEditar.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(19, 1) == "S") { btnVisualizar.Enabled = true; } else { btnVisualizar.Enabled = false; }
        }

        public void AtualizaDG()
        {
            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
            CarregaTabelaFuncionarios();
        }

        private void frmFuncionariosConsultar_Activated(object sender, EventArgs e)
        {
            dGridFuncionarios.Sort(dGridFuncionarios.Columns["codigo_ase"], ListSortDirection.Ascending);

            //if (XtraMessageBox.Show("Deseja recarregar os dados ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            //{
            //    CarregaTabelaFuncionarios();
            //}
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

        private void frmFuncionariosConsultar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    btnIncluir_Click(sender, e);
                    break;
                case Keys.F3:
                    btnEditar_Click(sender, e);
                    break;
                case Keys.F8:
                    btnVisualizar_Click(sender, e);
                    break;
                case Keys.F5:
                    btnConsultar_Click(sender, e);
                    break;
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                btnImprimirConsulta_Click(sender, e);
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

        private void cBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);
        }

        private void dGridFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        private void frmFuncionariosConsultar_FormClosing(object sender, FormClosingEventArgs e)
        {
            BD.Desconectar();
            this.Dispose();
        }

        #endregion

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
                    tipoBusca = $"f.nome ILIKE '%{tBoxTextoConsulta.Text.ToUpper().Trim()}%'";
                    break;
                default:
                    tipoBusca = "1=1";
                    break;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT f.id_funcionario, fc.descricao AS descricao_funcionario_cargo, f.tipo_sanguineo, f.codigo_ase, f.nome, f.data_admissao, f.telefone_1, f.telefone_2, f.telefone_3, telefone_4, CASE WHEN f.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM funcionario AS f INNER JOIN funcionario_cargo AS fc ON(f.id_funcionario_cargo = fc.id_funcionario_cargo) WHERE f.ativo = '{situacaoTraduzida}' AND {tipoBusca}", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridFuncionarios.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmFuncionariosCadastrar frmFuncionariosCadastrar = new frmFuncionariosCadastrar("Incluir", 0);
            frmFuncionariosCadastrar.Owner = this;
            frmFuncionariosCadastrar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string idFuncionarioGrid = dGridFuncionarios.SelectedRows[0].Cells[0].Value.ToString();
                frmFuncionariosCadastrar frmFuncionariosCadastrar = new frmFuncionariosCadastrar("Editar", int.Parse(idFuncionarioGrid));
                frmFuncionariosCadastrar.Owner = this;
                frmFuncionariosCadastrar.ShowDialog();
            }
            catch
            {
                XtraMessageBox.Show("Primeiro selecione o registro que deseja editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string idFuncionarioGrid = dGridFuncionarios.SelectedRows[0].Cells[0].Value.ToString();
                frmFuncionariosCadastrar frmFuncionariosCadastrar = new frmFuncionariosCadastrar("Visualizar", int.Parse(idFuncionarioGrid));
                frmFuncionariosCadastrar.Owner = this;
                frmFuncionariosCadastrar.ShowDialog();
            }
            catch
            {
                XtraMessageBox.Show("Primeiro selecione o registro que deseja visualizar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimirConsulta_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #endregion

    }
}