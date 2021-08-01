using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace Servipol.Forms.Cadastros.Funcionários
{
    public partial class frmFuncionariosConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        ConexaoBD BD = new ConexaoBD();
        #endregion

        public frmFuncionariosConsultar()
        {
            InitializeComponent();
        }

        private void frmFuncionariosConsultar_Load(object sender, EventArgs e)
        {
            CarregaTabelaFuncionarios();
        }

        #region Methods

        public void CarregaTabelaFuncionarios()
        {
            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT f.id_funcionario, fc.descricao AS descricao_funcionario_cargo, f.tipo_sanguineo, f.codigo_ase, f.nome, f.data_admissao, f.telefone_1, f.telefone_2, f.telefone_3, telefone_4, CASE WHEN f.ativo = 'S' THEN 'SIM' ELSE 'NÃO' END AS ativo FROM funcionario AS f INNER JOIN funcionario_cargo AS fc ON(f.id_funcionario_cargo = fc.id_funcionario_cargo) WHERE f.ativo = 'S' ORDER BY f.codigo_ase ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);

                dGridFuncionarios.DataSource = dp;
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
            CarregaTabelaFuncionarios();
        }

        #endregion

        #region Buttons

        private void btnConsultar_Click(object sender, EventArgs e)
        {

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

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimirConsulta_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}