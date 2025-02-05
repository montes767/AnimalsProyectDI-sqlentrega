using AnimalsProyectDI.Abstractions;
using AnimalsProyectDI.Repositories;
using AnimalsProyectDI.MVVM.Model;
using Microsoft.Extensions.Logging;

namespace AnimalsProyectDI
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

            builder.Services.AddSingleton<IBaseRepository<Animal>,AnimalRepositories<Animal>>();
            
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
