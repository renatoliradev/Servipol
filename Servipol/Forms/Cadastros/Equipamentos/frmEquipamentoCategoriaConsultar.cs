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

namespace Servipol.Forms.Cadastros.Equipamentos
{
    public partial class frmEquipamentoCategoriaConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        readonly ConexaoBD BD = new ConexaoBD();
        #endregion

        public frmEquipamentoCategoriaConsultar()
        {
            InitializeComponent();
        }

        private void frmEquipamentoCategoriaConsultar_Load(object sender, EventArgs e)
        {
            VerificaPermissao();

            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
            CarregaTabelaCategoriaEquipamentos();
            dGridCategoriaEquipamentos.Select();
        }

        #region Methods

        public void CarregaTabelaCategoriaEquipamentos()
        {
            try
            {
                cBoxSituacao.SelectedIndex = 0;
                cBoxTipoBusca.SelectedIndex = 0;
                tBoxTextoConsulta.Clear();

                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT ec.id_equipamento_categoria, ec.descricao, CASE WHEN ec.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM equipamento_categoria AS ec WHERE ec.ativo = 'S'", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);

                dGridCategoriaEquipamentos.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void VerificaPermissao()
        {
            if (SessaoSistema.UserPermission.Substring(38, 1) == "S") { btnIncluir.Enabled = true; } else { btnIncluir.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(39, 1) == "S") { btnEditar.Enabled = true; } else { btnEditar.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(40, 1) == "S") { btnInativar.Enabled = true; } else { btnInativar.Enabled = false; }
        }

        public void AtualizaDG()
        {
            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
            CarregaTabelaCategoriaEquipamentos();
        }


        #endregion

        private void cBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);

            if (SessaoSistema.UserPermission.Substring(36, 1) == "S" && cBoxSituacao.SelectedIndex == 0)
            {
                btnInativar.Enabled = true;
            }
            else
            {
                btnInativar.Enabled = false;
            }
        }

        private void dGridCategoriaEquipamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SessaoSistema.UserPermission.Substring(39, 1) == "S")
            {
                btnEditar_Click(sender, e);
            }
        }

        private void frmEquipamentoCategoriaConsultar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cBoxTipoBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            //busca por Todos
            if (cBoxTipoBusca.SelectedIndex == 0)
            {
                tBoxTextoConsulta.Visible = false;
                tBoxTextoConsulta.Clear();
                CarregaTabelaCategoriaEquipamentos();
                gbConsulta.Text = null;
            }
            //busca por Descrição
            else if (cBoxTipoBusca.SelectedIndex == 1)
            {
                tBoxTextoConsulta.Visible = true;
                tBoxTextoConsulta.BringToFront();
                tBoxTextoConsulta.Clear();
                gbConsulta.Text = "Descrição";
            }
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
                    tipoBusca = $"ec.descricao ILIKE '%{tBoxTextoConsulta.Text.ToUpper().Trim()}%'";
                    break;
                default:
                    tipoBusca = "1=1";
                    break;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT ec.id_equipamento_categoria, ec.descricao, CASE WHEN ec.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM equipamento_categoria AS ec WHERE ec.ativo = '{situacaoTraduzida}' AND {tipoBusca}", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridCategoriaEquipamentos.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmEquipamentosCadastrar frmEquipamentosCadastrar = new frmEquipamentosCadastrar("Incluir", 0);
            frmEquipamentosCadastrar.Owner = this;
            frmEquipamentosCadastrar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string _idRegistroSelecionadoGrid = dGridCategoriaEquipamentos.SelectedRows[0].Cells[0].Value.ToString();
                frmEquipamentosCadastrar frmEquipamentosCadastrar = new frmEquipamentosCadastrar("Editar", int.Parse(_idRegistroSelecionadoGrid));
                frmEquipamentosCadastrar.Owner = this;
                frmEquipamentosCadastrar.ShowDialog();
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
                string idRegistroSelecionadoGrid = dGridCategoriaEquipamentos.SelectedRows[0].Cells[0].Value.ToString();

                if (XtraMessageBox.Show("Deseja inativar a categoria selecionada ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string sqlCommand = $"UPDATE equipamento_categoria SET ativo = 'N', id_usuario_desativacao = {SessaoSistema.UserId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_equipamento_categoria = {idRegistroSelecionadoGrid}";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    XtraMessageBox.Show("Categoria inativada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            var dadosRelatorio = from DataGridViewRow linha in dGridCategoriaEquipamentos.Rows
                                 select new
                                 {
                                     Codigo = linha.Cells["codigo"].Value,
                                     Categoria = linha.Cells["descricao_categoria"].Value,
                                     Descricao = linha.Cells["descricao_equipamento"].Value,
                                     PrecoVenda = linha.Cells["preco_venda"].Value,
                                     Ativo = linha.Cells["ativo"].Value
                                 };

            Relatorios.frmRelatorio.ShowReport("Servipol.Forms.Relatorios.RelacaoDeEquipamentos.rdlc", true, new Dictionary<string, object>() { { "DataSetEquipamentos", dadosRelatorio.AsEnumerable() } });

        }
    }
}