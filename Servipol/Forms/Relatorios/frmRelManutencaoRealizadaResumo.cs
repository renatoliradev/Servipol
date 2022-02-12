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

namespace Servipol.Forms.Relatórios.Manutenção_de_Veículos
{
    public partial class frmRelManutencaoRealizadaResumo : DevExpress.XtraEditors.XtraForm
    {
        public frmRelManutencaoRealizadaResumo()
        {
            InitializeComponent();
        }

        private void frmRelManutencaoRealizadaResumo_Load(object sender, EventArgs e)
        {
            this.reportViewerResumoManutRealizada.RefreshReport();
        }
    }
}