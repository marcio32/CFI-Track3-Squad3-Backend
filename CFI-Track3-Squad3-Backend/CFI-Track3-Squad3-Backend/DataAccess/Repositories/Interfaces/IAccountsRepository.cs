using CFI_Track3_Squad3_Backend.DTOs;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces
{
    public interface IAccountsRepository<T> where T : class // Update interface name and entity type
    {
        public Task<List<AccountsDTO>> GetAllAccounts(int parameter,string state); // Update method name
        public Task<AccountsDTO> GetAccountsById(int id, int parameter); // Update method name
        public Task<bool> DeleteAccountsById(int id, int parameter); // Update method name
        public Task<bool> UpdateAccounts(AccountsDTO accountsDTO, int id, int parameter); // Update method name

        public Task<bool> InsertAccounts(AccountsDTO accountsDTO);

    }
}
