using _2kCupManager.Services;
using Microsoft.Extensions.Logging;

namespace _2kCupManager;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<PlayerService>();
        builder.Services.AddSingleton<TeamService>();
        builder.Services.AddSingleton<TournamentService>();

        return builder.Build();
    }
}