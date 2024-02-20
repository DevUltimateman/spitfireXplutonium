using Newtonsoft.Json;
using System.Collections.Generic;

namespace spitfire_solutions.ServerClasses
{
    public class Root
    {
       // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>();

        public List<Server> servers { get; set; }
        public int countPlayers { get; set; }
        public int countBots { get; set; }
        public int maxPlayers { get; set; }
        public int countServers { get; set; }
        public long date { get; set; }
        public string platform { get; set; }






        public string hostname { get; set; }

    }
}
