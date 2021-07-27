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

        private static string TipoChamada = string.Empty;
        private static int IdFuncionario = 0;
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
                cBoxCargo.Focus();
                return false;
            }
            else if (cBoxTipoSanguineo.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Selecione o [Tipo Sanguíneo] do funcionário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cBoxTipoSanguineo.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(tBoxNomeCompleto.Text))
            {
                XtraMessageBox.Show("Informe o [Nome Completo] do funcionário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            cBoxEstado.SelectedIndex = -1;
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

        #endregion

        #region Buttons

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidaCampos())
            {
                return;
            }
            else
            {
                XtraMessageBox.Show("Tudo certo");
            }
        }


        #endregion


    }
}