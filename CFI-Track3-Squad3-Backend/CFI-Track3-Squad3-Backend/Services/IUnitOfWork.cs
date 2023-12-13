using CFI_Track3_Squad3_Backend.DataAccess.Repositories;

namespace CFI_Track3_Squad3_Backend.Services
{
    public interface IUnitOfWork
    {
        public AccountsRepository AccountsRepository { get; }
        public RoleRepository RoleRepository { get; }
        public UserRepository UserRepository { get; }
        public Task<int> Complete();
    }
}
