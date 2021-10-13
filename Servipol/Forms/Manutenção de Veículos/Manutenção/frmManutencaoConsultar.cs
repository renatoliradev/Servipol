using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
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
                CarregaTabelaManutencoes();
                //btnBuscar_Click(sender, e);
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
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT mv.id_manutencao, mv.data_manutencao, mv.km_veiculo, MAX(kmd.km_veiculo) AS km_atual, CAST(MAX(kmd.km_veiculo) - mv.km_veiculo AS numeric) AS km_rodado, v.id_veiculo AS id_veiculo, v.placa, CAST(CASE WHEN tv.descricao = 'CARRO' THEN v.descricao WHEN v.ativo = 'N' AND tv.descricao = 'MOTO' THEN tv.descricao || ' ' || v.codigo || ' >>> REGISTRO INATIVO <<<' WHEN v.ativo = 'N' AND tv.descricao = 'CARRO' THEN v.descricao || ' >>> REGISTRO INATIVO <<<'  ELSE tv.descricao || ' ' || v.codigo END AS VARCHAR) AS veiculo, tm.descricao, lm.descricao, mv.valor_total, CAST(CASE WHEN id_funcionario_cargo = 1 THEN codigo || ' - ' || qra_ase ELSE nome END AS VARCHAR) AS qra, CAST(CASE WHEN mv.registro_excluido = 'N' THEN 'Confirmada' ELSE 'Excluída' END AS VARCHAR) AS situacao FROM manutencao AS mv INNER JOIN veiculo AS v ON(mv.id_veiculo = v.id_veiculo) INNER JOIN manutencao_tipo AS tm ON(mv.id_manutencao_tipo = tm.id_manutencao_tipo) INNER JOIN manutencao_local AS lm ON(mv.id_manutencao_local = lm.id_manutencao_local) INNER JOIN funcionario AS f ON(mv.id_funcionario = f.id_funcionario) INNER JOIN veiculo_tipo AS tv ON(v.tipo = tv.id_veiculo_tipo) INNER JOIN km_diario AS kmd ON(kmd.id_veiculo = v.id_veiculo) WHERE mv.confirmada = '{registroExcluido}' AND mv.registro_excluido = 'N' GROUP BY mv.id_manutencao, tv.descricao, v.id_veiculo, v.descricao, v.placa, v.codigo, tm.descricao, lm.descricao, f.id_funcionario_cargo, f.codigo_ase, f.qra_ase, f.nome ORDER BY 1 DESC LIMIT 20", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridManutencoes.DataSource = dp;

                string valor_total = string.Empty;
                NpgsqlCommand com = new NpgsqlCommand($"SELECT SUM(mv.valor_total) AS valor_total FROM manutencao AS mv WHERE mv.confirmada = '{registroExcluido}' AND mv.id_manutencao IN (SELECT id_manutencao FROM manutencao WHERE registro_excluido = '{registroExcluido}' ORDER BY 1 DESC LIMIT 20)", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        valor_total = dr["valor_total"].ToString();
                    }
                    tBoxValorTotal.Text = Convert.ToDouble(valor_total).ToString("C");
                }
            }
            catch
            {
                tBoxValorTotal.Text = "R$0,00";
            }
            finally
            {
                tBoxQtdRegistros.Text = dGridManutencoes.RowCount.ToString();
                BD.Desconectar();
            }
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
                com.CommandText = $"SELECT v.id_veiculo, CAST(CASE WHEN v.ativo = 'N' AND tv.descricao = 'MOTO' THEN tv.descricao || ' ' || v.codigo || ' - [' || v.placa || '] >>> REGISTRO INATIVO <<<' WHEN v.ativo = 'N' AND tv.descricao = 'CARRO' THEN v.descricao || ' - [' || v.placa || '] >>> REGISTRO INATIVO <<<'  ELSE tv.descricao || ' ' || v.codigo || ' - [' || v.placa || ']' END AS VARCHAR) AS veiculo FROM veiculo AS v JOIN veiculo_tipo AS tv ON(tv.id_veiculo_tipo = v.tipo) ORDER BY v.tipo DESC, v.codigo ASC";
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

            if (cBoxSituacao.SelectedIndex == 1)
            {
                btnExcluir.Enabled = false;
            }
            else
            {
                btnExcluir.Enabled = true;
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
            if (cBoxSituacao.SelectedIndex == 0 && e.KeyCode == Keys.Delete)
            {
                btnExcluir_Click(sender, e);
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
                    tipoBusca = "data_manutencao BETWEEN '" + tBoxDataInicial.Text + "' AND '" + tBoxDataFinal.Text + "'";
                }
                //busca por Veículo
                else if (cBoxTipoBusca.SelectedIndex == 2)
                {
                    tipoBusca = "mv.id_veiculo = " + cBoxVeiculo.SelectedValue + " AND data_manutencao BETWEEN '" + tBoxDataInicial.Text + "' AND '" + tBoxDataFinal.Text + "'";
                }
                //busca por Tipo da Manutenção
                else if (cBoxTipoBusca.SelectedIndex == 3)
                {
                    tipoBusca = "mv.id_tipo_manutencao = " + cBoxTipoManutencao.SelectedValue + " AND data_manutencao BETWEEN '" + tBoxDataInicial.Text + "' AND '" + tBoxDataFinal.Text + "'";
                }
                //busca por Local da Manutenção
                else if (cBoxTipoBusca.SelectedIndex == 4)
                {
                    tipoBusca = "mv.local_manutencao = " + cBoxLocalManutencao.SelectedValue + " AND data_manutencao BETWEEN '" + tBoxDataInicial.Text + "' AND '" + tBoxDataFinal.Text + "'";
                }
                //busca por Funcionário
                else if (cBoxTipoBusca.SelectedIndex == 5)
                {
                    tipoBusca = "mv.id_funcionario = " + cBoxFuncionario.SelectedValue + " AND data_manutencao BETWEEN '" + tBoxDataInicial.Text + "' AND '" + tBoxDataFinal.Text + "'";
                }
                //busca por usuário
                else if (cBoxTipoBusca.SelectedIndex == 6)
                {
                    tipoBusca = "mv.id_usuario_cadastro = " + cBoxUsuario.SelectedValue + " AND data_manutencao BETWEEN '" + tBoxDataInicial.Text + "' AND '" + tBoxDataFinal.Text + "'";
                }

                if (cBoxTipoBusca.SelectedIndex != 0)
                {
                    NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter("SELECT mv.id, mv.data_manutencao, mv.km_veiculo, MAX(kmd.km_veiculo) AS km_atual, CAST(MAX(kmd.km_veiculo) - mv.km_veiculo AS numeric) AS km_rodado, v.id AS id_veiculo, v.placa, CAST(CASE WHEN tv.descricao = 'CARRO' THEN v.descricao_veiculo WHEN v.ativo = 'N' AND tv.descricao = 'MOTO' THEN tv.descricao || ' ' || v.codigo_veiculo || ' >>> REGISTRO INATIVO <<<' WHEN v.ativo = 'N' AND tv.descricao = 'CARRO' THEN v.descricao_veiculo || ' >>> REGISTRO INATIVO <<<'  ELSE tv.descricao || ' ' || v.codigo_veiculo END AS VARCHAR) AS veiculo, tm.descricao_manutencao, lm.descricao, mv.valor_total_manutencao, CAST(CASE WHEN id_tipo_funcionario = 1 THEN codigo || ' - ' || qra ELSE nome END AS VARCHAR) AS qra, CAST(CASE WHEN mv.registro_excluido = 'N' THEN 'Confirmada' ELSE 'Excluída' END AS VARCHAR) AS situacao FROM manutencao_veiculo AS mv INNER JOIN veiculos AS v ON(mv.id_veiculo = v.id) INNER JOIN tipo_manutencao AS tm ON(mv.id_tipo_manutencao = tm.id_tipo_manutencao) INNER JOIN local_manutencao AS lm ON(mv.local_manutencao = lm.id_local_manutencao) INNER JOIN funcionarios AS f ON(mv.id_funcionario = f.id) INNER JOIN tipo_veiculo AS tv ON(v.tipo_veiculo = tv.id) INNER JOIN km_diario AS kmd ON(kmd.id_veiculo = v.id) WHERE " + tipoBusca + " AND mv.confirmada = 'S' AND mv.registro_excluido = '" + registroExcluido + "' GROUP BY mv.id, tv.descricao, v.id, v.descricao_veiculo, v.placa, v.codigo_veiculo, tm.descricao_manutencao, lm.descricao, f.id_tipo_funcionario, f.codigo, f.qra, f.nome ORDER BY v.tipo_veiculo DESC, v.codigo_veiculo ASC, mv.data_manutencao DESC", BD.ObjetoConexao);
                    DataTable dp = new DataTable();
                    retornoBD.Fill(dp);
                    dGridManutencoes.DataSource = dp;

                    string valor_total = string.Empty;
                    NpgsqlCommand com = new NpgsqlCommand("SELECT SUM(mv.valor_total_manutencao) AS valor_total FROM manutencao_veiculo AS mv WHERE " + tipoBusca + " AND mv.confirmada = 'S' AND mv.registro_excluido = '" + registroExcluido + "'", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            valor_total = dr["valor_total"].ToString();
                        }
                        tBoxValorTotal.Text = Convert.ToDouble(valor_total).ToString("C");
                    }
                }
                else
                {
                    CarregaTabelaManutencoes();
                }
            }
            catch
            {
                tBoxValorTotal.Text = "R$ 0,00";
            }
            finally
            {
                tBoxQtdRegistros.Text = dGridManutencoes.RowCount.ToString();
                BD.Desconectar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimirConsulta_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}