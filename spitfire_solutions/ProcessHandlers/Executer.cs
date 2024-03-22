using spitfire_solutions.ServerClasses;
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

        IntPtr Con_con;

        

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

        public async void DemoConsole( string c, string? v )
        {
            //FindPlutoniumConsole( "revision_test" );
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            
            Process.Start(psi);

            //we need this for command process exe 
            //the timer needs to delay till we type, otherwise writes it too fast and incorrectly
            await Task.Delay(670);
            
            SendKeys.SendWait("Black Ops 2 Text Test!");
            //SEND KEYS FUCKS UP, MIGHT WANT TO "SEND SENDKEYS" in another thread / method
            // SendKeys.SendWait((c + ", " + v) );
            //SendKeys.SendWait("{ENTER}");
            Console.WriteLine("LOLLOLLOL");
        }

        
        //main method of inserting stuff to a console
        public async void HookToConsole( string current_revision, string dvar, string value )
        {
            //Find a running instance of bootstrapper
            FindPlutoniumConsole(current_revision);
            //if pluto window isnt active
            if( Plutonium_app == null )
            {
                return;
            }
            //we found a window
            SetForegroundWindow(Plutonium_app);
            
            //User has input data into input area, let's read it and then send it to console


            //ProcessConnect( dvar);
            //debug
            MessageBox.Show("DVAR SENT TO CONSOLE");

            //lets return back to spitfire
            await Task.Delay(200);
            SetForegroundWindow(Spitfire_app);
        }

        //Console connect to server
        public async void ConsoleConnect(  string ip )
        {
            if( Plutonium_app != null )
            {
                //We found the window
                SetForegroundWindow(Plutonium_app);
                //paste ip and port into Plutonium console
                ProcessConnect("connect " + ip);
            }
            else { MessageBox.Show("FUCKED UP, RETRY!"); }
        }
        //parse dvar and value to characters, then send characters to console and insert a new line
        public async void ProcessConnect(string con_string)
        {
            if (Plutonium_app != null )
            {
                char[] chars = con_string.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    SendKeys.SendWait(chars[i].ToString());
                }
                SendKeys.SendWait("{ENTER}");
            }
        }



        // START OF PLUTO CONSOLE SECTION //
        public async void ConsoleExecuteDvars( string dvarName, string dvarValue )
        {
            if( Plutonium_app != null )
            {
                //in case the console is not visible
                SetForegroundWindow(Plutonium_app);
                //get var and value and paste them into the console
                ProcessDvar(dvarName, dvarValue);
            }
            else { MessageBox.Show("Couldn't execute dvar, retry."); }
        }

        public async void ProcessDvar(string dvar, string dvalue)
        {
            string dvar_combo = dvar.ToLower().ToString() + " " + dvalue.ToLower().ToString();
            char[] alphabet = dvar_combo.ToCharArray();
            for (int n = 0; n < alphabet.Length; n++)
            {
                SendKeys.SendWait(alphabet[n].ToString());
            }
            SendKeys.SendWait("\n" + "{ENTER}");
        }





        public void ShowPlutonium()
        {
            SetForegroundWindow(Plutonium_app);
        }

        // END OF PLUTO CONSOLE SECTION //
        //Set pointer initilaizer
        public void FindPlutoniumConsole(string? revision)
        {
            if (revision != null)
            {
                Plutonium_app = FindWindow(null, "Plutonium " + revision);
                Spitfire_app = FindWindow(null, "Spitfire_");
                Temp_con = FindWindow(null, "Command Prompt");
            }
            else { MessageBox.Show("Couldn't locate Plutonium. \nPlease make sure that your game is running!"); }
        }
        
        //set all window variables
        public void InitializeWindows( string revision = "r3963" )
        {
            try
            {
                Plutonium_app = FindWindow(null, "Plutonium " + revision);
                Spitfire_app = FindWindow(null, "Spitfire_");

                //for debug / basic console
                //Temp_con = FindWindow(null, "Command Prompt");
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Couldn't find Plutonium.\n" +
                    "Please make sure that your game is up and running, then retry.\n\n" + ex.Message);
            }
            
        }


        
        public void ShowSpitfire()
        {
            SetForegroundWindow(Spitfire_app);
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
