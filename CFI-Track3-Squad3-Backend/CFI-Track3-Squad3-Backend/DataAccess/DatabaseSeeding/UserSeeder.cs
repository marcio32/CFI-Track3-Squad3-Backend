using CFI_Track3_Squad3_Backend.Entities;
using CFI_Track3_Squad3_Backend.Helper;
using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DataAccess.DatabaseSeeding
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     FirstName = "Pablo",
                     LastName = "Ortiz",                    
                     Email = "adm@gmail.com", // Provide an email address
                     Password = PasswordEncryptHelper.EncryptPassword("123", "adm@gmail.com"),
                     IsDelete = false,
                     DeletedTimeUtc = null,
                     RoleId = 1
                 },
                new User
                {
                    Id = 2,
                    FirstName = "Kevin",
                    LastName = "Johnson",                   
                    Email = "noadm@gmail.com", // Provide an email address
                    Password = PasswordEncryptHelper.EncryptPassword("123", "noadm@gmail.com"),
                    IsDelete = false,
                    DeletedTimeUtc = null,
                    RoleId = 2
                });
        }
    }
}
