using Microsoft.EntityFrameworkCore;
using CFI_Track3_Squad3_Backend.Entities;
using CFI_Track3_Squad3_Backend.DTOs;

namespace CFI_Track3_Squad3_Backend.DataAccess.DatabaseSeeding
{
    public class AccountsSeeder : IEntitySeeder 
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
                });
        }
    }    
}
    
    
