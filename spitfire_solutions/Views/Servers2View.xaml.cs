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

        public string zombie_bo1_servers = "https://api.plutools.pw/v1/servers/plutonium/t5zm";
        public string zombie_bo2_servers = "https://api.plutools.pw/v1/servers/plutonium/t6zm";
        public string zombie_waw_servers = "https://api.plutools.pw/v1/servers/plutonium/wawzm";

        public string ChosenGame;
        public string multi_bo1_servers = "https://api.plutools.pw/v1/servers/plutonium/t5mp";
        public string multi_bo2_servers = "https://api.plutools.pw/v1/servers/plutonium/t6mp";
        public string multi_waw_servers = "https://api.plutools.pw/v1/servers/plutonium/wawmp";
        public string multi_mw3_servers = "https://api.plutools.pw/v1/servers/plutonium/mw3";

        public void showServers()
        {
            /*
            //server urls for each game ( json )
            string zombie_bo1_servers = "https://api.plutools.pw/v1/servers/plutonium/t5zm";
            string zombie_bo2_servers = "https://api.plutools.pw/v1/servers/plutonium/t6zm";
            string zombie_waw_servers = "https://api.plutools.pw/v1/servers/plutonium/wawzm";


            string multi_bo1_servers = "https://api.plutools.pw/v1/servers/plutonium/t5mp";
            string multi_bo2_servers = "https://api.plutools.pw/v1/servers/plutonium/t6mp";
            string multi_waw_servers = "https://api.plutools.pw/v1/servers/plutonium/wawmp";
            string multi_mw3_servers = "https://api.plutools.pw/v1/servers/plutonium/mw3";
            */
        }

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

                using (System.IO.FileStream fs = System.IO.File.Create(ServerFile))
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

            //ANOTHER FAILSAFE
            //WE GET ERROR EVERYNOW AND THEN THAT THE INDEX IS OUT OF RANGE,
            //LOOP THE TRY METOD TILL WE SETTLE INDEX AND CAN DISPLAY DATA.
            //ONCE INDEX SETTLED, BREAK OUT OF THE LOOP. GHETTO FIX BUT WORKS AND BRINGS THE LSTVIEW ITEMS TO VIEW CORRECTLY
            
            //THIS THE GHETTO CHECK
            bool KeepLooping = true;

            while( KeepLooping)
            {
                //failsafe
                try
                {

                    //another failsafe
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
                                //lstViewServer.Items.Add( deserial.servers[i].hostname);

                                //Add to specific list
                                slst_Hostname.Add(deserial.servers[i].hostname);
                                slst_Mapname.Add(deserial.servers[i].map);
                                slst_Round.Add(deserial.servers[i].round);
                                slst_Players.Add(deserial.servers[i].realClients);
                                slst_Game.Add(deserial.servers[i].game);

                                //debug laterrr
                                //works now
                                CreateServerList(
                                                    deserial.servers[i].hostname,
                                                    deserial.servers[i].map,
                                                    deserial.servers[i].realClients,
                                                    deserial.servers[i].round,
                                                    deserial.servers[i].game
                                                   /* deserial.servers[i].players.ToString()*/);
                            }
                            for (int j = 0; j < slst_Hostname.Count; j++)
                            {
                                lstViewServer.Items.Add(serverinfo[j]);
                            }
                            //auto click the first row to display some data on the right info box area
                            lstViewServer.SelectedIndex = 0;
                        }
                        //maybe couldnt fetch anything, tell it to the user
                        if (deserial == null)
                        {
                            System.Windows.Forms.MessageBox.Show("Couldn't retrieve server data, please try again later. \n\nPlease check your connection to ensure that you're connected online.\n\n");
                        }
                        //let's jump out of the loop, we found servers and can display them
                        KeepLooping = false;
                        break;
                    }
                }
                //the index is out of range, happens if the method is called when the previous one is running
                //skip crash and keep the try method looping till index is non negative
                catch (Exception e)
                {
                    KeepLooping = true;
                    //System.Windows.Forms.MessageBox.Show("Couldn't retrieve server data, please try again later. \n\nPlease check your connection to ensure that you're connected online.\n\n" + e.Message);

                }
            }
        }


        // THIS FETCHES THE URL AND DESERIALIZES IT
        public async void MyJsonOutput(string str)
        {
            try
            {
                var response_msg = await _httpClient.GetAsync(str);
                //read it
                string jsonResponse = await response_msg.Content.ReadAsStringAsync();
                Console.WriteLine(jsonResponse);

            }

            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }
        }



        

        
        //BUTTON STUFF, MAKE PRETTIER LATER
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            //new test, make the text file of all api return

            ServerListParser();
        }

        private void lstViewServer_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
                
                DisplayServerData(lstViewServer.SelectedIndex);
            
                   
        }


        //FILLS THE PROPER INFO TO PROPER ELEMENTS FROM SERVER
        public void DisplayServerData( int? index_at )
        {



            //string s = slst_Mapname.ElementAt(lstViewServer.SelectedIndex);
            


            string s_host = serverinfo[lstViewServer.SelectedIndex].SL_Host;
            string s_mapname = serverinfo[lstViewServer.SelectedIndex].SL_MapName;
            string s_game = serverinfo[lstViewServer.SelectedIndex].SL_Game;

            string s_round = serverinfo[lstViewServer.SelectedIndex].SL_Round;
            string s_rclients = serverinfo[lstViewServer.SelectedIndex].SL_PlayersPlaying;
            //string s_playernames = serverinfo[lstViewServer.SelectedIndex].SL_Players;

            //string s_gametype = serverinfo[lstViewServer.SelectedIndex]

            txtServerName.Text = "Server: " + s_host;
            txtRound.Text = "Match round: " + s_round;
            txtRealClients.Text = "Players playing: " + s_rclients;

            string temp = "";
            //(int i = 0; i < s_playernames.Length; i++ )
            /////{
            //    if( s_playernames.Substring( i ) == "," )
              //  {
               //     temp = temp + "\n";
               // }
               // else
               // {
                 //   temp += s_playernames[i];
               // }
                
           // }
            //txtPlayerNames.Text = ""; //temp

            DisplayServerGameLogo(s_game);

            //for displaying only t6 zom mapnames now till we get more important things worked on first
            if ( ShouldWriteConsoleNames( s_game ) )
            {
                txtMapName.Text = "Map: " + DisplayConsoleNameInReadable(s_mapname);
            }
            else { txtMapName.Text = "Map: " + s_mapname; }
            
           
        }

        public void SeeTest()
        {
            
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
        public string DisplayServerGameLogo( string game )
        {
            //Check if the game stays same
            //we don't need to remake bitmap unless the image needs to be rendered again
            if( IsTheGameSame != game )
            {
                Console.WriteLine("don't repeat the image"); 

            }

            //Create a new bitmap image based on the game parameter
            else if( IsTheGameSame == game )
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
        public string DisplayConsoleNameInReadable(string str)
        {   
            switch ( str )
            {
                case "zm_buried":
                    return "Buried";
                    break;
                case "zm_nuked":
                    return "Nuketown";
                    break;
                case "zm_transit":
                    return "Tranzit";
                    break;
                case "zm_tomb":
                    return "Origins";
                    break;
                case "zm_highrise":
                    return "Die Rise";
                    break;
                case "zm_prison":
                    return"Mob Of The Dead";
                    break;
            }        
            return "FAILED TO LOAD";
        }

        private void DeleteAllCurrentElements()
        {
            /* THESE CAUSE PROBLEMS ATM
            lstViewServer.ItemsSource = null;
            for ( int i = 0; i < lstViewServer.Items.Count; i++ )
            {
                lstViewServer.Items.Remove(lstViewServer.Items[i]);
                
                
            }
            */

            lstViewServer.Items.Clear();
            //another failsafe
            slst_Hostname.Clear();
            slst_Mapname.Clear();
            slst_Round.Clear();
            slst_Players.Clear();
            slst_Game.Clear();
            
        }
        private void btnRefresh_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DeleteAllCurrentElements();
            //clear also all text elements later
            //todo: 
            //ServerListParser();
        }


        

        private void fnbo1mp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateTextFile( multi_bo1_servers );
        }

        private void fnbo1zm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void fnbo2mp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateTextFile(multi_bo2_servers);
        }

        private void fnbo2zm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateTextFile(zombie_bo2_servers);
        }

        private void txtSortList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SortList();
        }



        public void SortList( )
        { 
            
        }


        public void CreateServerList(string host, string mapname, int playersize, int round, string game/*string playernames*/ )
        {
            
            serverinfo.Add(new ServerListInfo() { 
                SL_Host = host,
                SL_MapName = mapname,
                SL_Round = round.ToString(),
                SL_PlayersPlaying = playersize.ToString(),
                SL_Game = game//,
                //SL_Players = playernames.ToString()

                });
            
            
        }

        public void MakeListViewItemSource()
        {
            
        }

        private void lstViewServer_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            
        }
    }
}
