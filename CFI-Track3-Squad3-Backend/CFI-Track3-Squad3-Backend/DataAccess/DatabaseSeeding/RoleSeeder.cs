using CFI_Track3_Squad3_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DataAccess.DatabaseSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Administrator",
                    Description = "Administrator",
                    IsDeleted = false,
                    DeletedTimeUtc = null,

                },
                 new Role
                 {
                     Id = 2,
                     Name = "Consultant",
                     Description = "Consultant",
                     IsDeleted = false,
                     DeletedTimeUtc = null,
                 });
        }
    }
}
