using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.ServerClasses
{
    class ServerListInfo
    {
        public string SL_Host { get; set; }
        public string SL_Round { get; set; }
        public string SL_MapName { get; set; }
        public string SL_PlayersPlaying { get;set; }
        public string SL_Game { get; set; }


        public string? SL_Gametype { get; set; }
        public string? SL_Ip { get; set; }

        public string SL_Players { get; set; }
    }
}
