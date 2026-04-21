using _2kCupManager.Model;
using _2kCupManager.Utils;
using SQLite;

namespace _2kCupManager.Services;

public class PlayerService
{
    SQLiteAsyncConnection? database;

    async Task Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await database.CreateTableAsync<Player>();
    }

    public async Task<List<Player>> GetAll()
    {
        await Init();
        return await database!.Table<Player>().ToListAsync();
    }

    public async Task Save(Player player)
    {
        await Init();
        await database!.InsertAsync(player);
    }

    public async Task Delete(int id)
    {
        await Init();
        await database!.DeleteAsync<Player>(id);
    }
}