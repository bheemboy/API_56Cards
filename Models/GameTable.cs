using Newtonsoft.Json;

namespace API_56Cards.Models
{
    public enum GameStage {Unknown=0, WaitingForPlayers=1, Bidding=2, SelectingTrump=3, PlayingCards=4, GameOver=5}

    [JsonObject(MemberSerialization.OptIn)]
    public class GameTable
    {
        public TableType T {get;}
        [JsonProperty]
        public int Type => T.Type; // Used for JSON export only
        [JsonProperty]
        public int MaxPlayers => T.MaxPlayers; // Used for JSON export only
        [JsonProperty]
        public string TableName {get;}
        public GameStage Stage {get; set;} = GameStage.WaitingForPlayers;
        [JsonProperty]
        public bool GameCancelled {get; set;} = false;
        [JsonProperty]
        public bool GameForfeited {get; set;} = false;
        public List<string> Deck = []; 
        [JsonProperty]
        public List<Chair> Chairs;
        [JsonProperty]
        public BidInfo? Bid {get; set;} = null;
        [JsonProperty]
        public List<RoundInfo> Rounds {get; set;} = [];
        [JsonProperty]
        public int DealerPos {get; set;}
        public string TrumpCard {get; set;} = "";
        public bool TrumpExposed {get; set;}
        [JsonProperty]
        public int RoundWinner  {get; set;}
        [JsonProperty]
        public bool RoundOver  {get; set;}
        [JsonProperty]
        public int WinningTeam {get; set;} = -1;
        [JsonProperty]
        public int WinningScore {get; set;} = 0;
        [JsonProperty]
        public List<int> TeamScore {get; set;} = [];
        [JsonProperty]
        public List<int> CoolieCount {get; set;}
        public List<bool> KodiIrakkamRound {get; set;} = [false, false];
        public bool TableFull => Chairs.TrueForAll(c => c.Occupant != null);
        public bool WatchersFull => Chairs.TrueForAll(c => c.WatchersFull);
        public GameTable(TableType tableType, string tableName)
        {
            T = tableType;
            TableName = tableName;
            CoolieCount = [T.BaseCoolieCount,T.BaseCoolieCount];
            Chairs = Enumerable.Range(0, T.MaxPlayers).Select(i => new Chair(i)).ToList();
        }
    }
}
