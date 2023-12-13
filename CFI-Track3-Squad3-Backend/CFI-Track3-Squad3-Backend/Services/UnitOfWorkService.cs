using AutoMapper;
using CFI_Track3_Squad3_Backend.DataAccess.Repositories;
using CFI_Track3_Squad3_Backend.DTOs;


namespace CFI_Track3_Squad3_Backend.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;
        private readonly IMapper _mapper;

        public AccountsRepository AccountsRepository { get; set; }
        public RoleRepository RoleRepository { get; set; }
        public UserRepository UserRepository { get; set; }  

        public UnitOfWorkService(ContextDB contextDB, IMapper mapper)
        {
            _mapper = mapper;
            _contextDB = contextDB;
            AccountsRepository = new AccountsRepository(_contextDB);
            RoleRepository = new RoleRepository(_contextDB, _mapper);
            UserRepository = new UserRepository(_contextDB, _mapper);
        }

        public Task<int> Complete()
        {
            return _contextDB.SaveChangesAsync();   
        }
    }
}
