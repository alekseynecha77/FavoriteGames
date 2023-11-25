using Microsoft.EntityFrameworkCore;

namespace FavGames.Models {
    public class GamesContext : DbContext
    {
        public GamesContext(DbContextOptions<GamesContext> options)
            : base(options)
        {
        }

        // Your DbSets representing the tables in the database.
        // For example, if you have a "Game" model, you would have:
        public DbSet<Game> Games { get; set; }

        // Repeat the above line for each additional entity/model you have.
    }
}