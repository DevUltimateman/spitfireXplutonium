using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.MapNamesToReadable
{
    internal class MapNames_T5SP
    {
        public string ConvertT5ZombieMaps(string mapToConvert)
        {
            switch (mapToConvert)
            {
                //In release order
                case "zombie_theater": return "Kino Der Toten";
                case "zombie_pentagon": return "Five";
                case "zombietron": return "Dead Ops Arcade";
                case "zombie_cosmodrome": return "Asecension";
                case "zombie_coast": return "Call Of The Dead";
                case "zombie_temple": return "Shangri-La";
                case "zombie_moon": return "Moon";
                case "zombie_cod5_prototype": return "Shangri-La";
                case "zombie_cod5_asylum": return "Shangri-La";
                case "zombie_cod5_sumpf": return "Shangri-La";
                case "zombie_cod5_factory": return "Shangri-La";
            }
            //if we can't display any pre determined maps, show the map console name
            return "Server is playing a custom map called: " + mapToConvert;
        }
    }
}
