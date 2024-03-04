using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.MapNamesToReadable
{
    internal class MapNames_T6MP
    {
        public string ConvertT6MultiMaps(string mapToConvert)
        {
            //Alphabetical order, by mapnameDisplays
            switch (mapToConvert)
            {
                case "mp_la": return "Aftermath";
                case "mp_dockside": return "Cargo";
                case "mp_carrier": return "Carrier";
                case "mp_castaway": return "Cove";
                case "mp_bridge": return "Detour";
                case "mp_dig": return "Dig";
                case "mp_downhill": return "Downhill";
                case "mp_drone": return "Drone";
                case "mp_concert": return "Encore";
                case "mp_express": return "Express";
                case "mp_frostbite": return "Frost";
                case "mp_skate": return "Grind";
                case "mp_hijacked": return "Hijacked";
                case "mp_hydro": return "Hydro";
                case "mp_magma": return "Magma";
                case "mp_meltdown": return "Meltdown";
                case "mp_mirage": return "Mirage";
                case "mp_nuketown_2020": return "Nuketown 2025";
                case "mp_overflow": return "Overflow";
                case "mp_nightclub": return "Plaza";
                case "mp_pod": return "Pod";
                case "mp_raid": return "Raid";
                case "mp_paintball": return "Rush";
                case "mp_slums": return "Slums";
                case "mp_village": return "Standoff";
                case "mp_studio": return "Studio";
                case "mp_takeoff": return "Takeoff";
                case "mp_turbine": return "Turbine";
                case "mp_uplink": return "Uplink";
                case "mp_vertigo": return "Vertigo";
                case "mp_socotra": return "Yemen";
            }
            //if we can't display any pre determined maps, show the map console name
            return "Server is playing a custom map called: " + mapToConvert;
        }
    }
}
