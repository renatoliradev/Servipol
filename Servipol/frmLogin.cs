using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Servipol
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        #region INSTANCIAS
        readonly ConexaoBD BD = new ConexaoBD();
        Criptografia md5 = new Criptografia();

        public static string SenhaSistema = string.Empty;
        #endregion
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            CarregaUsuario();
            BuscaUltimoUsuarioLogin();
        }

        private void CarregaUsuario()
        {
            try
            {
                BD.Conectar();

                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = "SELECT id_usuario, login, senha FROM usuarios WHERE ativo = 'S' ORDER BY login ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxUsuario.ValueMember = "id_usuario";
                cBoxUsuario.DisplayMember = "login";
                cBoxUsuario.DataSource = dt;

                while (dr.Read())
                {
                    SenhaSistema = dr["senha"].ToString();
                }

                gbSenha.Focus();
                tBoxSenha.Select();
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha no comando ao banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        private void GravaUltimoUsuarioLogin()
        {
            try
            {
                string path = Environment.CurrentDirectory.ToString();
                StreamWriter escreve = new StreamWriter(path + @"opt\hidden\uul.prime");
                escreve.WriteLine($"UUL= {cBoxUsuario.SelectedValue}");
                escreve.Flush();
                escreve.Close();
            }
            catch { }
        }

        private void BuscaUltimoUsuarioLogin()
        {
            string _ultimoUsuario = string.Empty;
            try
            {
                string path = Environment.CurrentDirectory.ToString();
                StreamReader rd = new StreamReader(path + @"opt\hidden\uul.prime");

                while (!rd.EndOfStream)
                {
                    string linha = rd.ReadLine();
                    if (linha.StartsWith("UUL"))
                        _ultimoUsuario = linha.Substring(4).Trim();

                    cBoxUsuario.SelectedValue = _ultimoUsuario;
                }
                rd.Close();
                rd.Dispose();
            }
            catch { }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();

                if (md5.GerarMD5(tBoxSenha.Text).Trim().ToUpper() == SenhaSistema)
                {
                    NpgsqlCommand update1 = new NpgsqlCommand($"UPDATE sessao_login SET data_logout = CURRENT_TIMESTAMP, online = 'N' WHERE nome_pc = '{Environment.MachineName}' AND online = 'S'", BD.ObjetoConexao);
                    update1.ExecuteNonQuery();

                    NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO sessao_login VALUES (nextval('seq_id_sessao_login'), {cBoxUsuario.SelectedValue}, '{Environment.MachineName}', CURRENT_TIMESTAMP, NULL, 'S')", BD.ObjetoConexao);
                    command.ExecuteNonQuery();

                    GravaUltimoUsuarioLogin();

                    ((frmPrincipal)this.Owner).IniciaSessao();
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Senha inválida!", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tBoxSenha.Clear();
                    tBoxSenha.Focus();
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }
    }
}