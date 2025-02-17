using Newtonsoft.Json;

namespace API_56Cards.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RoundInfo(int firstPlayer) // Class that hold one round of game
    {
        [JsonProperty]
        public int FirstPlayer {get; set;} = firstPlayer;
        [JsonProperty]
        public int NextPlayer {get; set;} = firstPlayer;
        [JsonProperty]
        public List<string> PlayedCards {get; set;} = [];
        [JsonProperty]
        public string AutoPlayNextCard {get; set;} = "";
        [JsonProperty]
        public List<bool> TrumpExposed = [];
        [JsonProperty]
        public int Winner  {get; set;} = -1;
        [JsonProperty]
        public int Score  {get; set;} = -1;
    }
}
