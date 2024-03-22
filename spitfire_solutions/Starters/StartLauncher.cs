using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.Starters
{
    internal class StartLauncher
    {
        public void StartPlutoniumLauncher()
        {
            //plutonium-launcher-win32.exe
            string lr = "plutonium-launcher-win32.exe";
            string lp = "Plutonium Launcher";

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string remainingPath = "\\Plutonium\\bin\\";
            string[] subDirs =
            {
                "Plutonium",
                "bin"
            };
            string folderPath = System.IO.Path.Combine(appData, System.IO.Path.Combine(subDirs));
            string executableToStart;
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo fi in files)
            {
                if (fi.Name == lr)
                {
                    executableToStart = fi.Name;
                    Console.WriteLine(executableToStart);
                    Process.Start(folderPath + "\\" + executableToStart);
                    break;
                }
            }
        }
    }
}
