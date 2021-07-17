using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmLocalManutencaoConsultar : DevExpress.XtraEditors.XtraForm
    {
        public frmLocalManutencaoConsultar()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmLocalManutencaoCadastrar frmLocalManutencaoCadastrar = new frmLocalManutencaoCadastrar("TipoManutencao", 0);
            frmLocalManutencaoCadastrar.Owner = this;
            frmLocalManutencaoCadastrar.ShowInTaskbar = false;
            frmLocalManutencaoCadastrar.ShowDialog();
        }
    }
}