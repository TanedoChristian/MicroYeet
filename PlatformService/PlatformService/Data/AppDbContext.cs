using Microsoft.EntityFrameworkCore;
using PlatformService.Entities;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}
