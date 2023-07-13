using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace spitfire_solutions
{
    internal class FileExplorerQuery
    {
        OpenFileDialog folderSelector = new OpenFileDialog();

        //this is a debug int
        private int debugCounting = 0;

        public void OpenFilesWindow()
        {
            string mypath = new GameFolderList().giveMeAppData() + "\\Plutonium";
            if (folderSelector.CheckPathExists.Equals(mypath)) 
            {
                folderSelector.InitialDirectory = mypath;
            }
            else
            {
                folderSelector.InitialDirectory = @"C:\\";
            }
            folderSelector.Multiselect = true;
            folderSelector.Title = "Plutonium File Selector";   
        }
    }
}
