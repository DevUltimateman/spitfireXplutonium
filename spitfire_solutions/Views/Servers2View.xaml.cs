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
        public string v1Api = ("https://api.plutools.pw/v1/servers");
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

        



        public void CreateApiCall()
        {
            ListView myListView = new ListView();
            //string[] 
        }   

        public void Get_Api()
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


        public void TestingStuff()
        {
            string json = v1Api.ToString();
            var data = (JObject)JsonConvert.DeserializeObject(json);
            string user = data["username"].Value<string>();
            Console.WriteLine(user);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //JsonTest jtest = new JsonTest();
            //jtest.MakeApiCall();

            //var model = JsonConvert.DeserializeObject<List<Root>>(v1Api);
            //TestingStuff();

            dgG.Visibility = Visibility.Visible;
            //jsonDataDisplay();





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
