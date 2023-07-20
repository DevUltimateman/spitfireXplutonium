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
using spitfire_solutions.Views;

namespace spitfire_solutions.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        //PRIVATE FIELDS
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
      
        //CHILD VIEW ON GRID
        public ViewModelBase CurrentChildView 
        { 
            get 
            {  
                return _currentChildView; 
            } 
            set 
            { 
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView)); 
            } 
        }
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
        public ICommand ShowSettingsViewCommand { get; }
        

        //MainViewModel to be referenced
        public MainViewModel()
        {
            //INIT COMMANDS
            ShowHomeViewCommand = new ViewModelCommand( ExecuteShowHomeViewCommand );
            ShowInfoViewCommand = new ViewModelCommand(ExecuteShowInfoViewCommand);
            ShowMainViewCommand = new ViewModelCommand(ExecuteShowMainViewCommand);
            ShowModsViewCommand = new ViewModelCommand(ExecuteShowModsViewCommand);
            ShowServersViewCommand = new ViewModelCommand(ExecuteShowServersViewCommand);
            ShowSupportViewCommand = new ViewModelCommand(ExecuteShowSupportViewCommand);
            ShowSettingsViewCommand = new ViewModelCommand(ExecuteSettingsViewCommand);

            //DEFAULT
            //BOOT UP VIEW - SO THAT NOTHING IS SHOWN AT UPON BOOTING TILL USER CLICKS ONE OF THE SUB MENUS
            ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteSettingsViewCommand(object obj)
        {
            CurrentChildView = new SettingsViewModel();
            Caption = "Settings";
            Icon = IconChar.Gears;
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
            Icon = IconChar.Donate;
        }


    }
}
