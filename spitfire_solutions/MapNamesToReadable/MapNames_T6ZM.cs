using spitfire_solutions.ServerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.MapNamesToReadable
{
    internal class MapNames_T6ZM
    {
        string Mapname { get; set; }
        public string ConvertT6ZombieMaps( string mapToConvert )
        {
            switch( mapToConvert )
            {
                //In release order
                case "zm_transit": return "Tranzit";
                case "zm_nuked": return "Nuketown";
                case "zm_highrise": return "Die Rise";
                case "zm_prison": return "Mob Of The Dead";                    
                case "zm_buried": return "Buried";
                case "zm_tomb": return "Origins";
            }
            //if we can't display any pre determined maps, show the map console name
            return "Server is playing a custom map called: " + mapToConvert;
        }
    }
}
