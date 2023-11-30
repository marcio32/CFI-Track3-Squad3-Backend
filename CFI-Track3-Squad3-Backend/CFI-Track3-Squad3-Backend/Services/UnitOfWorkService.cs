using CFI_Track3_Squad3_Backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;

        public UnitOfWorkService(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public Task<int> Complete()
        {
            throw new NotImplementedException();
        }
    }
}
