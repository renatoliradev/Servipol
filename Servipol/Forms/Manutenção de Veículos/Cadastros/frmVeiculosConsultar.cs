using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmVeiculosConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        ConexaoBD BD = new ConexaoBD();
        #endregion

        public frmVeiculosConsultar()
        {
            InitializeComponent();
        }

        private void frmVeiculosConsultar_Load(object sender, EventArgs e)
        {
            CarregaTipoVeiculo();

            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
        }

        #region Methods

        public void CarregaTabelaVeiculos()
        {
            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT v.id_veiculo, vt.descricao AS tipo, v.codigo, CASE WHEN v.ativo = 'S' THEN v.descricao ELSE '>>>>> [REGISTRO INATIVO] <<<<< | ' || v.descricao END AS descricao, v.placa, v.combustivel, CASE WHEN v.registra_km_diario = 'S' THEN 'Sim' ELSE 'Não' END AS registra_km_diario, v.km_validade_oleo, CASE WHEN v.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM veiculo AS v INNER JOIN veiculo_tipo AS vt ON(v.id_veiculo_tipo = vt.id_veiculo_tipo) WHERE vt.descricao != 'Outros' AND v.ativo = 'S' ORDER BY v.codigo ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridVeiculos.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaTipoVeiculo()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id_veiculo_tipo, descricao FROM veiculo_tipo WHERE ativo = 'S' AND descricao != 'Outros' ORDER BY 1 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxTipoVeiculo.ValueMember = "id_veiculo_tipo";
                cBoxTipoVeiculo.DisplayMember = "descricao";
                cBoxTipoVeiculo.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void cBoxTipoVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);
        }

        private void cBoxTipoVeiculo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);
        }

        private void cBoxTipoBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxTipoBusca.SelectedIndex == 0)
            {
                cBoxTipoVeiculo.Visible = false;
                btnConsultar_Click(sender, e);
            }
            else
            {
                cBoxTipoVeiculo.Visible = true;
            }
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

        public void AtualizaDG()
        {
            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;

            cBoxTipoVeiculo.SelectedIndex = -1;

            CarregaTabelaVeiculos();
        }

        private void dGridVeiculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        private void frmVeiculosConsultar_Activated(object sender, EventArgs e)
        {
            dGridVeiculos.Sort(dGridVeiculos.Columns["codigo"], ListSortDirection.Ascending);

            //if (XtraMessageBox.Show("Deseja recarregar os dados ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            //{

            //}
        }

        private void frmVeiculosConsultar_KeyDown(object sender, KeyEventArgs e)
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

        private void cBoxTipoVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnConsultar_Click(sender, e);
                    break;
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
                    tipoBusca = $"v.id_veiculo_tipo = {cBoxTipoVeiculo.SelectedValue}";
                    break;
                default:
                    tipoBusca = "1=1";
                    break;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT v.id_veiculo, vt.descricao AS tipo, v.codigo, CASE WHEN v.ativo = 'S' THEN v.descricao ELSE '>>>>>  [REGISTRO INATIVO] <<<<< | ' || v.descricao END AS descricao, v.placa, v.combustivel, v.km_validade_oleo, CASE WHEN v.registra_km_diario = 'S' THEN 'Sim' ELSE 'Não' END AS registra_km_diario, CASE WHEN v.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM veiculo AS v INNER JOIN veiculo_tipo AS vt ON(v.id_veiculo_tipo = vt.id_veiculo_tipo) WHERE vt.descricao != 'Outros' AND v.ativo = '{situacaoTraduzida}' AND {tipoBusca}  ORDER BY v.codigo ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridVeiculos.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmVeiculosCadastrar frmVeiculosCadastrar = new frmVeiculosCadastrar("Incluir", 0);
            frmVeiculosCadastrar.Owner = this;
            frmVeiculosCadastrar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string idVeiculoGrid = dGridVeiculos.SelectedRows[0].Cells[0].Value.ToString();
                frmVeiculosCadastrar frmVeiculosCadastrar = new frmVeiculosCadastrar("Editar", int.Parse(idVeiculoGrid));
                frmVeiculosCadastrar.Owner = this;
                frmVeiculosCadastrar.ShowDialog();
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
                string idVeiculoSelecionadoGrid = dGridVeiculos.SelectedRows[0].Cells[0].Value.ToString();
                
                if (XtraMessageBox.Show("Deseja inativar o veículo selecionado ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string sqlCommand = $"UPDATE veiculo SET registra_km_diario = 'N', ativo = 'N', id_usuario_desativacao = {SessaoSistema.UserId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_veiculo = {idVeiculoSelecionadoGrid}";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    string sqlCommand4 = $"DELETE FROM km_diario WHERE id_veiculo = {idVeiculoSelecionadoGrid}";
                    NpgsqlCommand command4 = new NpgsqlCommand(sqlCommand4, BD.ObjetoConexao);
                    command4.ExecuteNonQuery();

                    string sqlCommand1 = $"UPDATE codigocarro SET id_veiculo = NULL WHERE id_veiculo = {idVeiculoSelecionadoGrid}";
                    NpgsqlCommand command1 = new NpgsqlCommand(sqlCommand1, BD.ObjetoConexao);
                    command1.ExecuteNonQuery();

                    string sqlCommand2 = $"UPDATE codigomoto SET id_veiculo = NULL WHERE id_veiculo = {idVeiculoSelecionadoGrid}";
                    NpgsqlCommand command2 = new NpgsqlCommand(sqlCommand2, BD.ObjetoConexao);
                    command2.ExecuteNonQuery();

                    XtraMessageBox.Show("Veículo inativado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        #endregion

        
    }
}