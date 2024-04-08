using spitfire_solutions.Dvars;
using spitfire_solutions.ServerClasses;
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
    /// Interaction logic for Mods2View.xaml
    /// </summary>
    public partial class Mods2View : UserControl
    {
        public Mods2View()
        {
            InitializeComponent();
            CreateDvarList();
        }

        //gets the real dvar list length
        public int ReturnDvarSize()
        {
            int divider = 2;
            int DvarSize = new ClientGameDvars().cDvars.Length;
            return DvarSize / divider;
        }


        //to fill the visible dvar list with proper info
        public void CreateDvarList()
        {
            ClientGameDvars cNew = new ClientGameDvars();
            int MaxLoop = ReturnDvarSize() / 2;
            for( int i = 0; i < MaxLoop; i++)
            {
                lstViewSe.Items.Add(cNew.cDvars[i, 0]);
            }
            Console.WriteLine("DONE FILLING VISIBLE DVAR LIST");
            
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //last one -1
            Console.WriteLine(new ClientGameDvars().cDvars[17, 1]);
            Console.WriteLine(ReturnDvarSize());
            CreateDvarList();
        }
    }



    
}
