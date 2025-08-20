using DungeonBattler.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DungeonBattler.Data
{
    public class GameContext : IdentityDbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        public DbSet<PlayerChar> PlayerChar { get; set; }
        public DbSet<NonPlayerChar> NonPlayerChar { get; set; }
    }
}

