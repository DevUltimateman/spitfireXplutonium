using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.ServerClasses
{
    class ServerListInfo
    {
        public string Host { get; set; }
        public string Round { get; set; }
        public string MapName { get; set; }
        public string PlayersPlaying { get;set; }
        public string Game { get; set; }


        public string? Gametype { get; set; }
        public string? Ip { get; set; }

        //public string Players { get; set; }

        public string PlayerList { get; set; }
    }
}
