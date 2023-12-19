// Implementación concreta de la interfaz IUnitOfWork que gestiona la unidad de trabajo para la base de datos

using AutoMapper;
using CFI_Track3_Squad3_Backend.DataAccess.Repositories;
using CFI_Track3_Squad3_Backend.DTOs;

namespace CFI_Track3_Squad3_Backend.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;
        private readonly IMapper _mapper;

        // Propiedades para acceder a los repositorios específicos
        public AccountsRepository AccountsRepository { get; set; }
        public RoleRepository RoleRepository { get; set; }
        public UserRepository UserRepository { get; set; }
        public UserRepository2 UserRepository2 { get; set; }

        // Constructor que inicializa el contexto de la base de datos y el mapeador AutoMapper
        public UnitOfWorkService(ContextDB contextDB, IMapper mapper)
        {
            _mapper = mapper;
            _contextDB = contextDB;

            // Inicialización de los repositorios
            AccountsRepository = new AccountsRepository(_contextDB);
            RoleRepository = new RoleRepository(_contextDB, _mapper);
            UserRepository = new UserRepository(_contextDB, _mapper);
            UserRepository2 = new UserRepository2(_contextDB);
        }

        // Método para completar las operaciones en la base de datos
        public Task<int> Complete()
        {
            return _contextDB.SaveChangesAsync();
        }
    }
}
