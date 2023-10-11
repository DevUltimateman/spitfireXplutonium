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
            //txtBSerTest.Text = CurrentApi();
            //LoadJson();
            //MyJsonOutput();
            //txtBSerTest.Text = Tt;



        }

        public string api = "https://plutonium.pw/api/servers/plutonium/t6mp";
        public string apiRaid = "http://api.raidmax.org:5000/servers";
        public string v1Api = ("https://api.plutools.pw/v1/servers");
        public string Tt;
        HttpClient _httpClient = new HttpClient();

        public string ServerFile = @"C:\Temp\ServerList.txt";

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

        //rip showServers() string into this file
        //ok this now working as intended. 
        //we need to populate the file.txt with json data, 
        //figure that out next 11/10/23
        public async void CreateTextFile()
        {
            try
            {
                if( System.IO.File.Exists( ServerFile ) )
                {
                    System.IO.File.Delete( ServerFile );
                }

                using ( System.IO.FileStream fs = System.IO.File.Create( ServerFile ))
                {
                   
                    //lets write the json string to a file.
                    //first we need to call the api
                    var response_msg = await _httpClient.GetAsync(zombie_bo2_servers);
                    //read it
                    string jsonResponse = await response_msg.Content.ReadAsStringAsync();
                    //convert it to bytes
                    byte[] bytes = Encoding.ASCII.GetBytes( jsonResponse );
                    fs.Write(bytes, 0, bytes.Length);

                    
                }

                using (StreamReader sr = new StreamReader(ServerFile))
                {
                    string s = "";
                    while( ( s = sr.ReadLine()) != null )
                    {
                        //Console.WriteLine(s);
                        Console.WriteLine("DONE");
                        
                    }
                }

                    /*
                    //deserialize it
                    string serverData = System.IO.File.ReadAllText(ServerFile);
                    Console.Write(serverData);
                    */
                    using var stream = System.IO.File.OpenRead( ServerFile );
                    var servers = System.Text.Json.JsonSerializer.Deserialize<List<Servers>>(stream);

                    foreach (var s in servers)
                    {
                        Console.WriteLine(s);
                        Console.WriteLine("DONE2");
                    }

                    //MakeServerListReadable();
                
                
                }
            catch (Exception ex )
            {

                Console.WriteLine (ex.Message);
            }
        }

        //Make it readable
        public void MakeServerListReadable()
        {
            if( !System.IO.File.Exists( ServerFile ) )
            {
                return;
            }
            string serverData = System.IO.File.ReadAllText( ServerFile );
            Console.Write(serverData);

            var servers = System.Text.Json.JsonSerializer.Deserialize<List<Servers>>(serverData);

            foreach( var s in servers )
            {
                Console.WriteLine(s);
                Console.WriteLine("DONE");
            }
        }


        public void tester()
        {
            //CONTINUE FROM HERE LATER ON!
            //11.10.23 
        }
        // THIS FETCHES THE URL AND DESERIALIZES IT
        public async void MyJsonOutput( string str )
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

        public List<SpitFireServers> servers = new List<SpitFireServers>();
        public class SpitFireServers
        {
            int PlayerCount;
            int PlayerCountMax;
            int PlayerLobbySize;
            int ServerPort;

            string ServerName;
            string ServerIP;
            string ServerLocation;


        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateTextFile();
        }

        //Making an object from human class
        public void MakeNObject()
        {
            Human human = new Human { Name = "John ", LastName = "Alias ", Age = 23 };
            Console.WriteLine(human.Name + human.LastName +  human.Age);
            
        }
    }

        

    //this how you create a class
    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }

    }
}
