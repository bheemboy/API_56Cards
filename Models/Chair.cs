
using Newtonsoft.Json;

namespace API_56Cards.Models

{
    [JsonObject(MemberSerialization.OptIn)]
    public class Chair(int posn)
    {
        [JsonProperty]
        public int Position { get; set; } = posn;
        public List<string> Cards {get; set;} = [];
        [JsonProperty]
        public Player? Occupant { get; set; } = null;
        [JsonProperty]
        public List<Player> Watchers { get; set; } = [];
        [JsonProperty]
        public int KodiCount { get; set; } = 0;
        [JsonProperty]
        public bool KodiJustInstalled { get; set; } = false;
        public bool WatchersFull  => Watchers.Count>=2;
    }
}
