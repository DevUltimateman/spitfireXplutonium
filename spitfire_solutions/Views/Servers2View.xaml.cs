using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using spitfire_solutions.ServerClasses;
using System.ComponentModel;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.IO.Packaging;
using spitfire_solutions.MapNamesToReadable;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Resources;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Globalization;
using spitfire_solutions.ProcessHandlers;
/*

R58KB0RVX3E
R58KB0RVX3E
R58KB0RVX3E
R58KB0RVX3E
*/
//for json

namespace spitfire_solutions.Views
{
    public partial class Servers2View : UserControl
    {
        public Servers2View()
        {
            InitializeComponent();
        }

        
        //HANDLE THE BITMAP IMAGE THAT WE SHOW IN THE INFO BOX
        BitmapImage BmInfoBox = new BitmapImage();

        List<ServerListInfo> serverinfo = new List<ServerListInfo>();

        //Don't repeat the bitmap everytime if the game stays same
        public string IsTheGameSame;

        //KEEP TRACK OF SELECTED LIST INDEX
        public int LST_CURRENT_INDEX;

        //PUBLIC COUNT
        public string debugval;
        //BITMAP URIS
        //world at war
        public string t4spuri = "/images/logo_titles/t4sp_logotitle.png";
        public string t4mpuri = "/images/logo_titles/t4mp_logotitle.png";
        //black ops
        public string t5spuri = "/images/logo_titles/t5sp_logotitle.png";
        public string t5mpuri = "/images/logo_titles/t5mp_logotitle.png";
        //black ops 2
        public string t6zmuri = "/images/logo_titles/t6zm_logotitle.png";
        public string t6mpuri = "/images/logo_titles/t6mp_logotitle.png";
        //modern warfare 3
        public string iw5uri = "/images/logo_titles/iw5_logotitle.png";

        /*THESE MIGHT GET DEFUCKED SINCE THEY ARE PRETTY MUCH USELESS
        WITH THE NEW LISTVIEWITEM SOURCE METHOD GETS THE DATA DIRECTLY FROM
        CUSTOM SERVERINFO CLASS*/
        //DEFINE THE SERVER LISTS
        List<string> slst_Hostname = new List<string>();
        List<string> slst_Mapname= new List<string>();
        List<string> slst_Gametype = new List<string>();
        List<int> slst_Players = new List<int>();
        List<string> slst_Maxplayers = new List<string>();
        List<string> slst_Hardcore = new List<string>();
        List<string> slst_Password = new List<string>();
        List<int> slst_Round = new List<int>();
        //List<string> = new List<string>();

        List<string> slst_Ip = new List<string>();
        List<string> slst_Port = new List<string>();
        List<string> slst_Game = new List<string>();

        List<string> slst_Username = new List<string>();
        List<string> slst_Id = new List<string>();
        List<string> slst_Ping = new List<string>();
        List<string> slst_Userslug = new List<string>();

        //to keep count of all of the available servers
        public int pb_servers_online;

        public CultureInfo cult;

        public int current_index = 0;

        public string api = "https://plutonium.pw/api/servers/plutonium/t6mp";
        public string apiRaid = "http://api.raidmax.org:5000/servers";
        public string v1Api = ("https://api.plutools.pw/v1/servers");
        public string Tt;
        HttpClient _httpClient = new HttpClient();

        //SERVERFILE
        //CHANGE THE DIRECTORY TO GO INSIDE OF PLUTONIUM FOLDER LATER
        public string ServerFile = @"C:\Temp\A_TEST_SERVERLIST_DEMO.txt";

        //TEST FILE
        public string TestFile = @"C:\Temp\A_TEST_SERVERLIST_HOST.txt";

        //game thats chosen from list
        public string ChosenGame;

        public string zombie_bo1_servers = "https://api.plutools.pw/v1/servers/plutonium/t5sp";
        public string zombie_bo2_servers = "https://api.plutools.pw/v1/servers/plutonium/t6zm";
        public string zombie_waw_servers = "https://api.plutools.pw/v1/servers/plutonium/t4sp";

        
        public string multi_bo1_servers = "https://api.plutools.pw/v1/servers/plutonium/t5mp";
        public string multi_bo2_servers = "https://api.plutools.pw/v1/servers/plutonium/t6mp";
        public string multi_waw_servers = "https://api.plutools.pw/v1/servers/plutonium/t4mp";
        public string multi_mw3_servers = "https://api.plutools.pw/v1/servers/plutonium/iw5mp";


        //Creates server list file
        //Another method handles parsing info from the file that this method creates
        //arg takes the proper game selected
        public async void CreateTextFile( string servers)
        {
            try
            {
                //For refreshing the server list, delete old one before creating new one
                //Serverfile defined on top of this class
                if (System.IO.File.Exists(ServerFile))
                {
                    System.IO.File.Delete(ServerFile);
                }

                using (FileStream fs = System.IO.File.Create(ServerFile))
                {
                    //uses method's arg to pass in the correct game url
                    var response_msg = await _httpClient.GetAsync(servers);
                    //waits
                    string jsonResponse = await response_msg.Content.ReadAsStringAsync();
                    //write the string to blanco
                    byte[] bytes = Encoding.ASCII.GetBytes(jsonResponse);
                    fs.Write(bytes, 0, bytes.Length);
                }
                //deserialize it
                string serverData = System.IO.File.ReadAllText(ServerFile);
                ServerListParser();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //RETURN API CALLS FROM 
        //ANOTHER METHOD HANDLES TYPE RANGING
        public void ServerListParser()
        {
            //we need to keep a check to not get a null value, otherwise we crash
            bool KeepLooping = true;
            int KeepTrack = 0;
            debugval = string.Empty;

            while ( KeepLooping )
            {
                try
                {
                    //failsafe
                    slst_Hostname.Clear();
                    slst_Mapname.Clear();
                    slst_Round.Clear();
                    slst_Players.Clear();
                    slst_Game.Clear();
                    serverinfo.Clear();

                    //if we have any objects in the list, remove them
                    for (int s = 0; s < lstViewServer.Items.Count; s++)
                    {
                        lstViewServer.Items.Remove(lstViewServer.Items[s]);
                    }
                    lstViewServer.Items.Clear();
                    //READ THE JSON DATA FROM THE FILE THAT WE JUST CREATED!
                    using (StreamReader su = new StreamReader(ServerFile))
                    {
                        //CREATE A STRING THAT STORES THE JSON DATA AS A VARIABLE
                        string jsonString = System.IO.File.ReadAllText(ServerFile);

                        //MAKE INSTANCE OF EACH "SERVERCLASSES" MODULE
                        var deserial = JsonConvert.DeserializeObject<Root>(jsonString);

                        //Let's test print

                        //check that we retrieve json data for the server list
                        //otherwise we crash unless theres no check
                        if (deserial != null)
                        {
                            Console.WriteLine("Total player count: " + deserial.countPlayers);
                            Console.WriteLine("Mapname: " + deserial.servers[0].hostname);
                            //print all servers to console for now
                            for (int i = 0; i < deserial.countServers; i++)
                            {
                                //specify the server sub class that we want to "print"
                                //ex. deserial.servers[ key ].whattype
                                Console.WriteLine("Server name: " + deserial.servers[i].hostname);

                                //Add to specific list
                                slst_Hostname.Add(deserial.servers[i].hostname);
                                slst_Mapname.Add(deserial.servers[i].map);
                                slst_Round.Add(deserial.servers[i].round);
                                slst_Players.Add(deserial.servers[i].realClients);
                                slst_Game.Add(deserial.servers[i].game);

                                //debug laterrr
                                //works now
                                //RN ONLY PRINTS FIRST NAME AND STOPS THEN

                                //reset debugval for each instance we make
                                //this seems to fix it for now
                                debugval = string.Empty;
                                //check server "x" player count and get players names if there are any
                                int s = deserial.servers[i].players.Count;
                                if (s > 0)
                                {
                                    for (int a = 0; a < s; a++)
                                    {

                                        debugval += deserial.servers[i].players[a].username + "    P: " + deserial.servers[i].players[a].ping.ToString() + "\n";
                                    }
                                }


                                CreateServerList(
                                                    deserial.servers[i].hostname,
                                                    deserial.servers[i].map,
                                                    deserial.servers[i].realClients,
                                                    deserial.servers[i].round,
                                                    deserial.servers[i].game,
                                                    debugval,
                                                    deserial.servers[i].gametypeDisplay,
                                                    deserial.servers[i].maxplayers.ToString(),
                                                    "" //temp for player ping now,
                                                    
                                                    
                                                    
                                                    
                                                   );
                            }
                            for (int j = 0; j < slst_Hostname.Count; j++)
                            {
                                lstViewServer.Items.Add(serverinfo[j]);
                            }


                            pb_servers_online = deserial.countServers;
                            //auto click the first row to display some data on the right info box area
                            lstViewServer.SelectedIndex = 0;
                            //need this so that we can index the list with arrows without pressing on the list with mouse first
                            lstViewServer.Focus();

                            //let's jump out of the loop, we found servers and can display them
                            KeepLooping = false;
                            KeepTrack = 0;
                            break;
                        }
                        //maybe couldnt fetch anything, tell it to the user
                        if (deserial == null)
                        {
                            System.Windows.Forms.MessageBox.Show("Couldn't retrieve server data, please try again later. \n\nPlease check your connection to ensure that you're connected online.\n\n");
                        }
                        
                    }
                }
                //the index is out of range, happens if the method is called when the previous one is running
                //skip crash and keep the try method looping till index is non negative
                catch (Exception e)
                {
                    KeepLooping = true;
                    KeepTrack++;
                    
                    Console.
                        WriteLine("Progma has tried " + KeepTrack.ToString() + " to process the ´try loop() ");
                    //System.Windows.Forms.MessageBox.Show("Couldn't retrieve server data, please try again later. \n\nPlease check your connection to ensure that you're connected online.\n\n" + e.Message);

                }
            }
        }

        //FILLS THE PROPER INFO TO PROPER ELEMENTS FROM SERVER
        public void DisplayServerData(int? index_at)
        {
            //servername
            string s_host = serverinfo[lstViewServer.SelectedIndex].Host;

            //console mapname
            string s_mapname = serverinfo[lstViewServer.SelectedIndex].MapName;

            //executable
            string s_game = serverinfo[lstViewServer.SelectedIndex].Game;

            //current round i.e round 25 on zombies
            string s_round = serverinfo[lstViewServer.SelectedIndex].Round;

            //current player size
            string s_rclients = serverinfo[lstViewServer.SelectedIndex].PlayersPlaying;

            //gametype readable
            string s_gtypes = serverinfo[lstViewServer.SelectedIndex].GameType;

            //empty return
            string s_desc = serverinfo[lstViewServer.SelectedIndex].Description;

            //max player size on lobby
            string s_maxplayers = serverinfo[lstViewServer.SelectedIndex].MaxPlayers;

            //all available servers in numbers
            string s_server_online = pb_servers_online.ToString();
            

            txtServerName.Text = s_host;
            txtRound.Text = s_round;
            txtRealClients.Text =  s_rclients;

            txtGametype.Text = s_gtypes;
            txtLobbySize.Text = s_rclients + " / " + s_maxplayers;

            txtServersOnline.Text = s_server_online;

            DisplayServerGameLogo(s_game);

            //for displaying only t6 zom mapnames now till we get more important things worked on first
            if (ShouldWriteConsoleNames(s_game))
            {
                Console.WriteLine("WE SHOULD PARSE CONSOLE NAMES FOR " + s_game.ToString());
            }
            //SelectedGameToParseMapName invokes 2 methods and returns the converted name
            txtMapName.Text = s_mapname;//SelectGameToParseMapName(s_game, s_mapname);

            //player name list

            //serverinfo[lstViewServer.SelectedIndex].PlayerList != string.Empty )
            
            //for sSOME REASON MOST TEXT IS CUT OUT NOW. FIX LATERR!!
            
                txtPlayerNames.Text = serverinfo[lstViewServer.SelectedIndex].PlayerList.ToString();
            
            MakeImage(s_mapname, s_game );
        }

        //chooses which method to unfuck console_mapnames
        public string SelectGameToParseMapName( string exc, string map )
        {
            string readable_mapname;
            switch( exc )
            {
                case "t6zm":
                    MapNames_T6ZM t6z = new MapNames_T6ZM();
                    readable_mapname = t6z.ConvertT6ZombieMaps(map);
                    return readable_mapname;

                case "t6mp":
                    MapNames_T6MP t6m = new MapNames_T6MP();
                    readable_mapname = t6m.ConvertT6MultiMaps(map);
                    return readable_mapname;

                case "t5sp":
                    MapNames_T5SP t5s = new MapNames_T5SP();
                    readable_mapname = t5s.ConvertT5ZombieMaps(map);
                    return readable_mapname;

                case "t5mp":
                    MapNames_T5MP t5m = new MapNames_T5MP();
                    readable_mapname = t5m.ConvertT5MultiMaps(map);
                    return readable_mapname;

                case "t4sp":
                    MapNames_T4SP t4s = new MapNames_T4SP();
                    readable_mapname = t4s.ConvertT4ZombieMaps(map);
                    return readable_mapname;

                case "t4mp":
                    MapNames_T4MP t4m = new MapNames_T4MP();
                    readable_mapname = t4m.ConvertT4MultiMaps(map);
                    return readable_mapname;

                case "iw5mp":
                    MapNames_IW5MP iw5m = new MapNames_IW5MP();
                    readable_mapname = iw5m.ConvertIW5MultiMaps(map);
                    return readable_mapname;

            }
            return "SelectGameToParseMapName() failed to execute proper method.";
        }


        //for now
        public bool ShouldWriteConsoleNames( string gamename )
        {
            if( gamename == "t6zm" )
            {
                return true;
            }
            return false;
        }


        public async void MakeImage(string mapImage, string gameName)
        {
            ConvertImagesToStack(mapImage, gameName);
            Console.WriteLine("DEBUGGING TO GET MAP: " + mapImage);
        }

        
        //CRASHES FIX THIS
        //TODO
        //stackpanel background converter, game_to_image == the exact filename that we need to match based on console.mapnamev
        public void ConvertImagesToStack(string game_to_image, string exe_to_image)
        {
            string mp_starts = "mp";
            string zm_starts = "zm";
            string sp_starts = "sp";

            try
            {
                //for multiplayer filtering ( temp )
                if (game_to_image.Contains(mp_starts))
                {
                    imgBack.Source = new BitmapImage(new Uri(@"pack://application:,,,/images/map_images/bo2/mp/processed/" + game_to_image + ".png"));
                    stckImage.ImageSource = imgBack.Source;
                }
                //for zombies filtering ( temp )
                else if (game_to_image.Contains(zm_starts))
                {
                    imgBack.Source = new BitmapImage(new Uri(@"pack://application:,,,/images/map_images/bo2/zm/processed/map_backgrounds/" + game_to_image + ".jpg"));
                    stckImage.ImageSource = imgBack.Source;
                }
            }
            //if we fail to get the image / the server plays custom map that we don't have the image for?...
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                //imgBack.Source = new BitmapImage(new Uri(@"pack://application:,,,/images/map_images/bo2/mp_test.png"));
            }
        }

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);
        public string DisplayServerGameLogo( string game )
        {
            //Check if the game stays same
            //we don't need to remake bitmap unless the image needs to be rendered again
            if( IsTheGameSame == game )
            {
                Console.WriteLine("don't repeat the image"); 

            }
            else if( IsTheGameSame != game )
            {
                switch (game)
                {
                    case "t4sp":
                        BitmapImage bm_t4sp= new BitmapImage(new Uri(t4spuri, UriKind.Relative));
                        imgServerGameLogo.Source = bm_t4sp;
                        break;

                    case "t4mp":
                        BitmapImage bm_t4mp = new BitmapImage(new Uri(t4mpuri, UriKind.Relative));
                        imgServerGameLogo.Source = bm_t4mp;
                        break;

                    case "t5sp":
                        BitmapImage bm_t5sp = new BitmapImage( new Uri(t5spuri, UriKind.Relative));
                        imgServerGameLogo.Source = bm_t5sp;
                        break;

                    case "t5mp":
                        BitmapImage bm_t5mp = new BitmapImage( new Uri( t5mpuri, UriKind.Relative));
                        imgServerGameLogo.Source = bm_t5mp;
                        break;

                    case "t6zm":
                        
                        BitmapImage bm_t6zm = new BitmapImage(new Uri(t6zmuri, UriKind.Relative));
                        imgServerGameLogo.Source = bm_t6zm;
                        break;
                    case "t6mp":
                        BitmapImage bm_t6mp = new BitmapImage(new Uri(t6mpuri, UriKind.Relative));
                        imgServerGameLogo.Source = bm_t6mp;
                        break;
                    case "iw5":
                        BitmapImage bm_iw5 = new BitmapImage(new Uri(iw5uri, UriKind.Relative));
                        imgServerGameLogo.Source = bm_iw5;
                        break;
                }
            }
            return null;
        }

        private void btnRefresh_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //DeleteAllCurrentElements();
        }

        private void fnbo1mp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateTextFile( multi_bo1_servers );
        }
        private void fnbo1zm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateTextFile(zombie_bo1_servers);
        }
        private void fnbo2mp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateTextFile(multi_bo2_servers);
        }
        private void fnbo2zm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateTextFile(zombie_bo2_servers);
        }
        private void fnt4sp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateTextFile(zombie_waw_servers);
        }
        private void fnt4mp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateTextFile(multi_waw_servers);
        }
        private void fniw5mp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateTextFile(multi_mw3_servers);
        }
        private void txtSortList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //SortList();
        }

        // THIS FETCHES THE URL AND DESERIALIZES IT
        public async void MyJsonOutput(string str)
        {
            try
            {
                var response_msg = await _httpClient.GetAsync(str);
                string jsonResponse = await response_msg.Content.ReadAsStringAsync();
                Console.WriteLine(jsonResponse);
            }
            catch (Exception e) { System.Windows.Forms.MessageBox.Show(e.Message); }
        }


        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            //new test, make the text file of all api return
            ServerListParser();
        }

        private void lstViewServer_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DisplayServerData(lstViewServer.SelectedIndex);
        }

        //add a new entry / item and it's sub items to serverinfo() class to listitem
        public void CreateServerList(string host, string mapname, int playersize, int round, string game, string player_names, string gametype, string maxplayers, string playerping )
        {
            serverinfo.Add(new ServerListInfo() { 
            Host = host,
            MapName = mapname,
            Round = round.ToString(),
            PlayersPlaying = playersize.ToString(),
            Game = game,
            PlayerList = player_names,
            GameType = gametype,
            MaxPlayers = maxplayers,
            PlayerPing = playerping
            //ServersOnline = servers_o
            

                });;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Executer ex = new Executer();
            ex.MakeShitHappen();
        }
    }
}
