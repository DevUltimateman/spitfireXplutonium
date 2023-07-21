using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions
{
    public class ListBoxToGames : Object
    {
        
        public virtual string ObjectGameName { get; set; }
        public virtual object Object { get; set; }
        public virtual string ObjectGamePath { get; set; }

        public ListBoxToGames(string gamename,  string gamepath)
        {
            this.ObjectGameName = gamename;
            //this.Object = obj;
            this.ObjectGamePath = gamepath;
        }

        

        public override string ToString()
        {
            return this.ObjectGameName;
        }



    }
}
