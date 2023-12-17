using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DataAccess.DatabaseSeeding
{
    /// <summary>
    /// Interfaz que define el contrato para clases de semilla de entidades en la base de datos.
    /// </summary>
    public interface IEntitySeeder
    {
        /// <summary>
        /// Método para sembrar datos en la base de datos utilizando el modelo de construcción (ModelBuilder).
        /// </summary>
        /// <param name="modelBuilder">Instancia de ModelBuilder utilizada para construir el modelo de base de datos.</param>
        void SeedDatabase(ModelBuilder modelBuilder);
    }
}
