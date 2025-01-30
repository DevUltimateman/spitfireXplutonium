using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.MapNamesToReadable
{
    internal class MapNames_T4MP
    {
        public string ConvertT4MultiMaps(string mapToConvert)
        {
            switch (mapToConvert)
            {
                //In release order
                case "mp_airfield": return "Airfield";
                case "mp_asylum": return "Asylum";
                case "mp_castle": return "Castle";
                case "mp_shrine": return "Cliffside";
                case "mp_courtyard": return "Cliffside";
                case "mp_dome": return "Dome";
                case "mp_downfall": return "Downfall";
                case "mp_hangar": return "Hangar";
                case "mp_makin": return "Makin";
                case "mp_outskirts": return "Outskirts";
                case "mp_roundhouse": return "Roundhouse";
                case "mp_seelow": return "Seelow";
                case "mp_suburban": return "Upheaval";
                    
                //DLC STUFF
                case "mp_kneedeep": return "Knee Deep";
                case "mp_nachtfeuer": return "Nightfire";
                case "mp_subway": return "Station";
                case "mp_kwai": return "Banzai";
                case "mp_stalingrad": return "Corrosion";
                case "mp_docks": return "Sub Pens";
                case "mp_drum": return "Battery";
                case "mp_bgate": return "Breach";
                case "mp_vodka": return "Revolution";
                case "mp_makinday": return "Makin Day";
            }

            return "Server is playing a custom map called: " + mapToConvert;
        }
    }
}
