using Microsoft.EntityFrameworkCore;

namespace CFI-Track3-Squad3-Backend.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabase(ModelBuilder modelBuilder);
    }
}