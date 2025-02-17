using Newtonsoft.Json;

namespace API_56Cards.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BidPass(int position, int bid)
    {
        [JsonProperty]
        public int Position {get; set;} = position;
        [JsonProperty]
        public int Bid {get; set;} = bid;
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class BidInfo
    {
        [JsonProperty]
        public int HighBid {get; set;} = -1;
        [JsonProperty]
        public int HighBidder {get; set;} = -1;
        [JsonProperty]
        public int NextBidder {get; set;}
        [JsonProperty]
        public int NextMinBid {get; set;} = 28;
        public int[] NextBidderFromTeam {get; set;} = new int[2];
        public int[] OutBidChance {get; set;}
        [JsonProperty]
        public List<BidPass> BidHistory {get; set;} = [];
        public BidInfo(TableType T, int firstBidder)
        {
            NextBidder = firstBidder;
            NextBidderFromTeam[T.TeamOf(firstBidder)] = firstBidder;
            NextBidderFromTeam[T.TeamOf(firstBidder+1)] = T.PlayerAt(firstBidder+1);
            OutBidChance = [.. Enumerable.Repeat(0, T.MaxPlayers)];
        }
    }
}
