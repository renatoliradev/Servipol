using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Servipol
{
    class Util : frmPrincipal
    {
        [DllImport("kernel32.dll")]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        public Util() { }

        public void FechaForms()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            LimpaMemoria();
        }
        public void LimpaMemoria()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }
    }
}
