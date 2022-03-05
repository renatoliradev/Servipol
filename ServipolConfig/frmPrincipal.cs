using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.IO;
using System.Windows.Forms;

namespace ServipolConfig
{
    public partial class frmPrincipal : DevExpress.XtraEditors.XtraForm
    {
        #region INSTANCES AND PROPERTIES

        private String _stringConexao;
        private NpgsqlConnection _conexao;

        public string SystemPath { get; set; }
        public string ipBD { get; set; }
        public string portBD { get; set; }
        public string nameBD { get; set; }
        public string userBD { get; set; }
        public string passBD { get; set; }
        public bool ValidatedConn { get; set; }

        #endregion

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ValidatedConn = false;

            SystemPath = Environment.CurrentDirectory.ToString();

            FindParameters();
        }

        #region Methods

        private void SaveParameters()
        {
            try
            {
                ipBD = tBoxBDServer.Text;
                portBD = tBoxBDPort.Text;
                nameBD = tBoxBDName.Text;
                userBD = tBoxBDUser.Text;
                passBD = tBoxBDPass.Text;

                StreamWriter WriteFile = new StreamWriter(SystemPath + @"\opt\hidden\prime.prime");

                // Write Connection Data
                WriteFile.WriteLine($"[CONNECTION]");
                WriteFile.WriteLine($"IP_BD= {ipBD}");
                WriteFile.WriteLine($"PORT_BD= {portBD}");
                WriteFile.WriteLine($"NAME_BD= {nameBD}");
                WriteFile.WriteLine($"USER_BD= {userBD}");
                WriteFile.WriteLine($"PASS_BD= {passBD}");

                WriteFile.Flush();
                WriteFile.Close();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao salvar parâmetros de conexão com o banco de dados.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FindParameters()
        {
            try
            {
                StreamReader rd = new StreamReader(SystemPath + @"\opt\hidden\prime.prime");

                while (!rd.EndOfStream)
                {
                    string linha = rd.ReadLine();

                    if (linha.StartsWith("IP_BD"))
                        ipBD = linha.Substring(6).Trim();

                    if (linha.StartsWith("PORT_BD"))
                        portBD = linha.Substring(8).Trim();

                    if (linha.StartsWith("NAME_BD"))
                        nameBD = linha.Substring(8).Trim();

                    if (linha.StartsWith("USER_BD"))
                        userBD = linha.Substring(8).Trim();

                    if (linha.StartsWith("PASS_BD"))
                        passBD = linha.Substring(8).Trim();

                    tBoxBDServer.Text = ipBD;
                    tBoxBDPort.Text = portBD;
                    tBoxBDName.Text = nameBD;
                    tBoxBDUser.Text = userBD;
                    tBoxBDPass.Text = passBD;
                }
                rd.Close();
                rd.Dispose();
            }
            catch
            {
                tBoxBDServer.Text = "localhost";
                tBoxBDPort.Text = "5432";
                tBoxBDUser.Text = "postgres";
                tBoxBDPass.Text = "cmo4lat1";
                tBoxBDName.Text = "servipol";
                tBoxBDServer.Focus();
            }
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

        public void ConnectBD()
        {
            try
            {
                _conexao.Close();
                _conexao.Open();

                ValidatedConn = true;
            }
            catch 
            {
                ValidatedConn = false;
            }
        }

        public void DisconnectBD()
        {
            try
            {
                _conexao.Close();
            }
            catch { }
        }

        public void DisposeConnectionBD()
        {
            try
            {
                _conexao.Close();
                _conexao.Dispose();
            }
            catch { }
        }

        #endregion

        #region Buttons

        private void btnValidateConnectionBD_Click(object sender, EventArgs e)
        {
            try
            {
                ipBD = tBoxBDServer.Text;
                portBD = tBoxBDPort.Text;
                nameBD = tBoxBDName.Text;
                userBD = tBoxBDUser.Text;
                passBD = tBoxBDPass.Text;

                StringConexao = $"Server={ipBD}; Port={portBD}; User ID={userBD}; Password={passBD}; Database={nameBD};";

                this._conexao = new NpgsqlConnection();
                this._stringConexao = StringConexao;
                this._conexao.ConnectionString = StringConexao;

                ConnectBD();

                if (ValidatedConn)
                {
                    SaveParameters();
                    XtraMessageBox.Show("Conexão com o BD Efetuada com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Erro ao efetuar conexão com o banco de dados.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao salvar parâmetros de conexão com o banco de dados.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                XtraMessageBox.Show("Funcionalidade em Desenvolvimento!", "Em breve...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao Realizar Backup.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                XtraMessageBox.Show("Funcionalidade em Desenvolvimento!", "Em breve...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao Realizar Restore.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ipBD = tBoxBDServer.Text;
            portBD = tBoxBDPort.Text;
            nameBD = tBoxBDName.Text;
            userBD = tBoxBDUser.Text;
            passBD = tBoxBDPass.Text;

            StringConexao = $"Server={ipBD}; Port={portBD}; User ID={userBD}; Password={passBD}; Database={nameBD};";

            this._conexao = new NpgsqlConnection();
            this._stringConexao = StringConexao;
            this._conexao.ConnectionString = StringConexao;

            ConnectBD();

            if (ValidatedConn)
            {
                SaveParameters();
            }

            DisposeConnectionBD();

            Close();
        }

        #endregion

    }
}