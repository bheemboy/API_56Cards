using System.Collections.Concurrent;
using API_56Cards.Models;

namespace API_56Cards.Storage
{
    public static class GameTables
    {
        private static readonly object _lock = new();
        public static readonly ConcurrentDictionary<string, GameTable> All = new();
        public static GameTable AddTable(int tableType, string tableId)
        {
            lock (_lock)
            {
                GameTable table = new(new TableType(tableType), tableId); 
                if (!All.TryAdd(tableId, table))
                {
                    throw new Exception($"Failed to add table '{tableId}' to AllPlayers");
                }
                Console.WriteLine($"Added new gametable {tableId}");
                return table;
            }
        }
        public static void RemoveTable(string tableId)
        {
            lock (_lock)
            {
                if (All.ContainsKey(tableId))
                {
                    if (!All.TryRemove(tableId, out GameTable? ignored))
                    {
                        throw new Exception($"Failed to remove table '{tableId}' from AllTables");
                    }
                    Console.WriteLine($"Removed empty gametable {tableId}");                    
                }
            }
        }
        public static GameTable GetFreeTable(int tableType, bool watchOnly)
        {
            lock (_lock)
            {
                foreach (var table in All.Values)
                {
                    if (table.T.Type==tableType && table.TableName.StartsWith("PUBLIC_TABLE_"))
                    {
                        if (watchOnly)
                        {
                            if (!table.WatchersFull) return table;
                        }
                        else
                        {
                            if (!table.TableFull) return table;
                        }
                    }
                }

                // Let us add a new table since there are no free tables...
                return AddTable(tableType, "PUBLIC_TABLE_" + Guid.NewGuid().ToString("N"));
            }
        }
    }
}

