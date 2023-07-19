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

         //PRIVATE FIELDS
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        
        //CHILD VIEW ON GRID
        public ViewModelBase CurrentChildView { get { return _currentChildView; } set { _currentChildView = value; } }
        //CAPTION CHANGER
        public string Caption { get { return _caption; } set { _caption = value; } }
        //ICON / IMAGE CHANGER
        public IconChar Icon { get { return _icon; } set { _icon = value;  } }
        

        //COMMANDS
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowInfoViewCommand { get; }
        public ICommand ShowMainViewCommand { get; }
        public ICommand ShowModsViewCommand { get; }
        public ICommand ShowServersViewCommand { get; }
        public ICommand ShowSupportViewCommand { get; }


        public MainWindow()
        {
            InitializeComponent();

            //one time initialization
            //frameMainLocked.Content = new PageHome();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;


            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowInfoViewCommand = new ViewModelCommand(ExecuteShowInfoViewCommand);
            ShowMainViewCommand = new ViewModelCommand(ExecuteShowMainViewCommand);
            ShowModsViewCommand = new ViewModelCommand(ExecuteShowModsViewCommand);
            ShowServersViewCommand = new ViewModelCommand(ExecuteShowServersViewCommand);
            ShowSupportViewCommand = new ViewModelCommand(ExecuteShowSupportViewCommand);

            //BOOT UP VIEW - SO THAT NOTHING IS SHOWN AT UPON BOOTING TILL USER CLICKS ONE OF THE SUB MENUS
            ExecuteShowHomeViewCommand(null);
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //to hold down the window + to move
        private void stckControlPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
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






        

        //VOIDS FOR CREATING A NEW INSTANCE OF SAID VIEWMODEL & DISPLAYING IT ON THE RIGHT BLOCK
        private void ExecuteShowModsViewCommand(object obj)
        {
            CurrentChildView = new ModsViewModel();
            Caption = "Mods";
            Icon = IconChar.Modx;
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Home";
            Icon = IconChar.Home;
        }
        private void ExecuteShowInfoViewCommand(object obj)
        {
            CurrentChildView = new InfoViewModel();
            Caption = "Info";
            Icon = IconChar.Info;
        }
        private void ExecuteShowMainViewCommand(object obj)
        {
            CurrentChildView = new MainViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }
        private void ExecuteShowServersViewCommand(object obj)
        {
            CurrentChildView = new ServersViewModel();
            Caption = "Servers";
            Icon = IconChar.Server;
        }
        private void ExecuteShowSupportViewCommand(object obj)
        {
            CurrentChildView = new SupportViewModel();
            Caption = "Support";
        }







        


    }
}
