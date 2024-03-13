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

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lp1, string lp2);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        //handles minimizing the window
        //public static extern bool ShowWindowASync(IntPtr hWnd, int nCmdShow);

        //spitfire app
        IntPtr Spitfire_app;

        //Plutonium app
        IntPtr Plutonium_app;

        IntPtr Temp_con;

        //Set pointer initilaizer
        public void FindPlutoniumConsole( string? revision )
        {
            if( revision != null )
            {
                Plutonium_app = FindWindow(null, "Plutonium " + revision);
                Spitfire_app = FindWindow(null, "Spitfire_");
                Temp_con = FindWindow(null, "Command Prompt");
                
            }
            else { MessageBox.Show("Couldn't locate Plutonium. \nPlease make sure that your game is running!"); }
        }

        public async void SendCommandToGame( string command, string? value )
        {
            string seperator = ", ";
            //SetForegroundWindow(Plutonium_app);
            SetForegroundWindow(Temp_con);
            SendKeys.SendWait(command + seperator + value);
            SendKeys.SendWait("{ENTER}");
            await Task.Delay(1500);
            SetForegroundWindow(Spitfire_app);
            
        }

        public void DemoConsole( string c, string? v )
        {
            Process.Start("cmd.exe");
            
            //Process.Start(psi);
            //FindWindow(null, "Command Prompt");
            //SetForegroundWindow(Temp_con);
            Task.Delay(3000);
            //SEND KEYS FUCKS UP, MIGHT WANT TO "SEND SENDKEYS" in another thread / method
            // SendKeys.SendWait((c + ", " + v) );
            //SendKeys.SendWait("{ENTER}");
            Console.WriteLine("LOLLOLLOL");
        }


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
