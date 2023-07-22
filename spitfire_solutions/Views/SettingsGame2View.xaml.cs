using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace spitfire_solutions.Views
{
    /// <summary>
    /// Game settings page for Spitfire
    /// </summary>
    public partial class SettingsGame2View : System.Windows.Controls.UserControl
    {
        //logic inherited from GameFolderList class
        GameFolderList gameFolderCall = new GameFolderList();

        //inherit the OpenfilesWindow viewer
        FileExplorerQuery locationViewer = new FileExplorerQuery();
        

        public SettingsGame2View()
        {
            InitializeComponent();
            CallGameFolderClass();
        }


        //creating the listbox items that we show on the GAMESETTINGS PAGE, inherits from "gamefolderlist" class
        //false pass = no scripts folder, just the executable folder
        //string pass != mp, return a zm location
        private void CallGameFolderClass()
        {
            ListBoxToGames game = new ListBoxToGames("Black Ops", gameFolderCall.bo1ScriptLocations(false, "s"));
            lstBoxChooseGame.Items.Add(game);
            game = new ListBoxToGames("Black Ops II", gameFolderCall.bo2ScriptLocations(false, "s") );
            lstBoxChooseGame.Items.Add(game);
            game = new ListBoxToGames("World At War", gameFolderCall.wawScriptLocations(false, "f"));
            lstBoxChooseGame.Items.Add(game);
            game = new ListBoxToGames( "Modern Warfare III", gameFolderCall.mwScriptLocations(false, "f") );
            lstBoxChooseGame.Items.Add(game);
        }

        private void lstBoxChooseGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //failsafe
            if( lstBoxChooseGame.Items.Count == 0 )
            {
                Console.WriteLine("oops did we fuck up");
                throw new Exception();
                
            }

            lblGameName.Content = ((ListBoxToGames)lstBoxChooseGame.SelectedItem).ObjectGameName;
            txtGameLoc.Text = ((ListBoxToGames)lstBoxChooseGame.SelectedItem).ObjectGamePath;
            //hard coded, cant be bothered out to figure out the proper way with all this workload, oops it seems like I figured it out ^
            /*
            switch ( lstBoxChooseGame.SelectedIndex )
            {
                case 0:
                    lblGameName.Content = lstBoxChooseGame.Items[0].ToString();
                    txtGameLoc.Text = gameFolderCall.bo1ScriptLocations(false, "s").ToString();
                    break;

                    case 1:
                        lblGameName.Content = lstBoxChooseGame.Items[1].ToString();
                        txtGameLoc.Text = gameFolderCall.bo2ScriptLocations(false, "s").ToString();
                        break;

                    case 2:
                    lblGameName.Content = lstBoxChooseGame.Items[2].ToString();
                    txtGameLoc.Text = gameFolderCall.wawScriptLocations(false, "s").ToString();
                    break;

                    case 3:
                    lblGameName.Content = lstBoxChooseGame.Items[3].ToString();
                    txtGameLoc.Text = gameFolderCall.mwScriptLocations(false, "s").ToString();
                    break;
            } 
            */
        }


        

        private void IconImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string pather = ((ListBoxToGames)lstBoxChooseGame.SelectedItem).ObjectGamePath;
            string namer = ((ListBoxToGames)lstBoxChooseGame.SelectedItem).ObjectGameName;
            //to display a new file explorer window with game's location
            showGameLoc(pather);
            //for debugging
            //System.Windows.Forms.MessageBox.Show("GAME PATH : " + pather + "\nGAME NAME: " + namer);
        }


        //so that we can display something else than fileexploer window title
        //not really useful for Win11 users, since theres no text to be displayed in the window title.
        //skip for now.
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string lpText);


        ///open window exploer with said parameter
        private void showGameLoc( string path )
        {
            Process.Start(path);   
        }
    }
}
