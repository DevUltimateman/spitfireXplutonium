using System.Collections.Generic; 
namespace spitfire_solutions{ 

    public class Root
    {
        public List<Server> servers { get; set; }
        public int countPlayers { get; set; }
        public int countBots { get; set; }
        public int maxPlayers { get; set; }
        public int countServers { get; set; }
        public object date { get; set; }
        public string platform { get; set; }
    }

}