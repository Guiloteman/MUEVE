using AppFletesMueve.Data;
using AppFletesMueve.Services;
using AppFletesMueve.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AppFletesMueve
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

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Registro de servicios y páginas
            builder.Services.AddSingleton<UsuarioService>();
            builder.Services.AddTransient<RegistroPage>();
            builder.Services.AddTransient<LoginPage>();

            // Ruta de la base de datos SQLite local
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "fletes.db");

            // Registro del DbContext para la inyección de dependencias
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Filename={dbPath}"));

            // Creación segura de la base de datos usando DbContextOptionsBuilder
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite($"Filename={dbPath}");

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }

            return builder.Build();
        }
    }
}