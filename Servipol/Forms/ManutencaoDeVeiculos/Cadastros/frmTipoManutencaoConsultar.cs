using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmTipoManutencaoConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        readonly ConexaoBD BD = new ConexaoBD();
        #endregion

        public frmTipoManutencaoConsultar()
        {
            InitializeComponent();
        }

        private void frmTipoManutencaoConsultar_Load(object sender, EventArgs e)
        {
            VerificaPermissao();

            CarregaTabelaTipoManutencao();

            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
        }

        #region Methods
        public void CarregaTabelaTipoManutencao()
        {
            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT mt.id_manutencao_tipo, CASE WHEN mt.ativo = 'S' THEN mt.descricao ELSE '[REGISTRO INATIVO] - ' || mt.descricao END AS descricao, CASE WHEN mt.aplicacao_carro = 'S' THEN 'Sim' ELSE 'Não' END AS aplicacao_carro, CASE WHEN mt.aplicacao_moto = 'S' THEN 'Sim' ELSE 'Não' END AS aplicacao_moto, CASE WHEN mt.exige_km_validade_oleo = 'S' THEN 'Sim' ELSE 'Não' END AS exige_km_validade_oleo, uc.nome AS usuario_cadastro, mt.data_cadastro, CASE WHEN mt.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM manutencao_tipo AS mt INNER JOIN usuario AS uc ON(uc.id_usuario = mt.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = mt.id_usuario_desativacao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = mt.id_usuario_alteracao) WHERE mt.ativo = 'S'", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridTipoManutencao.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void VerificaPermissao()
        {
            if (SessaoSistema.UserPermission.Substring(21, 1) == "S") { btnIncluir.Enabled = true; } else { btnIncluir.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(22, 1) == "S") { btnEditar.Enabled = true; } else { btnEditar.Enabled = false; }
            if (SessaoSistema.UserPermission.Substring(23, 1) == "S") { btnInativar.Enabled = true; } else { btnInativar.Enabled = false; }
        }

        public void AtualizaDG()
        {
            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            tBoxTextoConsulta.Clear();
            CarregaTabelaTipoManutencao();
        }

        private void cBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);

            if (SessaoSistema.UserPermission.Substring(23, 1) == "S" && cBoxSituacao.SelectedIndex == 0)
            {
                btnInativar.Enabled = true;
            }
            else
            {
                btnInativar.Enabled = false;
            }
        }

        private void dGridTipoManutencao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SessaoSistema.UserPermission.Substring(22, 1) == "S")
            {
                btnEditar_Click(sender, e);
            }
        }

        private void frmTipoManutencaoConsultar_KeyDown(object sender, KeyEventArgs e)
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
            if (SessaoSistema.UserPermission.Substring(21, 1) == "S" && e.KeyCode == Keys.F4)
            {
                btnIncluir_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(22, 1) == "S" && e.KeyCode == Keys.F3)
            {
                btnEditar_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(23, 1) == "S" && cBoxSituacao.SelectedIndex == 0 && e.KeyCode == Keys.Delete)
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

        private void tBoxTextoConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnConsultar_Click(sender, e);
                    break;
            }
        }

        private void frmTipoManutencaoConsultar_Activated(object sender, EventArgs e)
        {
            dGridTipoManutencao.Sort(dGridTipoManutencao.Columns["id_manutencao_tipo"], ListSortDirection.Ascending);
        }

        #endregion

        #region Buttons

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmTipoManutencaoCadastrar frmTipoManutencaoCadastrar = new frmTipoManutencaoCadastrar("Incluir", 0);
            frmTipoManutencaoCadastrar.Owner = this;
            frmTipoManutencaoCadastrar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string idRegistroSelecionadoGrid = dGridTipoManutencao.SelectedRows[0].Cells[0].Value.ToString();
                frmTipoManutencaoCadastrar frmTipoManutencaoCadastrar = new frmTipoManutencaoCadastrar("Editar", int.Parse(idRegistroSelecionadoGrid));
                frmTipoManutencaoCadastrar.Owner = this;
                frmTipoManutencaoCadastrar.ShowDialog();
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
                string idRegistroSelecionadoGrid = dGridTipoManutencao.SelectedRows[0].Cells[0].Value.ToString();

                if (XtraMessageBox.Show("Deseja inativar o tipo de manutenção selecionado ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string sqlCommand = $"UPDATE manutencao_tipo SET ativo = 'N', id_usuario_desativacao = {SessaoSistema.UserId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_manutencao_tipo = {idRegistroSelecionadoGrid}";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    XtraMessageBox.Show("Tipo de manutenção inativado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            var dadosRelatorio = from DataGridViewRow linha in dGridTipoManutencao.Rows
                                 select new
                                 {
                                     Descricao = linha.Cells["descricao"].Value,
                                     AplicacaoCarro = linha.Cells["aplicacao_carro"].Value,
                                     AplicacaoMoto = linha.Cells["aplicacao_moto"].Value,
                                     UsuarioCadastro = linha.Cells["usuario_cadastro"].Value,
                                     DataCadastro = linha.Cells["data_cadastro"].Value,
                                     Ativo = linha.Cells["ativo"].Value
                                 };

            Relatorios.frmRelatorio.ShowReport("Servipol.Forms.Relatorios.RelacaoTipoDeManutencao.rdlc", true, new Dictionary<string, object>() { { "DataSetTipoManutencao", dadosRelatorio.AsEnumerable() } });
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
                    tipoBusca = $"mt.descricao ILIKE '%{tBoxTextoConsulta.Text.ToUpper().Trim()}%'";
                    break;
                default:
                    tipoBusca = "1=1";
                    break;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT mt.id_manutencao_tipo, CASE WHEN mt.ativo = 'S' THEN mt.descricao ELSE '[REGISTRO INATIVO] - ' || mt.descricao END AS descricao, CASE WHEN mt.aplicacao_carro = 'S' THEN 'Sim' ELSE 'Não' END AS aplicacao_carro, CASE WHEN mt.aplicacao_moto = 'S' THEN 'Sim' ELSE 'Não' END AS aplicacao_moto, CASE WHEN mt.exige_km_validade_oleo = 'S' THEN 'Sim' ELSE 'Não' END AS exige_km_validade_oleo, uc.nome AS usuario_cadastro, mt.data_cadastro, CASE WHEN mt.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM manutencao_tipo AS mt INNER JOIN usuario AS uc ON(uc.id_usuario = mt.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = mt.id_usuario_desativacao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = mt.id_usuario_alteracao) WHERE mt.ativo = '{situacaoTraduzida}' AND {tipoBusca}", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridTipoManutencao.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }


        #endregion

    }
}