using CFI_Track3_Squad3_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DataAccess.DatabaseSeeding
{
    /// <summary>
    /// Clase de semilla para la entidad Role en la base de datos.
    /// </summary>
    public class RoleSeeder : IEntitySeeder
    {
        /// <summary>
        /// Método para sembrar datos iniciales de roles en la base de datos utilizando el modelo de construcción (ModelBuilder).
        /// </summary>
        /// <param name="modelBuilder">Instancia de ModelBuilder utilizada para construir el modelo de base de datos.</param>
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            // Se insertan datos iniciales en la entidad Role.
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
