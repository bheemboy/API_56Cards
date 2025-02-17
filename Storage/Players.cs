using System.Collections.Concurrent;
using API_56Cards.Models;

namespace API_56Cards.Storage
{
    public static class Players
    {
        public static readonly ConcurrentDictionary<string, Player> All = new();
        public static Player AddPlayer(string connectionid, string name, string lang, bool watchOnly)
        {
            name = name.Trim();
            if (name.Length <=0 ) throw new Exception($"Non-empty name is required.");

            Player player = new Player(connectionid, name, lang, watchOnly);
            if (!All.TryAdd(player.ConnID, player))
            {
                throw new Exception($"Failed to add player '{name}' to AllPlayers");
            }
            
            Console.WriteLine($"--> Player Registered: {connectionid}, Name: '{name}'");
            return player;
        }
        public static void RemovePlayerById(string playerId)
        {
            if (All.ContainsKey(playerId) && !All.TryRemove(playerId, out Player? ignored))
            {
                throw new Exception($"Failed to remove player '{playerId}' from AllPlayers");
            }
        }
    }
}

