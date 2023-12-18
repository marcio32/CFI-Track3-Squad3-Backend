using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces
{
    public interface IAccountsRepository: IRepository<Account> // Update interface name and entity type
    {
        public Task<List<AccountDTO>> GetAllAccounts(int parameter); // Update method name
        public Task<AccountDTO> GetAccountById(int id, int parameter); // Update method name
        public Task<bool> DeleteAccountById(int id, int parameter); // Update method name
        public Task<bool> UpdateAccount(AccountDTO accountsDTO, int id, int parameter); // Update method name

        public Task<bool> InsertAccount(AccountDTO accountsDTO);

    }
}
