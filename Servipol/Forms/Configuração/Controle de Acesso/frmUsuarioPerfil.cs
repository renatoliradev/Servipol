﻿using DevExpress.XtraEditors;
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
        public string PermissaoUsuario { get; set; }
        public string PermissaoPerfil { get; set; }
        #endregion

        public frmUsuarioPerfil(string tipoChamada, int _IdPermissao)
        {
            TipoChamada = tipoChamada;
            IdPermissao = _IdPermissao;

            InitializeComponent();
        }

        private void frmUsuarioPerfil_Load(object sender, EventArgs e)
        {
            BloqueiaTudo(this);

            if (TipoChamada == "Editar")
            {
                CarregaPermissaoPerfil();
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

            if (TipoChamada == "frmUsuariosEditarPermissoes")
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

        public void CarregaPermissaoUsuario()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand($"SELECT permissao FROM controle_permissao WHERE id_usuario = {IdPermissao}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PermissaoUsuario = dr["permissao"].ToString();
                    }
                }

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
                NpgsqlCommand com = new NpgsqlCommand($"SELECT descricao, permissao FROM controle_permissao_perfil WHERE id_controle_permissao_perfil = {IdPermissao}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PermissaoPerfil = dr["permissao"].ToString();
                        tBoxDescricao.Text = dr["descricao"].ToString();
                    }
                }

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

        private void cBoxPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaPermissaoPerfil();
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
        }

        private void btnBloquearTudo_Click(object sender, EventArgs e)
        {
            BloqueiaTudo(this);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}