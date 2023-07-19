using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using System.ComponentModel;
using System.Data.Common;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows;
using System.Runtime.InteropServices;
using Application = System.Windows.Application;

namespace spitfire_solutions.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        //PRIVATE FIELDS
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
      
        //CHILD VIEW ON GRID
        public ViewModelBase CurrentChildView { get {  return _currentChildView; } set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }
        //CAPTION CHANGER
        public string Caption { get { return _caption; } set { _caption = value; OnPropertyChanged(nameof(Caption)); } }
        //ICON / IMAGE CHANGER
        public IconChar Icon { get { return _icon; } set { _icon = value; OnPropertyChanged(nameof(Icon)); } }

        //COMMANDS
        public ICommand ShowHomeViewCommand     { get; }
        public ICommand ShowInfoViewCommand     { get; }
        public ICommand ShowMainViewCommand     { get; }
        public ICommand ShowModsViewCommand     { get; }
        public ICommand ShowServersViewCommand  { get; }
        public ICommand ShowSupportViewCommand  { get; }
        public WindowState WindowState { get; private set; }
        public double MaxHeight { get; private set; }

        //MainViewModel to be referenced
        public MainViewModel()
        {
            //INIT COMMANDS
            //ViewModelCommand & Execute ShoeHomeView are inherited from ViewModelCommand class!!
            
            ShowHomeViewCommand = new ViewModelCommand( ExecuteShowHomeViewCommand );
            ShowInfoViewCommand = new ViewModelCommand(ExecuteShowInfoViewCommand);
            ShowMainViewCommand = new ViewModelCommand(ExecuteShowMainViewCommand);
            ShowModsViewCommand = new ViewModelCommand(ExecuteShowModsViewCommand);
            ShowServersViewCommand = new ViewModelCommand(ExecuteShowServersViewCommand);
            ShowSupportViewCommand = new ViewModelCommand(ExecuteShowSupportViewCommand);


            //BOOT UP VIEW - SO THAT NOTHING IS SHOWN AT UPON BOOTING TILL USER CLICKS ONE OF THE SUB MENUS
            ExecuteShowHomeViewCommand(null);
        }

        //VOIDS FOR CREATING A NEW INSTANCE OF SAID VIEWMODEL & DISPLAYING IT ON THE RIGHT BLOCK
        private void ExecuteShowModsViewCommand(object obj) { CurrentChildView = new ModsViewModel();
            Caption = "Mods";
        }
        private void ExecuteShowHomeViewCommand(object obj) { CurrentChildView = new HomeViewModel();
            Caption = "Home";
        }
        private void ExecuteShowInfoViewCommand( object obj ) { CurrentChildView = new InfoViewModel();
            Caption = "Info";
        }  
        private void ExecuteShowMainViewCommand( object obj ) { CurrentChildView = new MainViewModel();
            Caption = "Dashboard";
        }
        private void ExecuteShowServersViewCommand( object obj ) { CurrentChildView = new ServersViewModel();
            Caption = "Servers";
        }  
        private void ExecuteShowSupportViewCommand( object obj ) { CurrentChildView = new SupportViewModel();
            Caption = "Support";
        }







        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //FROM MAIN WINDOW.CS
        private void stckControlPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //WindowInteropHelper helper = new WindowInteropHelper(thisS);
            //WindowInteropHelper helper = new WindowInteropHelper(View);
            //SendMessage(helper.Handle, 161, 2, 0);
            //DragMove();
        }

        private void stckControlPanel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
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

    }
}
