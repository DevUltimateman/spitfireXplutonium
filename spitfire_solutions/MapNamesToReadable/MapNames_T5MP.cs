using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.MapNamesToReadable
{
    internal class MapNames_T5MP
    {
        public string ConvertT5MultiMaps(string mapToConvert)
        {
            switch (mapToConvert)
            {
                //In alphabetical order
                case "mp_array": return "Array";
                case "mp_crisis": return "Crisis";
                case "mp_cracked": return "Cracked";
                case "mp_firingrange": return "Firing Range";
                case "mp_duga": return "Grid";
                case "mp_hanoi": return "Hanoi";
                case "mp_cairo": return "Havana";
                case "mp_havoc": return "Jungle";
                case "mp_cosmodrome": return "Launch";
                case "mp_nuked": return "Nuketown";
                case "mp_radiation": return "Radiation";
                case "mp_mountain": return "Summit";
                case "mp_villa": return "Villa";
                case "mp_russianbase": return "WMD";

                //DLC, in release order
                case "mp_berlinwall2": return "Berlin Wall";
                case "mp_discovery": return "Discovery";
                case "mp_kowloon": return "Kowloon";
                case "mp_stadium": return "Stadium";

                case "mp_gridlock": return "Convoy";
                case "mp_hotel": return "Hotel";
                case "mp_outskirts": return "Stockpile";
                case "mp_zoo": return "Zoo";

                case "mp_area51": return "Hangar 18";
                case "mp_drivein": return "Drive-In";
                case "mp_silo": return "Silo";
                case "mp_golfcourse": return "Hazard";
            }
            return "Server is playing a custom map called: " + mapToConvert;
        }
    }
}
