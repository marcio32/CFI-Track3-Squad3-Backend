using CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces;
using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entites;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories
{
    public class AccountsRepository : Repository<Accounts>, IAccountsRepository
    {       

        public Task<List<AccountsDTO>> GetAllAccounts(int parameter, string state)
        {
            throw new NotImplementedException();
        }

        public Task<AccountsDTO> GetAccountsById(int id, int parameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccountsById(int id, int parameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAccounts(AccountsDTO accountsDTO, int id, int parameter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAccounts(AccountsDTO accountsDTO)
        {
            throw new NotImplementedException();
        }
    }
}
