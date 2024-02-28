using System.Collections.Generic; 
namespace spitfire_solutions{ 

    public class Server
    {
        public string ip { get; set; }
        public int port { get; set; }
        public string game { get; set; }
        public string hostname { get; set; }
        public string map { get; set; }
        public string gametype { get; set; }
        public List<object> players { get; set; }
        public int maxplayers { get; set; }
        public bool hardcore { get; set; }
        public bool password { get; set; }
        public int bots { get; set; }
        public int voice { get; set; }
        public string description { get; set; }
        public string codInfo { get; set; }
        public int revision { get; set; }
        public string gametypeDisplay { get; set; }
        public string mapDisplay { get; set; }
        public string hostnameDisplay { get; set; }
        public string hostnameDisplayFull { get; set; }
        public int round { get; set; }
        public string gameDisplay { get; set; }
        public string aimassist { get; set; }
        public bool online { get; set; }
        public bool known { get; set; }
        public object date { get; set; }
        public bool uptodate { get; set; }
        public string country { get; set; }
        public string countryDisplay { get; set; }
        public bool changed { get; set; }
        public string identifier { get; set; }
        public string platform { get; set; }
        public int realClients { get; set; }
        public string challenge { get; set; }
        public string checksum { get; set; }
        public string gamename { get; set; }
        public string sv_motd { get; set; }
        public string xuid { get; set; }
        public int? clients { get; set; }
        public int? protocol { get; set; }
        public string fs_game { get; set; }
        public bool? hc { get; set; }
        public int? securityLevel { get; set; }
        public string shortversion { get; set; }
        public bool? sv_running { get; set; }
        public bool? wwwDownload { get; set; }
        public string wwwUrl { get; set; }
    }

}