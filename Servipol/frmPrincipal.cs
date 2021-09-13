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
using Servipol.Forms.Configuração.Controle_de_Acesso;
using Servipol.Entidades.Classes;
using Npgsql;
using DevExpress.XtraEditors;

namespace Servipol
{
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Instâncias
        ConexaoBD BD = new ConexaoBD();
        VerificaVersaoSistema VerificaVersao = new VerificaVersaoSistema();
        Util util = new Util();
        #endregion

        private static string _usuarioId, _usuarioNome;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ribbonCategoriaInterno.Visible = false;

            statusBarVersaoSistema.Caption = VerificaVersao.VersaoSistema();

            EfetuaLogout();

            frmLogin login = new frmLogin();
            login.Owner = this;
            login.ShowDialog();

        }

        #region Methods

        public void IniciaSessao()
        {
            try
            {
                BD.Conectar();

                NpgsqlCommand com = new NpgsqlCommand($"SELECT u.id_usuario, u.login FROM usuario AS u WHERE u.id_usuario = (SELECT id_usuario FROM sis_sessao_login WHERE nome_pc = '{Environment.MachineName}' AND online = 'S')", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        _usuarioId = dr["id_usuario"].ToString();
                        _usuarioNome = dr["login"].ToString();
                    }
                    statusBarUsuario.Caption = _usuarioNome;

                    SessaoSistema.UsuarioId = _usuarioId;
                    SessaoSistema.UsuarioNome = _usuarioNome;
                }
            }
            finally
            {
                BD.Desconectar();
                FechaForms();
            }
        }

        public void EfetuaLogout()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand update1 = new NpgsqlCommand($"UPDATE sis_sessao_login SET data_logout = CURRENT_TIMESTAMP, online = 'N' WHERE nome_pc = '{Environment.MachineName}' AND online = 'S'", BD.ObjetoConexao);
                update1.ExecuteNonQuery();

                SessaoSistema.UsuarioId = null;
                SessaoSistema.UsuarioNome = null;

                statusBarUsuario.Caption = string.Empty;
            }
            finally
            {
                BD.Desconectar();
                FechaForms();
            }
        }

        public void FechaForms()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            util.LimpaMemoria();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = XtraMessageBox.Show("Deseja Sair do Sistema ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    EfetuaLogout();
                    BD.DisposeConexao();
                }
            }
        }

        #endregion

        #region Buttons

        private void btnAlterarSenha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmUsuarioAlterarSenha frmUsuarioAlterarSenha = new frmUsuarioAlterarSenha(statusBarUsuario.Caption);
            frmUsuarioAlterarSenha.Owner = this;
            frmUsuarioAlterarSenha.ShowDialog();
        }

        private void btnEfetuarLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FechaForms();
            EfetuaLogout();

            frmLogin login = new frmLogin();
            login.Owner = this;
            login.ShowDialog();
        }

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
            frmRegistrarKmDiario.ShowDialog();
        }

        private void btnRegistrarManutencao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmManutencaoRegistrar frmManutencaoRegistrar = new frmManutencaoRegistrar();
            frmManutencaoRegistrar.Owner = this;
            frmManutencaoRegistrar.ShowDialog();
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
        #endregion


    }
}
