using AutoMapper;
using CFI_Track3_Squad3_Backend.DataAccess.Repositories;
using CFI_Track3_Squad3_Backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;
        private readonly IMapper _mapper;

        public AccountsRepository AccountsRepository { get; set; }
        public RoleRepository RoleRepository { get; set; }

        public UnitOfWorkService(ContextDB contextDB, IMapper mapper)
        {
            _mapper = mapper;
            _contextDB = contextDB;
            AccountsRepository = new AccountsRepository(_contextDB);
            RoleRepository = new RoleRepository(_contextDB);
        }

        public Task<int> Complete()
        {
            return _contextDB.SaveChangesAsync();   
        }
    }
}
