using _2kCupManager.Model;
using _2kCupManager.Utils;
using SQLite;

namespace _2kCupManager.Services;

public class TeamService
{
    SQLiteAsyncConnection? database;

    async Task Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await database.CreateTableAsync<Team>();
    }

    public async Task<List<Team>> GetAll()
    {
        await Init();
        return await database!.Table<Team>().ToListAsync();
    }

    public async Task Save(Team team)
    {
        await Init();
        await database!.InsertAsync(team);
    }

    public async Task Delete(int Id)
    {
        await Init();
        await database!.DeleteAsync(Id);
    }
}