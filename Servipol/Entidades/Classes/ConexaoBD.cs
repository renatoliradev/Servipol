using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.IO;
using System.Windows.Forms;

namespace Servipol.Entidades.Classes
{
    class ConexaoBD
    {
        private String _stringConexao;
        private NpgsqlConnection _conexao;
        private static string Arq_Config = @"opt\hidden\prime.prime";
        private static string IP_BD;
        private static string PORTA_BD;
        private static string NOME_BD;
        private static string SENHA_BD;
        private static string USER_BD;
        private static string StringConexaoBD;

        public ConexaoBD()
        {
            try
            {
                StreamReader rd = new StreamReader(Arq_Config);

                while (!rd.EndOfStream)
                {

                    string linha = rd.ReadLine();
                    if (linha.StartsWith("IP_BD"))
                        IP_BD = linha.Substring(6).Trim();

                    if (linha.StartsWith("PORTA_BD"))
                        PORTA_BD = linha.Substring(9).Trim();

                    if (linha.StartsWith("NOME_BD"))
                        NOME_BD = linha.Substring(8).Trim();

                    if (linha.StartsWith("SENHA_BD"))
                        SENHA_BD = linha.Substring(9).Trim();

                    if (linha.StartsWith("USER_BD"))
                        USER_BD = linha.Substring(8).Trim();

                    StringConexao = $"Server={IP_BD}; Port={PORTA_BD}; User ID={USER_BD}; Password={SENHA_BD}; Database={NOME_BD}; Pooling=true; MinPoolSize=1;";
                }
                rd.Close();
                rd.Dispose();
            }
            catch
            {
                XtraMessageBox.Show("Não foi possível ler o arquivo de configuração!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            _conexao = new NpgsqlConnection();
            _stringConexao = StringConexao;
            _conexao.ConnectionString = StringConexao;
        }

        public String StringConexao
        {
            get { return _stringConexao; }
            set { _stringConexao = value; }
        }

        public NpgsqlConnection ObjetoConexao
        {
            get { return _conexao; }
            set { _conexao = value; }
        }

        public void Conectar()
        {
            try
            {
                _conexao.Close();
                _conexao.Open();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao abrir conexão com o banco de dados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Desconectar()
        {
            _conexao.Close();
        }

        public void DisposeConexao()
        {
            _conexao.Dispose();
        }
    }
}
