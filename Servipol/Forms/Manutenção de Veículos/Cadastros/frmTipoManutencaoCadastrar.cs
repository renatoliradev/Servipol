using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmTipoManutencaoCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public string TipoChamada { get; set; }
        public int IdTipoManutencao { get; set; }
        #endregion

        public frmTipoManutencaoCadastrar(string tipoChamada, int idTipoManutencao)
        {
            InitializeComponent();

            TipoChamada = tipoChamada;
            IdTipoManutencao = idTipoManutencao;
        }

        private void frmTipoManutencaoCadastrar_Load(object sender, EventArgs e)
        {
            if (TipoChamada == "Editar")
            {
                CarregaRegistroParaEdicao();
                this.Text = "Editar Tipo de Manutenção";
            }
            else
            {
                chkBoxRegistroAtivo.Checked = true;
                chkBoxRegistroAtivo.Enabled = false;
                tabDadosRegistro.Parent = null;
                this.Text = "Cadastrar Tipo de Manutenção";
            }
            gbDescricao.Focus();
            tBoxDescricao.Select();
        }

        #region Methods

        public void CarregaRegistroParaEdicao()
        {
            try
            {
                BD.Conectar();

                #region Variáveis
                string descricao = string.Empty, aplicacao_carro = string.Empty, aplicacao_moto = string.Empty, exige_km_validade_oleo = string.Empty, km_validade_oleo_carro = string.Empty, km_validade_oleo_moto = string.Empty, usuario_cadastro = string.Empty, data_cadastro = string.Empty, usuario_desativacao = string.Empty, data_desativacao = string.Empty, usuario_alteracao = string.Empty, data_alteracao = string.Empty, registro_ativo = string.Empty;
                #endregion

                NpgsqlCommand com = new NpgsqlCommand($"SELECT mt.descricao, mt.aplicacao_carro, mt.aplicacao_moto, mt.exige_km_validade_oleo, mt.km_validade_oleo_carro, mt.km_validade_oleo_moto, uc.nome AS usuario_cadastro, mt.data_cadastro, ud.nome AS usuario_desativacao, mt.data_desativacao, ua.nome AS usuario_alteracao, mt.data_alteracao, mt.ativo FROM manutencao_tipo AS mt INNER JOIN usuario AS uc ON(uc.id_usuario = mt.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = mt.id_usuario_desativacao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = mt.id_usuario_alteracao) WHERE mt.id_manutencao_tipo = {IdTipoManutencao}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        descricao = dr["descricao"].ToString().Trim();
                        aplicacao_carro = dr["aplicacao_carro"].ToString();
                        aplicacao_moto = dr["aplicacao_moto"].ToString();
                        exige_km_validade_oleo = dr["exige_km_validade_oleo"].ToString();
                        km_validade_oleo_carro = dr["km_validade_oleo_carro"].ToString();
                        km_validade_oleo_moto = dr["km_validade_oleo_moto"].ToString();
                        registro_ativo = dr["ativo"].ToString();

                        //Dados do Registro
                        usuario_cadastro = dr["usuario_cadastro"].ToString();
                        data_cadastro = dr["data_cadastro"].ToString();
                        usuario_desativacao = dr["usuario_desativacao"].ToString();
                        data_desativacao = dr["data_desativacao"].ToString();
                        usuario_alteracao = dr["usuario_alteracao"].ToString();
                        data_alteracao = dr["data_alteracao"].ToString();
                    }

                    //Principal
                    tBoxDescricao.Text = descricao;
                    cBoxExigeKmValidadeOleo.SelectedItem = exige_km_validade_oleo;

                    //Dados do Registro
                    tBoxUsuarioCadastro.Text = usuario_cadastro;
                    tBoxDataCadastro.Text = data_cadastro;
                    tBoxUsuarioDesativacao.Text = usuario_desativacao;
                    tBoxDataDesativacao.Text = data_desativacao;
                    tBoxUsuarioAlteracao.Text = usuario_alteracao;
                    tBoxDataAlteracao.Text = data_alteracao;

                    #region Converte Exige Km Validade Oleo
                    switch (exige_km_validade_oleo)
                    {
                        case "S":
                            cBoxExigeKmValidadeOleo.SelectedIndex = 0;
                            break;
                        default:
                            cBoxExigeKmValidadeOleo.SelectedIndex = 1;
                            break;
                    }
                    #endregion

                    #region Conversão Aplicação Carro
                    switch (aplicacao_carro)
                    {
                        case "S":
                            chkBoxCarro.Checked = true;
                            break;
                        case "N":
                            chkBoxCarro.Checked = false;
                            break;
                    }
                    #endregion

                    #region Conversão Aplicação Moto
                    switch (aplicacao_moto)
                    {
                        case "S":
                            chkBoxMoto.Checked = true;
                            break;
                        case "N":
                            chkBoxMoto.Checked = false;
                            break;
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

                    #region Converte Km Validade Oleo Carro
                    if (km_validade_oleo_carro != "0")
                    {
                        cBoxKmValidadeOleoCarro.SelectedItem = km_validade_oleo_carro;
                    }
                    else
                    {
                        cBoxKmValidadeOleoCarro.SelectedIndex = -1;
                    }
                    #endregion

                    #region Converte Km Validade Oleo Moto
                    if (km_validade_oleo_moto != "0")
                    {
                        cBoxKmValidadeOleoMoto.SelectedItem = km_validade_oleo_moto;
                    }
                    else
                    {
                        cBoxKmValidadeOleoMoto.SelectedIndex = -1;
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

        private bool ValidaCampos()
        {
            if (string.IsNullOrEmpty(tBoxDescricao.Text))
            {
                XtraMessageBox.Show("Campo [Descrição do Serviço] não pode ficar em branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gbDescricao.Focus();
                tBoxDescricao.Select();
                return false;
            }
            else if (chkBoxCarro.Checked == false && chkBoxMoto.Checked == false)
            {
                XtraMessageBox.Show("O serviço deve ser aplicável para pelo menos 1 (um) tipo de veículo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gbAplicacao.Focus();
                return false;
            }
            else if (cBoxExigeKmValidadeOleo.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Obrigatório selecionar uma opção para [Exige informar Km Validade do Óleo]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gbExigeKmValidadeOleo.Focus();
                cBoxExigeKmValidadeOleo.Select();
                return false;
            }
            else if (chkBoxCarro.Checked == true && cBoxExigeKmValidadeOleo.SelectedIndex == 0 && cBoxKmValidadeOleoCarro.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Obrigatório selecionar uma opção para [Km Validade Óleo Carro]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gbKmValidadeOleoCarro.Focus();
                cBoxKmValidadeOleoCarro.Select();
                return false;
            }
            else if (chkBoxMoto.Checked == true && cBoxExigeKmValidadeOleo.SelectedIndex == 0 && cBoxKmValidadeOleoMoto.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Obrigatório selecionar uma opção para [Km Validade Óleo Moto]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gbKmValidadeOleoMoto.Focus();
                cBoxKmValidadeOleoMoto.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmTipoManutencaoCadastrar_KeyDown(object sender, KeyEventArgs e)
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

        private void cBoxExigeKmValidadeOleo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cBoxExigeKmValidadeOleo.SelectedIndex == 0)
                {
                    if (chkBoxCarro.Checked == true)
                    {
                        gbKmValidadeOleoCarro.Visible = true;
                    }
                    else
                    {
                        gbKmValidadeOleoCarro.Visible = false;
                        cBoxKmValidadeOleoCarro.SelectedIndex = -1;
                    }

                    if (chkBoxMoto.Checked == true)
                    {
                        gbKmValidadeOleoMoto.Visible = true;
                    }
                    else
                    {
                        gbKmValidadeOleoMoto.Visible = false;
                        cBoxKmValidadeOleoMoto.SelectedIndex = -1;
                    }
                }
                else
                {
                    gbKmValidadeOleoCarro.Visible = false;
                    gbKmValidadeOleoMoto.Visible = false;
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message);
            }
        }

        private void chkBoxCarro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxCarro.Checked == true && cBoxExigeKmValidadeOleo.SelectedIndex == 0)
            {
                gbKmValidadeOleoCarro.Visible = true;
            }
            else
            {
                gbKmValidadeOleoCarro.Visible = false;
                cBoxKmValidadeOleoCarro.SelectedIndex = -1;
            }
        }

        private void chkBoxMoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxMoto.Checked == true && cBoxExigeKmValidadeOleo.SelectedIndex == 0)
            {
                gbKmValidadeOleoMoto.Visible = true;
            }
            else
            {
                gbKmValidadeOleoMoto.Visible = false;
                cBoxKmValidadeOleoMoto.SelectedIndex = -1;
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
                if (!ValidaCampos())
                {
                    return;
                }
                else
                {
                    BD.Conectar();

                    #region Tipo Chamada: EDITAR
                    if (TipoChamada == "Editar")
                    {
                        string aplicacaoCarro = string.Empty, aplicacaoMoto = string.Empty, exigeKmValidadeOleo = string.Empty, kmValidadeOleoCarro = string.Empty, kmValidadeOleoMoto = string.Empty, registro_ativo = string.Empty;

                        #region Converte Aplicação
                        if (chkBoxCarro.Checked)
                            aplicacaoCarro = "S";
                        else
                            aplicacaoCarro = "N";

                        if (chkBoxMoto.Checked)
                            aplicacaoMoto = "S";
                        else
                            aplicacaoMoto = "N";
                        #endregion

                        #region Converte Exige Km Validade Oleo
                        if (cBoxExigeKmValidadeOleo.SelectedIndex == 0)
                            exigeKmValidadeOleo = "S";
                        else
                            exigeKmValidadeOleo = "N";
                        #endregion

                        #region Conversão Situação
                        registro_ativo = chkBoxRegistroAtivo.Checked ? "S" : "N";
                        #endregion

                        #region Converte Km Validade Óleo Carro
                        if (chkBoxCarro.Checked == true && cBoxExigeKmValidadeOleo.SelectedIndex == 0 && cBoxKmValidadeOleoCarro.SelectedIndex != -1)
                        {
                            kmValidadeOleoCarro = cBoxKmValidadeOleoCarro.Text;
                        }
                        else
                        {
                            kmValidadeOleoCarro = "0";
                        }
                        #endregion

                        #region Converte Km Validade Óleo Moto
                        if (chkBoxMoto.Checked == true && cBoxExigeKmValidadeOleo.SelectedIndex == 0 && cBoxKmValidadeOleoMoto.SelectedIndex != -1)
                        {
                            kmValidadeOleoMoto = cBoxKmValidadeOleoMoto.Text;
                        }
                        else
                        {
                            kmValidadeOleoMoto = "0";
                        }
                        #endregion

                        if (XtraMessageBox.Show("Confirmar Alterações ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            string sqlCommand = $"UPDATE manutencao_tipo SET descricao = '{tBoxDescricao.Text.ToUpper().Trim()}', aplicacao_carro = '{aplicacaoCarro}', aplicacao_moto = '{aplicacaoMoto}', exige_km_validade_oleo = '{exigeKmValidadeOleo}', km_validade_oleo_carro = {kmValidadeOleoCarro}, km_validade_oleo_moto = {kmValidadeOleoMoto} WHERE id_manutencao_tipo = {IdTipoManutencao}";
                            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                            command.ExecuteNonQuery();

                            if (registro_ativo == "N")
                            {
                                string sqlCommand2 = $"UPDATE manutencao_tipo SET ativo = '{registro_ativo}', id_usuario_desativacao = {SessaoSistema.UsuarioId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_manutencao_tipo = {IdTipoManutencao}";
                                NpgsqlCommand command2 = new NpgsqlCommand(sqlCommand2, BD.ObjetoConexao);
                                command2.ExecuteNonQuery();
                            }
                            else
                            {
                                string sqlCommand3 = $"UPDATE manutencao_tipo SET ativo = '{registro_ativo}', id_usuario_alteracao = {SessaoSistema.UsuarioId}, data_alteracao = CURRENT_TIMESTAMP WHERE id_manutencao_tipo = {IdTipoManutencao}";
                                NpgsqlCommand command3 = new NpgsqlCommand(sqlCommand3, BD.ObjetoConexao);
                                command3.ExecuteNonQuery();
                            }

                            XtraMessageBox.Show("Registro Alterado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ((frmTipoManutencaoConsultar)this.Owner).AtualizaDG();
                            this.Close();
                        }
                    }
                    #endregion

                    #region Tipo Chamada: INCLUIR
                    else
                    {
                        string aplicacaoCarro = string.Empty, aplicacaoMoto = string.Empty, exigeKmValidadeOleo = string.Empty, kmValidadeOleoCarro = string.Empty, kmValidadeOleoMoto = string.Empty;

                        #region Converte Aplicação
                        if (chkBoxCarro.Checked)
                            aplicacaoCarro = "S";
                        else
                            aplicacaoCarro = "N";

                        if (chkBoxMoto.Checked)
                            aplicacaoMoto = "S";
                        else
                            aplicacaoMoto = "N";
                        #endregion

                        #region Converte Exige Km Validade Oleo
                        if (cBoxExigeKmValidadeOleo.SelectedIndex == 0)
                            exigeKmValidadeOleo = "S";
                        else
                            exigeKmValidadeOleo = "N";
                        #endregion

                        #region Converte Km Validade Óleo Carro
                        if (chkBoxCarro.Checked == true && cBoxExigeKmValidadeOleo.SelectedIndex == 0 && cBoxKmValidadeOleoCarro.SelectedIndex != -1)
                        {
                            kmValidadeOleoCarro = cBoxKmValidadeOleoCarro.Text;
                        }
                        else
                        {
                            kmValidadeOleoCarro = "0";
                        }
                        #endregion

                        #region Converte Km Validade Óleo Moto
                        if (chkBoxMoto.Checked == true && cBoxExigeKmValidadeOleo.SelectedIndex == 0 && cBoxKmValidadeOleoMoto.SelectedIndex != -1)
                        {
                            kmValidadeOleoMoto = cBoxKmValidadeOleoMoto.Text;
                        }
                        else
                        {
                            kmValidadeOleoMoto = "0";
                        }
                        #endregion

                        string sqlCommand = $"INSERT INTO manutencao_tipo VALUES (nextval('seq_manutencao_tipo'), '{tBoxDescricao.Text.ToUpper().Trim()}', (SELECT MAX(ordem + 1) FROM manutencao_tipo), '{aplicacaoCarro}', '{aplicacaoMoto}', {SessaoSistema.UsuarioId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL, 'S', '{exigeKmValidadeOleo}', {kmValidadeOleoCarro}, {kmValidadeOleoMoto})";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        XtraMessageBox.Show("Cadastrado Efetuado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ((frmTipoManutencaoConsultar)this.Owner).AtualizaDG();
                        this.Close();
                    }
                }

                #endregion
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
        
        #endregion
    }
}