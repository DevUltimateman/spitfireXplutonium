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

using System.Windows.Interop;
using spitfire_solutions.ViewModels;
using spitfire_solutions.Views;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;

namespace spitfire_solutions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        
        //to hold down the window + to move
        private void stckControlPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);

            //if we dont do this, we error out upon releasing the button while drag is still enabled
            if( e.LeftButton == MouseButtonState.Pressed )
            {
                DragMove();
            }
            
        }

        private void stckControlPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //Environment.Exit(1);
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else { this.WindowState = WindowState.Normal; }
        }





        /*
        

        //VOIDS FOR CREATING A NEW INSTANCE OF SAID VIEWMODEL & DISPLAYING IT ON THE RIGHT BLOCK
        private void ExecuteShowModsViewCommand(object obj)
        {
            CurrentChildView = new ModsViewModel();
            Caption = "Mods";
            Icons = IconChar.Modx;
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Home";
            Icons = IconChar.Home;
        }
        private void ExecuteShowInfoViewCommand(object obj)
        {
            CurrentChildView = new InfoViewModel();
            Caption = "Info";
            Icons = IconChar.Info;
        }
        private void ExecuteShowMainViewCommand(object obj)
        {
            CurrentChildView = new MainViewModel();
            Caption = "Dashboard";
            Icons = IconChar.Home;
        }
        private void ExecuteShowServersViewCommand(object obj)
        {
            CurrentChildView = new ServersViewModel();
            Caption = "Servers";
            Icons = IconChar.Server;
        }
        private void ExecuteShowSupportViewCommand(object obj)
        {
            CurrentChildView = new SupportViewModel();
            Caption = "Support";
            Icons = IconChar.Donate;
        }



        */

    }
}
