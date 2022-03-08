using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Servipol.Forms.Cadastros.Equipamentos
{
    public partial class frmEquipamentosConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        readonly ConexaoBD BD = new ConexaoBD();
        #endregion

        public frmEquipamentosConsultar()
        {
            InitializeComponent();
        }

        private void frmEquipamentosConsultar_Load(object sender, EventArgs e)
        {
            VerificaPermissao();

            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
            CarregaCategoriaEquipamento();
            CarregaTabelaEquipamentos();
            dGridEquipamentos.Select();
        }

        #region Methods

        public void CarregaTabelaEquipamentos()
        {
            try
            {
                cBoxSituacao.SelectedIndex = 0;
                cBoxTipoBusca.SelectedIndex = 0;
                tBoxTextoConsulta.Clear();

                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT e.id_equipamento, e.codigo, e.descricao AS descricao_equipamento, ec.descricao AS descricao_categoria, e.preco_venda, CASE WHEN e.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM equipamento AS e INNER JOIN equipamento_categoria AS ec ON(e.id_equipamento_categoria = ec.id_equipamento_categoria) WHERE e.ativo = 'S'", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);

                dGridEquipamentos.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaCategoriaEquipamento()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT ec.id_equipamento_categoria, ec.descricao FROM equipamento_categoria AS ec WHERE ec.ativo = 'S'";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxCategoriaEquipamento.ValueMember = "id_equipamento_categoria";
                cBoxCategoriaEquipamento.DisplayMember = "descricao";
                cBoxCategoriaEquipamento.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void VerificaPermissao()
        {
            if (SessaoSistema.UserPermission.Substring(34, 1) == "S") { btnIncluir.Enabled = true; } else { btnIncluir.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(35, 1) == "S") { btnEditar.Enabled = true; } else { btnEditar.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(36, 1) == "S") { btnInativar.Enabled = true; } else { btnInativar.Enabled = false; }
        }

        public void AtualizaDG()
        {
            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
            cBoxCategoriaEquipamento.SelectedIndex = -1;
            CarregaTabelaEquipamentos();
        }

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

        private void dGridEquipamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SessaoSistema.UserPermission.Substring(35, 1) == "S")
            {
                btnEditar_Click(sender, e);
            }
        }

        private void frmEquipamentosConsultar_KeyDown(object sender, KeyEventArgs e)
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
            if (SessaoSistema.UserPermission.Substring(34, 1) == "S" && e.KeyCode == Keys.F4)
            {
                btnIncluir_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(35, 1) == "S" && e.KeyCode == Keys.F3)
            {
                btnEditar_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(36, 1) == "S" && cBoxSituacao.SelectedIndex == 0 && e.KeyCode == Keys.Delete)
            {
                btnInativar_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                btnImprimirConsulta_Click(sender, e);
            }
        }

        private void cBoxTipoBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            //busca por Todos
            if (cBoxTipoBusca.SelectedIndex == 0)
            {
                cBoxCategoriaEquipamento.SelectedIndex = -1;
                cBoxCategoriaEquipamento.Visible = false;
                tBoxTextoConsulta.Visible = false;
                tBoxTextoConsulta.Clear();
                CarregaTabelaEquipamentos();
                gbConsulta.Text = null;
            }
            //busca por Descrição
            else if (cBoxTipoBusca.SelectedIndex == 1)
            {
                tBoxTextoConsulta.Visible = true;
                cBoxCategoriaEquipamento.SelectedIndex = -1;
                cBoxCategoriaEquipamento.SendToBack();
                tBoxTextoConsulta.BringToFront();
                tBoxTextoConsulta.Clear();
                gbConsulta.Text = "Descrição";
            }
            //busca por Categoria
            else if (cBoxTipoBusca.SelectedIndex == 2)
            {
                cBoxCategoriaEquipamento.Visible = true;
                cBoxCategoriaEquipamento.SelectedIndex = -1;
                cBoxCategoriaEquipamento.BringToFront();
                tBoxTextoConsulta.SendToBack();
                tBoxTextoConsulta.Clear();
                gbConsulta.Text = "Categoria";
            }
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
                    tipoBusca = $"e.descricao ILIKE '%{tBoxTextoConsulta.Text.ToUpper().Trim()}%'";
                    break;
                case 2:
                    tipoBusca = $"e.id_equipamento_categoria = {cBoxCategoriaEquipamento.SelectedIndex}";
                    break;
                default:
                    tipoBusca = "1=1";
                    break;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT e.id_equipamento, e.codigo, e.descricao AS descricao_equipamento, ec.descricao AS descricao_categoria, e.preco_venda, CASE WHEN e.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM equipamento AS e INNER JOIN equipamento_categoria AS ec ON(e.id_equipamento_categoria = ec.id_equipamento_categoria) WHERE e.ativo = '{situacaoTraduzida}' AND {tipoBusca}", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridEquipamentos.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnImprimirConsulta_Click(object sender, EventArgs e)
        {
            var dadosRelatorio = from DataGridViewRow linha in dGridEquipamentos.Rows
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
                string _idRegistroSelecionadoGrid = dGridEquipamentos.SelectedRows[0].Cells[0].Value.ToString();
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
                string idRegistroSelecionadoGrid = dGridEquipamentos.SelectedRows[0].Cells[0].Value.ToString();

                if (XtraMessageBox.Show("Deseja inativar o equipamento selecionado ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string sqlCommand = $"UPDATE equipamento SET ativo = 'N', id_usuario_desativacao = {SessaoSistema.UserId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_equipamento = {idRegistroSelecionadoGrid}";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    XtraMessageBox.Show("Equipamento inativado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        #endregion

        private void cBoxCategoriaEquipamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);
        }
    }
}