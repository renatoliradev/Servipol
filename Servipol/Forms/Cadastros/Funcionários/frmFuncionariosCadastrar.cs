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

        #endregion

        #region Buttons

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            //Principal
            cBoxCargo.SelectedIndex = -1;
            tBoxCodControle.Clear();
            cBoxTipoSanguineo.SelectedIndex = -1;
            tBoxDataNascimento.ResetText();
            tBoxNomeCompletoFuncionario.Clear();
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
            rBtnCursoVigilanteNao.Checked = false;
            tBoxLocalCursoVigilante.Clear();
            tBoxCidadeCursoVigilante.Clear();
            cBoxUfCursoVigilante.SelectedIndex = -1;
            tBoxDataValidadeCursoVigilante.ResetText();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}