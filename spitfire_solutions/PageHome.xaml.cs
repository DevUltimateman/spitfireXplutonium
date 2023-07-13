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
        }

        private void txtHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            framePageView.Content = pageHomeView;
        }

        private void txtMods_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            framePageView.Content = new PageSettingsGame();
        }

        private void txtServers_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
