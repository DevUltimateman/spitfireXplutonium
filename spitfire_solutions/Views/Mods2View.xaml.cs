using spitfire_solutions.Dvars;
using spitfire_solutions.ServerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        //we need this to divide the arrays that hold the dvars due to the arrays
        //being two dimensional.
        //must divide the total value by two.
        public const int divider = 2;
        private bool RenderActive = false;
        private bool ClientActive = false;
        private bool ServerActive = false;
        public Mods2View()
        {
            InitializeComponent();
            //fill the temporary list view with dvars
            //CreateClientGameDvarList();
        } 

        //gets the real ClientGameDvars.cs dvars size
        public int ReturnClientDvarsSize()
        {
            int DvarSize = new ClientGameDvars().cDvars.Length;
            return DvarSize;// / divider;
        }


        //gets the real RenderDvars.cs dvars size
        public int ReturnRenderDvarsSize()
        {
            int RenderSize = new RenderDvars().rVars.Length;
            return RenderSize;// / divider;
        }

        //gets the real ServerDvars.cs dvars size
        public int ReturnServerDvarsSize()
        {
            int ServerSize = new ServerDvars().sVars.Length;
            return ServerSize;// / divider;
        }


        //to fill the visible dvar list with proper info
        public void CreateClientGameDvarList()
        {
            ClearDvarList();
            RenderActive = false;
            ClientActive = true;
            ServerActive = false;
            ClientGameDvars cNew = new ClientGameDvars();
            int MaxLoop = ReturnClientDvarsSize() / 2;
            for( int i = 0; i < MaxLoop; i++)
            {
                lstViewSe.Items.Add(cNew.cDvars[i, 0]);
            }
            Console.WriteLine("DONE FILLING VISIBLE ClientDVAR LIST");
        }

        //to fill the visible dvar list with proper info
        public void CreateServerSideDvarList()
        { 
            ClearDvarList();
            RenderActive = false;
            ClientActive = false;
            ServerActive = true;
            ServerDvars sNew = new ServerDvars();
            int MaxLoop = ReturnServerDvarsSize() / 2;
            for (int i = 0; i < MaxLoop; i++)
            {
                lstViewSe.Items.Add(sNew.sVars[i, 0]);
            }
            Console.WriteLine("DONE FILLING VISIBLE ServerDVAR LIST");
        }


        //to fill the visible dvar list with proper info
        public void CreateRenderSideDvarList()
        {
            ClearDvarList();
            RenderActive = true;
            ClientActive = false;
            ServerActive = false;
            RenderDvars rNew = new RenderDvars();
            int MaxLoop = ReturnRenderDvarsSize() / 2;
            for (int i = 0; i < MaxLoop; i++)
            {
                lstViewSe.Items.Add(rNew.rVars[i, 0]);
            }
            Console.WriteLine("DONE FILLING VISIBLE RenderDVAR LIST");
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //last one -1
            /*
            Console.WriteLine(new ClientGameDvars().cDvars[17, 1]);
            Console.WriteLine(ReturnClientDvarsSize());
        
            CreateClientGameDvarList();
            */
            ClearDvarList();
        }
        public void AnimateText()
        {

        }
        public void ClearDvarList()
        {
            lstViewSe.Items.Clear();
        }
        private void btnClientside_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateClientGameDvarList();
        }

        private void btnServerside_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateServerSideDvarList();
        }

        private void btnRenderside_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateRenderSideDvarList();

        }

        private void btnClientside_MouseEnter(object sender, MouseEventArgs e)
        {
            btnClientside.Width += btnClientside.Width / 10;
        }

        private void btnClientside_MouseLeave(object sender, MouseEventArgs e)
        {
            btnClientside.Width = 100;
        }

        private void btnServerside_MouseEnter(object sender, MouseEventArgs e)
        {
            btnServerside.Width += btnRenderside.Width / 10;
        }

        private void btnServerside_MouseLeave(object sender, MouseEventArgs e)
        {
            btnServerside.Width = 100;
        }

        private void btnRenderside_MouseEnter(object sender, MouseEventArgs e)
        {
            btnRenderside.Width += btnRenderside.Width / 10;
        }

        private void btnRenderside_MouseLeave(object sender, MouseEventArgs e)
        {
            btnRenderside.Width = 100;
        }

        private void lstViewSe_Selected(object sender, RoutedEventArgs e)
        {
            txtDvarInfo.Text = lstViewSe.SelectedItem.ToString();
        }

        private void lstViewSe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //fail safe to check if the list is null / empty
            if( lstViewSe.SelectedIndex < 0 )
            {
                txtDvarInfo.Text = null;
                txtDvarInfoSize.Text = null;
            }
            else if ( lstViewSe.SelectedIndex >= 0 )
            {
                txtDvarInfo.Text = lstViewSe.SelectedItem.ToString();
                txtDvarInfo.Text = lstViewSe.SelectedIndex.ToString();
                txtDvarInfoSize.Text = lstViewSe.Items.Count.ToString();
            }


            RenderDvars renderer = new RenderDvars();
            ClientGameDvars cenderer = new ClientGameDvars();
            ServerDvars serverer = new ServerDvars();
            switch ( RenderActive )
            {

                case true:
                    if (lstViewSe.SelectedIndex >= 0)
                        txtDvarInfo.Text = renderer.rVars[lstViewSe.SelectedIndex, 1];
                    return;
            }

            switch (ServerActive)
            {

                case true:
                    if (lstViewSe.SelectedIndex >= 0)
                        txtDvarInfo.Text = serverer.sVars[lstViewSe.SelectedIndex, 1];
                    return;
            }

            switch (ClientActive)
            {

                case true:
                    if( lstViewSe.SelectedIndex >= 0 )
                    {
                        txtDvarInfo.Text = cenderer.cDvars[lstViewSe.SelectedIndex, 1];
                    }
                    
                    return;
            }


            //ClientGameDvars;
            //ServerDvars;



            //&& renderer is two dimensional array.
            //renderer.rVars[ xxxx, 1 = max ]
            //txtDvarInfo.Text = renderer.rVars[ lstViewSe.SelectedIndex, 1];

        }
    }



    
}
