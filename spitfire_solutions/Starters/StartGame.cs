using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.Starters
{
    internal class StartGame
    {
        //when we choose a game, this string is set to get the executable's name
        public string Gname { get; set; }
        //executables
        public string[] gameNames =
        {
            "t4sp.exe",
            "t4mp.exe",
            "t5sp.exe",
            "t5mp.exe",
            "t6zm.exe",
            "t6mp.exe",
            "iw5mp.exe",
            "iw5sp.exe"
        };

        public void StartPlutoniumGame( string game )
        {

            //user's appdata folder
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
           
            //paths we need to combine on top of the appdata folder
            string[] subDirs =
            {
                "Plutonium",
                "games"
            };

            //full path to games folder
            string folderPath = System.IO.Path.Combine(appData, System.IO.Path.Combine(subDirs));
            
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] files = dir.GetFiles();
            string executableToStart;
            foreach (FileInfo fi in files)
            {
                if (fi.Name == game )
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
