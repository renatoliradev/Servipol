using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using Servipol.Forms.Cadastros.Clientes;
using Servipol.Forms.Cadastros.Equipamentos;
using Servipol.Forms.Cadastros.Funcionários;
using Servipol.Forms.Configuração.Controle_de_Acesso;
using Servipol.Forms.Manutenção_de_Veículos.Cadastros;
using Servipol.Forms.Manutenção_de_Veículos.Manutenção;
using System;
using System.Windows.Forms;

namespace Servipol
{
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Instâncias
        readonly ConexaoBD BD = new ConexaoBD();
        VerificaVersaoSistema VerificaVersao = new VerificaVersaoSistema();
        MemoryManagement MemoryManagement = new MemoryManagement();
        #endregion

        private static string _userId, _userName;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            statusBarVersaoSistema.Caption = VerificaVersao.VersaoSistema();

            EfetuaLogout();

            frmLogin Login = new frmLogin();
            Login.Owner = this;
            Login.ShowDialog();
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
                        _userId = dr["id_usuario"].ToString();
                        _userName = dr["login"].ToString();
                    }
                    statusBarUsuario.Caption = _userName;

                    SessaoSistema.UsuarioId = _userId;
                    SessaoSistema.UsuarioNome = _userName;
                }

                CallRegistrarKmDiario();

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
            MemoryManagement.FlushMemory();
        }

        public void CallRegistrarKmDiario()
        {
            try
            {
                string registrou_km_diario = string.Empty;
                BD.Conectar();
                NpgsqlCommand com2 = new NpgsqlCommand("SELECT v.id_veiculo AS id_veiculo FROM km_diario AS kmd INNER JOIN veiculo AS v ON(kmd.id_veiculo = v.id_veiculo) WHERE v.ativo = 'S' AND v.registra_km_diario = 'S' AND v.id_veiculo NOT IN(SELECT id_veiculo FROM km_diario WHERE data_km_diario = current_date) GROUP BY 1", BD.ObjetoConexao);
                using (NpgsqlDataReader dr2 = com2.ExecuteReader())
                {
                    while (dr2.Read())
                    {
                        registrou_km_diario = dr2[0].ToString();
                    }
                    if (registrou_km_diario != string.Empty)
                    {
                        frmRegistrarKmDiario frmRegistrarKmDiario = new frmRegistrarKmDiario();
                        frmRegistrarKmDiario.ShowInTaskbar = false;
                        frmRegistrarKmDiario.ShowDialog();
                    }
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Erro na função CallRegistrarKmDiario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BD.Desconectar();
            }
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
            MemoryManagement.FlushMemory();

            frmVeiculosConsultar frmVeiculos = new frmVeiculosConsultar();
            frmVeiculos.MdiParent = this;
            frmVeiculos.Show();
        }

        private void btnTipoManutencao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MemoryManagement.FlushMemory();

            frmTipoManutencaoConsultar frmTipoManutencao = new frmTipoManutencaoConsultar();
            frmTipoManutencao.MdiParent = this;
            frmTipoManutencao.Show();
        }

        private void btnLocalManutencao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MemoryManagement.FlushMemory();

            frmLocalManutencaoConsultar frmLocalManutencao = new frmLocalManutencaoConsultar();
            frmLocalManutencao.MdiParent = this;
            frmLocalManutencao.Show();
        }

        private void btnRegistrarKmDiario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FechaForms();

            frmRegistrarKmDiario frmRegistrarKmDiario = new frmRegistrarKmDiario();
            frmRegistrarKmDiario.Owner = this;
            frmRegistrarKmDiario.ShowDialog();
        }

        private void btnRegistrarManutencao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FechaForms();

            frmManutencaoRegistrar frmManutencaoRegistrar = new frmManutencaoRegistrar();
            frmManutencaoRegistrar.Owner = this;
            frmManutencaoRegistrar.ShowDialog();
        }

        private void btnRegistrarAbastecimento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnPainelBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MemoryManagement.FlushMemory();

            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnManutencoesRealizadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MemoryManagement.FlushMemory();

            frmManutencaoConsultar frmManutencaoConsultar = new frmManutencaoConsultar();
            frmManutencaoConsultar.MdiParent = this;
            frmManutencaoConsultar.Show();
        }

        private void btnAbastecimentosRealizados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnRegistrarAtaAgente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVerAtasFechadasAgente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegistrarAtaOperador_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVerAtasFechadasOperador_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPerfilUsuario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MemoryManagement.FlushMemory();

            frmUsuarioPerfilConsultar frmUsuarioPerfilConsultar = new frmUsuarioPerfilConsultar();
            frmUsuarioPerfilConsultar.MdiParent = this;
            frmUsuarioPerfilConsultar.Show();
        }

        private void btnUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnProxTrocaOleoRevisao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MemoryManagement.FlushMemory();

            frmProxTrocaOleoRevisao frmProxTrocaOleoRevisao = new frmProxTrocaOleoRevisao();
            frmProxTrocaOleoRevisao.Owner = this;
            frmProxTrocaOleoRevisao.ShowDialog();
        }
        #endregion


    }
}
