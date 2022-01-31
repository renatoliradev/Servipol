using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    public partial class frmManutencaoConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();
        MemoryManagement MemoryManagement = new MemoryManagement();

        #endregion

        public frmManutencaoConsultar()
        {
            InitializeComponent();
        }

        private void frmManutencaoConsultar_Load(object sender, EventArgs e)
        {
            try
            {
                VerificaPermissao();

                cBoxSituacao.SelectedIndex = 0;
                cBoxTipoBusca.SelectedIndex = 0;
                gBoxFuncionario.Visible = false;
                gBoxLocalManutencao.Visible = false;
                gBoxTipoManutencao.Visible = false;
                gBoxUsuario.Visible = false;
                gBoxVeiculo.Visible = false;

                CarregaDataInicialFinal();
                CarregaFuncionario();
                CarregaLocalManutencao();
                CarregaTipoManutencao();
                CarregaVeiculo();
                CarregaUsuario();
            }
            finally
            {
                dGridManutencoes.Focus();
                dGridManutencoes.Select();
            }
        }

        #region Methods
        public void CarregaTabelaManutencoes()
        {
            string registroExcluido;

            if (cBoxSituacao.SelectedIndex == 0)
            {
                registroExcluido = "N";
                btnExcluir.Enabled = true;
            }
            else
            {
                registroExcluido = "S";
                btnExcluir.Enabled = false;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT mv.id_manutencao, v.id_veiculo AS id_veiculo, mv.data_manutencao, v.placa, CAST(CASE WHEN tv.descricao = 'CARRO' THEN v.descricao WHEN v.ativo = 'N' AND tv.descricao = 'MOTO' THEN tv.descricao || ' ' || v.codigo || ' >>> REGISTRO INATIVO <<<' WHEN v.ativo = 'N' AND tv.descricao = 'CARRO' THEN v.descricao || ' >>> REGISTRO INATIVO <<<'  ELSE tv.descricao || ' ' || v.codigo END AS VARCHAR) AS veiculo, mv.km_veiculo, MAX(kmd.km_veiculo) AS km_atual, CAST(MAX(kmd.km_veiculo) - mv.km_veiculo AS numeric) AS km_rodado, tm.descricao AS descricao_tipo_manutencao, lm.descricao AS descricao_local_manutencao, CAST(CASE WHEN id_funcionario_cargo = 1 THEN codigo || ' - ' || qra_ase ELSE nome END AS VARCHAR) AS qra, CAST(CASE WHEN mv.registro_excluido = 'N' THEN 'Confirmada' ELSE 'Excluída' END AS VARCHAR) AS situacao, mv.valor_total AS valor_total_manutencao FROM manutencao AS mv INNER JOIN veiculo AS v ON(mv.id_veiculo = v.id_veiculo) INNER JOIN manutencao_tipo AS tm ON(mv.id_manutencao_tipo = tm.id_manutencao_tipo) INNER JOIN manutencao_local AS lm ON(mv.id_manutencao_local = lm.id_manutencao_local) INNER JOIN funcionario AS f ON(mv.id_funcionario = f.id_funcionario) INNER JOIN veiculo_tipo AS tv ON(v.id_veiculo_tipo = tv.id_veiculo_tipo) INNER JOIN km_diario AS kmd ON(kmd.id_veiculo = v.id_veiculo) WHERE mv.confirmada = 'S' AND mv.registro_excluido = '{registroExcluido}' GROUP BY mv.id_manutencao, tv.descricao, v.id_veiculo, v.descricao, v.placa, v.codigo, tm.descricao, lm.descricao, f.id_funcionario_cargo, f.codigo_ase, f.qra_ase, f.nome ORDER BY mv.data_manutencao DESC LIMIT 20", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridManutencoes.DataSource = dp;

                tBoxValorTotal.Text = dGridManutencoes.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[valor_total_manutencao.Name].Value ?? 0)).ToString("C");

            }
            catch
            {
                tBoxValorTotal.Text = "R$0,00";
            }
            finally
            {
                dGridManutencoes.Columns["id_manutencao"].Visible = false;
                dGridManutencoes.Columns["id_veiculo"].Visible = false;

                dGridManutencoes.Columns["data_manutencao"].HeaderText = "Data da Manutenção";
                dGridManutencoes.Columns["placa"].HeaderText = "Placa";
                dGridManutencoes.Columns["veiculo"].HeaderText = "Veículo";
                dGridManutencoes.Columns["km_veiculo"].HeaderText = "Km da Manutenção";
                dGridManutencoes.Columns["km_atual"].HeaderText = "Km Atual";
                dGridManutencoes.Columns["km_rodado"].HeaderText = "Km Rodado";
                dGridManutencoes.Columns["descricao_tipo_manutencao"].HeaderText = "Tipo da Manutenção";
                dGridManutencoes.Columns["descricao_local_manutencao"].HeaderText = "Local da Manutenção";
                dGridManutencoes.Columns["qra"].HeaderText = "Funcionário";
                dGridManutencoes.Columns["situacao"].HeaderText = "Situação";
                dGridManutencoes.Columns["valor_total_manutencao"].HeaderText = "Valor da Manutenção";

                dGridManutencoes.Columns["data_manutencao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dGridManutencoes.Columns["km_veiculo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dGridManutencoes.Columns["km_atual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dGridManutencoes.Columns["km_rodado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dGridManutencoes.Columns["situacao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dGridManutencoes.Columns["valor_total_manutencao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dGridManutencoes.Columns["valor_total_manutencao"].DefaultCellStyle.Format = "C2";

                tBoxQtdRegistros.Text = dGridManutencoes.RowCount.ToString();
                BD.Desconectar();
            }
        }

        public void VerificaPermissao()
        {
            if (SessaoSistema.UserPermission.Substring(30, 1) == "S") { btnExcluir.Enabled = true; } else { btnExcluir.Enabled = false; }
        }

        public void AtualizaDG()
        {
            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
            gBoxFuncionario.Visible = false;
            gBoxLocalManutencao.Visible = false;
            gBoxTipoManutencao.Visible = false;
            gBoxUsuario.Visible = false;
            gBoxVeiculo.Visible = false;
            CarregaTabelaManutencoes();
        }

        public void AtualizaDGDepoisDeExcluir(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }

        private void frmManutencaoConsultar_FormClosing(object sender, FormClosingEventArgs e)
        {
            MemoryManagement.FlushMemory();
        }

        public void CarregaVeiculo()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT v.id_veiculo, CAST(CASE WHEN v.ativo = 'N' AND tv.descricao = 'Moto' THEN '>>>>>> REGISTRO INATIVO <<<<<< | ' || tv.descricao || ' 0' || v.codigo || ' - [' || v.placa || ']' 	WHEN v.ativo = 'N' AND tv.descricao = 'Carro' THEN '>>>>>> REGISTRO INATIVO <<<<<< | ' || v.descricao || ' - [' || v.placa || ']' 	WHEN v.ativo = 'S' AND tv.descricao = 'Moto' THEN tv.descricao || ' 0' || v.codigo || ' - [' || v.placa|| ']' 	WHEN v.ativo = 'S' AND tv.descricao = 'Carro' THEN v.descricao || ' - [' || v.placa || ']' 	ELSE tv.descricao || ' ' || v.codigo || ' - [' || v.placa || ']' END AS VARCHAR) AS veiculo FROM veiculo AS v JOIN veiculo_tipo AS tv ON(tv.id_veiculo_tipo = v.id_veiculo_tipo) WHERE v.id_veiculo_tipo != 3 ORDER BY v.ativo DESC, v.id_veiculo_tipo DESC, v.codigo ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxVeiculo.ValueMember = "id_veiculo";
                cBoxVeiculo.DisplayMember = "veiculo";
                cBoxVeiculo.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaTipoManutencao()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id_manutencao_tipo, descricao, ordem FROM manutencao_tipo WHERE ativo = 'S' OR (id_manutencao_tipo IN (SELECT id_manutencao_tipo FROM manutencao)) ORDER BY 3 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxTipoManutencao.ValueMember = "id_manutencao_tipo";
                cBoxTipoManutencao.DisplayMember = "descricao";
                cBoxTipoManutencao.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaLocalManutencao()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id_manutencao_local, descricao FROM manutencao_local WHERE ativo = 'S' OR (id_manutencao_local IN (SELECT id_manutencao_local FROM manutencao)) ORDER BY 2 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxLocalManutencao.ValueMember = "id_manutencao_local";
                cBoxLocalManutencao.DisplayMember = "descricao";
                cBoxLocalManutencao.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaFuncionario()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id_funcionario, CAST(CASE WHEN id_funcionario_cargo = 1 THEN codigo_ase || ' - ' || qra_ase ELSE nome END AS VARCHAR) AS qra FROM funcionario WHERE ativo = 'S' OR (id_funcionario IN (SELECT id_funcionario FROM manutencao)) ORDER BY codigo_ase ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxFuncionario.ValueMember = "id_funcionario";
                cBoxFuncionario.DisplayMember = "qra";
                cBoxFuncionario.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaUsuario()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = "SELECT id_usuario, nome FROM usuario WHERE ativo = 'S' OR (id_usuario_cadastro IN (SELECT id_usuario_cadastro FROM manutencao)) ORDER BY nome ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxUsuario.ValueMember = "id_usuario";
                cBoxUsuario.DisplayMember = "nome";
                cBoxUsuario.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaDataInicialFinal()
        {
            try
            {
                DateTime dataFinal = DateTime.Today;
                DateTime dataInicial = new DateTime(dataFinal.Year, dataFinal.Month, 1);

                tBoxDataInicial.Text = dataInicial.ToString();
                tBoxDataFinal.Text = dataFinal.ToString();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao obter data inicial e data final", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);

            if (SessaoSistema.UserPermission.Substring(30, 1) == "S" && cBoxSituacao.SelectedIndex == 0)
            {
                btnExcluir.Enabled = true;
            }
            else
            {
                btnExcluir.Enabled = false;
            }
        }

        private void dGridManutencoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVisualizar_Click(sender, e);
        }

        private void frmManutencaoConsultar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    btnVisualizar_Click(sender, e);
                    break;
                case Keys.F5:
                    btnBuscar_Click(sender, e);
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                btnImprimirConsulta_Click(sender, e);
            }
            if (SessaoSistema.UserPermission.Substring(9, 1) == "S" && cBoxSituacao.SelectedIndex == 0 && e.KeyCode == Keys.Delete)
            {
                btnExcluir_Click(sender, e);
            }
        }

        private void cBoxTipoBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxTipoBusca.SelectedIndex == 0)
            {
                CarregaTabelaManutencoes();

                gBoxVeiculo.Visible = false;
                gBoxFuncionario.Visible = false;
                gBoxLocalManutencao.Visible = false;
                gBoxTipoManutencao.Visible = false;
                gBoxUsuario.Visible = false;
                gBoxDataManutencao.Visible = false;
            }
            //busca por Data da Manutenção
            else if (cBoxTipoBusca.SelectedIndex == 1)
            {
                gBoxVeiculo.Visible = false;
                gBoxFuncionario.Visible = false;
                gBoxLocalManutencao.Visible = false;
                gBoxTipoManutencao.Visible = false;
                gBoxUsuario.Visible = false;

                gBoxDataManutencao.Visible = true;

                dGridManutencoes.DataSource = null;
            }
            //busca por Veículo
            else if (cBoxTipoBusca.SelectedIndex == 2)
            {
                gBoxFuncionario.Visible = false;
                gBoxLocalManutencao.Visible = false;
                gBoxTipoManutencao.Visible = false;
                gBoxUsuario.Visible = false;

                gBoxVeiculo.Visible = true;
                gBoxDataManutencao.Visible = true;

                dGridManutencoes.DataSource = null;
            }
            //busca por Tipo da Manutenção
            else if (cBoxTipoBusca.SelectedIndex == 3)
            {
                gBoxVeiculo.Visible = false;
                gBoxFuncionario.Visible = false;
                gBoxLocalManutencao.Visible = false;
                gBoxUsuario.Visible = false;

                gBoxTipoManutencao.Visible = true;
                gBoxDataManutencao.Visible = true;

                cBoxTipoManutencao.Select();

                dGridManutencoes.DataSource = null;
            }
            //busca por Local da Manutenção
            else if (cBoxTipoBusca.SelectedIndex == 4)
            {
                gBoxVeiculo.Visible = false;
                gBoxFuncionario.Visible = false;
                gBoxTipoManutencao.Visible = false;
                gBoxUsuario.Visible = false;

                gBoxLocalManutencao.Visible = true;
                gBoxDataManutencao.Visible = true;

                dGridManutencoes.DataSource = null;
            }
            //busca por Funcionário
            else if (cBoxTipoBusca.SelectedIndex == 5)
            {
                gBoxVeiculo.Visible = false;
                gBoxLocalManutencao.Visible = false;
                gBoxTipoManutencao.Visible = false;
                gBoxUsuario.Visible = false;

                gBoxFuncionario.Visible = true;
                gBoxDataManutencao.Visible = true;

                dGridManutencoes.DataSource = null;
            }
            //busca por usuário
            else if (cBoxTipoBusca.SelectedIndex == 6)
            {
                gBoxVeiculo.Visible = false;
                gBoxLocalManutencao.Visible = false;
                gBoxTipoManutencao.Visible = false;
                gBoxFuncionario.Visible = false;

                gBoxUsuario.Visible = true;
                gBoxDataManutencao.Visible = true;

                dGridManutencoes.DataSource = null;
            }
        }

        #endregion

        #region Buttons

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();
                string registroExcluido;

                if (cBoxSituacao.SelectedIndex == 0)
                {
                    registroExcluido = "N";
                    btnExcluir.Enabled = true;
                }
                else
                {
                    registroExcluido = "S";
                    btnExcluir.Enabled = false;
                }

                string tipoBusca = string.Empty;

                //busca por Data da Manutenção
                if (cBoxTipoBusca.SelectedIndex == 1)
                {
                    tipoBusca = $"data_manutencao BETWEEN '{tBoxDataInicial.Text}' AND '{tBoxDataFinal.Text}'";
                }
                //busca por Veículo
                else if (cBoxTipoBusca.SelectedIndex == 2)
                {
                    tipoBusca = $"mv.id_veiculo = {cBoxVeiculo.SelectedValue} AND data_manutencao BETWEEN '{tBoxDataInicial.Text}' AND '{tBoxDataFinal.Text}'";
                }
                //busca por Tipo da Manutenção
                else if (cBoxTipoBusca.SelectedIndex == 3)
                {
                    tipoBusca = $"mv.id_manutencao_tipo = {cBoxTipoManutencao.SelectedValue} AND data_manutencao BETWEEN '{tBoxDataInicial.Text}' AND '{tBoxDataFinal.Text}'";
                }
                //busca por Local da Manutenção
                else if (cBoxTipoBusca.SelectedIndex == 4)
                {
                    tipoBusca = $"mv.id_manutencao_local = {cBoxLocalManutencao.SelectedValue} AND data_manutencao BETWEEN '{tBoxDataInicial.Text}' AND '{tBoxDataFinal.Text}'";
                }
                //busca por Funcionário
                else if (cBoxTipoBusca.SelectedIndex == 5)
                {
                    tipoBusca = $"mv.id_funcionario = {cBoxFuncionario.SelectedValue} AND data_manutencao BETWEEN '{tBoxDataInicial.Text}' AND '{tBoxDataFinal.Text}'";
                }
                //busca por usuário
                else if (cBoxTipoBusca.SelectedIndex == 6)
                {
                    tipoBusca = $"mv.id_usuario_cadastro = {cBoxUsuario.SelectedValue} AND data_manutencao BETWEEN '{tBoxDataInicial.Text}' AND '{tBoxDataFinal.Text}'";
                }

                if (cBoxTipoBusca.SelectedIndex != 0)
                {
                    NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT mv.id_manutencao, v.id_veiculo, mv.data_manutencao, v.placa, CAST(CASE WHEN tv.descricao = 'CARRO' THEN v.descricao WHEN v.ativo = 'N' AND tv.descricao = 'MOTO' THEN tv.descricao || ' ' || v.codigo || ' >>> REGISTRO INATIVO <<<' WHEN v.ativo = 'N' AND tv.descricao = 'CARRO' THEN v.descricao || ' >>> REGISTRO INATIVO <<<'  ELSE tv.descricao || ' ' || v.codigo END AS VARCHAR) AS veiculo, mv.km_veiculo, MAX(kmd.km_veiculo) AS km_atual, CAST(MAX(kmd.km_veiculo) - mv.km_veiculo AS numeric) AS km_rodado, tm.descricao AS descricao_tipo_manutencao, lm.descricao AS descricao_local_manutencao, CAST(CASE WHEN id_funcionario_cargo = 1 THEN codigo || ' - ' || qra_ase ELSE nome END AS VARCHAR) AS qra, CAST(CASE WHEN mv.registro_excluido = 'N' THEN 'Confirmada' ELSE 'Excluída' END AS VARCHAR) AS situacao, mv.valor_total AS valor_total_manutencao FROM manutencao AS mv INNER JOIN veiculo AS v ON(mv.id_veiculo = v.id_veiculo) INNER JOIN manutencao_tipo AS tm ON(mv.id_manutencao_tipo = tm.id_manutencao_tipo) INNER JOIN manutencao_local AS lm ON(mv.id_manutencao_local = lm.id_manutencao_local) INNER JOIN funcionario AS f ON(mv.id_funcionario = f.id_funcionario) INNER JOIN veiculo_tipo AS tv ON(v.id_veiculo_tipo = tv.id_veiculo_tipo) INNER JOIN km_diario AS kmd ON(kmd.id_veiculo = v.id_veiculo) WHERE {tipoBusca} AND mv.confirmada = 'S' AND mv.registro_excluido = '{registroExcluido}' GROUP BY mv.id_manutencao, tv.descricao, v.id_veiculo, v.descricao, v.placa, v.codigo, tm.descricao, lm.descricao, f.id_funcionario_cargo, f.codigo_ase, f.qra_ase, f.nome ORDER BY mv.data_manutencao DESC", BD.ObjetoConexao);
                    DataTable dp = new DataTable();
                    retornoBD.Fill(dp);
                    dGridManutencoes.DataSource = dp;

                    tBoxValorTotal.Text = dGridManutencoes.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[valor_total_manutencao.Name].Value ?? 0)).ToString("C");
                }
                else
                {
                    CarregaTabelaManutencoes();
                }
        }
            catch
            {
                tBoxValorTotal.Text = "R$0,00";
            }
            finally
            {
                dGridManutencoes.Columns["id_manutencao"].Visible = false;
                dGridManutencoes.Columns["id_veiculo"].Visible = false;

                dGridManutencoes.Columns["data_manutencao"].HeaderText = "Data da Manutenção";
                dGridManutencoes.Columns["placa"].HeaderText = "Placa";
                dGridManutencoes.Columns["veiculo"].HeaderText = "Veículo";
                dGridManutencoes.Columns["km_veiculo"].HeaderText = "Km da Manutenção";
                dGridManutencoes.Columns["km_atual"].HeaderText = "Km Atual";
                dGridManutencoes.Columns["km_rodado"].HeaderText = "Km Rodado";
                dGridManutencoes.Columns["descricao_tipo_manutencao"].HeaderText = "Tipo da Manutenção";
                dGridManutencoes.Columns["descricao_local_manutencao"].HeaderText = "Local da Manutenção";
                dGridManutencoes.Columns["qra"].HeaderText = "Funcionário";
                dGridManutencoes.Columns["situacao"].HeaderText = "Situação";
                dGridManutencoes.Columns["valor_total_manutencao"].HeaderText = "Valor da Manutenção";

                dGridManutencoes.Columns["data_manutencao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dGridManutencoes.Columns["km_veiculo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dGridManutencoes.Columns["km_atual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dGridManutencoes.Columns["km_rodado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dGridManutencoes.Columns["situacao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dGridManutencoes.Columns["valor_total_manutencao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dGridManutencoes.Columns["valor_total_manutencao"].DefaultCellStyle.Format = "C2";

                tBoxQtdRegistros.Text = dGridManutencoes.RowCount.ToString();
                BD.Desconectar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string _idRegistroSelecionado = dGridManutencoes.SelectedRows[0].Cells[0].Value.ToString();
                string tipoManutencaoSelecionada = dGridManutencoes.SelectedRows[0].Cells["descricao_tipo_manutencao"].Value.ToString();
                string kmVeiculo = dGridManutencoes.SelectedRows[0].Cells["km_veiculo"].Value.ToString();
                string idVeiculo = dGridManutencoes.SelectedRows[0].Cells["id_veiculo"].Value.ToString();

                frmManutencaoMotivoExcluir frmManutencaoMotivoExcluir = new frmManutencaoMotivoExcluir(Convert.ToInt32(_idRegistroSelecionado));
                frmManutencaoMotivoExcluir.Owner = this;
                frmManutencaoMotivoExcluir.ShowInTaskbar = false;
                frmManutencaoMotivoExcluir.ShowDialog();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao excluir registro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string _idRegistroSelecionado = dGridManutencoes.SelectedRows[0].Cells[0].Value.ToString();
                frmManutencaoDetalhadaVeiculo frmManutencaoDetalhadaVeiculo = new frmManutencaoDetalhadaVeiculo(Convert.ToInt32(_idRegistroSelecionado));
                frmManutencaoDetalhadaVeiculo.ShowInTaskbar = false;
                frmManutencaoDetalhadaVeiculo.ShowDialog();
            }
            catch
            {
            }
        }

        private void btnImprimirConsulta_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

    }
}