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


/*

R58KB0RVX3E
R58KB0RVX3E
R58KB0RVX3E
R58KB0RVX3E
*/
//for json




namespace spitfire_solutions.Views
{
    /// <summary>
    /// Interaction logic for Servers2View.xaml
    /// </summary>
    public partial class Servers2View : UserControl
    {
        public Servers2View()
        {
            InitializeComponent();
        }

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
        public async void CreateTextFile( string? game)
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
                    var response_msg = await _httpClient.GetAsync(zombie_bo2_servers);

                    //waits
                    string jsonResponse = await response_msg.Content.ReadAsStringAsync();

                    //write the string to blanco
                    byte[] bytes = Encoding.ASCII.GetBytes(jsonResponse);
                    fs.Write(bytes, 0, bytes.Length);
                }
                //deserialize it
                string serverData = System.IO.File.ReadAllText(ServerFile);
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
            //READ THE JSON DATA FROM THE FILE THAT WE JUST CREATED!
            using (StreamReader su = new StreamReader(ServerFile))
            {
                //CREATE A STRING THAT STORES THE JSON DATA AS A VARIABLE
                string jsonString = System.IO.File.ReadAllText(ServerFile);

                //MAKE INSTANCE OF EACH "SERVERCLASSES" MODULE
                var deserial = JsonConvert.DeserializeObject<Root>(jsonString);

                //Let's test print
                Console.WriteLine("Total player count: " + deserial.countPlayers);
                Console.WriteLine("Mapname: " + deserial.servers[0].hostname);

                //print all servers to console for now
                for (int i = 0; i < deserial.countServers; i++)
                {
                    //specify the server sub class that we want to "print"
                    //ex. deserial.servers[ key ].whattype
                    Console.WriteLine("Server name: " + deserial.servers[i].hostname);
                    //lstServer.Items.Add(deserial.servers[i].hostname +"  " + deserial.servers[i].game);
                    lstServer.Items.Add(deserial.servers[i].hostname + "  " + deserial.servers[i].gameDisplay);
                    lstServer.Items.Add(deserial.servers[i].countryDisplay + " " + deserial.servers[i].password);
                    

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
                MessageBox.Show(e.Message);

            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //new test, make the text file of all api return
            ServerListParser();
        }
    }
}
