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

namespace spitfire_solutions
{
    /// <summary>
    /// Interaction logic for PageHome.xaml
    /// </summary>
    public partial class PageHome : Page
    {
        
        public PageHome()
        {
            InitializeComponent();
            //initializeAllWindows();,
            //page Settings on boot up / hidden

            //all views updated & hidden
            hideAllAtStart();
        }
        
        
        private PageSettingsGame pSet = new PageSettingsGame();
        private PageModsGame pMod = new PageModsGame();
        private PageServersGame pSer = new PageServersGame();
       
        
        private void hideAllAtStart()
        {
            pSet.Visibility = Visibility.Hidden;
            pMod.Visibility = Visibility.Hidden;
            pSer.Visibility = Visibility.Hidden;
        }
        
        private void txtHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            framePageView.Visibility = Visibility.Hidden;
        }

        private void txtMods_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (framePageView.Content != pMod)
            {
                Console.WriteLine("Yeah nothing was found, creating the view");
                framePageView.Content = pMod;
                if (pMod.Visibility == Visibility.Hidden)
                {
                    pMod.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if( framePageView.Visibility != Visibility.Visible )
                {
                    framePageView.Visibility = Visibility.Visible;
                }
                Console.WriteLine("Page " + framePageView.Content.ToString() + " already exists, visibility set TRUE, skipping the callstack");
            }
        }
        private void txtSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (framePageView.Content != pSet)
            {
                Console.WriteLine("Yeah nothing was found, creating the view");
                framePageView.Content = pSet;
                if (pSet.Visibility == Visibility.Hidden)
                {
                    pSet.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (framePageView.Visibility != Visibility.Visible)
                {
                    framePageView.Visibility = Visibility.Visible;
                }
                Console.WriteLine("Page " + framePageView.Content.ToString() + " already exists, visibility set TRUE, skipping the callstack");
            }

        }

        private void txtServers_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (framePageView.Content != pSer)
            {
                Console.WriteLine("Yeah nothing was found, creating the view");
                framePageView.Content = pSer;
                if (pSer.Visibility == Visibility.Hidden)
                {
                    pSer.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (framePageView.Visibility != Visibility.Visible)
                {
                    framePageView.Visibility = Visibility.Visible;
                }
                Console.WriteLine("Page " + framePageView.Content.ToString() + " already exists, visibility set TRUE, skipping the callstack");
            }
        }

        private void passTheVisibilityCheck( string checking )
        {
            
        }
        private void keepSettingsAlive()
        {   
            //settings
            pSet.Visibility = Visibility.Visible;
            //mods
            pMod.Visibility = Visibility.Hidden;
            //servers
            pSer.Visibility = Visibility.Hidden;
            
        }

        private void keepHomeAlive()
        {
            //settings
            pSet.Visibility = Visibility.Visible;
            //mods
            pMod.Visibility = Visibility.Hidden;
            //servers
            pSer.Visibility = Visibility.Hidden;
            //home
            this.Visibility = Visibility.Visible;
        }

        private void keepModsAlive()
        {
            //settings
            pSet.Visibility = Visibility.Hidden;
            //mods
            pMod.Visibility = Visibility.Visible;
            //servers
            pSer.Visibility = Visibility.Hidden;
            //home
            //this.Visibility = Visibility.Visible;
        }

        private void keepServersAlive()
        {
            //settings
            pSet.Visibility = Visibility.Hidden;
            //mods
            pMod.Visibility = Visibility.Hidden;
            //servers
            pSer.Visibility = Visibility.Visible;
            //home
            //this.Visibility = Visibility.Visible;
        }
    }
}
