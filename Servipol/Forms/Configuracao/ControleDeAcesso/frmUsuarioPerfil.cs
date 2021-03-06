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
        public int IdPermissao { get; set; }
        public string Login { get; set; }
        public string PermissaoUsuario { get; set; }
        public string PermissaoPerfil { get; set; }
        public string RegistroAtivo { get; set; }

        #endregion

        public frmUsuarioPerfil(string tipoChamada, string _login, int _IdPermissao)
        {
            TipoChamada = tipoChamada;
            IdPermissao = _IdPermissao;
            Login = _login;

            InitializeComponent();
        }

        private void frmUsuarioPerfil_Load(object sender, EventArgs e)
        {
            try
            {
                BloqueiaTudo(this);
                VerificaTipoChamada();
            }
            finally
            {
                tBoxDescricao.Focus();
            }
        }

        #region Methods

        private void VerificaTipoChamada()
        {
            if (TipoChamada == "Editar")
            {
                gbDescricaoPerfil.Enabled = true;
                gbDescricaoPerfil.Visible = true;
                tBoxDescricao.Enabled = true;
                tBoxDescricao.Visible = true;

                gbSelecionarPerfil.Enabled = false;
                gbSelecionarPerfil.Visible = false;
                cBoxPerfil.Enabled = false;
                cBoxPerfil.Visible = false;

                CarregaPermissaoPerfilEditar();

                this.Text = "Definindo as permissões do Perfil";
            }

            if (TipoChamada == "Incluir")
            {
                tabDadosRegistro.Parent = null;

                gbDescricaoPerfil.Enabled = true;
                gbDescricaoPerfil.Visible = true;
                tBoxDescricao.Enabled = true;
                tBoxDescricao.Visible = true;

                gbSelecionarPerfil.Enabled = false;
                gbSelecionarPerfil.Visible = false;
                cBoxPerfil.Enabled = false;
                cBoxPerfil.Visible = false;

                this.Text = "Cadastrando um novo Perfil";
            }

            if (TipoChamada == "frmIncluirUsuario")
            {
                tabDadosRegistro.Parent = null;

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

                this.Text = $"Definindo as permissões do usuário: {Login}";
            }

            if (TipoChamada == "frmUsuariosEditarPermissoes")
            {
                gbDadosExclusaoRegistro.Visible = false;

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

                CarregaPermissaoUsuario();

                this.Text = $"Definindo as permissões do usuário: {Login}";
            }
        }

        public void CarregaPerfil()
        {
            try
            {
                BD.Conectar();

                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = "SELECT id_controle_permissao_perfil, descricao FROM controle_permissao_perfil WHERE ativo = 'S' ORDER BY 1";
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

        public void CarregaPermissaoUsuario()
        {
            try
            {
                BD.Conectar();

                NpgsqlCommand com = new NpgsqlCommand($"SELECT cp.permissao, uc.nome AS usuario_cadastro, cp.data_cadastro, ua.nome AS usuario_alteracao, cp.data_alteracao FROM controle_permissao AS cp INNER JOIN usuario AS uc ON(uc.id_usuario = cp.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = cp.id_usuario_alteracao) WHERE cp.id_usuario = {IdPermissao}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PermissaoUsuario = dr["permissao"].ToString();

                        //Dados do Registro
                        tBoxUsuarioCadastro.Text = dr["usuario_cadastro"].ToString();
                        tBoxDataCadastro.Text = dr["data_cadastro"].ToString();
                        tBoxUsuarioAlteracao.Text = dr["usuario_alteracao"].ToString();
                        tBoxDataAlteracao.Text = dr["data_alteracao"].ToString();
                    }
                }

                #region Set permission to checkbox

                //0	- Acessar Parâmetros do Sistema
                if (PermissaoUsuario.Substring(0, 1) == "S") { chkBoxAcessarParametrosSistema.Checked = true; } else { chkBoxAcessarParametrosSistema.Checked = false; }

                //1	- Editar Parâmetros do Sistema
                if (PermissaoUsuario.Substring(1, 1) == "S") { chkBoxEditarParametrosSistema.Checked = true; } else { chkBoxEditarParametrosSistema.Checked = false; }

                //2	- Acessar Perfil
                if (PermissaoUsuario.Substring(2, 1) == "S") { chkBoxAcessarPerfil.Checked = true; } else { chkBoxAcessarPerfil.Checked = false; }

                //3	- Incluir Perfil
                if (PermissaoUsuario.Substring(3, 1) == "S") { chkBoxIncluirPerfil.Checked = true; } else { chkBoxIncluirPerfil.Checked = false; }

                //4	- Editar Perfil
                if (PermissaoUsuario.Substring(4, 1) == "S") { chkBoxEditarPerfil.Checked = true; } else { chkBoxEditarPerfil.Checked = false; }

                //5	- Excluir Perfil
                if (PermissaoUsuario.Substring(5, 1) == "S") { chkBoxExcluirPerfil.Checked = true; } else { chkBoxExcluirPerfil.Checked = false; }

                //6	- Acessar Usuários
                if (PermissaoUsuario.Substring(6, 1) == "S") { chkBoxAcessarUsuarios.Checked = true; } else { chkBoxAcessarUsuarios.Checked = false; }

                //7	- Incluir Usuários
                if (PermissaoUsuario.Substring(7, 1) == "S") { chkBoxIncluirUsuarios.Checked = true; } else { chkBoxIncluirUsuarios.Checked = false; }

                //8	- Editar Usuários
                if (PermissaoUsuario.Substring(8, 1) == "S") { chkBoxEditarUsuarios.Checked = true; } else { chkBoxEditarUsuarios.Checked = false; }

                //9	- Inativar / Reativar Usuários
                if (PermissaoUsuario.Substring(9, 1) == "S") { chkBoxInativarReativarUsuarios.Checked = true; } else { chkBoxInativarReativarUsuarios.Checked = false; }

                //10 - Resetar Senha
                if (PermissaoUsuario.Substring(10, 1) == "S") { chkBoxResetarSenhaUsuarios.Checked = true; } else { chkBoxResetarSenhaUsuarios.Checked = false; }

                //11 - Alterar Permissões
                if (PermissaoUsuario.Substring(11, 1) == "S") { chkBoxAlterarPermissaoUsuarios.Checked = true; } else { chkBoxAlterarPermissaoUsuarios.Checked = false; }

                //12 - Acessar Veículos
                if (PermissaoUsuario.Substring(12, 1) == "S") { chkBoxAcessarVeiculos.Checked = true; } else { chkBoxAcessarVeiculos.Checked = false; }

                //13 - Incluir Veículos
                if (PermissaoUsuario.Substring(13, 1) == "S") { chkBoxIncluirVeiculos.Checked = true; } else { chkBoxIncluirVeiculos.Checked = false; }

                //14 - Editar Veículos
                if (PermissaoUsuario.Substring(14, 1) == "S") { chkBoxEditarVeiculos.Checked = true; } else { chkBoxEditarVeiculos.Checked = false; }

                //15 - Inativar Veículos
                if (PermissaoUsuario.Substring(15, 1) == "S") { chkBoxInativarVeiculos.Checked = true; } else { chkBoxInativarVeiculos.Checked = false; }

                //16 - Acessar Funcionários
                if (PermissaoUsuario.Substring(16, 1) == "S") { chkBoxAcessarFuncionarios.Checked = true; } else { chkBoxAcessarFuncionarios.Checked = false; }

                //17 - Incluir Funcionários
                if (PermissaoUsuario.Substring(17, 1) == "S") { chkBoxIncluirFuncionarios.Checked = true; } else { chkBoxIncluirFuncionarios.Checked = false; }

                //18 - Editar Funcionários
                if (PermissaoUsuario.Substring(18, 1) == "S") { chkBoxEditarFuncionarios.Checked = true; } else { chkBoxEditarFuncionarios.Checked = false; }

                //19 - Visualizar Cadastro Completo Funcionários
                if (PermissaoUsuario.Substring(19, 1) == "S") { chkBoxVisualizarCadCompletoFunc.Checked = true; } else { chkBoxVisualizarCadCompletoFunc.Checked = false; }

                //20 - Acessar Tipo de Manutenção
                if (PermissaoUsuario.Substring(20, 1) == "S") { chkBoxAcessarTipoManutencao.Checked = true; } else { chkBoxAcessarTipoManutencao.Checked = false; }

                //21 - Incluir Tipo de Manutenção
                if (PermissaoUsuario.Substring(21, 1) == "S") { chkBoxIncluirTipoManutencao.Checked = true; } else { chkBoxIncluirTipoManutencao.Checked = false; }

                //22 - Editar Tipo de Manutenção
                if (PermissaoUsuario.Substring(22, 1) == "S") { chkBoxEditarTipoManutencao.Checked = true; } else { chkBoxEditarTipoManutencao.Checked = false; }

                //23 - Inativar Tipo de Manutenção
                if (PermissaoUsuario.Substring(23, 1) == "S") { chkBoxInativarTipoManutencao.Checked = true; } else { chkBoxInativarTipoManutencao.Checked = false; }

                //24 - Acessar Local de Manutenção
                if (PermissaoUsuario.Substring(24, 1) == "S") { chkBoxAcessarLocalManutencao.Checked = true; } else { chkBoxAcessarLocalManutencao.Checked = false; }

                //25 - Incluir Local de Manutenção
                if (PermissaoUsuario.Substring(25, 1) == "S") { chkBoxIncluirLocalManutencao.Checked = true; } else { chkBoxIncluirLocalManutencao.Checked = false; }

                //26 - Editar Local de Manutenção
                if (PermissaoUsuario.Substring(26, 1) == "S") { chkBoxEditarLocalManutencao.Checked = true; } else { chkBoxEditarLocalManutencao.Checked = false; }

                //27 - Inativar Local de Manutenção
                if (PermissaoUsuario.Substring(27, 1) == "S") { chkBoxInativarLocalManutencao.Checked = true; } else { chkBoxInativarLocalManutencao.Checked = false; }

                //28 - Registrar Manutenção
                if (PermissaoUsuario.Substring(28, 1) == "S") { chkBoxRegistrarManutencao.Checked = true; } else { chkBoxRegistrarManutencao.Checked = false; }

                //29 - Visualizar Manutenções Realizadas
                if (PermissaoUsuario.Substring(29, 1) == "S") { chkBoxManutencoesRealizadas.Checked = true; } else { chkBoxManutencoesRealizadas.Checked = false; }

                //30 - Excluir Manutenção Realizada
                if (PermissaoUsuario.Substring(30, 1) == "S") { chkBoxExcluirManutencaoRealizada.Checked = true; } else { chkBoxExcluirManutencaoRealizada.Checked = false; }

                //31 - Visualizar Próximas Trocas de Óleo
                if (PermissaoUsuario.Substring(31, 1) == "S") { chkBoxProxTrocaOleo.Checked = true; } else { chkBoxProxTrocaOleo.Checked = false; }

                //32 - Acessar Painel B.I.
                if (PermissaoUsuario.Substring(32, 1) == "S") { chkBoxPainelBI.Checked = true; } else { chkBoxPainelBI.Checked = false; }

                //33 - Acessar Equipamentos
                if (PermissaoUsuario.Substring(33, 1) == "S") { chkBoxAcessarEquipamentos.Checked = true; } else { chkBoxAcessarEquipamentos.Checked = false; }

                //34 - Incluir Equipamentos
                if (PermissaoUsuario.Substring(34, 1) == "S") { chkBoxIncluirEquipamentos.Checked = true; } else { chkBoxIncluirEquipamentos.Checked = false; }

                //35 - Editar Equipamentos
                if (PermissaoUsuario.Substring(35, 1) == "S") { chkBoxEditarEquipamentos.Checked = true; } else { chkBoxEditarEquipamentos.Checked = false; }

                //36 - Inativar Equipamentos
                if (PermissaoUsuario.Substring(36, 1) == "S") { chkBoxInativarEquipamentos.Checked = true; } else { chkBoxInativarEquipamentos.Checked = false; }

                //37 - Acessar Categoria de Equipamentos
                if (PermissaoUsuario.Substring(37, 1) == "S") { chkBoxAcessarCategoriaEquipamentos.Checked = true; } else { chkBoxAcessarCategoriaEquipamentos.Checked = false; }

                //38 - Incluir Categoria de Equipamentos
                if (PermissaoUsuario.Substring(38, 1) == "S") { chkBoxIncluirCategoriaEquip.Checked = true; } else { chkBoxIncluirCategoriaEquip.Checked = false; }

                //39 - Editar Categoria de Equipamentos
                if (PermissaoUsuario.Substring(39, 1) == "S") { chkBoxEditarCategoriaEquip.Checked = true; } else { chkBoxEditarCategoriaEquip.Checked = false; }

                //40 - Inativar Categoria de Equipamentos
                if (PermissaoUsuario.Substring(40, 1) == "S") { chkBoxInativarCategoriaEquip.Checked = true; } else { chkBoxInativarCategoriaEquip.Checked = false; }

                #endregion
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaPermissaoPerfil()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand($"SELECT cpp.descricao, cpp.permissao, uc.nome AS usuario_cadastro, cpp.data_cadastro, ua.nome AS usuario_alteracao, cpp.data_alteracao, ue.nome AS usuario_exclusao, cpp.data_exclusao FROM controle_permissao_perfil AS cpp INNER JOIN usuario AS uc ON(uc.id_usuario = cpp.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = cpp.id_usuario_alteracao) LEFT OUTER JOIN usuario AS ue ON(ue.id_usuario = cpp.id_usuario_exclusao) WHERE cpp.id_controle_permissao_perfil = {cBoxPerfil.SelectedValue}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PermissaoPerfil = dr["permissao"].ToString();
                        tBoxDescricao.Text = dr["descricao"].ToString();
                    }
                }

                #region Set permission to checkbox

                //0	- Acessar Parâmetros do Sistema
                if (PermissaoPerfil.Substring(0, 1) == "S") { chkBoxAcessarParametrosSistema.Checked = true; } else { chkBoxAcessarParametrosSistema.Checked = false; }

                //1	- Editar Parâmetros do Sistema
                if (PermissaoPerfil.Substring(1, 1) == "S") { chkBoxEditarParametrosSistema.Checked = true; } else { chkBoxEditarParametrosSistema.Checked = false; }

                //2	- Acessar Perfil
                if (PermissaoPerfil.Substring(2, 1) == "S") { chkBoxAcessarPerfil.Checked = true; } else { chkBoxAcessarPerfil.Checked = false; }

                //3	- Incluir Perfil
                if (PermissaoPerfil.Substring(3, 1) == "S") { chkBoxIncluirPerfil.Checked = true; } else { chkBoxIncluirPerfil.Checked = false; }

                //4	- Editar Perfil
                if (PermissaoPerfil.Substring(4, 1) == "S") { chkBoxEditarPerfil.Checked = true; } else { chkBoxEditarPerfil.Checked = false; }

                //5	- Excluir Perfil
                if (PermissaoPerfil.Substring(5, 1) == "S") { chkBoxExcluirPerfil.Checked = true; } else { chkBoxExcluirPerfil.Checked = false; }

                //6	- Acessar Usuários
                if (PermissaoPerfil.Substring(6, 1) == "S") { chkBoxAcessarUsuarios.Checked = true; } else { chkBoxAcessarUsuarios.Checked = false; }

                //7	- Incluir Usuários
                if (PermissaoPerfil.Substring(7, 1) == "S") { chkBoxIncluirUsuarios.Checked = true; } else { chkBoxIncluirUsuarios.Checked = false; }

                //8	- Editar Usuários
                if (PermissaoPerfil.Substring(8, 1) == "S") { chkBoxEditarUsuarios.Checked = true; } else { chkBoxEditarUsuarios.Checked = false; }

                //9	- Inativar / Reativar Usuários
                if (PermissaoPerfil.Substring(9, 1) == "S") { chkBoxInativarReativarUsuarios.Checked = true; } else { chkBoxInativarReativarUsuarios.Checked = false; }

                //10 - Resetar Senha
                if (PermissaoPerfil.Substring(10, 1) == "S") { chkBoxResetarSenhaUsuarios.Checked = true; } else { chkBoxResetarSenhaUsuarios.Checked = false; }

                //11 - Alterar Permissões
                if (PermissaoPerfil.Substring(11, 1) == "S") { chkBoxAlterarPermissaoUsuarios.Checked = true; } else { chkBoxAlterarPermissaoUsuarios.Checked = false; }

                //12 - Acessar Veículos
                if (PermissaoPerfil.Substring(12, 1) == "S") { chkBoxAcessarVeiculos.Checked = true; } else { chkBoxAcessarVeiculos.Checked = false; }

                //13 - Incluir Veículos
                if (PermissaoPerfil.Substring(13, 1) == "S") { chkBoxIncluirVeiculos.Checked = true; } else { chkBoxIncluirVeiculos.Checked = false; }

                //14 - Editar Veículos
                if (PermissaoPerfil.Substring(14, 1) == "S") { chkBoxEditarVeiculos.Checked = true; } else { chkBoxEditarVeiculos.Checked = false; }

                //15 - Inativar Veículos
                if (PermissaoPerfil.Substring(15, 1) == "S") { chkBoxInativarVeiculos.Checked = true; } else { chkBoxInativarVeiculos.Checked = false; }

                //16 - Acessar Funcionários
                if (PermissaoPerfil.Substring(16, 1) == "S") { chkBoxAcessarFuncionarios.Checked = true; } else { chkBoxAcessarFuncionarios.Checked = false; }

                //17 - Incluir Funcionários
                if (PermissaoPerfil.Substring(17, 1) == "S") { chkBoxIncluirFuncionarios.Checked = true; } else { chkBoxIncluirFuncionarios.Checked = false; }

                //18 - Editar Funcionários
                if (PermissaoPerfil.Substring(18, 1) == "S") { chkBoxEditarFuncionarios.Checked = true; } else { chkBoxEditarFuncionarios.Checked = false; }

                //19 - Visualizar Cadastro Completo Funcionários
                if (PermissaoPerfil.Substring(19, 1) == "S") { chkBoxVisualizarCadCompletoFunc.Checked = true; } else { chkBoxVisualizarCadCompletoFunc.Checked = false; }

                //20 - Acessar Tipo de Manutenção
                if (PermissaoPerfil.Substring(20, 1) == "S") { chkBoxAcessarTipoManutencao.Checked = true; } else { chkBoxAcessarTipoManutencao.Checked = false; }

                //21 - Incluir Tipo de Manutenção
                if (PermissaoPerfil.Substring(21, 1) == "S") { chkBoxIncluirTipoManutencao.Checked = true; } else { chkBoxIncluirTipoManutencao.Checked = false; }

                //22 - Editar Tipo de Manutenção
                if (PermissaoPerfil.Substring(22, 1) == "S") { chkBoxEditarTipoManutencao.Checked = true; } else { chkBoxEditarTipoManutencao.Checked = false; }

                //23 - Inativar Tipo de Manutenção
                if (PermissaoPerfil.Substring(23, 1) == "S") { chkBoxInativarTipoManutencao.Checked = true; } else { chkBoxInativarTipoManutencao.Checked = false; }

                //24 - Acessar Local de Manutenção
                if (PermissaoPerfil.Substring(24, 1) == "S") { chkBoxAcessarLocalManutencao.Checked = true; } else { chkBoxAcessarLocalManutencao.Checked = false; }

                //25 - Incluir Local de Manutenção
                if (PermissaoPerfil.Substring(25, 1) == "S") { chkBoxIncluirLocalManutencao.Checked = true; } else { chkBoxIncluirLocalManutencao.Checked = false; }

                //26 - Editar Local de Manutenção
                if (PermissaoPerfil.Substring(26, 1) == "S") { chkBoxEditarLocalManutencao.Checked = true; } else { chkBoxEditarLocalManutencao.Checked = false; }

                //27 - Inativar Local de Manutenção
                if (PermissaoPerfil.Substring(27, 1) == "S") { chkBoxInativarLocalManutencao.Checked = true; } else { chkBoxInativarLocalManutencao.Checked = false; }

                //28 - Registrar Manutenção
                if (PermissaoPerfil.Substring(28, 1) == "S") { chkBoxRegistrarManutencao.Checked = true; } else { chkBoxRegistrarManutencao.Checked = false; }

                //29 - Visualizar Manutenções Realizadas
                if (PermissaoPerfil.Substring(29, 1) == "S") { chkBoxManutencoesRealizadas.Checked = true; } else { chkBoxManutencoesRealizadas.Checked = false; }

                //30 - Excluir Manutenção Realizada
                if (PermissaoPerfil.Substring(30, 1) == "S") { chkBoxExcluirManutencaoRealizada.Checked = true; } else { chkBoxExcluirManutencaoRealizada.Checked = false; }

                //31 - Visualizar Próximas Trocas de Óleo
                if (PermissaoPerfil.Substring(31, 1) == "S") { chkBoxProxTrocaOleo.Checked = true; } else { chkBoxProxTrocaOleo.Checked = false; }

                //32 - Acessar Painel B.I.
                if (PermissaoPerfil.Substring(32, 1) == "S") { chkBoxPainelBI.Checked = true; } else { chkBoxPainelBI.Checked = false; }

                //33 - Acessar Equipamentos
                if (PermissaoPerfil.Substring(33, 1) == "S") { chkBoxAcessarEquipamentos.Checked = true; } else { chkBoxAcessarEquipamentos.Checked = false; }

                //34 - Incluir Equipamentos
                if (PermissaoPerfil.Substring(34, 1) == "S") { chkBoxIncluirEquipamentos.Checked = true; } else { chkBoxIncluirEquipamentos.Checked = false; }

                //35 - Editar Equipamentos
                if (PermissaoPerfil.Substring(35, 1) == "S") { chkBoxEditarEquipamentos.Checked = true; } else { chkBoxEditarEquipamentos.Checked = false; }

                //36 - Inativar Equipamentos
                if (PermissaoPerfil.Substring(36, 1) == "S") { chkBoxInativarEquipamentos.Checked = true; } else { chkBoxInativarEquipamentos.Checked = false; }

                //37 - Acessar Categoria de Equipamentos
                if (PermissaoPerfil.Substring(37, 1) == "S") { chkBoxAcessarCategoriaEquipamentos.Checked = true; } else { chkBoxAcessarCategoriaEquipamentos.Checked = false; }

                //38 - Incluir Categoria de Equipamentos
                if (PermissaoPerfil.Substring(38, 1) == "S") { chkBoxIncluirCategoriaEquip.Checked = true; } else { chkBoxIncluirCategoriaEquip.Checked = false; }

                //39 - Editar Categoria de Equipamentos
                if (PermissaoPerfil.Substring(39, 1) == "S") { chkBoxEditarCategoriaEquip.Checked = true; } else { chkBoxEditarCategoriaEquip.Checked = false; }

                //40 - Inativar Categoria de Equipamentos
                if (PermissaoPerfil.Substring(40, 1) == "S") { chkBoxInativarCategoriaEquip.Checked = true; } else { chkBoxInativarCategoriaEquip.Checked = false; }

                #endregion
            }
            catch { }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaPermissaoPerfilEditar()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand($"SELECT cpp.descricao, cpp.permissao, cpp.ativo, uc.nome AS usuario_cadastro, cpp.data_cadastro, ua.nome AS usuario_alteracao, cpp.data_alteracao, ue.nome AS usuario_exclusao, cpp.data_exclusao FROM controle_permissao_perfil AS cpp INNER JOIN usuario AS uc ON(uc.id_usuario = cpp.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = cpp.id_usuario_alteracao) LEFT OUTER JOIN usuario AS ue ON(ue.id_usuario = cpp.id_usuario_exclusao) WHERE cpp.id_controle_permissao_perfil = {IdPermissao}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PermissaoPerfil = dr["permissao"].ToString();
                        tBoxDescricao.Text = dr["descricao"].ToString();
                        RegistroAtivo = dr["ativo"].ToString();

                        //Dados do Registro
                        tBoxUsuarioCadastro.Text = dr["usuario_cadastro"].ToString();
                        tBoxDataCadastro.Text = dr["data_cadastro"].ToString();
                        tBoxUsuarioAlteracao.Text = dr["usuario_alteracao"].ToString();
                        tBoxDataAlteracao.Text = dr["data_alteracao"].ToString();
                        tBoxUsuarioExclusao.Text = dr["usuario_exclusao"].ToString();
                        tBoxDataExclusao.Text = dr["data_exclusao"].ToString();
                    }

                    if (RegistroAtivo == "N")
                    {
                        btnConfirmar.Enabled = false;
                        btnLiberarTudo.Enabled = false;
                        btnBloquearTudo.Enabled = false;

                        tBoxDescricao.Enabled = false;
                        gbParametroSistema.Enabled = false;
                        gbPerfilUsuarios.Enabled = false;
                        gbVeiculos.Enabled = false;
                        gbFuncionarios.Enabled = false;
                        gbTipoDeManutencao.Enabled = false;
                        gbLocalDeManutencao.Enabled = false;
                        gbManutencaoDeVeiculo.Enabled = false;
                        gbEquipamentos.Enabled = false;

                        btnCancelar.Select();
                    }
                }

                #region Set permission to checkbox

                //0	- Acessar Parâmetros do Sistema
                if (PermissaoPerfil.Substring(0, 1) == "S") { chkBoxAcessarParametrosSistema.Checked = true; } else { chkBoxAcessarParametrosSistema.Checked = false; }

                //1	- Editar Parâmetros do Sistema
                if (PermissaoPerfil.Substring(1, 1) == "S") { chkBoxEditarParametrosSistema.Checked = true; } else { chkBoxEditarParametrosSistema.Checked = false; }

                //2	- Acessar Perfil
                if (PermissaoPerfil.Substring(2, 1) == "S") { chkBoxAcessarPerfil.Checked = true; } else { chkBoxAcessarPerfil.Checked = false; }

                //3	- Incluir Perfil
                if (PermissaoPerfil.Substring(3, 1) == "S") { chkBoxIncluirPerfil.Checked = true; } else { chkBoxIncluirPerfil.Checked = false; }

                //4	- Editar Perfil
                if (PermissaoPerfil.Substring(4, 1) == "S") { chkBoxEditarPerfil.Checked = true; } else { chkBoxEditarPerfil.Checked = false; }

                //5	- Excluir Perfil
                if (PermissaoPerfil.Substring(5, 1) == "S") { chkBoxExcluirPerfil.Checked = true; } else { chkBoxExcluirPerfil.Checked = false; }

                //6	- Acessar Usuários
                if (PermissaoPerfil.Substring(6, 1) == "S") { chkBoxAcessarUsuarios.Checked = true; } else { chkBoxAcessarUsuarios.Checked = false; }

                //7	- Incluir Usuários
                if (PermissaoPerfil.Substring(7, 1) == "S") { chkBoxIncluirUsuarios.Checked = true; } else { chkBoxIncluirUsuarios.Checked = false; }

                //8	- Editar Usuários
                if (PermissaoPerfil.Substring(8, 1) == "S") { chkBoxEditarUsuarios.Checked = true; } else { chkBoxEditarUsuarios.Checked = false; }

                //9	- Inativar / Reativar Usuários
                if (PermissaoPerfil.Substring(9, 1) == "S") { chkBoxInativarReativarUsuarios.Checked = true; } else { chkBoxInativarReativarUsuarios.Checked = false; }

                //10 - Resetar Senha
                if (PermissaoPerfil.Substring(10, 1) == "S") { chkBoxResetarSenhaUsuarios.Checked = true; } else { chkBoxResetarSenhaUsuarios.Checked = false; }

                //11 - Alterar Permissões
                if (PermissaoPerfil.Substring(11, 1) == "S") { chkBoxAlterarPermissaoUsuarios.Checked = true; } else { chkBoxAlterarPermissaoUsuarios.Checked = false; }

                //12 - Acessar Veículos
                if (PermissaoPerfil.Substring(12, 1) == "S") { chkBoxAcessarVeiculos.Checked = true; } else { chkBoxAcessarVeiculos.Checked = false; }

                //13 - Incluir Veículos
                if (PermissaoPerfil.Substring(13, 1) == "S") { chkBoxIncluirVeiculos.Checked = true; } else { chkBoxIncluirVeiculos.Checked = false; }

                //14 - Editar Veículos
                if (PermissaoPerfil.Substring(14, 1) == "S") { chkBoxEditarVeiculos.Checked = true; } else { chkBoxEditarVeiculos.Checked = false; }

                //15 - Inativar Veículos
                if (PermissaoPerfil.Substring(15, 1) == "S") { chkBoxInativarVeiculos.Checked = true; } else { chkBoxInativarVeiculos.Checked = false; }

                //16 - Acessar Funcionários
                if (PermissaoPerfil.Substring(16, 1) == "S") { chkBoxAcessarFuncionarios.Checked = true; } else { chkBoxAcessarFuncionarios.Checked = false; }

                //17 - Incluir Funcionários
                if (PermissaoPerfil.Substring(17, 1) == "S") { chkBoxIncluirFuncionarios.Checked = true; } else { chkBoxIncluirFuncionarios.Checked = false; }

                //18 - Editar Funcionários
                if (PermissaoPerfil.Substring(18, 1) == "S") { chkBoxEditarFuncionarios.Checked = true; } else { chkBoxEditarFuncionarios.Checked = false; }

                //19 - Visualizar Cadastro Completo Funcionários
                if (PermissaoPerfil.Substring(19, 1) == "S") { chkBoxVisualizarCadCompletoFunc.Checked = true; } else { chkBoxVisualizarCadCompletoFunc.Checked = false; }

                //20 - Acessar Tipo de Manutenção
                if (PermissaoPerfil.Substring(20, 1) == "S") { chkBoxAcessarTipoManutencao.Checked = true; } else { chkBoxAcessarTipoManutencao.Checked = false; }

                //21 - Incluir Tipo de Manutenção
                if (PermissaoPerfil.Substring(21, 1) == "S") { chkBoxIncluirTipoManutencao.Checked = true; } else { chkBoxIncluirTipoManutencao.Checked = false; }

                //22 - Editar Tipo de Manutenção
                if (PermissaoPerfil.Substring(22, 1) == "S") { chkBoxEditarTipoManutencao.Checked = true; } else { chkBoxEditarTipoManutencao.Checked = false; }

                //23 - Inativar Tipo de Manutenção
                if (PermissaoPerfil.Substring(23, 1) == "S") { chkBoxInativarTipoManutencao.Checked = true; } else { chkBoxInativarTipoManutencao.Checked = false; }

                //24 - Acessar Local de Manutenção
                if (PermissaoPerfil.Substring(24, 1) == "S") { chkBoxAcessarLocalManutencao.Checked = true; } else { chkBoxAcessarLocalManutencao.Checked = false; }

                //25 - Incluir Local de Manutenção
                if (PermissaoPerfil.Substring(25, 1) == "S") { chkBoxIncluirLocalManutencao.Checked = true; } else { chkBoxIncluirLocalManutencao.Checked = false; }

                //26 - Editar Local de Manutenção
                if (PermissaoPerfil.Substring(26, 1) == "S") { chkBoxEditarLocalManutencao.Checked = true; } else { chkBoxEditarLocalManutencao.Checked = false; }

                //27 - Inativar Local de Manutenção
                if (PermissaoPerfil.Substring(27, 1) == "S") { chkBoxInativarLocalManutencao.Checked = true; } else { chkBoxInativarLocalManutencao.Checked = false; }

                //28 - Registrar Manutenção
                if (PermissaoPerfil.Substring(28, 1) == "S") { chkBoxRegistrarManutencao.Checked = true; } else { chkBoxRegistrarManutencao.Checked = false; }

                //29 - Visualizar Manutenções Realizadas
                if (PermissaoPerfil.Substring(29, 1) == "S") { chkBoxManutencoesRealizadas.Checked = true; } else { chkBoxManutencoesRealizadas.Checked = false; }

                //30 - Excluir Manutenção Realizada
                if (PermissaoPerfil.Substring(30, 1) == "S") { chkBoxExcluirManutencaoRealizada.Checked = true; } else { chkBoxExcluirManutencaoRealizada.Checked = false; }

                //31 - Visualizar Próximas Trocas de Óleo
                if (PermissaoPerfil.Substring(31, 1) == "S") { chkBoxProxTrocaOleo.Checked = true; } else { chkBoxProxTrocaOleo.Checked = false; }

                //32 - Acessar Painel B.I.
                if (PermissaoPerfil.Substring(32, 1) == "S") { chkBoxPainelBI.Checked = true; } else { chkBoxPainelBI.Checked = false; }

                //33 - Acessar Equipamentos
                if (PermissaoPerfil.Substring(33, 1) == "S") { chkBoxAcessarEquipamentos.Checked = true; } else { chkBoxAcessarEquipamentos.Checked = false; }

                //34 - Incluir Equipamentos
                if (PermissaoPerfil.Substring(34, 1) == "S") { chkBoxIncluirEquipamentos.Checked = true; } else { chkBoxIncluirEquipamentos.Checked = false; }

                //35 - Editar Equipamentos
                if (PermissaoPerfil.Substring(35, 1) == "S") { chkBoxEditarEquipamentos.Checked = true; } else { chkBoxEditarEquipamentos.Checked = false; }

                //36 - Inativar Equipamentos
                if (PermissaoPerfil.Substring(36, 1) == "S") { chkBoxInativarEquipamentos.Checked = true; } else { chkBoxInativarEquipamentos.Checked = false; }

                //37 - Acessar Categoria de Equipamentos
                if (PermissaoPerfil.Substring(37, 1) == "S") { chkBoxAcessarCategoriaEquipamentos.Checked = true; } else { chkBoxAcessarCategoriaEquipamentos.Checked = false; }

                //38 - Incluir Categoria de Equipamentos
                if (PermissaoPerfil.Substring(38, 1) == "S") { chkBoxIncluirCategoriaEquip.Checked = true; } else { chkBoxIncluirCategoriaEquip.Checked = false; }

                //39 - Editar Categoria de Equipamentos
                if (PermissaoPerfil.Substring(39, 1) == "S") { chkBoxEditarCategoriaEquip.Checked = true; } else { chkBoxEditarCategoriaEquip.Checked = false; }

                //40 - Inativar Categoria de Equipamentos
                if (PermissaoPerfil.Substring(40, 1) == "S") { chkBoxInativarCategoriaEquip.Checked = true; } else { chkBoxInativarCategoriaEquip.Checked = false; }

                #endregion
            }
            catch { }
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

        private void cBoxPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaPermissaoPerfil();
        }

        private void frmUsuarioPerfil_KeyDown(object sender, KeyEventArgs e)
        {
            if (RegistroAtivo == "S" && e.KeyCode == Keys.F12)
            {
                btnConfirmar_Click(sender, e);
            }

            if (TipoChamada != "frmIncluirUsuario" && e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        #endregion

        #region Buttons

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLiberarTudo_Click(object sender, EventArgs e)
        {
            LiberaTudo(this);
            cBoxPerfil.SelectedIndex = -1;
        }

        private void btnBloquearTudo_Click(object sender, EventArgs e)
        {
            BloqueiaTudo(this);
            cBoxPerfil.SelectedIndex = -1;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();

                if (TipoChamada == "frmIncluirUsuario" && XtraMessageBox.Show("Confirmar alteração de permissões ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    #region Variáveis
                    string _acessarParametroSistema = chkBoxAcessarParametrosSistema.Checked ? "S" : "N";
                    string _editarParametroSistema = chkBoxEditarParametrosSistema.Checked ? "S" : "N";

                    string _acessarPerfil = chkBoxAcessarPerfil.Checked ? "S" : "N";
                    string _incluirPerfil = chkBoxIncluirPerfil.Checked ? "S" : "N";
                    string _editarPerfil = chkBoxEditarPerfil.Checked ? "S" : "N";
                    string _excluirPerfil = chkBoxExcluirPerfil.Checked ? "S" : "N";

                    string _acessarUsuario = chkBoxAcessarUsuarios.Checked ? "S" : "N";
                    string _incluirUsuario = chkBoxIncluirUsuarios.Checked ? "S" : "N";
                    string _editarUsuario = chkBoxEditarUsuarios.Checked ? "S" : "N";
                    string _inativarReativarUsuario = chkBoxInativarReativarUsuarios.Checked ? "S" : "N";
                    string _resetarSenhaUsuario = chkBoxResetarSenhaUsuarios.Checked ? "S" : "N";
                    string _alterarPermissaoUsuario = chkBoxAlterarPermissaoUsuarios.Checked ? "S" : "N";

                    string _acessarVeiculo = chkBoxAcessarVeiculos.Checked ? "S" : "N";
                    string _incluirVeiculo = chkBoxIncluirVeiculos.Checked ? "S" : "N";
                    string _editarVeiculo = chkBoxEditarVeiculos.Checked ? "S" : "N";
                    string _inativarVeiculo = chkBoxInativarVeiculos.Checked ? "S" : "N";

                    string _acessarFuncionario = chkBoxAcessarFuncionarios.Checked ? "S" : "N";
                    string _incluirFuncionario = chkBoxIncluirFuncionarios.Checked ? "S" : "N";
                    string _editarFuncionario = chkBoxEditarFuncionarios.Checked ? "S" : "N";
                    string _visualizarCadCompletoFuncionario = chkBoxVisualizarCadCompletoFunc.Checked ? "S" : "N";

                    string _acessarTipoManutencao = chkBoxAcessarTipoManutencao.Checked ? "S" : "N";
                    string _incluirTipoManutencao = chkBoxIncluirTipoManutencao.Checked ? "S" : "N";
                    string _editarTipoManutencao = chkBoxEditarTipoManutencao.Checked ? "S" : "N";
                    string _inativarTipoManutencao = chkBoxInativarTipoManutencao.Checked ? "S" : "N";

                    string _acessarLocalManutencao = chkBoxAcessarLocalManutencao.Checked ? "S" : "N";
                    string _incluirLocalManutencao = chkBoxIncluirLocalManutencao.Checked ? "S" : "N";
                    string _editarLocalManutencao = chkBoxEditarLocalManutencao.Checked ? "S" : "N";
                    string _inativarLocalManutencao = chkBoxInativarLocalManutencao.Checked ? "S" : "N";

                    string _registrarManutencao = chkBoxRegistrarManutencao.Checked ? "S" : "N";
                    string _visualizarManutencoesRealizadas = chkBoxManutencoesRealizadas.Checked ? "S" : "N";
                    string _excluirManutencaoRealizada = chkBoxExcluirManutencaoRealizada.Checked ? "S" : "N";
                    string _visualizarProxTrocaOleo = chkBoxProxTrocaOleo.Checked ? "S" : "N";
                    string _acessarPainelBI = chkBoxPainelBI.Checked ? "S" : "N";

                    string _acessarEquipamentos = chkBoxAcessarEquipamentos.Checked ? "S" : "N";
                    string _incluirEquipamentos = chkBoxIncluirEquipamentos.Checked ? "S" : "N";
                    string _editarEquipamentos = chkBoxEditarEquipamentos.Checked ? "S" : "N";
                    string _inativarEquipamentos = chkBoxInativarEquipamentos.Checked ? "S" : "N";
                    string _acessarCategoriaEquipamentos = chkBoxAcessarCategoriaEquipamentos.Checked ? "S" : "N";
                    string _incluirCategoriaEquipamentos = chkBoxIncluirCategoriaEquip.Checked ? "S" : "N";
                    string _editarCategoriaEquipamentos = chkBoxEditarCategoriaEquip.Checked ? "S" : "N";
                    string _inativarCategoriaEquipamentos = chkBoxInativarCategoriaEquip.Checked ? "S" : "N";

                    string novaPermissao = $"{_acessarParametroSistema}{_editarParametroSistema}{_acessarPerfil}{_incluirPerfil}{_editarPerfil}{_excluirPerfil}{_acessarUsuario}{_incluirUsuario}{_editarUsuario}{_inativarReativarUsuario}{_resetarSenhaUsuario}{_alterarPermissaoUsuario}{_acessarVeiculo}{_incluirVeiculo}{_editarVeiculo}{_inativarVeiculo}{_acessarFuncionario}{_incluirFuncionario}{_editarFuncionario}{_visualizarCadCompletoFuncionario}{_acessarTipoManutencao}{_incluirTipoManutencao}{_editarTipoManutencao}{_inativarTipoManutencao}{_acessarLocalManutencao}{_incluirLocalManutencao}{_editarLocalManutencao}{_inativarLocalManutencao}{_registrarManutencao}{_visualizarManutencoesRealizadas}{_excluirManutencaoRealizada}{_visualizarProxTrocaOleo}{_acessarPainelBI}{_acessarEquipamentos}{_incluirEquipamentos}{_editarEquipamentos}{_inativarEquipamentos}{_acessarCategoriaEquipamentos}{_incluirCategoriaEquipamentos}{_editarCategoriaEquipamentos}{_inativarCategoriaEquipamentos}";
                    #endregion

                    NpgsqlCommand update1 = new NpgsqlCommand($"INSERT INTO controle_permissao VALUES({IdPermissao}, '{novaPermissao}', {SessaoSistema.UserId}, CURRENT_TIMESTAMP, NULL, NULL, 'S')", BD.ObjetoConexao);
                    update1.ExecuteNonQuery();

                    XtraMessageBox.Show("Permissões alteradas com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                else if (TipoChamada == "frmUsuariosEditarPermissoes" && XtraMessageBox.Show("Confirmar alteração de permissões ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    #region Variáveis
                    string _acessarParametroSistema = chkBoxAcessarParametrosSistema.Checked ? "S" : "N";
                    string _editarParametroSistema = chkBoxEditarParametrosSistema.Checked ? "S" : "N";

                    string _acessarPerfil = chkBoxAcessarPerfil.Checked ? "S" : "N";
                    string _incluirPerfil = chkBoxIncluirPerfil.Checked ? "S" : "N";
                    string _editarPerfil = chkBoxEditarPerfil.Checked ? "S" : "N";
                    string _excluirPerfil = chkBoxExcluirPerfil.Checked ? "S" : "N";

                    string _acessarUsuario = chkBoxAcessarUsuarios.Checked ? "S" : "N";
                    string _incluirUsuario = chkBoxIncluirUsuarios.Checked ? "S" : "N";
                    string _editarUsuario = chkBoxEditarUsuarios.Checked ? "S" : "N";
                    string _inativarReativarUsuario = chkBoxInativarReativarUsuarios.Checked ? "S" : "N";
                    string _resetarSenhaUsuario = chkBoxResetarSenhaUsuarios.Checked ? "S" : "N";
                    string _alterarPermissaoUsuario = chkBoxAlterarPermissaoUsuarios.Checked ? "S" : "N";

                    string _acessarVeiculo = chkBoxAcessarVeiculos.Checked ? "S" : "N";
                    string _incluirVeiculo = chkBoxIncluirVeiculos.Checked ? "S" : "N";
                    string _editarVeiculo = chkBoxEditarVeiculos.Checked ? "S" : "N";
                    string _inativarVeiculo = chkBoxInativarVeiculos.Checked ? "S" : "N";

                    string _acessarFuncionario = chkBoxAcessarFuncionarios.Checked ? "S" : "N";
                    string _incluirFuncionario = chkBoxIncluirFuncionarios.Checked ? "S" : "N";
                    string _editarFuncionario = chkBoxEditarFuncionarios.Checked ? "S" : "N";
                    string _visualizarCadCompletoFuncionario = chkBoxVisualizarCadCompletoFunc.Checked ? "S" : "N";

                    string _acessarTipoManutencao = chkBoxAcessarTipoManutencao.Checked ? "S" : "N";
                    string _incluirTipoManutencao = chkBoxIncluirTipoManutencao.Checked ? "S" : "N";
                    string _editarTipoManutencao = chkBoxEditarTipoManutencao.Checked ? "S" : "N";
                    string _inativarTipoManutencao = chkBoxInativarTipoManutencao.Checked ? "S" : "N";

                    string _acessarLocalManutencao = chkBoxAcessarLocalManutencao.Checked ? "S" : "N";
                    string _incluirLocalManutencao = chkBoxIncluirLocalManutencao.Checked ? "S" : "N";
                    string _editarLocalManutencao = chkBoxEditarLocalManutencao.Checked ? "S" : "N";
                    string _inativarLocalManutencao = chkBoxInativarLocalManutencao.Checked ? "S" : "N";

                    string _registrarManutencao = chkBoxRegistrarManutencao.Checked ? "S" : "N";
                    string _visualizarManutencoesRealizadas = chkBoxManutencoesRealizadas.Checked ? "S" : "N";
                    string _excluirManutencaoRealizada = chkBoxExcluirManutencaoRealizada.Checked ? "S" : "N";
                    string _visualizarProxTrocaOleo = chkBoxProxTrocaOleo.Checked ? "S" : "N";
                    string _acessarPainelBI = chkBoxPainelBI.Checked ? "S" : "N";

                    string _acessarEquipamentos = chkBoxAcessarEquipamentos.Checked ? "S" : "N";
                    string _incluirEquipamentos = chkBoxIncluirEquipamentos.Checked ? "S" : "N";
                    string _editarEquipamentos = chkBoxEditarEquipamentos.Checked ? "S" : "N";
                    string _inativarEquipamentos = chkBoxInativarEquipamentos.Checked ? "S" : "N";
                    string _acessarCategoriaEquipamentos = chkBoxAcessarCategoriaEquipamentos.Checked ? "S" : "N";
                    string _incluirCategoriaEquipamentos = chkBoxIncluirCategoriaEquip.Checked ? "S" : "N";
                    string _editarCategoriaEquipamentos = chkBoxEditarCategoriaEquip.Checked ? "S" : "N";
                    string _inativarCategoriaEquipamentos = chkBoxInativarCategoriaEquip.Checked ? "S" : "N";

                    string novaPermissao = $"{_acessarParametroSistema}{_editarParametroSistema}{_acessarPerfil}{_incluirPerfil}{_editarPerfil}{_excluirPerfil}{_acessarUsuario}{_incluirUsuario}{_editarUsuario}{_inativarReativarUsuario}{_resetarSenhaUsuario}{_alterarPermissaoUsuario}{_acessarVeiculo}{_incluirVeiculo}{_editarVeiculo}{_inativarVeiculo}{_acessarFuncionario}{_incluirFuncionario}{_editarFuncionario}{_visualizarCadCompletoFuncionario}{_acessarTipoManutencao}{_incluirTipoManutencao}{_editarTipoManutencao}{_inativarTipoManutencao}{_acessarLocalManutencao}{_incluirLocalManutencao}{_editarLocalManutencao}{_inativarLocalManutencao}{_registrarManutencao}{_visualizarManutencoesRealizadas}{_excluirManutencaoRealizada}{_visualizarProxTrocaOleo}{_acessarPainelBI}{_acessarEquipamentos}{_incluirEquipamentos}{_editarEquipamentos}{_inativarEquipamentos}{_acessarCategoriaEquipamentos}{_incluirCategoriaEquipamentos}{_editarCategoriaEquipamentos}{_inativarCategoriaEquipamentos}";
                    #endregion

                    NpgsqlCommand update1 = new NpgsqlCommand($"UPDATE controle_permissao SET permissao = '{novaPermissao}', id_usuario_alteracao = {SessaoSistema.UserId}, data_alteracao = CURRENT_TIMESTAMP WHERE id_usuario = {IdPermissao}", BD.ObjetoConexao);
                    update1.ExecuteNonQuery();

                    XtraMessageBox.Show("Permissões alteradas com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                else if (TipoChamada == "Editar" && XtraMessageBox.Show("Confirmar alteração de permissões ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    #region Variáveis
                    string _acessarParametroSistema = chkBoxAcessarParametrosSistema.Checked ? "S" : "N";
                    string _editarParametroSistema = chkBoxEditarParametrosSistema.Checked ? "S" : "N";

                    string _acessarPerfil = chkBoxAcessarPerfil.Checked ? "S" : "N";
                    string _incluirPerfil = chkBoxIncluirPerfil.Checked ? "S" : "N";
                    string _editarPerfil = chkBoxEditarPerfil.Checked ? "S" : "N";
                    string _excluirPerfil = chkBoxExcluirPerfil.Checked ? "S" : "N";

                    string _acessarUsuario = chkBoxAcessarUsuarios.Checked ? "S" : "N";
                    string _incluirUsuario = chkBoxIncluirUsuarios.Checked ? "S" : "N";
                    string _editarUsuario = chkBoxEditarUsuarios.Checked ? "S" : "N";
                    string _inativarReativarUsuario = chkBoxInativarReativarUsuarios.Checked ? "S" : "N";
                    string _resetarSenhaUsuario = chkBoxResetarSenhaUsuarios.Checked ? "S" : "N";
                    string _alterarPermissaoUsuario = chkBoxAlterarPermissaoUsuarios.Checked ? "S" : "N";

                    string _acessarVeiculo = chkBoxAcessarVeiculos.Checked ? "S" : "N";
                    string _incluirVeiculo = chkBoxIncluirVeiculos.Checked ? "S" : "N";
                    string _editarVeiculo = chkBoxEditarVeiculos.Checked ? "S" : "N";
                    string _inativarVeiculo = chkBoxInativarVeiculos.Checked ? "S" : "N";

                    string _acessarFuncionario = chkBoxAcessarFuncionarios.Checked ? "S" : "N";
                    string _incluirFuncionario = chkBoxIncluirFuncionarios.Checked ? "S" : "N";
                    string _editarFuncionario = chkBoxEditarFuncionarios.Checked ? "S" : "N";
                    string _visualizarCadCompletoFuncionario = chkBoxVisualizarCadCompletoFunc.Checked ? "S" : "N";

                    string _acessarTipoManutencao = chkBoxAcessarTipoManutencao.Checked ? "S" : "N";
                    string _incluirTipoManutencao = chkBoxIncluirTipoManutencao.Checked ? "S" : "N";
                    string _editarTipoManutencao = chkBoxEditarTipoManutencao.Checked ? "S" : "N";
                    string _inativarTipoManutencao = chkBoxInativarTipoManutencao.Checked ? "S" : "N";

                    string _acessarLocalManutencao = chkBoxAcessarLocalManutencao.Checked ? "S" : "N";
                    string _incluirLocalManutencao = chkBoxIncluirLocalManutencao.Checked ? "S" : "N";
                    string _editarLocalManutencao = chkBoxEditarLocalManutencao.Checked ? "S" : "N";
                    string _inativarLocalManutencao = chkBoxInativarLocalManutencao.Checked ? "S" : "N";

                    string _registrarManutencao = chkBoxRegistrarManutencao.Checked ? "S" : "N";
                    string _visualizarManutencoesRealizadas = chkBoxManutencoesRealizadas.Checked ? "S" : "N";
                    string _excluirManutencaoRealizada = chkBoxExcluirManutencaoRealizada.Checked ? "S" : "N";
                    string _visualizarProxTrocaOleo = chkBoxProxTrocaOleo.Checked ? "S" : "N";
                    string _acessarPainelBI = chkBoxPainelBI.Checked ? "S" : "N";

                    string _acessarEquipamentos = chkBoxAcessarEquipamentos.Checked ? "S" : "N";
                    string _incluirEquipamentos = chkBoxIncluirEquipamentos.Checked ? "S" : "N";
                    string _editarEquipamentos = chkBoxEditarEquipamentos.Checked ? "S" : "N";
                    string _inativarEquipamentos = chkBoxInativarEquipamentos.Checked ? "S" : "N";
                    string _acessarCategoriaEquipamentos = chkBoxAcessarCategoriaEquipamentos.Checked ? "S" : "N";
                    string _incluirCategoriaEquipamentos = chkBoxIncluirCategoriaEquip.Checked ? "S" : "N";
                    string _editarCategoriaEquipamentos = chkBoxEditarCategoriaEquip.Checked ? "S" : "N";
                    string _inativarCategoriaEquipamentos = chkBoxInativarCategoriaEquip.Checked ? "S" : "N";

                    string novaPermissao = $"{_acessarParametroSistema}{_editarParametroSistema}{_acessarPerfil}{_incluirPerfil}{_editarPerfil}{_excluirPerfil}{_acessarUsuario}{_incluirUsuario}{_editarUsuario}{_inativarReativarUsuario}{_resetarSenhaUsuario}{_alterarPermissaoUsuario}{_acessarVeiculo}{_incluirVeiculo}{_editarVeiculo}{_inativarVeiculo}{_acessarFuncionario}{_incluirFuncionario}{_editarFuncionario}{_visualizarCadCompletoFuncionario}{_acessarTipoManutencao}{_incluirTipoManutencao}{_editarTipoManutencao}{_inativarTipoManutencao}{_acessarLocalManutencao}{_incluirLocalManutencao}{_editarLocalManutencao}{_inativarLocalManutencao}{_registrarManutencao}{_visualizarManutencoesRealizadas}{_excluirManutencaoRealizada}{_visualizarProxTrocaOleo}{_acessarPainelBI}{_acessarEquipamentos}{_incluirEquipamentos}{_editarEquipamentos}{_inativarEquipamentos}{_acessarCategoriaEquipamentos}{_incluirCategoriaEquipamentos}{_editarCategoriaEquipamentos}{_inativarCategoriaEquipamentos}";
                    #endregion

                    NpgsqlCommand update1 = new NpgsqlCommand($"UPDATE controle_permissao_perfil SET descricao = '{tBoxDescricao.Text.ToUpper().Trim()}', permissao = '{novaPermissao}', id_usuario_alteracao = {SessaoSistema.UserId}, data_alteracao = CURRENT_TIMESTAMP WHERE id_controle_permissao_perfil = {IdPermissao}", BD.ObjetoConexao);
                    update1.ExecuteNonQuery();

                    XtraMessageBox.Show("Permissões alteradas com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((frmUsuarioPerfilConsultar)this.Owner).AtualizaDG();
                    this.Close();
                }

                else if (TipoChamada == "Incluir" && XtraMessageBox.Show("Confirmar alteração de permissões ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    #region Variáveis
                    string _acessarParametroSistema = chkBoxAcessarParametrosSistema.Checked ? "S" : "N";
                    string _editarParametroSistema = chkBoxEditarParametrosSistema.Checked ? "S" : "N";

                    string _acessarPerfil = chkBoxAcessarPerfil.Checked ? "S" : "N";
                    string _incluirPerfil = chkBoxIncluirPerfil.Checked ? "S" : "N";
                    string _editarPerfil = chkBoxEditarPerfil.Checked ? "S" : "N";
                    string _excluirPerfil = chkBoxExcluirPerfil.Checked ? "S" : "N";

                    string _acessarUsuario = chkBoxAcessarUsuarios.Checked ? "S" : "N";
                    string _incluirUsuario = chkBoxIncluirUsuarios.Checked ? "S" : "N";
                    string _editarUsuario = chkBoxEditarUsuarios.Checked ? "S" : "N";
                    string _inativarReativarUsuario = chkBoxInativarReativarUsuarios.Checked ? "S" : "N";
                    string _resetarSenhaUsuario = chkBoxResetarSenhaUsuarios.Checked ? "S" : "N";
                    string _alterarPermissaoUsuario = chkBoxAlterarPermissaoUsuarios.Checked ? "S" : "N";

                    string _acessarVeiculo = chkBoxAcessarVeiculos.Checked ? "S" : "N";
                    string _incluirVeiculo = chkBoxIncluirVeiculos.Checked ? "S" : "N";
                    string _editarVeiculo = chkBoxEditarVeiculos.Checked ? "S" : "N";
                    string _inativarVeiculo = chkBoxInativarVeiculos.Checked ? "S" : "N";

                    string _acessarFuncionario = chkBoxAcessarFuncionarios.Checked ? "S" : "N";
                    string _incluirFuncionario = chkBoxIncluirFuncionarios.Checked ? "S" : "N";
                    string _editarFuncionario = chkBoxEditarFuncionarios.Checked ? "S" : "N";
                    string _visualizarCadCompletoFuncionario = chkBoxVisualizarCadCompletoFunc.Checked ? "S" : "N";

                    string _acessarTipoManutencao = chkBoxAcessarTipoManutencao.Checked ? "S" : "N";
                    string _incluirTipoManutencao = chkBoxIncluirTipoManutencao.Checked ? "S" : "N";
                    string _editarTipoManutencao = chkBoxEditarTipoManutencao.Checked ? "S" : "N";
                    string _inativarTipoManutencao = chkBoxInativarTipoManutencao.Checked ? "S" : "N";

                    string _acessarLocalManutencao = chkBoxAcessarLocalManutencao.Checked ? "S" : "N";
                    string _incluirLocalManutencao = chkBoxIncluirLocalManutencao.Checked ? "S" : "N";
                    string _editarLocalManutencao = chkBoxEditarLocalManutencao.Checked ? "S" : "N";
                    string _inativarLocalManutencao = chkBoxInativarLocalManutencao.Checked ? "S" : "N";

                    string _registrarManutencao = chkBoxRegistrarManutencao.Checked ? "S" : "N";
                    string _visualizarManutencoesRealizadas = chkBoxManutencoesRealizadas.Checked ? "S" : "N";
                    string _excluirManutencaoRealizada = chkBoxExcluirManutencaoRealizada.Checked ? "S" : "N";
                    string _visualizarProxTrocaOleo = chkBoxProxTrocaOleo.Checked ? "S" : "N";
                    string _acessarPainelBI = chkBoxPainelBI.Checked ? "S" : "N";

                    string _acessarEquipamentos = chkBoxAcessarEquipamentos.Checked ? "S" : "N";
                    string _incluirEquipamentos = chkBoxIncluirEquipamentos.Checked ? "S" : "N";
                    string _editarEquipamentos = chkBoxEditarEquipamentos.Checked ? "S" : "N";
                    string _inativarEquipamentos = chkBoxInativarEquipamentos.Checked ? "S" : "N";
                    string _acessarCategoriaEquipamentos = chkBoxAcessarCategoriaEquipamentos.Checked ? "S" : "N";
                    string _incluirCategoriaEquipamentos = chkBoxIncluirCategoriaEquip.Checked ? "S" : "N";
                    string _editarCategoriaEquipamentos = chkBoxEditarCategoriaEquip.Checked ? "S" : "N";
                    string _inativarCategoriaEquipamentos = chkBoxInativarCategoriaEquip.Checked ? "S" : "N";

                    string novaPermissao = $"{_acessarParametroSistema}{_editarParametroSistema}{_acessarPerfil}{_incluirPerfil}{_editarPerfil}{_excluirPerfil}{_acessarUsuario}{_incluirUsuario}{_editarUsuario}{_inativarReativarUsuario}{_resetarSenhaUsuario}{_alterarPermissaoUsuario}{_acessarVeiculo}{_incluirVeiculo}{_editarVeiculo}{_inativarVeiculo}{_acessarFuncionario}{_incluirFuncionario}{_editarFuncionario}{_visualizarCadCompletoFuncionario}{_acessarTipoManutencao}{_incluirTipoManutencao}{_editarTipoManutencao}{_inativarTipoManutencao}{_acessarLocalManutencao}{_incluirLocalManutencao}{_editarLocalManutencao}{_inativarLocalManutencao}{_registrarManutencao}{_visualizarManutencoesRealizadas}{_excluirManutencaoRealizada}{_visualizarProxTrocaOleo}{_acessarPainelBI}{_acessarEquipamentos}{_incluirEquipamentos}{_editarEquipamentos}{_inativarEquipamentos}{_acessarCategoriaEquipamentos}{_incluirCategoriaEquipamentos}{_editarCategoriaEquipamentos}{_inativarCategoriaEquipamentos}";
                    #endregion

                    NpgsqlCommand update1 = new NpgsqlCommand($"INSERT INTO controle_permissao_perfil VALUES(nextval('seq_controle_permissao_perfil'), '{tBoxDescricao.Text.ToUpper().Trim()}', '{novaPermissao}', {SessaoSistema.UserId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL, 'S')", BD.ObjetoConexao);
                    update1.ExecuteNonQuery();

                    XtraMessageBox.Show("Permissões alteradas com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((frmUsuarioPerfilConsultar)this.Owner).AtualizaDG();
                    this.Close();
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnRecarregaPermissoesUsuario_Click(object sender, EventArgs e)
        {
            CarregaPerfil();
            cBoxPerfil.SelectedIndex = -1;
            cBoxPerfil.Focus();

            CarregaPermissaoUsuario();

            XtraMessageBox.Show("Permissões do usuário recarregadas com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}