using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_56Cards.Models
{
    public class GameHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime GameDateTime { get; set; }
        public string TableName { get; set; } = string.Empty;
        public int WinningTeam { get; set; }
        public int WinningScore { get; set; }
        public bool GameCancelled { get; set; }
        public bool GameForfeited { get; set; }
        
        [Column(TypeName = "jsonb")]
        public string GameState { get; set; } = string.Empty;
    }
}
