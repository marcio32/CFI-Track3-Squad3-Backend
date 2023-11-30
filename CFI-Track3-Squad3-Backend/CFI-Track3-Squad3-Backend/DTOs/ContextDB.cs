using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DTOs
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB>options): base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
