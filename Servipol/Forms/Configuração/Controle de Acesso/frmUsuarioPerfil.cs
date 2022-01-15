using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace Servipol.Forms.Configuração.Controle_de_Acesso
{
    public partial class frmUsuarioPerfil : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public string TipoChamada { get; set; }
        public int IdUsuarioPerfil { get; set; }
        public string PermissaoUsuario { get; set; }
        public string PermissaoPerfil { get; set; }
        #endregion

        public frmUsuarioPerfil(string tipoChamada, int _IdUsuarioPerfil)
        {
            TipoChamada = tipoChamada;
            IdUsuarioPerfil = _IdUsuarioPerfil;

            InitializeComponent();
        }

        private void frmUsuarioPerfil_Load(object sender, EventArgs e)
        {
            BloqueiaTudo(this);

            if (TipoChamada == "Editar")
            {
                CarregaPermissoesUsuario();
            }

            if (TipoChamada == "frmIncluirUsuario")
            {
                gbDescricaoPerfil.Enabled = false;
                gbDescricaoPerfil.Visible = false;
                tBoxDescricao.Enabled = false;
                tBoxDescricao.Visible = false;

                gbSelecionarPerfil.Enabled = true;
                gbSelecionarPerfil.Visible = true;
                cBoxPerfil.Enabled = true;
                cBoxPerfil.Visible = true;

                CarregaPerfil();
                cBoxPerfil.SelectedIndex = -1;
                cBoxPerfil.Focus();

                XtraMessageBox.Show("Agora defina as permissões do novo usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancelar.Visible = false;
            }
            tBoxDescricao.Focus();
        }

        #region Methods

        public void CarregaPerfil()
        {
            try
            {
                BD.Conectar();

                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = "SELECT id_controle_permissao_perfil, descricao FROM controle_permissao_perfil WHERE registro_excluido = 'N' ORDER BY 1";
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cBoxPerfil.ValueMember = "id_controle_permissao_perfil";
                    cBoxPerfil.DisplayMember = "descricao";
                    cBoxPerfil.DataSource = dt;
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaPermissoesUsuario()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand($"SELECT permissao FROM controle_permissao WHERE id_usuario = {IdUsuarioPerfil}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PermissaoUsuario = dr["permissao"].ToString();
                    }
                }

                //1	- Acessar Usuários
                if (PermissaoUsuario.Substring(0, 1) == "S") { chkBoxAcessarUsuarios.Checked = true; } else { chkBoxAcessarUsuarios.Checked = false; }

                //2	- Incluir Usuário
                if (PermissaoUsuario.Substring(1, 1) == "S") { chkBoxIncluirUsuarios.Checked = true; } else { chkBoxIncluirUsuarios.Checked = false; }

                //3	- Editar Usuário
                if (PermissaoUsuario.Substring(2, 1) == "S") { chkBoxEditarUsuarios.Checked = true; } else { chkBoxEditarUsuarios.Checked = false; }

                //4	- Inativar / Reativar Usuário
                if (PermissaoUsuario.Substring(3, 1) == "S") { chkBoxInativarReativarUsuarios.Checked = true; } else { chkBoxInativarReativarUsuarios.Checked = false; }

                //5	- Resetar Senha
                if (PermissaoUsuario.Substring(4, 1) == "S") { chkBoxResetarSenhaUsuarios.Checked = true; } else { chkBoxResetarSenhaUsuarios.Checked = false; }

                //6	- Alterar Permissões
                if (PermissaoUsuario.Substring(5, 1) == "S") { chkBoxAlterarPermissaoUsuarios.Checked = true; } else { chkBoxAlterarPermissaoUsuarios.Checked = false; }

                //7	- Acessar Funcionários
                if (PermissaoUsuario.Substring(6, 1) == "S") { chkBoxAcessarFuncionarios.Checked = true; } else { chkBoxAcessarFuncionarios.Checked = false; }

                //8	- Incluir Funcionário
                if (PermissaoUsuario.Substring(7, 1) == "S") { chkBoxIncluirFuncionarios.Checked = true; } else { chkBoxIncluirFuncionarios.Checked = false; }

                //9	- Editar Funcionário
                if (PermissaoUsuario.Substring(8, 1) == "S") { chkBoxEditarFuncionarios.Checked = true; } else { chkBoxEditarFuncionarios.Checked = false; }

                //10 - Inativar / Reativar Funcionário
                if (PermissaoUsuario.Substring(9, 1) == "S") { funciona.Checked = true; } else { chkBoxExcluirFuncionarios.Checked = false; }

                //11 - Visualizar Cadastro Completo
                if (PermissaoUsuario.Substring(10, 1) == "S") { chkBoxVisualizarCadCompletoFunc.Checked = true; } else { chkBoxVisualizarCadCompletoFunc.Checked = false; }

                //12 - Acessar Veículos
                if (PermissaoUsuario.Substring(11, 1) == "S") { chkBoxAcessarVeiculos.Checked = true; } else { chkBoxAcessarVeiculos.Checked = false; }

                //13 - Incluir Veículo
                if (PermissaoUsuario.Substring(12, 1) == "S") { chkBoxIncluirVeiculos.Checked = true; } else { chkBoxIncluirVeiculos.Checked = false; }

                //14 - Editar Veículo
                if (PermissaoUsuario.Substring(13, 1) == "S") { chkBoxEditarVeiculos.Checked = true; } else { chkBoxEditarVeiculos.Checked = false; }

                //15 - Inativar / Reativar Veículo
                if (PermissaoUsuario.Substring(14, 1) == "S") { chkBoxExcluirVeiculos.Checked = true; } else { chkBoxExcluirVeiculos.Checked = false; }

                //16 - Acessar Tipo de Manutenção
                if (PermissaoUsuario.Substring(15, 1) == "S") { chkBoxAcessarTipoManutencao.Checked = true; } else { chkBoxAcessarTipoManutencao.Checked = false; }

                //17 - Incluir Tipo de Manutenção
                if (PermissaoUsuario.Substring(16, 1) == "S") { chkBoxIncluirTipoManutencao.Checked = true; } else { chkBoxIncluirTipoManutencao.Checked = false; }

                //18 - Editar Tipo de Manutenção
                if (PermissaoUsuario.Substring(17, 1) == "S") { chkBoxEditarTipoManutencao.Checked = true; } else { chkBoxEditarTipoManutencao.Checked = false; }

                //19 - Excluir Tipo de Manutenção
                if (PermissaoUsuario.Substring(18, 1) == "S") { chkBoxExcluirTipoManutencao.Checked = true; } else { chkBoxExcluirTipoManutencao.Checked = false; }

                //20 - Acessar Local de Manutenção
                if (PermissaoUsuario.Substring(19, 1) == "S") { chkBoxAcessarLocalManutencao.Checked = true; } else { chkBoxAcessarLocalManutencao.Checked = false; }

                //21 - Incluir Local de Manutenção
                if (PermissaoUsuario.Substring(20, 1) == "S") { chkBoxIncluirLocalManutencao.Checked = true; } else { chkBoxIncluirLocalManutencao.Checked = false; }

                //22 - Editar Local de Manutenção
                if (PermissaoUsuario.Substring(21, 1) == "S") { chkBoxEditarLocalManutencao.Checked = true; } else { chkBoxEditarLocalManutencao.Checked = false; }

                //23 - Excluir Local de Manutenção
                if (PermissaoUsuario.Substring(22, 1) == "S") { chkBoxExcluirLocalManutencao.Checked = true; } else { chkBoxExcluirLocalManutencao.Checked = false; }

                //24 - Acessar Recados
                if (PermissaoUsuario.Substring(23, 1) == "S") { chkBoxAcessarRecado.Checked = true; } else { chkBoxAcessarRecado.Checked = false; }

                //25 - Incluir Recado
                if (PermissaoUsuario.Substring(24, 1) == "S") { chkBoxIncluirRecado.Checked = true; } else { chkBoxIncluirRecado.Checked = false; }

                //26 - Editar Recado
                if (PermissaoUsuario.Substring(25, 1) == "S") { chkBoxEditarRecado.Checked = true; } else { chkBoxEditarRecado.Checked = false; }

                //27 - Excluir Recado
                if (PermissaoUsuario.Substring(26, 1) == "S") { chkBoxExcluirRecado.Checked = true; } else { chkBoxExcluirRecado.Checked = false; }

                //28 - Registrar Manutenção
                if (PermissaoUsuario.Substring(27, 1) == "S") { chkBoxRegistrarManutencao.Checked = true; } else { chkBoxRegistrarManutencao.Checked = false; }

                //29 - Visualizar Próximas Trocas de Óleo
                if (PermissaoUsuario.Substring(28, 1) == "S") { chkBoxProxTrocasOleo.Checked = true; } else { chkBoxProxTrocasOleo.Checked = false; }

                //30 - Visualizar Manutenções Realizadas
                if (PermissaoUsuario.Substring(29, 1) == "S") { chkBoxManutencoesRealizadas.Checked = true; } else { chkBoxManutencoesRealizadas.Checked = false; }

                //31 - Excluir Manutenção Realizada
                if (PermissaoUsuario.Substring(30, 1) == "S") { chkBoxExcluirManutencaoRealizada.Checked = true; } else { chkBoxExcluirManutencaoRealizada.Checked = false; }

                //32 - Abrir ATA
                if (PermissaoUsuario.Substring(31, 1) == "S") { chkBoxAbrirATA.Checked = true; } else { chkBoxAbrirATA.Checked = false; }

                //33 - Fechar ATA
                if (PermissaoUsuario.Substring(32, 1) == "S") { chkBoxFecharATA.Checked = true; } else { chkBoxFecharATA.Checked = false; }

                //34 - Visualizar ATAs Fechadas
                if (PermissaoUsuario.Substring(33, 1) == "S") { chkBoxATAsFinalizadas.Checked = true; } else { chkBoxATAsFinalizadas.Checked = false; }

            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void BloqueiaTudo(Control parent)
        {
            foreach (Control cont in parent.Controls)
            {
                if (cont is CheckBox)
                    (cont as CheckBox).Checked = false;

                this.BloqueiaTudo(cont);
            }
        }

        public void LiberaTudo(Control parent)
        {
            foreach (Control cont in parent.Controls)
            {
                if (cont is CheckBox)
                    (cont as CheckBox).Checked = true;

                this.LiberaTudo(cont);
            }
        }


        #endregion

        private void cBoxPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}