using Newtonsoft.Json;

namespace API_56Cards.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Player(string ConnId, string name, string lang, bool watchOnly)
    {
        public string ConnID {get;} = ConnId;
        [JsonProperty]
        public string PlayerID {get;} = System.Guid.NewGuid().ToString().ToUpper();
        [JsonProperty]
        public string Name {get;} = name;
        [JsonProperty]
        public string Lang {get;} = lang;
        public string TableName {get; set;} = "";
        public int Position {get; set;} = -1;
        [JsonProperty]
        public bool WatchOnly {get; set;} = watchOnly;
    }
}
