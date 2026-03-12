using Microsoft.EntityFrameworkCore;
using RazorPagesAnime.Data;

namespace RazorPagesAnime.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesAnimeContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesAnimeContext>>()))
        {
            if (context == null || context.Anime == null)
            {
                throw new ArgumentNullException("Null RazorPagesAnimeContext");
            }

            // Look for any anime.
            if (context.Anime.Any())
            {
                return;   // DB has been seeded
            }

            context.Anime.AddRange(
                new Anime
                {
                    Title = "Attack on Titan",
                    ReleaseDate = DateTime.Parse("2013-4-7"),
                    Genre = "Action",
                    Seasons = 4,
                    Rating = 10
                },

                new Anime
                {
                    Title = "Solo Leveling",
                    ReleaseDate = DateTime.Parse("2024-1-7"),
                    Genre = "Action",
                    Seasons = 2,
                    Rating = 9
                },

                new Anime
                {
                    Title = "Jujutsu Kaisen",
                    ReleaseDate = DateTime.Parse("2020-10-3"),
                    Genre = "Action",
                    Seasons = 3,
                    Rating = 9
                },

                new Anime
                {
                    Title = "That Time I Got Reincarnated as a Slime",
                    ReleaseDate = DateTime.Parse("2018-10-2"),
                    Genre = "Comedy",
                    Seasons = 4,
                    Rating = 8
                }
            );
            context.SaveChanges();
        }
    }
}