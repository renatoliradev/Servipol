using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servipol.Forms.ATA;
using Servipol.Forms.Cadastros;
using Servipol.Forms.Cadastros.Clientes;
using Servipol.Forms.Cadastros.Funcionários;
using Servipol.Forms.Cadastros.Equipamentos;
using Servipol.Forms.Configuração;
using Servipol.Forms.Manutenção_de_Veículos;
using Servipol.Forms.Manutenção_de_Veículos.Cadastros;
using Servipol.Forms.Manutenção_de_Veículos.Manutenção;
using Servipol.Entidades.Classes;


namespace Servipol
{
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ConexaoBD BD = new ConexaoBD();
        VerificaVersaoSistema VerificaVersao = new VerificaVersaoSistema();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            statusBarVersaoSistema.Caption = VerificaVersao.VersaoSistema();
        }

        #region Botôes

        private void btnAlterarSenha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnEfetuarLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        #endregion

        private void btnClientes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmClientesConsultar frmClientes = new frmClientesConsultar();
            frmClientes.MdiParent = this;
            frmClientes.Show();
        }

        private void btnFuncionarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmFuncionariosConsultar frmFuncionarios = new frmFuncionariosConsultar();
            frmFuncionarios.MdiParent = this;
            frmFuncionarios.Show();
        }

        private void btnEquipamentos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEquipamentosConsultar frmEquipamentos = new frmEquipamentosConsultar();
            frmEquipamentos.MdiParent = this;
            frmEquipamentos.Show();
        }

        private void btnVeiculos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVeiculosConsultar frmVeiculos = new frmVeiculosConsultar();
            frmVeiculos.MdiParent = this;
            frmVeiculos.Show();
        }

        private void btnTipoManutencao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTipoManutencaoConsultar frmTipoManutencao = new frmTipoManutencaoConsultar();
            frmTipoManutencao.MdiParent = this;
            frmTipoManutencao.Show();
        }

        private void btnLocalManutencao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLocalManutencaoConsultar frmLocalManutencao = new frmLocalManutencaoConsultar();
            frmLocalManutencao.MdiParent = this;
            frmLocalManutencao.Show();
        }

        private void btnRegistrarKmDiario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRegistrarKmDiario frmRegistrarKmDiario = new frmRegistrarKmDiario();
            frmRegistrarKmDiario.Owner = this;
            frmRegistrarKmDiario.ShowInTaskbar = false;
            frmRegistrarKmDiario.ShowDialog();
        }

        private void btnRegistrarManutencao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnRegistrarAbastecimento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnPainelBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnManutencoesRealizadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnAbastecimentosRealizados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnProxTrocaOleoRevisao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
