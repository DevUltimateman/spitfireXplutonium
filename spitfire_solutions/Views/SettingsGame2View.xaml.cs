using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace spitfire_solutions.Views
{
    /// <summary>
    /// Interaction logic for SettingsGame2View.xaml
    /// </summary>
    public partial class SettingsGame2View : System.Windows.Controls.UserControl
    {
        GameFolderList gameFolderCall = new GameFolderList();
        

        public SettingsGame2View()
        {
            InitializeComponent();
            CallGameFolderClass();

        }


        private void CallGameFolderClass()
        {
            ListBoxToGames game = new ListBoxToGames( "Black Ops", )
        }

        private void lstBoxChooseGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lstBoxChooseGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblGameName.Content = lstBoxChooseGame.SelectedItem.ToString();
        }
    }


    
}
