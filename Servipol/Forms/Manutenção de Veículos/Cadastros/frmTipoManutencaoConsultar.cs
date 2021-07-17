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
    public partial class frmTipoManutencaoConsultar : DevExpress.XtraEditors.XtraForm
    {
        public frmTipoManutencaoConsultar()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmTipoManutencaoCadastrar frmTipoManutencaoCadastrar = new frmTipoManutencaoCadastrar("TipoManutencao", 0);
            frmTipoManutencaoCadastrar.Owner = this;
            frmTipoManutencaoCadastrar.ShowInTaskbar = false;
            frmTipoManutencaoCadastrar.ShowDialog();
        }
    }
}