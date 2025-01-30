using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.MapNamesToReadable
{
    internal class MapNames_T4SP
    {
        public string ConvertT4ZombieMaps(string mapToConvert)
        {
            switch (mapToConvert)
            {
                //In release order
                case "nazi_zombie_prototype": return "Nacht Der Untoten";
                case "nazi_zombie_asylum": return "Verruckt";
                case "nazi_zombie_sumpf": return "Shi No Numa";
                case "nazi_zombie_factory": return "Der Rise";
            }
            return "Server is playing a custom map called: " + mapToConvert;
        }
    }
}
