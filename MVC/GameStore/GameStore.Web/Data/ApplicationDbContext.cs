using GameStore.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<GameDetails> GameDetails { get; set; }
    }
}
