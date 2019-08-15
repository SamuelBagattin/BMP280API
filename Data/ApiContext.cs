using BMP280API.Models;
using Microsoft.EntityFrameworkCore;

namespace BMP280API.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext
            (DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Module> Modules { get; set; }
        
        public DbSet<ModuleData> ModuleDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>()
                .HasMany(e => e.ModuleDatas)
                .WithOne()
                .HasForeignKey(e => e.ModuleGuid);
        }
    }
}