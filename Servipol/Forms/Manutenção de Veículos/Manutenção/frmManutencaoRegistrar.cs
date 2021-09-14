using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    public partial class frmManutencaoRegistrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public string TipoVeiculo { get; set; }
        public int UltimoKmServico { get; set; }
        public string UltimaDataServico { get; set; }
        public string DescricaoManutencao { get; set; }
        public string ExigeKmTrocaOleo { get; set; }
        public string KmJaRegistrado { get; set; }
        public int ExisteManutencaoNaoConfirmada { get; set; }
        #endregion

        public frmManutencaoRegistrar()
        {
            InitializeComponent();
        }

        private void frmManutencaoRegistrar_Load(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();

                CarregaVeiculo();
                CarregaFuncionario();
                CarregaLocalManutencao();
                CarregaTabelaPreRegistroManutencao();
                LimparCampos();

                if (ExisteManutencaoNaoConfirmada > 0)
                {
                    XtraMessageBox.Show("Existem manutenções que foram incluídas porém não foram confirmadas. Os registros serão carregados novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                tBoxDataManutencao.Value = DateTime.Now;
            }
            finally
            {

            }
        }

        #region Methods

        public void CarregaTabelaPreRegistroManutencao()
        {
            try
            {
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT mv.id_manutencao AS pre_id_manutencao_veiculo, mv.id_veiculo AS pre_id_veiculo, mv.data_manutencao AS pre_data_manutencao, v.placa AS pre_placa, mv.km_veiculo AS pre_km_manutencao, CAST(CASE WHEN tv.descricao = 'Carro' THEN v.descricao WHEN v.ativo = 'N' AND tv.descricao = 'Moto' THEN tv.descricao || ' ' || v.codigo || ' >>> REGISTRO INATIVO <<<' WHEN v.ativo = 'N' AND tv.descricao = 'Carro' THEN v.descricao || ' >>> REGISTRO INATIVO <<<'  ELSE tv.descricao || ' ' || v.codigo END AS VARCHAR) AS pre_veiculo, tm.descricao AS pre_tipo_manutencao, lm.descricao AS pre_local_manutencao, mv.valor_peca AS pre_valor_produto, mv.valor_servico AS pre_valor_servico, mv.valor_desconto AS pre_valor_desconto, mv.valor_acrescimo AS pre_valor_acrescimo, mv.valor_total AS pre_total_manutencao, CAST(CASE WHEN id_funcionario_cargo = 1 THEN codigo || ' - ' || qra_ase ELSE nome END AS VARCHAR) AS pre_funcionario_manutencao FROM manutencao AS mv INNER JOIN veiculo AS v ON(mv.id_veiculo = v.id_veiculo) INNER JOIN manutencao_tipo AS tm ON(mv.id_manutencao_tipo = tm.id_manutencao_tipo) INNER JOIN manutencao_local AS lm ON(mv.id_manutencao_local = lm.id_manutencao_local) INNER JOIN funcionario AS f ON(mv.id_funcionario = f.id_funcionario) INNER JOIN veiculo_tipo AS tv ON(v.tipo = tv.id_veiculo_tipo) WHERE mv.confirmada = 'N' GROUP BY mv.id_manutencao, tv.descricao, v.id_veiculo, v.descricao, v.placa, v.codigo, tm.descricao, lm.descricao, f.id_funcionario_cargo, f.codigo_ase, f.qra_ase, f.nome ORDER BY v.tipo DESC, v.codigo ASC, mv.id_manutencao ASC", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridPreRegistroManutencao.DataSource = dp;
                dGridPreRegistroManutencao.ClearSelection();

                ExisteManutencaoNaoConfirmada = Convert.ToInt32(dGridPreRegistroManutencao.RowCount.ToString());
            }
            catch { }
        }

        public void CarregaFuncionario()
        {
            try
            {
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = "SELECT id_funcionario, CAST(CASE WHEN id_funcionario_cargo = 1 THEN codigo_ase || ' - ' || qra_ase ELSE nome END AS VARCHAR) AS nome FROM funcionario WHERE ativo = 'S' ORDER BY id_funcionario_cargo, codigo_ase ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxFuncionario.ValueMember = "id_funcionario";
                cBoxFuncionario.DisplayMember = "nome";
                cBoxFuncionario.DataSource = dt;
            }
            finally
            {
                cBoxFuncionario.SelectedIndex = -1;
            }
        }

        public void CarregaVeiculo()
        {
            try
            {
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT v.id_veiculo, CAST(CASE WHEN vt.descricao = 'CARRO' THEN v.descricao || ' ' || v.placa ELSE vt.descricao || ' ' || v.codigo END AS VARCHAR) AS veiculo FROM veiculo AS v JOIN veiculo_tipo AS vt ON(vt.id_veiculo_tipo = v.tipo) WHERE v.ativo = 'S' AND tipo != 3 ORDER BY  v.tipo DESC, v.codigo ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxVeiculo.ValueMember = "id_veiculo";
                cBoxVeiculo.DisplayMember = "veiculo";
                cBoxVeiculo.DataSource = dt;
            }
            finally
            {
                cBoxVeiculo.SelectedIndex = -1;
            }
        }

        public void CarregaDadosVeiculo()
        {
            try
            {
                if (cBoxVeiculo.SelectedIndex != -1)
                {
                    #region DECLARACAO DE VARIAVEIS
                    string CDV_descricao_veiculo = string.Empty, CDV_placa = string.Empty, CDV_km_ultima_troca_oleo_motor = string.Empty, CDV_data_ultima_troca_oleo_motor = string.Empty, CDV_km_diario = string.Empty, CDV_veiculo_tipo = string.Empty;
                    #endregion

                    NpgsqlCommand com = new NpgsqlCommand($"SELECT v.descricao, v.placa, v.tipo FROM veiculo AS v WHERE v.id_veiculo = {cBoxVeiculo.SelectedValue}", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CDV_descricao_veiculo = dr["descricao"].ToString();
                            CDV_placa = dr["placa"].ToString();
                            CDV_veiculo_tipo = dr["tipo"].ToString();
                        }
                        labelDescricao.Text = CDV_descricao_veiculo;
                        labelPlaca.Text = CDV_placa;

                        switch (CDV_veiculo_tipo)
                        {
                            case "1":
                                TipoVeiculo = "CARRO";
                                break;
                            case "2":
                                TipoVeiculo = "MOTO";
                                break;
                        }
                    }

                    NpgsqlCommand com2 = new NpgsqlCommand($"SELECT MAX(km_veiculo) AS ultimo_km_troca_oleo, MAX(TO_CHAR(data_manutencao, 'DD/MM/YYYY')) AS data_ultima_troca FROM manutencao WHERE id_manutencao_tipo = 1 AND id_veiculo = {cBoxVeiculo.SelectedValue} AND registro_excluido = 'N'", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr2 = com2.ExecuteReader())
                    {
                        while (dr2.Read())
                        {
                            CDV_km_ultima_troca_oleo_motor = dr2["ultimo_km_troca_oleo"].ToString();
                            CDV_data_ultima_troca_oleo_motor = dr2["data_ultima_troca"].ToString();
                        }
                        labelDataUltimaTrocaOleo.Text = CDV_data_ultima_troca_oleo_motor;
                        labelUltimoKM.Text = CDV_km_ultima_troca_oleo_motor;
                    }

                    NpgsqlCommand com3 = new NpgsqlCommand($"SELECT km_veiculo FROM km_diario WHERE id_veiculo = {cBoxVeiculo.SelectedValue} AND data_km_diario = CURRENT_DATE", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr3 = com3.ExecuteReader())
                    {
                        while (dr3.Read())
                        {
                            CDV_km_diario = dr3["km_veiculo"].ToString();
                        }

                        if (!string.IsNullOrEmpty(CDV_km_diario))
                        {
                            tBoxKmAtual.Text = CDV_km_diario;
                        }
                        else
                        {
                            tBoxKmAtual.Text = string.Empty;
                        }
                        tBoxKmAtual.SelectAll();
                    }
                }
            }
            finally { }
        }

        public void CarregaTipoManutencao()
        {
            try
            {
                if (TipoVeiculo == "MOTO")
                {
                    NpgsqlCommand com = new NpgsqlCommand();
                    com.Connection = BD.ObjetoConexao;
                    com.CommandText = $"SELECT id_manutencao_tipo, descricao, ordem FROM manutencao_tipo WHERE ativo = 'S' AND aplicacao_moto = 'S' ORDER BY 3 ASC";
                    NpgsqlDataReader dr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cBoxTipoManutencao.ValueMember = "id_manutencao_tipo";
                    cBoxTipoManutencao.DisplayMember = "descricao";
                    cBoxTipoManutencao.DataSource = dt;
                }
                else if (TipoVeiculo == "CARRO")
                {
                    NpgsqlCommand com = new NpgsqlCommand();
                    com.Connection = BD.ObjetoConexao;
                    com.CommandText = $"SELECT id_manutencao_tipo, descricao, ordem FROM manutencao_tipo WHERE ativo = 'S' AND aplicacao_carro = 'S' ORDER BY 3 ASC";
                    NpgsqlDataReader dr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cBoxTipoManutencao.ValueMember = "id_manutencao_tipo";
                    cBoxTipoManutencao.DisplayMember = "descricao";
                    cBoxTipoManutencao.DataSource = dt;
                }
            }
            finally
            {
                cBoxTipoManutencao.SelectedIndex = -1;
            }
        }

        public void VerificaTipoManutencao()
        {
            try
            {
                #region Variáveis
                string descricao_manutencao = string.Empty, exige_km_troca_oleo = string.Empty, validade_km_troca_oleo_carro = string.Empty, validade_km_troca_oleo_moto = string.Empty;
                #endregion

                NpgsqlCommand com = new NpgsqlCommand($"SELECT mt.descricao, mt.exige_km_validade_oleo, mt.km_validade_oleo_carro, mt.km_validade_oleo_moto FROM manutencao_tipo AS mt WHERE mt.id_manutencao_tipo = {cBoxTipoManutencao.SelectedValue}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        descricao_manutencao = dr["descricao"].ToString();
                        exige_km_troca_oleo = dr["exige_km_validade_oleo"].ToString();
                        validade_km_troca_oleo_carro = dr["km_validade_oleo_carro"].ToString();
                        validade_km_troca_oleo_moto = dr["km_validade_oleo_moto"].ToString();
                    }
                    DescricaoManutencao = descricao_manutencao;
                    ExigeKmTrocaOleo = exige_km_troca_oleo;

                    if (ExigeKmTrocaOleo == "S")
                    {
                        cBoxKmValidadeOleo.Enabled = true;

                        if (TipoVeiculo == "CARRO")
                        {
                            cBoxKmValidadeOleo.SelectedItem = validade_km_troca_oleo_carro;
                        }
                        else if (TipoVeiculo == "MOTO")
                        {
                            cBoxKmValidadeOleo.SelectedItem = validade_km_troca_oleo_moto;
                        }
                    }
                    else
                    {
                        cBoxKmValidadeOleo.SelectedIndex = -1;
                        cBoxKmValidadeOleo.Enabled = false;
                    }
                }
            }
            finally
            { }
        }

        public void CarregaLocalManutencao()
        {
            try
            {
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id_manutencao_local, descricao FROM manutencao_local WHERE posto_combustivel = 'N' AND ativo = 'S' ORDER BY 2 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxLocalManutencao.ValueMember = "id_manutencao_local";
                cBoxLocalManutencao.DisplayMember = "descricao";
                cBoxLocalManutencao.DataSource = dt;
            }
            finally
            {
                cBoxLocalManutencao.SelectedIndex = -1;
            }
        }

        public void VerificaUltimoKmServico()
        {
            try
            {
                #region Variáveis
                string ultimo_km_servico = string.Empty, ultima_data_servico = string.Empty;
                #endregion

                NpgsqlCommand com = new NpgsqlCommand($"SELECT MAX(km_veiculo) AS ultimo_km_servico, MAX(TO_CHAR(data_manutencao, 'DD/MM/YYYY')) AS data_manutencao FROM manutencao WHERE id_manutencao_tipo = {cBoxTipoManutencao.SelectedValue} AND id_veiculo = {cBoxVeiculo.SelectedValue} AND registro_excluido = 'N'", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ultimo_km_servico = dr["ultimo_km_servico"].ToString();
                        ultima_data_servico = dr["data_manutencao"].ToString();
                    }

                    if (ultimo_km_servico != null)
                    {
                        UltimoKmServico = Convert.ToInt32(ultimo_km_servico);
                    }
                    else
                    {
                        UltimoKmServico = 0;
                    }

                    UltimaDataServico = ultima_data_servico;
                }
            }
            catch { }
        }

        public void CalculaValorManutencao()
        {
            try
            {
                double valorPeca = Convert.ToDouble(tBoxValorPeca.Text.Replace("R$", ""));
                double valorServico = Convert.ToDouble(tBoxValorServico.Text.Replace("R$", ""));
                double valorDesconto = Convert.ToDouble(tBoxDesconto.Text.Replace("R$", ""));
                double valorAcrescimo = Convert.ToDouble(tBoxAcrescimo.Text.Replace("R$", ""));
                double valorTotalManutencao = Convert.ToDouble(tBoxValorTotal.Text.Replace("R$", ""));

                valorTotalManutencao = valorPeca + valorServico - valorDesconto + valorAcrescimo;

                tBoxValorTotal.Text = valorTotalManutencao.ToString("C");

            }
            catch { }
        }

        private bool ValidaCampos()
        {
            if (cBoxVeiculo.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Selecione o [Veículo].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxVeiculo.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(tBoxKmAtual.Text))
            {
                XtraMessageBox.Show("Informe o [KM Atual] do veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxKmAtual.Focus();
                return false;
            }
            else if (cBoxFuncionario.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Selecione o [funcionário que fez o serviço]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxFuncionario.Focus();
                return false;
            }
            else if (cBoxLocalManutencao.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Selecione o [Local da Manutenção]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxLocalManutencao.Focus();
                return false;
            }
            else if (cBoxTipoManutencao.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Selecione o [Tipo da Manutenção]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxTipoManutencao.Focus();
                return false;
            }
            else if (UltimoKmServico > Convert.ToInt32(tBoxKmAtual.Text))
            {
                XtraMessageBox.Show($"O Km Atual é menor que o último Km informado para este veículo e serviço!\n\nDescrição do serviço: {DescricaoManutencao}\nData do serviço: {UltimaDataServico}\nKm informado para o serviço: {UltimoKmServico}\n\nKm Atual informado: {tBoxKmAtual.Text}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxKmAtual.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LimparCampos()
        {
            cBoxVeiculo.SelectedIndex = -1;
            labelDescricao.Text = null;
            labelPlaca.Text = null;
            labelDataUltimaTrocaOleo.Text = null;
            labelUltimoKM.Text = null;
            tBoxObservacaoManutencao.Clear();
            tBoxDataManutencao.Value = DateTime.Now;
            tBoxKmAtual.Clear();
            cBoxFuncionario.SelectedIndex = -1;
            cBoxLocalManutencao.SelectedIndex = -1;
            cBoxTipoManutencao.SelectedIndex = -1;
            tBoxValorPeca.Text = "R$ 0,00";
            tBoxValorServico.Text = "R$ 0,00";
            tBoxDesconto.Text = "R$ 0,00";
            tBoxAcrescimo.Text = "R$ 0,00";
            tBoxValorTotal.Text = "R$ 0,00";
        }

        private void cBoxTipoManutencao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxTipoManutencao.SelectedIndex != -1)
            {
                VerificaTipoManutencao();
            }
        }

        private void cBoxVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cBoxVeiculo.SelectedIndex != -1)
                {
                    labelDataUltimaTrocaOleo.Text = null;
                    labelUltimoKM.Text = null;
                    CarregaDadosVeiculo();
                    CarregaTipoManutencao();
                }
            }
            finally
            {
                tBoxKmAtual.Focus();
            }
        }

        private void frmManutencaoRegistrar_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && ExisteManutencaoNaoConfirmada > 0)
            {
                var result = XtraMessageBox.Show("Existem registros pendentes de confirmação!\nOs registros ficarão pendentes e serão carregados automaticamente quando essa tela for reaberta. \n\nDeseja fechar essa tela ? ", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    BD.Desconectar();
                    //memoryManagement.FlushMemory();
                    LimparCampos();
                }
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                LimparCampos();
            }
        }

        public void AproveitarDadosBasicos()
        {
            cBoxTipoManutencao.SelectedIndex = -1;
            cBoxKmValidadeOleo.SelectedIndex = -1;
            tBoxObservacaoManutencao.Clear();

            tBoxValorPeca.Text = "R$ 0,00";
            tBoxValorServico.Text = "R$ 0,00";
            tBoxDesconto.Text = "R$ 0,00";
            tBoxAcrescimo.Text = "R$ 0,00";
            tBoxValorTotal.Text = "R$ 0,00";

            gBoxTipoManutencao.Focus();
            cBoxTipoManutencao.Select();
        }

        #endregion

        #region Buttons

        private void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                string idRegistroSelecionadoGrid = dGridPreRegistroManutencao.SelectedRows[0].Cells[0].Value.ToString();
                
                NpgsqlCommand update1 = new NpgsqlCommand($"DELETE FROM manutencao WHERE id_manutencao = {idRegistroSelecionadoGrid}", BD.ObjetoConexao);
                update1.ExecuteNonQuery();

                CarregaTabelaPreRegistroManutencao();
            }
            catch
            {
                XtraMessageBox.Show("Primeiro selecione qual registro deseja cancelar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnIncluirPreRegistro_Click(object sender, EventArgs e)
        {
            VerificaUltimoKmServico();
            CalculaValorManutencao();

            if (!ValidaCampos())
            {
                return;
            }
            else
            {
                double valorPeca = Convert.ToDouble(tBoxValorPeca.Text.Replace("R$", ""));
                double valorServico = Convert.ToDouble(tBoxValorServico.Text.Replace("R$", ""));
                double valorDesconto = Convert.ToDouble(tBoxDesconto.Text.Replace("R$", ""));
                double valorAcrescimo = Convert.ToDouble(tBoxAcrescimo.Text.Replace("R$", ""));
                double valorTotalManutencao = Convert.ToDouble(tBoxValorTotal.Text.Replace("R$", ""));

                int km_validade_oleo = 0;

                if (ExigeKmTrocaOleo == "S")
                {
                    km_validade_oleo = Convert.ToInt32(cBoxKmValidadeOleo.Text);
                }

                if (valorTotalManutencao == 0)
                {
                    if (XtraMessageBox.Show("Não foi informado nenhum valor da manutenção.\n Deseja incluir assim mesmo ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //VERIFICA SE O KM DO DIA JÁ FOI REGISTRADO
                        NpgsqlCommand com4 = new NpgsqlCommand($"SELECT 1 AS km_ja_registrado FROM km_diario WHERE id_veiculo = {cBoxVeiculo.SelectedValue} AND data_km_diario = CURRENT_DATE", BD.ObjetoConexao);
                        using (NpgsqlDataReader dr4 = com4.ExecuteReader())
                        {
                            while (dr4.Read())
                            {
                                KmJaRegistrado = dr4["km_ja_registrado"].ToString();
                            }
                        }

                        if (KmJaRegistrado != "1")
                        {
                            string sqlCommand5 = $"INSERT INTO km_diario VALUES (nextval('seq_km_diario'), {cBoxVeiculo.SelectedValue}, {tBoxKmAtual.Text}, CURRENT_DATE, {SessaoSistema.UsuarioId}, CURRENT_TIMESTAMP)";
                            NpgsqlCommand command5 = new NpgsqlCommand(sqlCommand5, BD.ObjetoConexao);
                            command5.ExecuteNonQuery();
                        }

                        string sqlCommand = $"INSERT INTO manutencao VALUES (nextval('seq_manutencao'), '{tBoxDataManutencao.Value}', '{tBoxObservacaoManutencao.Text.ToUpper().Trim()}', {km_validade_oleo}, {cBoxVeiculo.SelectedValue}, {cBoxTipoManutencao.SelectedValue},  {cBoxLocalManutencao.SelectedValue}, {cBoxFuncionario.SelectedValue}, {SessaoSistema.UsuarioId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, {UltimoKmServico}, {tBoxKmAtual.Text}, {valorPeca.ToString().Replace(",", ".")}, {valorServico.ToString().Replace(",", ".")}, {valorDesconto.ToString().Replace(",", ".")}, {valorAcrescimo.ToString().Replace(",", ".")}, {valorTotalManutencao.ToString().Replace(",", ".")}, 'N', 'N')";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        AproveitarDadosBasicos();
                        CarregaTabelaPreRegistroManutencao();
                    }
                    else
                    {
                        tBoxValorPeca.Select();
                    }
                }
                else
                {
                    //VERIFICA SE O KM DO DIA JÁ FOI REGISTRADO
                    NpgsqlCommand com4 = new NpgsqlCommand($"SELECT 1 AS km_ja_registrado FROM km_diario WHERE id_veiculo = {cBoxVeiculo.SelectedValue} AND data_km_diario = CURRENT_DATE", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr4 = com4.ExecuteReader())
                    {
                        while (dr4.Read())
                        {
                            KmJaRegistrado = dr4["km_ja_registrado"].ToString();
                        }
                    }

                    if (KmJaRegistrado != "1")
                    {
                        string sqlCommand5 = $"INSERT INTO km_diario VALUES (nextval('seq_km_diario'), {cBoxVeiculo.SelectedValue}, {tBoxKmAtual.Text}, CURRENT_DATE, {SessaoSistema.UsuarioId}, CURRENT_TIMESTAMP)";
                        NpgsqlCommand command5 = new NpgsqlCommand(sqlCommand5, BD.ObjetoConexao);
                        command5.ExecuteNonQuery();
                    }

                    string sqlCommand = $"INSERT INTO manutencao VALUES (nextval('seq_manutencao'), '{tBoxDataManutencao.Value}', '{tBoxObservacaoManutencao.Text.ToUpper().Trim()}', {km_validade_oleo}, {cBoxVeiculo.SelectedValue}, {cBoxTipoManutencao.SelectedValue},  {cBoxLocalManutencao.SelectedValue}, {cBoxFuncionario.SelectedValue}, {SessaoSistema.UsuarioId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, {UltimoKmServico}, {tBoxKmAtual.Text}, {valorPeca.ToString().Replace(",", ".")}, {valorServico.ToString().Replace(",", ".")}, {valorDesconto.ToString().Replace(",", ".")}, {valorAcrescimo.ToString().Replace(",", ".")}, {valorTotalManutencao.ToString().Replace(",", ".")}, 'N', 'N')";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    AproveitarDadosBasicos();
                    CarregaTabelaPreRegistroManutencao();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int quantRegistros = Convert.ToInt32(dGridPreRegistroManutencao.RowCount.ToString());

                if (quantRegistros > 0)
                {
                    string sqlCommand = $"UPDATE manutencao SET confirmada = 'S' WHERE confirmada = 'N'";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    XtraMessageBox.Show("Manutenções confirmadas com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregaTabelaPreRegistroManutencao();
                }
                else
                {
                    XtraMessageBox.Show("Não existem manutenções pendentes de confirmação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                XtraMessageBox.Show("Erro ao confirmar manutenções! Tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //XtraMessageBox.Show(err.Message, "Falha no botão 'btnConfirmar_Click'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                
            }
        }

        #endregion

        private void frmManutencaoRegistrar_FormClosed(object sender, FormClosedEventArgs e)
        {
            BD.Desconectar();
            //memoryManagement.FlushMemory();
            LimparCampos();
        }

        private void tBoxValorPeca_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBoxValorServico.Select();
                    break;
            }
        }

        private void tBoxValorServico_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBoxDesconto.Select();
                    break;
            }
        }

        private void tBoxDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBoxAcrescimo.Select();
                    break;
            }
        }

        private void tBoxAcrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnIncluirPreRegistro_Click(sender, e);
                    break;
            }
        }

        private void frmManutencaoRegistrar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F12:
                    btnConfirmar_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void tBoxValorPeca_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxValorPeca.Text.Length - 1; i++)
            {
                if ((tBoxValorPeca.Text[i] >= '0' &&
                    tBoxValorPeca.Text[i] <= '9') ||
                    tBoxValorPeca.Text[i] == ',')
                {
                    x += tBoxValorPeca.Text[i];
                }
            }
            tBoxValorPeca.Text = x;
            tBoxValorPeca.SelectAll();
        }

        private void tBoxValorPeca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               (e.KeyChar != ',' && e.KeyChar != '.' &&
                e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!tBoxValorPeca.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void tBoxValorPeca_Leave(object sender, EventArgs e)
        {
            try
            {
                tBoxValorPeca.Text = Convert.ToDouble(tBoxValorPeca.Text).ToString("C");
                CalculaValorManutencao();
            }
            catch
            {
                tBoxValorPeca.Text = "R$0,00";
            }
        }

        private void tBoxValorPeca_MouseClick(object sender, MouseEventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxValorPeca.Text.Length - 1; i++)
            {
                if ((tBoxValorPeca.Text[i] >= '0' &&
                    tBoxValorPeca.Text[i] <= '9') ||
                    tBoxValorPeca.Text[i] == ',')
                {
                    x += tBoxValorPeca.Text[i];
                }
            }
            tBoxValorPeca.Text = x;
            tBoxValorPeca.SelectAll();
        }

        private void tBoxValorServico_Leave(object sender, EventArgs e)
        {
            try
            {
                tBoxValorServico.Text = Convert.ToDouble(tBoxValorServico.Text).ToString("C");
            }
            catch
            {
                tBoxValorServico.Text = "R$0,00";
            }
        }

        private void tBoxDesconto_Leave(object sender, EventArgs e)
        {
            try
            {
                tBoxDesconto.Text = Convert.ToDouble(tBoxDesconto.Text).ToString("C");
            }
            catch
            {
                tBoxDesconto.Text = "R$0,00";
            }
        }

        private void tBoxAcrescimo_Leave(object sender, EventArgs e)
        {
            try
            {
                tBoxAcrescimo.Text = Convert.ToDouble(tBoxAcrescimo.Text).ToString("C");
            }
            catch
            {
                tBoxAcrescimo.Text = "R$0,00";
            }
        }

        private void tBoxValorServico_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxValorServico.Text.Length - 1; i++)
            {
                if ((tBoxValorServico.Text[i] >= '0' &&
                    tBoxValorServico.Text[i] <= '9') ||
                    tBoxValorServico.Text[i] == ',')
                {
                    x += tBoxValorServico.Text[i];
                }
            }
            tBoxValorServico.Text = x;
            tBoxValorServico.SelectAll();
        }

        private void tBoxDesconto_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxDesconto.Text.Length - 1; i++)
            {
                if ((tBoxDesconto.Text[i] >= '0' &&
                    tBoxDesconto.Text[i] <= '9') ||
                    tBoxDesconto.Text[i] == ',')
                {
                    x += tBoxDesconto.Text[i];
                }
            }
            tBoxDesconto.Text = x;
            tBoxDesconto.SelectAll();
        }

        private void tBoxAcrescimo_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxAcrescimo.Text.Length - 1; i++)
            {
                if ((tBoxAcrescimo.Text[i] >= '0' &&
                    tBoxAcrescimo.Text[i] <= '9') ||
                    tBoxAcrescimo.Text[i] == ',')
                {
                    x += tBoxAcrescimo.Text[i];
                }
            }
            tBoxAcrescimo.Text = x;
            tBoxAcrescimo.SelectAll();
        }

        private void tBoxValorServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               (e.KeyChar != ',' && e.KeyChar != '.' &&
                e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!tBoxValorServico.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void tBoxDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               (e.KeyChar != ',' && e.KeyChar != '.' &&
                e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!tBoxDesconto.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void tBoxAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               (e.KeyChar != ',' && e.KeyChar != '.' &&
                e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!tBoxAcrescimo.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void tBoxValorPeca_KeyUp(object sender, KeyEventArgs e)
        {
            CalculaValorManutencao();
        }

        private void tBoxDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double valorDesconto = Convert.ToDouble(tBoxDesconto.Text.Replace("R$", ""));
            }
            catch { }
            CalculaValorManutencao();
        }

        private void tBoxAcrescimo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double valorAcrescimo = Convert.ToDouble(tBoxAcrescimo.Text.Replace("R$", ""));
            }
            catch { }
            CalculaValorManutencao();
        }

        private void tBoxValorServico_MouseClick(object sender, MouseEventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxValorServico.Text.Length - 1; i++)
            {
                if ((tBoxValorServico.Text[i] >= '0' &&
                    tBoxValorServico.Text[i] <= '9') ||
                    tBoxValorServico.Text[i] == ',')
                {
                    x += tBoxValorServico.Text[i];
                }
            }
            tBoxValorServico.Text = x;
            tBoxValorServico.SelectAll();
        }

        private void tBoxDesconto_MouseClick(object sender, MouseEventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxDesconto.Text.Length - 1; i++)
            {
                if ((tBoxDesconto.Text[i] >= '0' &&
                    tBoxDesconto.Text[i] <= '9') ||
                    tBoxDesconto.Text[i] == ',')
                {
                    x += tBoxDesconto.Text[i];
                }
            }
            tBoxDesconto.Text = x;
            tBoxDesconto.SelectAll();
        }

        private void tBoxAcrescimo_MouseClick(object sender, MouseEventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxAcrescimo.Text.Length - 1; i++)
            {
                if ((tBoxAcrescimo.Text[i] >= '0' &&
                    tBoxAcrescimo.Text[i] <= '9') ||
                    tBoxAcrescimo.Text[i] == ',')
                {
                    x += tBoxAcrescimo.Text[i];
                }
            }
            tBoxAcrescimo.Text = x;
            tBoxAcrescimo.SelectAll();
        }
    }
}