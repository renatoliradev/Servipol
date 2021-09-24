using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Servipol.Entidades.Classes
{
    public class MemoryManagement
    {
        [DllImport("kernel32.dll")]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        public MemoryManagement()
        {
        }

        public void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }
    }
}
