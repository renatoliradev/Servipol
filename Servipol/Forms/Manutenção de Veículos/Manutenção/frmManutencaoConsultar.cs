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
using Servipol.Entidades.Classes;
using Npgsql;

namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    public partial class frmManutencaoConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();
        MemoryManagement MemoryManagement = new MemoryManagement();

        #endregion

        public frmManutencaoConsultar()
        {
            InitializeComponent();
        }

        private void frmManutencaoConsultar_Load(object sender, EventArgs e)
        {

        }

        private void frmManutencaoConsultar_FormClosing(object sender, FormClosingEventArgs e)
        {
            MemoryManagement.FlushMemory();
        }
    }
}