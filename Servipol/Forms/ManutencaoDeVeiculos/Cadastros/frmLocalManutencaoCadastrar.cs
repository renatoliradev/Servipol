using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmLocalManutencaoCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public string TipoChamada { get; set; }
        public int IdLocalManutencao { get; set; }
        #endregion

        public frmLocalManutencaoCadastrar(string tipoChamada, int idLocalManutencao)
        {
            TipoChamada = tipoChamada;
            IdLocalManutencao = idLocalManutencao;

            InitializeComponent();
        }

        private void frmLocalManutencaoCadastrar_Load(object sender, EventArgs e)
        {
            if (TipoChamada == "Editar")
            {
                CarregaRegistroParaEdicao();
                this.Text = "Editar Local de Manutenção";
            }
            else
            {
                chkBoxRegistroAtivo.Checked = true;
                chkBoxRegistroAtivo.Enabled = false;
                tabDadosRegistro.Parent = null;
                this.Text = "Cadastrar Local de Manutenção";
            }
            gbDescricao.Focus();
            tBoxDescricao.Select();
        }

        #region Methods

        public void CarregaRegistroParaEdicao()
        {
            try
            {
                BD.Conectar();

                #region Variáveis
                string descricao = string.Empty, posto_combustivel = string.Empty, usuario_cadastro = string.Empty, data_cadastro = string.Empty, usuario_desativacao = string.Empty, data_desativacao = string.Empty, usuario_alteracao = string.Empty, data_alteracao = string.Empty, registro_ativo = string.Empty;
                #endregion

                NpgsqlCommand com = new NpgsqlCommand($"SELECT ml.descricao, ml.posto_combustivel, uc.nome AS usuario_cadastro, ml.data_cadastro, ud.nome AS usuario_desativacao, ml.data_desativacao, ua.nome AS usuario_alteracao, ml.data_alteracao, ml.ativo FROM manutencao_local AS ml INNER JOIN usuario AS uc ON(uc.id_usuario = ml.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = ml.id_usuario_desativacao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = ml.id_usuario_alteracao) WHERE ml.id_manutencao_local = {IdLocalManutencao}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        descricao = dr["descricao"].ToString().Trim();
                        posto_combustivel = dr["posto_combustivel"].ToString();
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

                    #region Conversão Posto Combustivel
                    switch (posto_combustivel)
                    {
                        case "S":
                            chkBoxPostoCombustivel.Checked = true;
                            break;
                        case "N":
                            chkBoxPostoCombustivel.Checked = false;
                            break;
                    }
                    #endregion

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
                XtraMessageBox.Show("Campo [Denominação] não pode ficar em branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gbDescricao.Focus();
                tBoxDescricao.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmLocalManutencaoCadastrar_KeyDown(object sender, KeyEventArgs e)
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

        #endregion

        #region Buttons

        private void btnCancelarCadastro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmaInclusao_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();
                if (TipoChamada == "Editar")
                {
                    if (tBoxDescricao.Text == string.Empty)
                    {
                        XtraMessageBox.Show("Campo [Denominação] não pode ficar em branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tBoxDescricao.Select();
                    }
                    else
                    {
                        if (XtraMessageBox.Show("Confirma alteração ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            string postoCombustivel = string.Empty;
                            if (chkBoxPostoCombustivel.Checked)
                            {
                                postoCombustivel = "S";
                            }
                            else
                            {
                                postoCombustivel = "N";
                            }

                            string sqlCommand = $"UPDATE manutencao_local SET descricao = '{tBoxDescricao.Text.ToUpper().Trim()}', posto_combustivel = '{postoCombustivel}' WHERE id_manutencao_local = {IdLocalManutencao}";
                            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                            command.ExecuteNonQuery();

                            XtraMessageBox.Show("Local de Manutenção Alterado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //((frmLocalManutencao)this.Owner).atualizaDG();
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (tBoxDescricao.Text == string.Empty)
                    {
                        XtraMessageBox.Show("Campo [Denominação] não pode ficar em branco.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tBoxDescricao.Select();
                    }
                    else
                    {
                        if (XtraMessageBox.Show("Confirma inclusão ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            string postoCombustivel = string.Empty;
                            if (chkBoxPostoCombustivel.Checked)
                            {
                                postoCombustivel = "S";
                            }
                            else
                            {
                                postoCombustivel = "N";
                            }

                            string sqlCommand = $"INSERT INTO manutencao_local VALUES (nextval('seq_chave_primaria'), '{tBoxDescricao.Text.ToUpper().Trim()}', {SessaoSistema.UserId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL, 'S', '{postoCombustivel}')";
                            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                            command.ExecuteNonQuery();

                            XtraMessageBox.Show("Local de Manutenção Cadastrado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //((frmLocalManutencao)this.Owner).atualizaDG();
                                this.Close();
                        }
                    }
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }

        #endregion

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
                        string posto_combustivel = string.Empty, registro_ativo = string.Empty;

                        #region Converte Posto Combustivel
                        if (chkBoxPostoCombustivel.Checked)
                            posto_combustivel = "S";
                        else
                            posto_combustivel = "N";
                        #endregion

                        #region Conversão Situação
                        registro_ativo = chkBoxRegistroAtivo.Checked ? "S" : "N";
                        #endregion

                        if (XtraMessageBox.Show("Confirmar Alterações ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            string sqlCommand = $"UPDATE manutencao_local SET descricao = '{tBoxDescricao.Text.ToUpper().Trim()}', posto_combustivel = '{posto_combustivel}' WHERE id_manutencao_local = {IdLocalManutencao}";
                            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                            command.ExecuteNonQuery();

                            if (registro_ativo == "N")
                            {
                                string sqlCommand2 = $"UPDATE manutencao_local SET ativo = '{registro_ativo}', id_usuario_desativacao = {SessaoSistema.UserId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_manutencao_local = {IdLocalManutencao}";
                                NpgsqlCommand command2 = new NpgsqlCommand(sqlCommand2, BD.ObjetoConexao);
                                command2.ExecuteNonQuery();
                            }
                            else
                            {
                                string sqlCommand3 = $"UPDATE manutencao_local SET ativo = '{registro_ativo}', id_usuario_alteracao = {SessaoSistema.UserId}, data_alteracao = CURRENT_TIMESTAMP WHERE id_manutencao_local = {IdLocalManutencao}";
                                NpgsqlCommand command3 = new NpgsqlCommand(sqlCommand3, BD.ObjetoConexao);
                                command3.ExecuteNonQuery();
                            }

                            XtraMessageBox.Show("Registro Alterado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ((frmLocalManutencaoConsultar)this.Owner).AtualizaDG();
                            this.Close();
                        }
                    }
                    #endregion

                    #region Tipo Chamada: INCLUIR
                    else
                    {
                        string posto_combustivel = string.Empty;

                        #region Converte Posto Combustivel
                        if (chkBoxPostoCombustivel.Checked)
                            posto_combustivel = "S";
                        else
                            posto_combustivel = "N";
                        #endregion

                        string sqlCommand = $"INSERT INTO manutencao_local VALUES (nextval('seq_manutencao_local'), '{tBoxDescricao.Text.ToUpper().Trim()}', {SessaoSistema.UserId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL, 'S', '{posto_combustivel}')";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        XtraMessageBox.Show("Cadastro Efetuado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ((frmLocalManutencaoConsultar)this.Owner).AtualizaDG();
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
    }
}