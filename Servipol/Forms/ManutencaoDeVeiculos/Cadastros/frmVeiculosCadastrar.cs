using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmVeiculosCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public string TipoChamada { get; set; }
        public int IdVeiculo { get; set; }
        #endregion

        public frmVeiculosCadastrar(string tipoChamada, int idVeiculo)
        {
            InitializeComponent();

            TipoChamada = tipoChamada;
            IdVeiculo = idVeiculo;
        }

        private void frmVeiculosCadastrar_Load(object sender, EventArgs e)
        {
            CarregaTipoVeiculo();
            VerificaTipoChamada();

            gbTipoVeiculo.Select();
            cBoxTipoVeiculo.Select();
        }

        #region Methods

        private void cBoxTipoVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cBoxTipoVeiculo.SelectedValue.ToString() == "1")
                {
                    CarregaCodigoCarro();
                }
                else if (cBoxTipoVeiculo.SelectedValue.ToString() == "2")
                {
                    CarregaCodigoMoto();
                }
            }
            catch { }
        }

        public void VerificaTipoChamada()
        {
            try
            {
                if (TipoChamada == "Incluir")
                {
                    this.Text = "Incluir Veículo";

                    cBoxTipoVeiculo.SelectedIndex = -1;
                    cBoxCombustivel.SelectedIndex = -1;
                    cBoxRegistraKmDiario.SelectedIndex = -1;
                    cBoxKmValidadeOleo.SelectedIndex = -1;
                    tBoxDescricaoVeiculo.Clear();
                    tBoxPlacaVeiculo.Clear();
                    tBoxDescricaoVeiculo.Focus();
                    chkBoxRegistroAtivo.Checked = true;
                    chkBoxRegistroAtivo.Enabled = false;
                    tabDadosRegistro.Parent = null;
                }
                else if (TipoChamada == "Editar")
                {
                    this.Text = "Editar Veículo";
                    CarregaRegistroParaEdicao();
                }
            }
            finally
            {
            }
        }

        public void CarregaTipoVeiculo()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id_veiculo_tipo, descricao FROM veiculo_tipo WHERE descricao != 'Outros' AND ativo = 'S' ORDER BY 2 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxTipoVeiculo.ValueMember = "id_veiculo_tipo";
                cBoxTipoVeiculo.DisplayMember = "descricao";
                cBoxTipoVeiculo.DataSource = dt;

                if (cBoxTipoVeiculo.SelectedValue.ToString() == "1")
                {
                    CarregaCodigoCarro();
                }
                else if (cBoxTipoVeiculo.SelectedValue.ToString() == "2")
                {
                    CarregaCodigoMoto();
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha na função carregaTipoVeiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaCodigoCarro()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id FROM codigocarro WHERE id_veiculo = {IdVeiculo} OR id_veiculo IS NULL ORDER BY 1 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxCodigoVeiculo.ValueMember = "id";
                cBoxCodigoVeiculo.DisplayMember = "id";
                cBoxCodigoVeiculo.DataSource = dt;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha na função carregaCodigoCarro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaCodigoMoto()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id FROM codigomoto WHERE id_veiculo = {IdVeiculo} OR  id_veiculo IS NULL ORDER BY 1 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxCodigoVeiculo.ValueMember = "id";
                cBoxCodigoVeiculo.DisplayMember = "id";
                cBoxCodigoVeiculo.DataSource = dt;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha na função carregaCodigoMoto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaRegistroParaEdicao()
        {
            try
            {
                BD.Conectar();

                #region Variáveis
                string tipo_veiculo = string.Empty, codigo = string.Empty, descricao = string.Empty, placa = string.Empty, combustivel = string.Empty, registra_km_diario = string.Empty, km_validade_oleo = string.Empty, usuario_cadastro = string.Empty, data_cadastro = string.Empty, usuario_desativacao = string.Empty, data_desativacao = string.Empty, usuario_reativacao = string.Empty, data_reativacao = string.Empty, usuario_alteracao = string.Empty, data_alteracao = string.Empty, registro_ativo = string.Empty;
                #endregion

                NpgsqlCommand com = new NpgsqlCommand($"SELECT v.id_veiculo, v.id_veiculo_tipo, v.codigo, v.descricao, v.placa, v.combustivel, v.registra_km_diario, v.km_validade_oleo, uc.nome AS usuario_cadastro, v.data_cadastro, ud.nome AS usuario_desativacao, v.data_desativacao, ur.nome AS usuario_reativacao, v.data_reativacao, ua.nome AS usuario_alteracao, v.data_alteracao, v.ativo FROM veiculo AS v INNER JOIN usuario AS uc ON(uc.id_usuario = v.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = v.id_usuario_desativacao) LEFT OUTER JOIN usuario AS ur ON(ur.id_usuario = v.id_usuario_reativacao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = v.id_usuario_alteracao) WHERE v.id_veiculo = {IdVeiculo}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tipo_veiculo = dr["id_veiculo_tipo"].ToString();
                        codigo = dr["codigo"].ToString();
                        descricao = dr["descricao"].ToString().Trim();
                        placa = dr["placa"].ToString();
                        combustivel = dr["combustivel"].ToString();
                        registra_km_diario = dr["registra_km_diario"].ToString();
                        km_validade_oleo = dr["km_validade_oleo"].ToString();
                        registro_ativo = dr["ativo"].ToString();

                        //Dados do Registro
                        usuario_cadastro = dr["usuario_cadastro"].ToString();
                        data_cadastro = dr["data_cadastro"].ToString();
                        usuario_desativacao = dr["usuario_desativacao"].ToString();
                        data_desativacao = dr["data_desativacao"].ToString();
                        usuario_reativacao = dr["usuario_reativacao"].ToString();
                        data_reativacao = dr["data_reativacao"].ToString();
                        usuario_alteracao = dr["usuario_alteracao"].ToString();
                        data_alteracao = dr["data_alteracao"].ToString();
                    }

                    //Principal
                    tBoxDescricaoVeiculo.Text = descricao;
                    cBoxTipoVeiculo.SelectedValue = tipo_veiculo;
                    cBoxCodigoVeiculo.Text = codigo;
                    cBoxCombustivel.SelectedItem = combustivel;

                    //Dados do Registro
                    tBoxUsuarioCadastro.Text = usuario_cadastro;
                    tBoxDataCadastro.Text = data_cadastro;
                    tBoxUsuarioDesativacao.Text = usuario_desativacao;
                    tBoxDataDesativacao.Text = data_desativacao;
                    tBoxUsuarioAlteracao.Text = usuario_alteracao;
                    tBoxDataAlteracao.Text = data_alteracao;

                    #region Identifica Tipo da Placa
                    if (placa.Contains("-"))
                    {
                        rBtnPlacaAntiga.Checked = true;
                        tBoxPlacaVeiculo.Text = placa;
                    }
                    else
                    {
                        rBtnPlacaMercosul.Checked = true;
                        tBoxPlacaVeiculo.Text = placa;
                    }
                    #endregion

                    #region Conversão Registra Km Diário
                    switch (registra_km_diario)
                    {
                        case "S":
                            cBoxRegistraKmDiario.SelectedIndex = 0;
                            break;
                        default:
                            cBoxRegistraKmDiario.SelectedIndex = 1;
                            break;
                    }
                    #endregion

                    #region Converte Km Validade Oleo
                    if (km_validade_oleo != "0")
                    {
                        cBoxKmValidadeOleo.SelectedItem = km_validade_oleo;
                    }
                    else
                    {
                        cBoxKmValidadeOleo.SelectedIndex = -1;
                    }
                    #endregion

                    #region Conversão Situação
                    switch (registro_ativo)
                    {
                        case "S":
                            chkBoxRegistroAtivo.Checked = true;
                            break;
                        case "N":
                            chkBoxRegistroAtivo.Checked = false;
                            break;
                    }
                    #endregion
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void rBtnPlacaMercosul_CheckedChanged(object sender, EventArgs e)
        {
            tBoxPlacaVeiculo.Clear();
            tBoxPlacaVeiculo.Mask = "LLL0L00";
            tBoxPlacaVeiculo.Select();
        }

        private void rBtnPlacaAntiga_CheckedChanged(object sender, EventArgs e)
        {
            tBoxPlacaVeiculo.Clear();
            tBoxPlacaVeiculo.Mask = "LLL-0000";
            tBoxPlacaVeiculo.Select();
        }

        private void tBoxPlacaVeiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }

        private bool ValidaCampos()
        {
            if (cBoxTipoVeiculo.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Selecione o [Tipo] do Veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxTipoVeiculo.Focus();
                return false;
            }
            else if (cBoxCodigoVeiculo.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Selecione o [Código] do Veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxCodigoVeiculo.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(tBoxDescricaoVeiculo.Text))
            {
                XtraMessageBox.Show("Informe uma [Descrição] do Veículo.\n\n Ex.: Gol Técnico", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxDescricaoVeiculo.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(tBoxPlacaVeiculo.Text))
            {
                XtraMessageBox.Show("Informe a [Placa] do Veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tBoxPlacaVeiculo.Focus();
                return false;
            }
            else if (cBoxCombustivel.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Selecione o [Combustível preferencial] do Veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxCombustivel.Focus();
                return false;
            }
            else if (cBoxRegistraKmDiario.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Informe se é [Obrigatório registrar Km Diário] do veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxRegistraKmDiario.Focus();
                return false;
            }
            else if (cBoxKmValidadeOleo.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Informe o [Km Validade Óleo] do veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxKmValidadeOleo.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmVeiculosCadastrar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    btnCancelar_Click(sender, e);
                    break;
                case Keys.F12:
                    btnConfirmar_Click(sender, e);
                    break;
            }
        }

        #endregion

        #region Buttons
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();

                if (!ValidaCampos())
                {
                    return;
                }
                else
                {
                    #region Variáveis
                    string km_validade_oleo = string.Empty, registra_km_diario = string.Empty, registro_ativo = string.Empty;
                    
                    #region Conversão Km Validade Oleo
                    if (cBoxKmValidadeOleo.SelectedIndex < 0)
                    {
                        km_validade_oleo = "0";
                    }
                    else
                    {
                        km_validade_oleo = cBoxKmValidadeOleo.SelectedItem.ToString();
                    }
                    #endregion

                    #region Conversão Registra Km Diário

                    if (cBoxRegistraKmDiario.SelectedIndex == 0)
                    {
                        registra_km_diario = "S";
                    }
                    else
                    {
                        registra_km_diario = "N";
                    }

                    #endregion

                    #region Conversão Situação
                    registro_ativo = chkBoxRegistroAtivo.Checked ? "S" : "N";
                    #endregion
                    #endregion

                    if (TipoChamada == "Incluir")
                    {
                        string sqlCommand = $"INSERT INTO veiculo VALUES (nextval('seq_veiculo'), {cBoxTipoVeiculo.SelectedValue}, {cBoxCodigoVeiculo.SelectedValue}, '{tBoxDescricaoVeiculo.Text.ToUpper().Trim()}', '{tBoxPlacaVeiculo.Text.ToUpper()}', '{cBoxCombustivel.SelectedItem}', '{registra_km_diario}', {SessaoSistema.UserId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL, NULL, NULL, {km_validade_oleo}, 'S')";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        if (cBoxTipoVeiculo.SelectedValue.ToString() == "1")
                        {
                            string sqlCommand2 = $"UPDATE codigocarro SET id_veiculo = (SELECT MAX(id) AS id_veiculo FROM veiculo) WHERE id = {cBoxCodigoVeiculo.SelectedValue}";
                            NpgsqlCommand command2 = new NpgsqlCommand(sqlCommand2, BD.ObjetoConexao);
                            command2.ExecuteNonQuery();
                        }
                        else
                        {
                            string sqlCommand2 = $"UPDATE codigomoto SET id_veiculo = (SELECT MAX(id) AS id_veiculo FROM veiculo) WHERE id = {cBoxCodigoVeiculo.SelectedValue}";
                            NpgsqlCommand command2 = new NpgsqlCommand(sqlCommand2, BD.ObjetoConexao);
                            command2.ExecuteNonQuery();
                        }
                        XtraMessageBox.Show("Veículo cadastrado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (TipoChamada == "Editar")
                    {
                        string sqlCommand = $"UPDATE veiculo SET id_veiculo_tipo = {cBoxTipoVeiculo.SelectedValue}, codigo = {cBoxCodigoVeiculo.SelectedValue}, descricao = '{tBoxDescricaoVeiculo.Text.ToUpper().Trim()}', placa = '{tBoxPlacaVeiculo.Text.ToUpper()}', combustivel = '{cBoxCombustivel.SelectedItem}', km_validade_oleo = '{km_validade_oleo}', registra_km_diario = '{registra_km_diario}', ativo = '{registro_ativo}', id_usuario_alteracao = {SessaoSistema.UserId}, data_alteracao = CURRENT_TIMESTAMP WHERE id_veiculo = {IdVeiculo}";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        if (cBoxTipoVeiculo.SelectedValue.ToString() == "1")
                        {
                            string sqlCommand4 = $"UPDATE codigocarro SET id_veiculo = NULL WHERE id_veiculo = {IdVeiculo}";
                            NpgsqlCommand command4 = new NpgsqlCommand(sqlCommand4, BD.ObjetoConexao);
                            command4.ExecuteNonQuery();

                            string sqlCommand5 = $"UPDATE codigocarro SET id_veiculo = {IdVeiculo} WHERE id = {cBoxCodigoVeiculo.SelectedValue}";
                            NpgsqlCommand command5 = new NpgsqlCommand(sqlCommand5, BD.ObjetoConexao);
                            command5.ExecuteNonQuery();
                        }
                        else
                        {
                            string sqlCommand6 = $"UPDATE codigomoto SET id_veiculo = NULL WHERE id_veiculo = {IdVeiculo}";
                            NpgsqlCommand command6 = new NpgsqlCommand(sqlCommand6, BD.ObjetoConexao);
                            command6.ExecuteNonQuery();

                            string sqlCommand7 = $"UPDATE codigomoto SET id_veiculo = {IdVeiculo} WHERE id = {cBoxCodigoVeiculo.SelectedValue}";
                            NpgsqlCommand command7 = new NpgsqlCommand(sqlCommand7, BD.ObjetoConexao);
                            command7.ExecuteNonQuery();
                        }

                        if (registro_ativo == "N")
                        {
                            string sqlCommand8 = $"UPDATE veiculo SET registra_km_diario = 'N', ativo = 'N', id_usuario_desativacao = {SessaoSistema.UserId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_veiculo = {IdVeiculo}";
                            NpgsqlCommand command8 = new NpgsqlCommand(sqlCommand8, BD.ObjetoConexao);
                            command8.ExecuteNonQuery();

                            string sqlCommand2 = $"UPDATE codigocarro SET id_veiculo = NULL WHERE id_veiculo = {IdVeiculo}";
                            NpgsqlCommand command2 = new NpgsqlCommand(sqlCommand2, BD.ObjetoConexao);
                            command2.ExecuteNonQuery();

                            string sqlCommand3 = $"UPDATE codigomoto SET id_veiculo = NULL WHERE id_veiculo = {IdVeiculo}";
                            NpgsqlCommand command3 = new NpgsqlCommand(sqlCommand3, BD.ObjetoConexao);
                            command3.ExecuteNonQuery();
                        }

                        XtraMessageBox.Show("Veículo alterado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((frmVeiculosConsultar)this.Owner).AtualizaDG();
                        this.Close();
                    }
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }

        #endregion

    }
}