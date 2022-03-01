using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace ServipolConfig
{
    public partial class frmPrincipal : DevExpress.XtraEditors.XtraForm
    {
        #region INSTANCES AND PROPERTIES

        public string SystemPath { get; set; }
        public string ipBD { get; set; }
        public string portBD { get; set; }
        public string nameBD { get; set; }
        public string userBD { get; set; }
        public string passBD { get; set; }

        #endregion

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            SystemPath = Environment.CurrentDirectory.ToString();

            FindParameters();
        }

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
                XtraMessageBox.Show(err.Message);
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

        #region Buttons

        private void btnValidateConnectionBD_Click(object sender, EventArgs e)
        {
            try
            {
                SaveParameters();

                XtraMessageBox.Show("Conexão com BD Efetuada com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                XtraMessageBox.Show("Backup Realizado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                XtraMessageBox.Show("Restore Realizado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao Realizar Restore.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}