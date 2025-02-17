using NGettext;

namespace API_56Cards.Models
{
    public class TableType(int tableType)
    {
        public int Type { get; } = tableType;
        private int[] _BaseCoolieCount = [6,6,7];
        public int BaseCoolieCount => _BaseCoolieCount[Type]; 
        private int[] _MaxPlayers = [4,6,8];
        public int MaxPlayers => _MaxPlayers[Type];
        public int PlayersPerTeam => MaxPlayers/2; 
        private int[] _DeckSize = [32,48,64];
        public int DeckSize => _DeckSize[Type];
        public const string CLUBS="Clubs";
        public const string HEARTS="Hearts";
        public const string DIAMOND="Diamond";
        public const string SPADE="Spade";
        public List<string> Suits => ["h","s","d","c"];
        private List<string>[] _Ranks = [
            ["10","1","9","11"],
            ["12","13","10","1","9","11"],
            ["7","8","12","13","10","1","9","11"]
        ];
        public List<string> Ranks => _Ranks[Type];
        public int PlayerAt(int position) => position%MaxPlayers;
        public int TeamOf(int position) => position%2;
        public bool SameTeam(int posn1, int posn2) => posn1%2 == posn2%2;
        public readonly int MaxBid = 57;

        private static int StageForBid(int bid)
        {
            if (bid >= 57) return 5; // THANI
            if (bid == 56) return 4;
            if (bid >= 48) return 3;
            if (bid >= 40) return 2;
            return 1;
        }
        public int NextMinBidAfterBid(int bid)
        {
            if (bid < 28) return 28;
            else if (bid <= 39) return 40;
            else return 48;
        }
        public int GetWinPointsForBid(int bid)
        {
            return StageForBid(bid) switch
            {
                5 => BaseCoolieCount * 2,
                4 => 4,
                3 => 3,
                2 => 2,
                _ => 1,
            };
        }
        public int GetLosePointsForBid(int bid)
        {
            return StageForBid(bid) switch
            {
                5 => BaseCoolieCount * 2,
                4 => 5,
                3 => 4,
                2 => 3,
                _ => 2,
            };
        }
        public int PointsForCard(string card)
        {
            int rank = int.Parse(card.Substring(1));

            if (rank == 11) return 3;
            else if (rank == 9) return 2;
            else if (rank == 1 || rank == 10)  return 1;
            return 0;
        }
        public string GetSuitName(char c)
        {
            string suitName = (c == 'c') ? CLUBS : (c == 'd') ? DIAMOND : (c == 'h') ? HEARTS : SPADE;
        	Catalog catalog = new("strings", "./locale", Thread.CurrentThread.CurrentCulture);
            return catalog.GetString(suitName);;
        } 
        public int CompareSuit(string cardA, string cardB)
        {
            // return 1 if cardA comes before cardB in ascending sort order
            int aVal = Suits.IndexOf(cardA.Substring(0,1));
            int bVal = Suits.IndexOf(cardB.Substring(0,1));
            if (aVal < bVal) return 1;
            else if (aVal > bVal) return -1;
            else return 0;
        }
        public int CompareRank(string cardA, string cardB)
        {
            // return 1 if cardA comes before cardB in ascending sort order
            int aVal = Ranks.IndexOf(cardA.Substring(1));
            int bVal = Ranks.IndexOf(cardB.Substring(1));
            if (aVal < bVal) return 1;
            else if (aVal > bVal) return -1;
            else return 0;
        }
        public int CompareCards(string cardA, string cardB)
        {
            if (cardA == cardB) return 0;
            int suiteDiff = CompareSuit(cardA, cardB);
            if (suiteDiff != 0) 
                return suiteDiff;
            else 
                return CompareRank(cardA, cardB);
        }
    }
}