using SQLite;

namespace _2kCupManager.Model;

public class Tournament
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Team> Teams { get; set; } = new();
}