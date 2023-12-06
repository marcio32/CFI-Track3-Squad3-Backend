using CFI_Track3_Squad3_Backend.DataAccess.Repositories;
using CFI_Track3_Squad3_Backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;

        public AccountsRepository AccountsRepository { get; set; }
        public UnitOfWorkService(ContextDB contextDB)
        {
            _contextDB = contextDB;
            AccountsRepository = new AccountsRepository(contextDB);
        }

        public Task<int> Complete()
        {
            return _contextDB.SaveChangesAsync();   
        }
    }
}
