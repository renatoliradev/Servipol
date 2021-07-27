using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;

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
            //carregaTabelaFuncionarios();
        }

        #region Methods

        public void carregaTabelaFuncionarios()
        {
            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT f.id, tf.descricao_tipo_funcionario, f.cod_controle, f.codigo, f.nome, f.data_admissao, f.telefone_funcionario_1, f.telefone_funcionario_2, f.telefone_funcionario_3, CASE WHEN f.ativo = 'S' THEN 'SIM' ELSE 'NÃO' END AS ativo FROM funcionario AS f INNER JOIN tipo_funcionario AS tf ON(f.id_tipo_funcionario = tf.id_tipo_funcionario) WHERE f.ativo = 'S' ORDER BY f.codigo ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);

                dGridFuncionarios.DataSource = dp;
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

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmFuncionariosCadastrar frmFuncionariosCadastrar = new frmFuncionariosCadastrar("Incluir", 0);
            frmFuncionariosCadastrar.Owner = this;
            frmFuncionariosCadastrar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string idFuncionarioGrid = dGridFuncionarios.SelectedRows[0].Cells[0].Value.ToString();
            frmFuncionariosCadastrar frmFuncionariosCadastrar = new frmFuncionariosCadastrar("Editar", int.Parse(idFuncionarioGrid));
            frmFuncionariosCadastrar.Owner = this;
            frmFuncionariosCadastrar.ShowDialog();
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