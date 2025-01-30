using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.MapNamesToReadable
{
    internal class MapNames_IW5MP
    {
        public string ConvertIW5MultiMaps(string mapToConvert)
        {
            switch (mapToConvert)
            {
                //In alphabetical order
                case "mp_plaza2": return "Arkaden";
                case "mp_mogadishu": return "Bakaara";
                case "mp_bootleg": return "Bootleg";
                case "mp_carbon": return "Carbon";
                case "mp_dome": return "Dome";
                case "mp_exchange": return "Downturn";
                case "mp_lambeth": return "Fallen";
                case "mp_hardhat": return "Hardhat";
                case "mp_interchange": return "Interchange";
                case "mp_alpha": return "Lockdown";
                case "mp_bravo": return "Mission";
                case "mp_radar": return "Outpost";
                case "mp_paris": return "Resistance";
                case "mp_seatown": return "Seatown";
                case "mp_underground": return "Underground";
                case "mp_village": return "Village";

                //dlc maps next, in release order
                case "mp_park": return "Liberation";
                case "mp_italy": return "Piazza";
                case "mp_overwatch": return "Overwatch";
                case "mp_morningwood": return "Black Box";
                case "mp_cement": return "Foundation";
                case "mp_meteora": return "Sanctuary";
                case "mp_restrepo_ss": return "Lookout";
                case "mp_hillside_ss": return "Getaway";
                case "mp_qadeem": return "Oasis";
                case "mp_six_ss": return "Vortex";
                case "mp_crosswalk_ss": return "Intersection";
                case "mp_burn_ss": return "U-Turn";
                case "mp_shipbreaker": return "Decommission";
                case "mp_roughneck": return "Off Shore";
                case "mp_boardwalk": return "Boardwalk";
                case "mp_moab": return "Gulch";
                case "mp_nola": return "Parish";
                case "mp_courtyard": return "Erosion";
                case "mp_aground_ss": return "Aground";
                case "mp_terminal": return "Terminal";
            }
            return "Server is playing a custom map called: " + mapToConvert;
        }
    }
}
