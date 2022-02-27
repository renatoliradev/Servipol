using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace ServipolConfig
{
    public partial class frmPrincipal : DevExpress.XtraEditors.XtraForm
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            btnFindSystemPath.Select();
        }

        private void SaveParameters()
        {
            try
            {
                string _systemPath = tBoxSystemPath.Text;

                string _ipBD = tBoxBDServer.Text;
                string _portBD = tBoxBDPort.Text;
                string _nameBD = tBoxBDName.Text;
                string _userBD = tBoxBDUser.Text;
                string _passBD = tBoxBDPass.Text;

                StreamWriter WriteFile = new StreamWriter(_systemPath + @"\opt\hidden\prime.prime");

                // Write Connection Data
                WriteFile.WriteLine($"[CONNECTION]");
                WriteFile.WriteLine($"IP_BD= {_ipBD}");
                WriteFile.WriteLine($"PORT_BD= {_portBD}");
                WriteFile.WriteLine($"NAME_BD= {_nameBD}");
                WriteFile.WriteLine($"USER_BD= {_userBD}");
                WriteFile.WriteLine($"PASS_BD= {_passBD}");

                WriteFile.Flush();
                WriteFile.Close();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message);
            }
        }

        private void FindParameters()
        {
            string _systemPath = tBoxSystemPath.Text;
            string _ipBD = string.Empty;
            string _portBD = string.Empty;
            string _nameBD = string.Empty;
            string _userBD = string.Empty;
            string _passBD = string.Empty;

            try
            {
                StreamReader rd = new StreamReader(_systemPath + @"\opt\hidden\prime.prime");

                while (!rd.EndOfStream)
                {
                    string linha = rd.ReadLine();

                    if (linha.StartsWith("IP_BD"))
                        _ipBD = linha.Substring(6).Trim();

                    if (linha.StartsWith("PORT_BD"))
                        _portBD = linha.Substring(8).Trim();

                    if (linha.StartsWith("NAME_BD"))
                        _nameBD = linha.Substring(8).Trim();

                    if (linha.StartsWith("USER_BD"))
                        _userBD = linha.Substring(8).Trim();

                    if (linha.StartsWith("PASS_BD"))
                        _passBD = linha.Substring(8).Trim();

                    tBoxBDServer.Text = _ipBD;
                    tBoxBDPort.Text = _portBD;
                    tBoxBDName.Text = _nameBD;
                    tBoxBDUser.Text = _userBD;
                    tBoxBDPass.Text = _passBD;
                }
                rd.Close();
                rd.Dispose();
            }
            catch
            {
                XtraMessageBox.Show("Arquivo de configuração não encontrado. \n\n Preencha os dados de conexão com o banco de dados e clique no botão [Validar Conexão com BD].", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tBoxBDServer.Text = "localhost";
                tBoxBDPort.Text = "5432";
                tBoxBDUser.Text = "postgres";
                tBoxBDPass.Text = "cmo4lat1";
                tBoxBDName.Text = "servipol";
                tBoxBDServer.Focus();
            }
        }

        #region Buttons

        private void btnValidateConnectionBD_Click(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnFindSystemPath_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog.SelectedPath = tBoxSystemPath.Text;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tBoxSystemPath.Text = folderBrowserDialog.SelectedPath;

                    FindParameters();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}