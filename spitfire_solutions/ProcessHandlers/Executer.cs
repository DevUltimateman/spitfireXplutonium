using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spitfire_solutions.ProcessHandlers
{
    internal class Executer
    {

        public void ExecuteCommands()
        {
            Process executeProcess = new Process();

            executeProcess.StartInfo.FileName = "plutonium-bootstrapper-win32.exe";


        }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lp1, string lp2);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public void MakeShitHappen()
        {
            IntPtr handle = FindWindow("ConsoleWindowClass", "plutonium-bootstrapper-win32");
            if (!handle.Equals(IntPtr.Zero))
            {
                if (SetForegroundWindow(handle))
                {
                    // send 
                    SendKeys.Send("cg_fov" + 90 );
                    // send key "Enter"
                    SendKeys.Send("{ENTER}");
                }
            }
        }

    }
}
