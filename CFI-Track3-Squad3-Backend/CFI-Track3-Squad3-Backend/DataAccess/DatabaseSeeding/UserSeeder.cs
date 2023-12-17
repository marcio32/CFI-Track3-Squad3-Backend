using CFI_Track3_Squad3_Backend.Entities;
using CFI_Track3_Squad3_Backend.Helper;
using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DataAccess.DatabaseSeeding
{
    /// <summary>
    /// Clase de semilla para la entidad User en la base de datos.
    /// </summary>
    public class UserSeeder : IEntitySeeder
    {
        /// <summary>
        /// Método para sembrar datos iniciales de usuarios en la base de datos utilizando el modelo de construcción (ModelBuilder).
        /// </summary>
        /// <param name="modelBuilder">Instancia de ModelBuilder utilizada para construir el modelo de base de datos.</param>
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            // Se insertan datos iniciales en la entidad User.
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Administrador",
                    Email = "admin@gmail.com", // Proporcione una dirección de correo electrónico
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
                    Email = "user@gmail.com", // Proporcione una dirección de correo electrónico
                    Password = PasswordEncryptHelper.EncryptPassword("123", "user@gmail.com"),
                    IsDelete = false,
                    DeletedTimeUtc = null,
                    RoleId = 2
                });
        }
    }
}
