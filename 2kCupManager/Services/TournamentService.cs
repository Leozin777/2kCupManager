using _2kCupManager.Model;
using _2kCupManager.Utils;
using SQLite;

namespace _2kCupManager.Services;

public class TournamentService
{
    SQLiteAsyncConnection? database;

    async Task Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await database.CreateTableAsync<Tournament>();
    }

    public async Task<List<Tournament>> GetAll()
    {
        await Init();
        return await database.Table<Tournament>().ToListAsync();
    }

    public async Task Save(Tournament team)
    {
        await Init();
        await database.InsertAsync(team);
    }

    public async Task Delete(int Id)
    {
        await Init();
        await database.DeleteAsync(Id);
    }
}