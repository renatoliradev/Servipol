using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servipol.Entidades.Classes;
using Npgsql;

namespace Servipol.Forms.Cadastros.Funcionários
{
    public partial class frmFuncionariosCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        ConexaoBD BD = new ConexaoBD();

        public string TipoChamada { get; set; }
        public int IdFuncionario { get; set; }
        #endregion

        public frmFuncionariosCadastrar(string tipoChamada, int idFuncionario)
        {
            TipoChamada = tipoChamada;
            IdFuncionario = idFuncionario;

            InitializeComponent();
        }

        private void frmFuncionariosCadastrar_Load(object sender, EventArgs e)
        {
            CarregaCargos();
            CarregaCodigoASE();
            VerificaTipoChamada();
        }

        #region Methods

        private void VerificaTipoChamada()
        {
            try
            {
                if (TipoChamada == "Incluir")
                {
                    this.Text = "Cadastrar Funcionário";
                    LimparCampos();
                }
                else if (TipoChamada == "Editar")
                {
                    this.Text = "Editar Funcionário";
                    btnLimparCampos.Enabled = false;
                    btnLimparCampos.Visible = false;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void CarregaCargos()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id_funcionario_cargo, descricao FROM funcionario_cargo WHERE ativo = 'S' ORDER BY id_funcionario_cargo ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxCargo.ValueMember = "id_funcionario_cargo";
                cBoxCargo.DisplayMember = "descricao";
                cBoxCargo.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaCodigoASE()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT codigo FROM codigoqra WHERE id_funcionario IS NULL ORDER BY 1 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxCodigoASE.ValueMember = "codigo";
                cBoxCodigoASE.DisplayMember = "codigo";
                cBoxCodigoASE.DataSource = dt;

                cBoxCodigoASE.SelectedIndex = -1;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private bool ValidaCampos()
        {
            if (cBoxCargo.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Selecione o [Cargo] do funcionário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabPrincipal);
                cBoxCargo.Focus();
                return false;
            }
            else if (cBoxTipoSanguineo.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Selecione o [Tipo Sanguíneo] do funcionário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabPrincipal);
                cBoxTipoSanguineo.Focus();
                return false;
            }
            else if (Convert.ToDateTime(tBoxDataNascimento.Text) > DateTime.Now)
            {
                XtraMessageBox.Show("Informe corretamente a [Data de Nascimento] do funcionário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabPrincipal);
                tBoxDataNascimento.Focus();
                return false;
            }
            else if (tBoxDataNascimento.Text == DateTime.Now.ToString("d"))
            {
                XtraMessageBox.Show("Informe corretamente a [Data de Nascimento] do funcionário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabPrincipal);
                tBoxDataNascimento.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(tBoxNomeCompleto.Text))
            {
                XtraMessageBox.Show("Informe o [Nome Completo] do funcionário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabPrincipal);
                tBoxNomeCompleto.Focus();
                return false;
            }
            else if (cBoxCargo.SelectedIndex == 0 && cBoxCodigoASE.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Selecione o [Código] do Agente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabDadosAdicionaisASE);
                cBoxCodigoASE.Focus();
                return false;
            }
            else if (cBoxCargo.SelectedIndex == 0 && string.IsNullOrEmpty(tBoxQraASE.Text))
            {
                XtraMessageBox.Show("Informe o [QRA] do Agente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabDadosAdicionaisASE);
                tBoxQraASE.Focus();
                return false;
            }
            else if (cBoxCargo.SelectedIndex == 0 && cBoxCargoASE.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Selecione o [Cargo Operacional Externo] do Agente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabDadosAdicionaisASE);
                cBoxCargoASE.Focus();
                return false;
            }
            else if (cBoxCargo.SelectedIndex == 0 && rBtnCursoVigilanteSim.Checked && string.IsNullOrEmpty(tBoxLocalCursoVigilante.Text))
            {
                XtraMessageBox.Show("Informe o [Local do curso] de vigilante do agente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabDadosAdicionaisASE);
                tBoxLocalCursoVigilante.Focus();
                return false;
            }
            else if (cBoxCargo.SelectedIndex == 0 && rBtnCursoVigilanteSim.Checked && string.IsNullOrEmpty(tBoxCidadeCursoVigilante.Text))
            {
                XtraMessageBox.Show("Informe a [Cidade] do curso de vigilante do agente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabDadosAdicionaisASE);
                tBoxCidadeCursoVigilante.Focus();
                return false;
            }
            else if (cBoxCargo.SelectedIndex == 0 && rBtnCursoVigilanteSim.Checked && cBoxUfCursoVigilante.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Selecione a [UF] da cidade do curso de vigilante do agente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlFuncionario.SelectTab(tabDadosAdicionaisASE);
                cBoxCargoASE.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LimparCampos()
        {
            //Principal
            cBoxCargo.SelectedIndex = -1;
            tBoxCodControle.Clear();
            cBoxTipoSanguineo.SelectedIndex = -1;
            tBoxDataNascimento.ResetText();
            tBoxNomeCompleto.Clear();
            tBoxNomeMae.Clear();
            tBoxNomePai.Clear();
            tBoxCpf.Clear();
            tBoxRg.Clear();
            cBoxUfExpRg.SelectedIndex = -1;
            tBoxDataExpRg.ResetText();
            chkBoxCatCnhA.Checked = false;
            chkBoxCatCnhB.Checked = false;
            chkBoxCatCnhC.Checked = false;
            chkBoxCatCnhD.Checked = false;
            chkBoxCatCnhE.Checked = false;
            tBoxNumeroRegistroCNH.Clear();
            tBoxDataValidadeCnh.ResetText();
            tBoxObs.Clear();

            //Dados Profissionais
            tBoxDataAdmissao.ResetText();
            tBoxPisPasep.Clear();
            tBoxNrCTPS.Clear();
            tBoxSerieCTPS.Clear();
            cBoxUfEmissaoCTPS.SelectedIndex = -1;

            //Endereço e Contatos
            tBoxLogradouro.Clear();
            tBoxNumero.Clear();
            tBoxBairro.Clear();
            tBoxCidade.Clear();
            cBoxUfEndereco.SelectedIndex = -1;
            tBoxCep.Clear();
            tBoxEmail.Clear();
            tBoxTelefone1.Clear();
            tBoxTelefone2.Clear();
            tBoxTelefone3.Clear();
            tBoxTelefone4.Clear();
            tBoxTipoContato1.Clear();
            tBoxTipoContato2.Clear();
            tBoxTipoContato3.Clear();
            tBoxTipoContato4.Clear();
            tBoxNomeContato1.Clear();
            tBoxNomeContato2.Clear();
            tBoxNomeContato3.Clear();
            tBoxNomeContato4.Clear();

            //Dados Adicionais (Operacional Externo)
            cBoxCodigoASE.SelectedIndex = -1;
            tBoxQraASE.Clear();
            cBoxCargoASE.SelectedIndex = -1;
            rBtnCursoVigilanteSim.Checked = false;
            rBtnCursoVigilanteNao.Checked = true;
            tBoxLocalCursoVigilante.Clear();
            tBoxCidadeCursoVigilante.Clear();
            cBoxUfCursoVigilante.SelectedIndex = -1;
            tBoxDataValidadeCursoVigilante.ResetText();
        }

        private void cBoxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxCargo.SelectedIndex == 0)
            {
                tabDadosAdicionaisASE.Parent = tabControlFuncionario;
            }
            else
            {
                tBoxQraASE.Clear();
                cBoxCodigoASE.SelectedIndex = -1;
                cBoxCargoASE.SelectedIndex = -1;
                rBtnCursoVigilanteNao.Checked = true;
                tBoxLocalCursoVigilante.Clear();
                tBoxCidadeCursoVigilante.Clear();
                cBoxUfCursoVigilante.SelectedIndex = -1;
                tBoxDataValidadeCursoVigilante.ResetText();
                tabDadosAdicionaisASE.Parent = null;
            }
        }

        private void frmFuncionariosCadastrar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F12:
                    btnConfirmar_Click(sender, e);
                    break;
                case Keys.F5:
                    if (TipoChamada == "Incluir")
                    {
                        btnLimparCampos_Click(sender, e);
                    }
                    break;
                case Keys.Escape:
                    btnCancelar_Click(sender, e);
                    break;
            }
        }

        #endregion

        #region Buttons

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
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
                    #region Variáveis
                    string cargo, codigo, tipo_sanguineo, qra, cod_controle, nome_completo, cpf, rg, uf_exp_rg, data_exp_rg, data_nascimento, data_admissao, data_validade_cnh, cat_cnh_a, cat_cnh_b, cat_cnh_c, cat_cnh_d, cat_cnh_e, observacao, end_logradouro, end_numero, end_bairro,
                        end_cidade, end_uf, end_cep, email, telefone_1, telefone_2, telefone_3, telefone_4, contato_1, contato_2, contato_3, contato_4, nome_contato_1, nome_contato_2, nome_contato_3, nome_contato_4, numero_registro_cnh, cargo_agente, pis_pasep, numero_ctps, serie_ctps, uf_emissao_ctps, nome_mae, nome_pai, tem_curso_vigilante, local_curso_vigilante, cidade_curso_vigilante, uf_curso_vigilante, data_validade_curso_vigilante;

                    //Principal
                    cargo = cBoxCargo.SelectedValue.ToString();
                    cod_controle = string.IsNullOrEmpty(tBoxCodControle.Text) ? "" : tBoxCodControle.Text.ToUpper().Trim();
                    tipo_sanguineo = cBoxTipoSanguineo.SelectedItem.ToString().ToUpper();
                    data_nascimento = tBoxDataNascimento.Text.Replace("/", "-");
                    nome_completo = tBoxNomeCompleto.Text.ToUpper().Trim();
                    nome_mae = tBoxNomeMae.Text == string.Empty ? "" : tBoxNomeMae.Text.ToUpper().Trim();
                    nome_pai = tBoxNomePai.Text == string.Empty ? "" : tBoxNomePai.Text.ToUpper().Trim();
                    cpf = tBoxCpf.Text;
                    rg = tBoxRg.Text.Trim();
                    uf_exp_rg = cBoxUfExpRg.SelectedIndex == -1 ? "" : cBoxUfExpRg.SelectedItem.ToString();
                    data_exp_rg = tBoxDataExpRg.Text.Replace("/", "-");
                    cat_cnh_a = chkBoxCatCnhA.Checked ? "S" : "N";
                    cat_cnh_b = chkBoxCatCnhB.Checked ? "S" : "N";
                    cat_cnh_c = chkBoxCatCnhC.Checked ? "S" : "N";
                    cat_cnh_d = chkBoxCatCnhD.Checked ? "S" : "N";
                    cat_cnh_e = chkBoxCatCnhE.Checked ? "S" : "N";
                    numero_registro_cnh = tBoxNumeroRegistroCNH.Text.ToUpper().Trim();
                    data_validade_cnh = tBoxDataValidadeCnh.Text.Replace("/", "-");
                    observacao = tBoxObs.Text.ToUpper().Trim();

                    //Dados Profissionais
                    data_admissao = string.IsNullOrEmpty(tBoxDataAdmissao.Text) ? DateTime.Now.ToString("d") : tBoxDataAdmissao.Text.Replace("/", "-");
                    pis_pasep = tBoxPisPasep.Text == string.Empty ? "" : tBoxPisPasep.Text.ToUpper().Trim();
                    numero_ctps = tBoxNrCTPS.Text == string.Empty ? "" : tBoxNrCTPS.Text.ToUpper().Trim();
                    serie_ctps = tBoxSerieCTPS.Text == string.Empty ? "" : tBoxSerieCTPS.Text.ToUpper().Trim();
                    uf_emissao_ctps = cBoxUfEmissaoCTPS.SelectedIndex == -1 ? "" : cBoxUfEmissaoCTPS.SelectedItem.ToString();

                    //Endereços e Contatos
                    end_logradouro = tBoxLogradouro.Text.ToUpper().Trim();
                    end_numero = tBoxNumero.Text.ToUpper().Trim();
                    end_bairro = tBoxBairro.Text.ToUpper().Trim();
                    end_cidade = tBoxCidade.Text.ToUpper().Trim();
                    end_uf = cBoxUfEndereco.SelectedIndex == -1 ? "" : cBoxUfEndereco.SelectedItem.ToString();
                    end_cep = tBoxCep.Text;
                    email = tBoxEmail.Text.ToLower().Trim();
                    telefone_1 = tBoxTelefone1.Text;
                    telefone_2 = tBoxTelefone2.Text;
                    telefone_3 = tBoxTelefone3.Text;
                    telefone_4 = tBoxTelefone4.Text;
                    contato_1 = tBoxTipoContato1.Text.ToUpper().Trim();
                    contato_2 = tBoxTipoContato2.Text.ToUpper().Trim();
                    contato_3 = tBoxTipoContato3.Text.ToUpper().Trim();
                    contato_4 = tBoxTipoContato4.Text.ToUpper().Trim();
                    nome_contato_1 = tBoxNomeContato1.Text.ToUpper().Trim();
                    nome_contato_2 = tBoxNomeContato2.Text.ToUpper().Trim();
                    nome_contato_3 = tBoxNomeContato3.Text.ToUpper().Trim();
                    nome_contato_4 = tBoxNomeContato4.Text.ToUpper().Trim();

                    //Dados Adicionais (Operacional Externo)
                    codigo = cBoxCodigoASE.SelectedIndex == -1 ? "" : cBoxCodigoASE.SelectedValue.ToString();
                    qra = string.IsNullOrEmpty(tBoxQraASE.Text) ? "" : tBoxQraASE.Text.ToUpper().Trim();
                    cargo_agente = cBoxCargoASE.SelectedIndex == -1 ? "" : cBoxCargoASE.SelectedItem.ToString();
                    tem_curso_vigilante = rBtnCursoVigilanteSim.Checked == true ? "S" : "N";
                    local_curso_vigilante = tBoxLocalCursoVigilante.Text.ToUpper().Trim();
                    cidade_curso_vigilante = tBoxCidadeCursoVigilante.Text.ToUpper().Trim();
                    uf_curso_vigilante = cBoxUfCursoVigilante.SelectedIndex == -1 ? "" : cBoxUfCursoVigilante.SelectedItem.ToString();
                    data_validade_curso_vigilante = string.IsNullOrEmpty(tBoxDataValidadeCursoVigilante.Text) ? "01-01-2100" : tBoxDataValidadeCursoVigilante.Text.Replace("/", "-");

                    #endregion
                    BD.Conectar();
                    string sqlCommand = $"INSERT INTO funcionario VALUES (nextval('seq_funcionario'), {cargo}, '{cod_controle}', '{tipo_sanguineo}', '{data_nascimento}', '{nome_completo}', '{nome_mae}', '{nome_pai}', '{cpf}', '{rg}', '{uf_exp_rg}', '{data_exp_rg}', '{cat_cnh_a}', '{cat_cnh_b}', '{cat_cnh_c}', '{cat_cnh_d}', '{cat_cnh_e}', '{numero_registro_cnh}', '{data_validade_cnh}', '{observacao}', '{data_admissao}', '{pis_pasep}', '{numero_ctps}', '{serie_ctps}', '{uf_emissao_ctps}', '{end_logradouro}', '{end_numero}', '{end_bairro}', '{end_cidade}', '{end_uf}', '{end_cep}', '{email}', '{telefone_1}', '{telefone_2}', '{telefone_3}', '{telefone_4}', '{contato_1}', '{contato_2}', '{contato_3}', '{contato_4}', '{nome_contato_1}', '{nome_contato_2}', '{nome_contato_3}', '{nome_contato_4}', '{cargo_agente}', '{codigo}', '{qra}', '{tem_curso_vigilante}', '{local_curso_vigilante}', '{cidade_curso_vigilante}', '{uf_curso_vigilante}', '{data_validade_curso_vigilante}', {SessaoSistema.UsuarioId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL, 'S')";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    if (cBoxCargo.SelectedIndex == 0)
                    {
                        string sqlCommand2 = $"UPDATE codigoqra SET id_funcionario = (SELECT MAX(id_funcionario) AS id FROM funcionario) WHERE codigo = {cBoxCodigoASE.SelectedValue}";
                        NpgsqlCommand command2 = new NpgsqlCommand(sqlCommand2, BD.ObjetoConexao);
                        command2.ExecuteNonQuery();
                    }

                    CarregaCodigoASE();

                    XtraMessageBox.Show("Funcionário Cadastrado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((frmFuncionariosConsultar)this.Owner).AtualizaDG();
                    this.Close();
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        #endregion


    }
}