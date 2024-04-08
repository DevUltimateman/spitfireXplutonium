using spitfire_solutions.Starters;
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
    /// Interaction logic for Home2View.xaml
    /// </summary>
    public partial class Home2View : UserControl
    {
        public Home2View()
        {
            InitializeComponent();
        }

        //Mouse hits QuickLaunch Border Button, launch Plutonium Launcher
        private void lblQbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StartLauncher sL = new StartLauncher();
            sL.StartPlutoniumLauncher();
        }
        //Mouse enters QuickLaunch Border Button
        private void lblQbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            bdQuickLaunch.BorderBrush = Brushes.Aqua;
            bdQuickLaunch.Background = Brushes.Transparent;

           
        }
        //Mouse leaves QuickLaunch Border Button
        private void lblQbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            bdQuickLaunch.Background = Brushes.Transparent;
            bdQuickLaunch.BorderBrush = Brushes.MintCream;
        }

        private void bdQuickLaunch_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void lblQbtn_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void bdShrtMods_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
