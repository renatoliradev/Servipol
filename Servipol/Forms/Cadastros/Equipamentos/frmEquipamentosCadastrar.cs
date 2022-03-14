using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Servipol.Forms.Cadastros.Equipamentos
{
    public partial class frmEquipamentosCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public string TipoChamada { get; set; }
        public int IdEquipamento { get; set; }
        #endregion

        public frmEquipamentosCadastrar(string tipoChamada, int idEquipamento)
        {
            TipoChamada = tipoChamada;
            IdEquipamento = idEquipamento;

            InitializeComponent();
        }

        private void frmEquipamentosCadastrar_Load(object sender, EventArgs e)
        {
            CarregaCategoriaEquipamento();
            VerificaTipoChamada();

            gbCodigo.Focus();
            tBoxCodigo.Select();
        }

        #region Methods

        public void VerificaTipoChamada()
        {
            try
            {
                if (TipoChamada == "Incluir")
                {
                    this.Text = "Cadastrar Equipamento";

                    tBoxCodigo.Clear();
                    tBoxDescricao.Clear();
                    cBoxCategoriaEquipamento.SelectedIndex = -1;
                    tBoxPrecoCusto.Clear();
                    tBoxMargemDesejada.Clear();
                    tBoxPrecoSugerido.Clear();
                    tBoxPrecoVenda.Clear();
                    tBoxQuantidadeEstoque.Clear();
                    chkBoxRegistroAtivo.Checked = true;
                    chkBoxRegistroAtivo.Enabled = false;
                    tabDadosRegistro.Parent = null;

                    cBoxCategoriaEquipamento.SelectedIndex = -1;
                    tBoxPrecoCusto.Text = "R$ 0,00";
                    tBoxMargemDesejada.Text = "0";
                    tBoxPrecoSugerido.Text = "R$ 0,00";
                    tBoxPrecoVenda.Text = "R$ 0,00";
                }
                else if (TipoChamada == "Editar")
                {
                    this.Text = "Editar Equipamento";
                    CarregaRegistroParaEdicao();
                }
            }
            finally
            {
            }
        }

        public void CarregaCategoriaEquipamento()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT ec.id_equipamento_categoria, ec.descricao FROM equipamento_categoria AS ec WHERE ec.ativo = 'S'";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxCategoriaEquipamento.ValueMember = "id_equipamento_categoria";
                cBoxCategoriaEquipamento.DisplayMember = "descricao";
                cBoxCategoriaEquipamento.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void CarregaRegistroParaEdicao()
        {
            try
            {
                BD.Conectar();

                #region Variáveis
                string codigo = string.Empty, descricao = string.Empty, categoria = string.Empty, preco_custo = string.Empty, margem_desejada = string.Empty, preco_sugerido = string.Empty, preco_venda = string.Empty, estoque = string.Empty, usuario_cadastro = string.Empty, data_cadastro = string.Empty, usuario_desativacao = string.Empty, data_desativacao = string.Empty, usuario_alteracao = string.Empty, data_alteracao = string.Empty, registro_ativo = string.Empty;
                #endregion

                NpgsqlCommand com = new NpgsqlCommand($"SELECT e.codigo, e.id_equipamento_categoria, e.descricao, e.preco_custo, e.preco_venda, e.margem_desejada, e.estoque_atual, uc.nome AS usuario_cadastro, e.data_cadastro, ud.nome AS usuario_desativacao, e.data_desativacao, ua.nome AS usuario_alteracao, e.data_alteracao, e.ativo FROM equipamento AS e INNER JOIN usuario AS uc ON(uc.id_usuario = e.id_usuario_cadastro) LEFT OUTER JOIN usuario AS ud ON(ud.id_usuario = e.id_usuario_desativacao) LEFT OUTER JOIN usuario AS ua ON(ua.id_usuario = e.id_usuario_alteracao) WHERE e.id_equipamento = {IdEquipamento}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        codigo = dr["codigo"].ToString().Trim();
                        descricao = dr["descricao"].ToString().Trim();
                        categoria = dr["id_equipamento_categoria"].ToString();
                        preco_custo = dr["preco_custo"].ToString();
                        margem_desejada = dr["margem_desejada"].ToString();
                        preco_venda = dr["preco_venda"].ToString();
                        estoque = dr["estoque_atual"].ToString();
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
                    tBoxCodigo.Text = codigo;
                    tBoxDescricao.Text = descricao;
                    cBoxCategoriaEquipamento.SelectedValue = categoria;
                    tBoxPrecoCusto.Text = preco_custo;
                    tBoxMargemDesejada.Text = margem_desejada;
                    tBoxPrecoVenda.Text = preco_venda;
                    tBoxQuantidadeEstoque.Text = estoque;

                    double custo = Convert.ToDouble(tBoxPrecoCusto.Text.Replace("R$", ""));
                    double margem = Convert.ToDouble(tBoxMargemDesejada.Text);
                    double sugerido = custo + (custo * (margem / 100));

                    tBoxPrecoSugerido.Text = sugerido.ToString("C");

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
                XtraMessageBox.Show("Informe a [Descrição] do equipamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gbDescricao.Focus();
                tBoxDescricao.Select();
                return false;
            }
            if (cBoxCategoriaEquipamento.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Selecione a [Categoria] do equipamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gbCategoria.Focus();
                cBoxCategoriaEquipamento.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CalculaPrecoSugerido()
        {
            try
            {
                double custo = Convert.ToDouble(tBoxPrecoCusto.Text.Replace("R$", ""));
                double margem = Convert.ToDouble(tBoxMargemDesejada.Text);
                double sugerido = custo + (custo * (margem / 100));

                tBoxPrecoSugerido.Text = sugerido.ToString("C");

            }
            catch
            {
                tBoxPrecoSugerido.Text = "R$0,00";
            }
        }

        private void tBoxPrecoCusto_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxPrecoCusto.Text.Length - 1; i++)
            {
                if ((tBoxPrecoCusto.Text[i] >= '0' &&
                    tBoxPrecoCusto.Text[i] <= '9') ||
                    tBoxPrecoCusto.Text[i] == ',')
                {
                    x += tBoxPrecoCusto.Text[i];
                }
            }
            tBoxPrecoCusto.Text = x;
            tBoxPrecoCusto.SelectAll();
        }

        private void tBoxPrecoVenda_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxPrecoVenda.Text.Length - 1; i++)
            {
                if ((tBoxPrecoVenda.Text[i] >= '0' &&
                    tBoxPrecoVenda.Text[i] <= '9') ||
                    tBoxPrecoVenda.Text[i] == ',')
                {
                    x += tBoxPrecoVenda.Text[i];
                }
            }
            tBoxPrecoVenda.Text = x;
            tBoxPrecoVenda.SelectAll();
        }

        private void tBoxPrecoCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               (e.KeyChar != ',' && e.KeyChar != '.' &&
                e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!tBoxPrecoCusto.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void tBoxPrecoVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               (e.KeyChar != ',' && e.KeyChar != '.' &&
                e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!tBoxPrecoVenda.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void tBoxPrecoCusto_Leave(object sender, EventArgs e)
        {
            try
            {
                tBoxPrecoCusto.Text = Convert.ToDouble(tBoxPrecoCusto.Text).ToString("C");
                CalculaPrecoSugerido();
            }
            catch
            {
                tBoxPrecoCusto.Text = "R$0,00";
            }
        }

        private void tBoxPrecoVenda_Leave(object sender, EventArgs e)
        {
            try
            {
                tBoxPrecoVenda.Text = Convert.ToDouble(tBoxPrecoVenda.Text).ToString("C");
            }
            catch
            {

            }
        }

        private void tBoxPrecoCusto_MouseClick(object sender, MouseEventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxPrecoCusto.Text.Length - 1; i++)
            {
                if ((tBoxPrecoCusto.Text[i] >= '0' &&
                    tBoxPrecoCusto.Text[i] <= '9') ||
                    tBoxPrecoCusto.Text[i] == ',')
                {
                    x += tBoxPrecoCusto.Text[i];
                }
            }
            tBoxPrecoCusto.Text = x;
            tBoxPrecoCusto.SelectAll();
        }

        private void tBoxPrecoVenda_MouseClick(object sender, MouseEventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxPrecoVenda.Text.Length - 1; i++)
            {
                if ((tBoxPrecoVenda.Text[i] >= '0' &&
                    tBoxPrecoVenda.Text[i] <= '9') ||
                    tBoxPrecoVenda.Text[i] == ',')
                {
                    x += tBoxPrecoVenda.Text[i];
                }
            }
            tBoxPrecoVenda.Text = x;
            tBoxPrecoVenda.SelectAll();
        }

        private void tBoxPrecoCusto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double valorCusto = Convert.ToDouble(tBoxPrecoCusto.Text.Replace("R$", ""));
            }
            catch { }
            CalculaPrecoSugerido();
        }

        private void tBoxMargemDesejada_KeyUp(object sender, KeyEventArgs e)
        {
            CalculaPrecoSugerido();
        }

        private void tBoxMargemDesejada_Leave(object sender, EventArgs e)
        {
            try
            {
                CalculaPrecoSugerido();
            }
            catch
            {

            }
        }

        private void tBoxMargemDesejada_MouseClick(object sender, MouseEventArgs e)
        {
            String x = "";
            for (int i = 0; i <= tBoxMargemDesejada.Text.Length - 1; i++)
            {
                if ((tBoxMargemDesejada.Text[i] >= '0' &&
                    tBoxMargemDesejada.Text[i] <= '9'))
                {
                    x += tBoxMargemDesejada.Text[i];
                }
            }
            tBoxMargemDesejada.Text = x;
            tBoxMargemDesejada.SelectAll();
        }

        private void tBoxMargemDesejada_Enter(object sender, EventArgs e)
        {
            tBoxMargemDesejada.SelectAll();
        }

        private void tBoxMargemDesejada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void frmEquipamentosCadastrar_KeyDown(object sender, KeyEventArgs e)
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

                    double valorCusto = Convert.ToDouble(tBoxPrecoCusto.Text.Replace("R$", ""));
                    double margemDesejada = Convert.ToDouble(tBoxMargemDesejada.Text);
                    double valorVenda = Convert.ToDouble(tBoxPrecoVenda.Text.Replace("R$", ""));

                    #region Tipo Chamada: EDITAR
                    if (TipoChamada == "Editar")
                    {
                        #region Conversão Situação
                        string registro_ativo = chkBoxRegistroAtivo.Checked ? "S" : "N";
                        #endregion

                        if (XtraMessageBox.Show("Confirmar Alterações ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            string sqlCommand = $"UPDATE equipamento SET codigo = '{tBoxCodigo.Text.Trim()}', descricao = '{tBoxDescricao.Text.ToUpper().Trim()}', id_equipamento_categoria = {cBoxCategoriaEquipamento.SelectedValue}, preco_custo = {valorCusto.ToString().Replace(",", ".")}, margem_desejada = {margemDesejada.ToString().Replace(",", ".")}, preco_venda = {valorVenda.ToString().Replace(",", ".")}, estoque_atual = {tBoxQuantidadeEstoque.Text} WHERE id_equipamento = {IdEquipamento}";
                            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                            command.ExecuteNonQuery();

                            if (registro_ativo == "N")
                            {
                                string sqlCommand2 = $"UPDATE equipamento SET ativo = '{registro_ativo}', id_usuario_alteracao = {SessaoSistema.UserId}, data_alteracao = CURRENT_TIMESTAMP, id_usuario_desativacao = {SessaoSistema.UserId}, data_desativacao = CURRENT_TIMESTAMP WHERE id_equipamento = {IdEquipamento}";
                                NpgsqlCommand command2 = new NpgsqlCommand(sqlCommand2, BD.ObjetoConexao);
                                command2.ExecuteNonQuery();
                            }
                            else
                            {
                                string sqlCommand3 = $"UPDATE equipamento SET ativo = '{registro_ativo}', id_usuario_alteracao = {SessaoSistema.UserId}, data_alteracao = CURRENT_TIMESTAMP WHERE id_equipamento = {IdEquipamento}";
                                NpgsqlCommand command3 = new NpgsqlCommand(sqlCommand3, BD.ObjetoConexao);
                                command3.ExecuteNonQuery();
                            }

                            XtraMessageBox.Show("Equipamento Alterado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ((frmEquipamentosConsultar)this.Owner).AtualizaDG();
                            this.Close();
                        }
                    }
                    #endregion

                    #region Tipo Chamada: INCLUIR
                    else
                    {
                        string sqlCommand = $"INSERT INTO equipamento VALUES (nextval('seq_equipamento'), {cBoxCategoriaEquipamento.SelectedValue}, '{tBoxCodigo.Text.Trim()}', '{tBoxDescricao.Text.ToUpper().Trim()}', {valorCusto.ToString().Replace(",", ".")}, {valorVenda.ToString().Replace(",", ".")}, {margemDesejada.ToString()}, {tBoxQuantidadeEstoque.Text}, {SessaoSistema.UserId}, CURRENT_TIMESTAMP, NULL, NULL, NULL, NULL, 'S')";
                        NpgsqlCommand command = new NpgsqlCommand(sqlCommand, BD.ObjetoConexao);
                        command.ExecuteNonQuery();

                        XtraMessageBox.Show("Cadastro Efetuado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ((frmEquipamentosConsultar)this.Owner).AtualizaDG();
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

        private void tBoxCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBoxDescricao.Select();
                    break;
            }
        }

        private void tBoxDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    cBoxCategoriaEquipamento.Select();
                    break;
            }
        }

        private void cBoxCategoriaEquipamento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBoxPrecoCusto.Select();
                    break;
            }
        }

        private void tBoxPrecoCusto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBoxMargemDesejada.Select();
                    break;
            }
        }

        private void tBoxMargemDesejada_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBoxPrecoVenda.Select();
                    break;
            }
        }

        private void tBoxPrecoVenda_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tBoxQuantidadeEstoque.Select();
                    break;
            }
        }

        private void tBoxQuantidadeEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnConfirmar.Select();
                    break;
            }
        }
    }
}