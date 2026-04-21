using SQLite;

namespace _2kCupManager.Model;

public class Team
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Player> Players { get; set; } = new();
}