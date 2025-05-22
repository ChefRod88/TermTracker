using Microsoft.Extensions.Logging;
using TermTracker.ViewModels.StudentLounge;

namespace TermTracker
{
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

            builder.Services.AddSingleton(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7009/") // 🔁 Replace with Azure URL after deployment//
                });

            builder.Services.AddSingleton<ForumService>();
            builder.Services.AddSingleton<ForumViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
