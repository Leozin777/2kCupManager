using SQLite;

namespace _2kCupManager.Model;

public class Player
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Ovr { get; set; }
}