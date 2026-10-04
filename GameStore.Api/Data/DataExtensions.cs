using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace GameStore.Api.Data
{
    public static class DataExtensions
    {
        public static void MirgateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.
                GetRequiredService<GameStoreContext>();
            dbContext.Database.Migrate();
        }

        public static void AddGameStoreDb(this WebApplicationBuilder builder)
        {
            var ConString = builder.Configuration.GetConnectionString("GameStore");

            builder.Services.AddScoped< GameStoreContext > ();
            builder.Services.AddSqlite<GameStoreContext>(
                ConString,
                optionsAction: options => options.UseSeeding((context, _) =>
                {
                    if (!context.Set<Genre>().Any())
                    {
                        context.Set<Genre>().AddRange(
                                new Genre { Name = "Fighting" },
                                new Genre { Name = "RPG" },
                                new Genre { Name = "Platformer" },
                                new Genre { Name = "Racing" },
                                new Genre { Name = "Sports" }
                            );
                        context.SaveChanges();
                    }
                })
                );
        }
    }
}
