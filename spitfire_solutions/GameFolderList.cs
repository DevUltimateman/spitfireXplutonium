using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

namespace spitfire_solutions
{
    internal class GameFolderList
    {

        //debug title
        private string spit = "***Spitfire_Solutions Debugger***";

        //generic error
        private string fml = "The program fucked up & don't know what to do!\n Error: ";

        //extension names for folder paths / scripts

        //multi
        private string scriptsFolderPath_multi = "\\scripts\\zm";

        //zombie
        private string scriptsFolderPath_zombie = "\\scripts\\zm";

        //textures
        private string textureFolderPath = "\\images";

        private string pluto = "\\Plutonium\\storage\\";
        //generic expressions
        private string gameFolderNotFound = "Spitfire was unable to locate ";
        private string gameFolderAsk = "Would you like the program to create this path for you?";


        //listbox for storing the game list
        public ListBox gameListBox = new ListBox();

        //find user's local appdata where we'll merge the extensions names on top
        public string giveMeAppData()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }


        //INCASE WE WANT TO KNOW THE GAME LOCATIONS IN ANOTHER CLASS WITHOUT THE ARRAY RETURN DEFINED IN RETURNMODFOLDERS()

        

        //ALL RETURN VALUES FOR INHERITANCES
        public string bo1ScriptLocations( bool scripts, string mode )
        {
            if( scripts )
            {
                if (mode == "mp") { return giveMeAppData() + pluto + "t5" + scriptsFolderPath_multi; }
                else return giveMeAppData() + pluto + "t5" + scriptsFolderPath_zombie;
            }
            else { return giveMeAppData() + pluto + "t5"; }
        }

        public string bo2ScriptLocations( bool scripts, string mode )
        {
            if (scripts)
            {
                if (mode == "mp") { return giveMeAppData() + pluto + "t6" + scriptsFolderPath_multi; }
                else return giveMeAppData() + pluto + "t6" + scriptsFolderPath_zombie;
            }
            else { return giveMeAppData() + pluto + "t6"; }
        }

        public string wawScriptLocations( bool scripts, string mode )
        {
            if (scripts)
            {
                if (mode == "mp") { return giveMeAppData() + pluto + "t4" + scriptsFolderPath_multi; }
                else return giveMeAppData() + pluto + "t4" + scriptsFolderPath_zombie;
            }
            else { return giveMeAppData() + pluto + "t4"; }
        }

        public string mwScriptLocations( bool scripts, string mode )
        {
            if (scripts)
            {
                if (mode == "mp") { return giveMeAppData() + pluto + "iw5" + scriptsFolderPath_multi; }
                else return giveMeAppData() + pluto + "iw5" + scriptsFolderPath_zombie;
            }
            else { return giveMeAppData() + pluto + "iw5"; }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        //all the available games on plutonium atm
        public string[] returnGames()
        {
            string[] gameNames = {
                "Black Ops Multiplayer",
                "Black Ops Zombies",
                "Black Ops II Multiplayer",
                "Black Ops II Zombies",
                "World At War Multiplayer",
                "World At War Zombies",
                "Modern Warfare III"
            };

            //let's return the array
            return gameNames;
        }

        //let's populate the list box with our gamelist
        public void makeGameList( bool showMessage, ListBox lboxParam )
        {
            //clear all previous items just in case
            if( lboxParam.Items.Count > 0 )
            {
                try
                {
                    lboxParam.Items.Clear();
                }

                catch( Exception a)
                {
                    MessageBox.Show(fml + a.Message);
                }
            }

            //okay the list is clear, now populate it.
            string[] templist = returnGames();
            lboxParam.ItemsSource = templist;

            //debug stuff
            //let's see if we have populated the list and and print em out in console.
            for( int i = 0; i < lboxParam.Items.Count; i++ )
            {
                if( showMessage )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine( lboxParam.Items[i].ToString() );
                }
            }

            //show the total amount ( during prod. )
            MessageBox.Show("Total amount of games: " + lboxParam.Items.Count.ToString(), spit );

            //if debug enable
            if( showMessage )
            {
                MessageBox.Show("Your appdata path: " + giveMeAppData());
            }

            //let's pass mod folders to a temp array
            string[] temps = returnModFolders();
        }


        public string[] returnModFolders()
        {
            //pluto/storage
            string pluto = "\\Plutonium\\storage\\";

            string bo1mp = giveMeAppData() + pluto + "t5";
            string bo1zm = giveMeAppData() + pluto + "t5";
            string bo2mp = giveMeAppData() + pluto + "t6";
            string bo2zm = giveMeAppData() + pluto + "t6";
            string wawmp = giveMeAppData() + pluto + "t4";
            string wawzm = giveMeAppData() + pluto + "t4";
            string mw = giveMeAppData() + pluto + "iw5";

            //pass all the strings into an array
            string[] myGameLocations = 
            {
                bo1mp, bo1zm,
                bo2mp, bo2zm,
                wawmp, wawzm,
                mw
            };

            //return the array info from this method
            return myGameLocations;
        }

        public void setGameLocsAuto()
        {
            string[] locs = returnModFolders();

            //let's set all the game locations
            try
            {
                for( int s = 0; s < locs.Length; s++ )
                {
                    //it's a mp folder
                    if( s % 2 == 0)
                    {
                        if (!Directory.Exists(locs[s]))
                        {
                            //let's ask the user
                            //if we wants the program to make the folder
                            //in case its not found.

                            MessageBoxResult askv = MessageBox.Show("Folder: " + locs[s] + " was not found." +
                                "\nDo you want the program to create this automatically?", spit );

                            if (askv == MessageBoxResult.Yes)
                            {
                                Directory.CreateDirectory(locs[s]);
                                Console.WriteLine("Folderpath: " + locs[s] + " was created!");
                            }
                            else
                            {
                                Console.WriteLine("Damn, ok. Set it up manually later");
                            }


                        }
                    }
                    
                    //it's a zombies folder
                    else
                    {
                        if (!Directory.Exists(locs[s]))
                        {
                            MessageBoxResult askzm = MessageBox.Show("Folder: " + locs[s] + " was not found." +
                               "\nDo you want the program to create this automatically?", spit);

                            if(askzm == MessageBoxResult.Yes)
                            {
                                Directory.CreateDirectory(locs[s]);
                                Console.WriteLine("Folderpath: " + locs[s] + " was created!");
                            }

                            else
                            {
                                Console.WriteLine("Damn, ok. Set it up manually later");
                            }
                        }
                    }
                }
            }
            catch (Exception oioi )
            {
                throw new Exception(oioi.Message);
            }
        }
    }
}
