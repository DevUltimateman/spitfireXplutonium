using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using static System.Net.WebRequestMethods;

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
            MyJsonOutput();
            //txtBSerTest.Text = Tt;



        }

        public string api = "https://plutonium.pw/api/servers/plutonium";
        public string apiRaid = "http://api.raidmax.org:5000/servers";
        public string v1Api = "https://api.plutools.pw/v1/servers";
        public string Tt;
        HttpClient _httpClient = new HttpClient();

        public string CurrentApi()
        {
            string url = 
                "https://plutonium.pw/api/servers";
            
            return url;
        }
        
        public void txttest()
        {
           
        }
        public async void MyJsonOutput()
        {
            try
            {
                var response_msg = await _httpClient.GetAsync(v1Api);
                //read it
                string jsonResponse = await response_msg.Content.ReadAsStringAsync();
                Console.WriteLine(jsonResponse);
                
                
                /*
                foreach ( var item in jsonResponse.Split() )
                {
                   Console.WriteLine(item);
                    txt1.Text = item;
                    txt2.Text = item;
                    item.Split();


                }

                */

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
        public void LoadJson()
        {
            
            using (StreamReader r = new StreamReader( CurrentApi() ))
            {
               string json = r.ReadToEnd();
                List<jItems> items = JsonConvert.DeserializeObject<List<jItems>>(json);
                
                
            }

            ListBox lol = new ListBox();
           
            
            

        }

        public class jItems
        {

            public string serverName;
            public string serverLocation;
            public string serverIP;
            public int serverPort;

            public int playerSize;
            public string playerName;
            public string playerSizeMax;

            

            
        }
    }
}
