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
                     FirstName = "Admin",
                     LastName = "Administrador",                    
                     Email = "admin@gmail.com", // Provide an email address
                     Password = PasswordEncryptHelper.EncryptPassword("123", "admin@gmail.com"),
                     IsDelete = false,
                     DeletedTimeUtc = null,
                     RoleId = 1
                 },
                new User
                {
                    Id = 2,
                    FirstName = "User",
                    LastName = "UserTest",                   
                    Email = "user@gmail.com", // Provide an email address
                    Password = PasswordEncryptHelper.EncryptPassword("123", "user@gmail.com"),
                    IsDelete = false,
                    DeletedTimeUtc = null,
                    RoleId = 2
                });
        }
    }
}
