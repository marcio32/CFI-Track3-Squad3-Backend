﻿using CFI_Track3_Squad3_Backend.DataAccess.Repositories;

namespace CFI_Track3_Squad3_Backend.Services
{
    public interface IUnitOfWork
    {
        public AccountsRepository AccountsRepository { get; set; }
        public Task<int> Complete();
    }
}
