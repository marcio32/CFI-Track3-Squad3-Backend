using CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces;
using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories
{
    public class AccountsRepository : Repository<Account>
    {
        protected readonly ContextDB _contextDB;
        public AccountsRepository(ContextDB contextDB) : base(contextDB) 
        {
            _contextDB = contextDB;
        }
        
        public async Task<List<Account>> GetAllAccount()
        {
            try
            {
                return await _contextDB.Accounts.Where(x => x.IsBlocked ==  false).ToListAsync();
                
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener todas las cuentas", ex);
            }
        }

        public async Task<Account?> GetAccountId(int id)
        {
            try
            {
                return await _contextDB.Accounts.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener cuenta", ex);
            }
        }

        public async Task<bool> InsertAccount(AccountsDTO accountsDTO)
        {
            try
            {
                var account = new Account();
                account = accountsDTO;
                return await base.Insert(account);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al insertar cuenta", ex);
            }
        }

        public async Task<bool> UpdataAccount(AccountsDTO accountsDTO, int id)
        {
            try
            {
                var account = new Account();
                account = accountsDTO;
                account.Id = id;
                account.IsBlocked = accountsDTO.IsBlocked;
                return await base.Update(account);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al actualizar cuenta", ex);
            }
        }

        public async Task<bool> DeleteAccount(int id)
        {
            try
            {
                var account = await GetAccountId(id);
                account.IsBlocked = true;
                return await base.Delete(account);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar cuenta", ex);
            }
        }

    }
}
