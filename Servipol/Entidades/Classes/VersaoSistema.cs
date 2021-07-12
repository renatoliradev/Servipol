using DevExpress.XtraEditors;
using Npgsql;
using System.Windows.Forms;

namespace Servipol.Entidades.Classes
{
    class VerificaVersaoSistema
    {
        ConexaoBD BD = new ConexaoBD();
        public string VersaoExe { get; set; }
        public string VersaoBD { get; set; }

        public string VersaoSistema()
        {
            try
            {
                BD.Conectar();

                 VersaoBD = string.Empty;
                 VersaoExe = this.GetType().Assembly.GetName().Version.ToString();

                //Versão do BD
                NpgsqlCommand com = new NpgsqlCommand("SELECT versao FROM sis_controle_versao ORDER BY id_sis_controle_versao DESC LIMIT 1", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VersaoBD = dr["versao"].ToString();
                    }

                    if (VersaoBD != VersaoExe)
                    {
                        if (XtraMessageBox.Show($"A versão do executável é diferente da versão do banco de dados!\n\nVersão do Executável: {VersaoExe}\nVersão do Banco de Dados: {VersaoBD}", "Versão Incompatível", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            Application.Exit();
                        }
                    }
                    return VersaoExe;
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }
    }
}
