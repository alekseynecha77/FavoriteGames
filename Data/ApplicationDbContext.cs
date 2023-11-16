using Microsoft.EntityFrameworkCore;

namespace FavGames.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Your DbSets representing the tables in the database.
        // For example, if you have a "Game" model, you would have:
        public DbSet<Game> Games { get; set; }

        // Repeat the above line for each additional entity/model you have.
    }
}