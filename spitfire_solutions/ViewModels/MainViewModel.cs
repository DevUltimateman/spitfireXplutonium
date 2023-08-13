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
        public ViewModelBase CurrentChildView { get { return _currentChildView; } set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }
        
        //CAPTION CHANGER
        public string Caption { get { return _caption; } set { _caption = value; OnPropertyChanged(nameof(Caption)); } }
        
        //ICON / IMAGE CHANGER
        public IconChar Icon { get { return _icon; } set { _icon = value; OnPropertyChanged(nameof(Icon)); } }
        
        //COMMANDS
        public ICommand ShowHomeViewCommand                 { get; }
        public ICommand ShowInfoViewCommand                 { get; }
        public ICommand ShowMainViewCommand                 { get; }
        public ICommand ShowModsViewCommand                 { get; }
        public ICommand ShowServersViewCommand              { get; }
        public ICommand ShowSupportViewCommand              { get; }
        public ICommand ShowGameSettingsViewCommand         { get; }
        public ICommand ShowAppSettingsViewCommand          { get; }
        public ICommand ShowH2omeViewCommand                { get; }
        


        //MainViewModel to be referenced
        public MainViewModel()
        {
            
            //INIT COMMANDS
            ShowHomeViewCommand = new ViewModelCommand( ExecuteHomeViewCommand );
            ShowInfoViewCommand = new ViewModelCommand(ExecuteInfoViewCommand);
            ShowMainViewCommand = new ViewModelCommand(ExecuteMainViewCommand);
            ShowModsViewCommand = new ViewModelCommand(ExecuteModsViewCommand);
            ShowServersViewCommand = new ViewModelCommand(ExecuteServersViewCommand);
            ShowSupportViewCommand = new ViewModelCommand(ExecuteSupportViewCommand);
            ShowGameSettingsViewCommand = new ViewModelCommand(ExecuteGameSettingsViewCommand);
            ShowAppSettingsViewCommand = new ViewModelCommand(ExecuteAppSettingsViewCommand);
            ShowH2omeViewCommand = new ViewModelCommand(ExecuteH2omeViewCommand);
            

            //DEFAULT
            //BOOT UP VIEW - SO THAT NOTHING IS SHOWN AT UPON BOOTING TILL USER CLICKS ONE OF THE SUB MENUS
            ExecuteHomeViewCommand(null);
        }

        
        //let's initialize these here so that the views wont be restored upon page swapping.
        //public SettingsGameViewModel lol = new SettingsGameViewModel();

        private void ExecuteAppSettingsViewCommand(object obj)
        {
            CurrentChildView = new SettingsAppViewModel();
            Caption = "App Settings";
            Icon = IconChar.Tools;
        }

        private void ExecuteH2omeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "h2 test";
            Icon = IconChar.Laugh;
        }

        private void ExecuteGameSettingsViewCommand(object obj)
        {
            CurrentChildView = new SettingsGameViewModel();
            Caption = "Game Settings";
            Icon = IconChar.Gears;
        }

        //VOIDS FOR CREATING A NEW INSTANCE OF SAID VIEWMODEL & DISPLAYING IT ON THE RIGHT BLOCK
        private void ExecuteModsViewCommand(object obj) 
        {
            CurrentChildView = new ModsViewModel();
            Caption = "Mods";
            Icon = IconChar.Modx;
            
        }
        private void ExecuteHomeViewCommand(object obj) 
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Home";
            Icon = IconChar.Home;
        }
        private void ExecuteInfoViewCommand(object obj) 
        {
            CurrentChildView = new InfoViewModel();
            Caption = "Info";
            Icon = IconChar.Info;
        }  
        private void ExecuteMainViewCommand(object obj) 
        {
            CurrentChildView = new MainViewModel();
            
        }
        private void ExecuteServersViewCommand(object obj) 
        {
            CurrentChildView = new ServersViewModel();
            Caption = "Servers";
            Icon = IconChar.Server;
        }  
        private void ExecuteSupportViewCommand(object obj) 
        {
            CurrentChildView = new SupportViewModel();
            Caption = "Support";
            Icon = IconChar.Donate;
        }


    }
}
