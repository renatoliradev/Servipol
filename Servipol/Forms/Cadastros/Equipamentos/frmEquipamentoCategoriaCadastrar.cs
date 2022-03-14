using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Windows.Forms;

namespace Servipol.Forms.Cadastros.Equipamentos
{
    public partial class frmEquipamentoCategoriaCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public string TipoChamada { get; set; }
        public int IdCategoria { get; set; }
        #endregion

        public frmEquipamentoCategoriaCadastrar(string tipoChamada, int idCategoria)
        {
            TipoChamada = tipoChamada;
            IdCategoria = idCategoria;

            InitializeComponent();
        }

        private void frmEquipamentoCategoriaCadastrar_Load(object sender, EventArgs e)
        {
            VerificaTipoChamada();

            gbDescricao.Focus();
            tBoxDescricao.Select();
        }

        #region Methods

        public void VerificaTipoChamada()
        {
            try
            {
                if (TipoChamada == "Incluir")
                {
                    this.Text = "Cadastrar Categoria de Equipamento";

                    tBoxDescricao.Clear();
                    chkBoxRegistroAtivo.Checked = true;
                    chkBoxRegistroAtivo.Enabled = false;
                    tabDadosRegistro.Parent = null;
                }
                else if (TipoChamada == "Editar")
                {
                    this.Text = "Editar Categoria de Equipamento";
                    CarregaRegistroParaEdicao();
                }
            }
            finally
            {
            }
        }

        public void CarregaRegistroParaEdicao()
        {
            try
            {
                BD.Conectar();

                #region Variáveis
                string descricao = string.Empty, usuario_cadastro = string.Empty, data_cadastro = string.Empty, usuario_desativacao = string.Empty, data_desativacao = string.Empty, usuario_alteracao = string.Empty, data_alteracao = string.Empty, registro_ativo = string.Empty;
                #endregion

                NpgsqlCommand com = new NpgsqlCommand($"SELECT ec.id_equipamento_categoria, ec.descricao, uc.nome AS usuario_cadastro, ec.data_cadastro, ud.nome AS usuario_desativacao, ec.data_desativacao, ua.nome AS usuario_alteracao, ec.data_alteracao, ec.ativo FROM equipamento_categoria AS ec INNER JOIN usuario AS uc ON(uc.id_usuario = ec.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = ec.id_usuario_desativacao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = ec.id_usuario_alteracao) WHERE ec.id_equipamento_categoria = {IdCategoria}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        descricao = dr["descricao"].ToString().Trim();
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
                    
                    //Dados do Registro
                    tBoxUsuarioCadastro.Text = usuario_cadastro;
                    tBoxDataCadastro.Text = data_cadastro;
                    tBoxUsuarioDesativacao.Text = usuario_desativacao;
                    tBoxDataDesativacao.Text = data_desativacao;
                    tBoxUsuarioAlteracao.Text = usuario_alteracao;
                    tBoxDataAlteracao.Text = data_alteracao;

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
                XtraMessageBox.Show("Informe a [Descrição] da categoria de equipamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gbDescricao.Focus();
                tBoxDescricao.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmEquipamentoCategoriaCadastrar_KeyDown(object sender, KeyEventArgs e)
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

        private void tBoxDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnConfirmar_Click(sender, e);
                    break;
            }
        }

        #endregion

        #region Buttons

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
                        #region Conversão Situação
                        string registro_ativo = chkBoxRegistroAtivo.Checked ? "S" : "N";
                        #endregion

                        if (XtraMessageBox.Show("Confirmar Alterações ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            string sqlCommand = $"UPDATE equipamento_categoria SET descricao = '{tBoxDescricao.Text.ToUpper().Trim()}' WHERE id_equipamento_categoria = {IdCategoria}";
                            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                            command.ExecuteNonQuery();

                            if (registro_ativo == "N")
                            {
                                string sqlCommand2 = $"UPDATE equipamento_categoria SET ativo = '{registro_ativo}', id_usuario_alteracao = {SessaoSistema.UserId}, data_alteracao = CURRENT_TIMESTAMP, id_usuario_desativacao = {SessaoSistema.UserId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_equipamento_categoria = {IdCategoria}";
                                NpgsqlCommand command2 = new NpgsqlCommand(sqlCommand2, BD.ObjetoConexao);
                                command2.ExecuteNonQuery();
                            }
                            else
                            {
                                string sqlCommand3 = $"UPDATE equipamento_categoria SET ativo = '{registro_ativo}', id_usuario_alteracao = {SessaoSistema.UserId}, data_alteracao = CURRENT_TIMESTAMP WHERE id_equipamento_categoria = {IdCategoria}";
                                NpgsqlCommand command3 = new NpgsqlCommand(sqlCommand3, BD.ObjetoConexao);
                                command3.ExecuteNonQuery();
                            }

                            XtraMessageBox.Show("Categoria de Equipamento Alterada com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ((frmEquipamentoCategoriaConsultar)this.Owner).AtualizaDG();
                            this.Close();
                        }
                    }
                    #endregion

                    #region Tipo Chamada: INCLUIR
                    else
                    {
                        string sqlCommand = $"INSERT INTO equipamento_categoria VALUES (nextval('seq_equipamento_categoria'), '{tBoxDescricao.Text.ToUpper().Trim()}', {SessaoSistema.UserId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL, 'S')";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        XtraMessageBox.Show("Cadastro Efetuado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ((frmEquipamentoCategoriaConsultar)this.Owner).AtualizaDG();
                        this.Close();
                    }
                }



                #endregion
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion
    }
}