using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace spitfire_solutions
{
    internal class SolutionImages
    {
        //list to store all the project images for backgroundclicking
        public List<string> imageListMiniBackground = new List<string>();

        //METHODS
        //METHODS
        //METHODS
        public void populateMiniBackgroundImages()
        {
            string[] imagePaths = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\images\\logos");
            try
            {
                foreach (string filler in imagePaths)
                {
                    imageListMiniBackground.Add(filler);
                    Console.WriteLine(filler + "\n\n" + imageListMiniBackground.Count.ToString() + " / 4 ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        public void makeMiniBackGroundDirectory()
        {
            DirectoryInfo miniBackGroundI = new DirectoryInfo("~/images/logos");
            FileInfo[] imageFiles = miniBackGroundI.GetFiles();

            //might want to move this out of this method
            ArrayList imgs = new ArrayList();

            foreach (FileInfo img in imageFiles )
            {
                imgs.Add(img.FullName);
            }
        }

    }
}
