// Interfaz que define la unidad de trabajo para la gestión de repositorios y operaciones en la base de datos

using CFI_Track3_Squad3_Backend.DataAccess.Repositories;

namespace CFI_Track3_Squad3_Backend.Services
{
    public interface IUnitOfWork
    {
        // Propiedades que exponen los repositorios específicos
        public AccountsRepository AccountsRepository { get; }
        public RoleRepository RoleRepository { get; }
        public UserRepository UserRepository { get; }
        public UserRepository2 UserRepository2 { get; }

        // Método para completar las operaciones en la base de datos
        public Task<int> Complete();
    }
}
