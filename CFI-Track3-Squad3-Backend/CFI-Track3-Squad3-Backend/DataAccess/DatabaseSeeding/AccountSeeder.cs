using Microsoft.EntityFrameworkCore;
using CFI-Track3-Squad3-Backend.Entities;

namespace CFI-Track3-Squad3-Backend.DataAccess.DatabaseSeeding
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    DateTime = DateTime.Now,
                    Money = 1000.00m,
                    IsBlocked = false,
                    UserId = 1
                },
                new Account
                {
                    Id = 2,
                    DateTime = DateTime.Now,
                    Money = 2000.00m,
                    IsBlocked = false,
                    UserId = 1
                },
                   new Account
                   {
                       Id = 3,
                       DateTime = DateTime.Now,
                       Money = 1500.50m,
                       IsBlocked = true,
                       UserId = 2
                   },
                new Account
                {
                    Id = 4,
                    DateTime = DateTime.Now,
                    Money = 3000.75m,
                    IsBlocked = false,
                    UserId = 2
                },);
        }
    }
}