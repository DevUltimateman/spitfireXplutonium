using System;
using System.Collections.Generic;
using System.Linq;
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

namespace spitfire_solutions.Views
{
    /// <summary>
    /// Interaction logic for Mods2View.xaml
    /// </summary>
    public partial class Mods2View : UserControl
    {
        ListBox games = new ListBox();
        GameFolderList GamesList = new GameFolderList();


        //lets declare a list
        //private List<PlutoGames> _plutogames = new List<PlutoGames>();


        public Mods2View()
        {
            InitializeComponent();
            TestFillList();

            //ListViewGameInfo();


            DoSomething();


        }

        public void TestersLife()
        {

        }
        public void DoSomething()
        {
            //Games g_ames = new Games();
            //lstBox1.Items.Add( new Games() { GameName = "BLACK", GameNameExe = "t5sssssss", GameNameIsZombies=true});

            ListView Lister = new ListView();
            Lister.HorizontalAlignment = HorizontalAlignment.Center;
            Lister.VerticalAlignment = VerticalAlignment.Center;
            //Lister.Items.Add("LOL", "LOLS", "LOLLIT");
            //Lister.Items.Add("GUCCI MANE");
            //
            /*
            for( int s = 0; s < Lister.Items.Count; s++ )
            {
                Console.WriteLine(Lister.Items[ s ] );
            }
            */
        }
        public void ListViewGameInfo()
        {

            /*
            //return Gamenames
            string temps = GamesList.returnGames();
            //return Executables
            string exes = GamesList.returnGamesExe();
            */




        }
        
        public void PopulateListView()
        {
            ListViewItem listItem = new ListViewItem();
            
        }

        //CREATE A DICTIONARY STYLE LISTING!!!
        private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        public void PopulateDic()
        {
            _dictionary.Add("TITLE", "EXECUTABLE");
            

            foreach( var item in _dictionary )
            {
                //listViewX.Items.Add( new ListViewItem(new[] { item.Key, item.Value })
               // {
               //     Tag = item.Key
               // });
            }
        }
        public void TestFillList()
        {
            //lstBox1.Items.Add(new Games() { GameName = "TESTGAME", GameNameExe = "TESTIX", GameNameIsZombies = false });
            //lstBox1.Items.Add(new Games() { GameName = "TESTGAME2", GameNameExe = "TESTIX2", GameNameIsZombies = false });
            BasicConstructor();


        }

        public void BasicConstructor()
        {
            // object temporary = new GamesStruct() { GameName = gamename, GameExecutable = gameexe };

            MyListItems lists = new MyListItems( "Black Opsie", "GivenMy" );
            
            
            

        }


    }


    public class MyListItems
    {
        public string MyGameName { get; set; }
        public string MyGameExecutable { get; set; }

        public MyListItems( string nameGame, string executableName )
        {
            MyGameName = nameGame;
            MyGameExecutable = executableName;
        }
    }
}
