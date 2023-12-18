using CFI_Track3_Squad3_Backend.DataAccess.DatabaseSeeding;
using CFI_Track3_Squad3_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DTOs
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; } 
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new RoleSeeder(),
                new AccountsSeeder(),
                new UserSeeder()                
            };

            foreach (var seeder in seeders)
            {

                seeder.SeedDatabase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
