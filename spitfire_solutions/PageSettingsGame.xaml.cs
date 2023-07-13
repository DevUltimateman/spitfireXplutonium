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
    /// Interaction logic for PageSettingsGame.xaml
    /// </summary>
    public partial class PageSettingsGame : Page
    {
        public PageSettingsGame()
        {
            InitializeComponent();

            //populate the list with temp info upon boot
            lstMylist.ItemsSource = new GameFolderList().returnGames();

        }

        //just change the big text to info text is mouse is hovering on top.
        private void lblSelectFromList_MouseEnter(object sender, MouseEventArgs e)
        {
            lblSelectFromList.FontSize = 12.5;
            lblSelectFromList.Foreground = Brushes.AntiqueWhite;
            lblSelectFromList.FontWeight = FontWeights.Light;
            lblSelectFromList.Text = "Choose the game you want to edit from the list";
        }

        //revert the text value if we are this fuckeddddd
        private void lblSelectFromList_MouseLeave(object sender, MouseEventArgs e)
        {
            lblSelectFromList.Text = "Select Game";
            lblSelectFromList.Foreground = Brushes.AntiqueWhite;
            lblSelectFromList.FontWeight = FontWeights.Bold;
            lblSelectFromList.FontSize = 20;
        }
    }
}
