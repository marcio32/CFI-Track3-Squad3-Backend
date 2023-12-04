using CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces;
using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Linq;
using AutoMapper;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories
{
    public class AccountsRepository : Repository<Accounts>, IAccountsRepository
    {
        private readonly IMapper _mapper;

        public AccountsRepository(ContextDB contextDB, IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }

        public async Task<bool> UpdateAccounts(AccountsDTO AccountsDTO, int id, int parameter)
        {
            try
            {

                var accountsFinding = await GetById(id);
                if (accountsfinding == null)
                {
                    return false;
                }
                if (parameter == 0)
                {
                    var accounts = _mapper.Map<Accounts>(accountsDTO);
                    _mapper.Map(accounts, accountsFinding);
                    _contextDB.Update(accountsFinding);
                    return true;
                }
                if (accountsFinding.IsDeleted != false && parameter == 1)
                {
                    accountsFinding.IsDeleted = false;
                    accountsFinding.DeletedTimeUtc = null;
                    _contextDB.Update(accountsFinding);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<List<AccountsDTO>> GetAllAccounts(int parameter, string state)
        {
            try
            {
                AccountsStatus status;
                status = _mapper.Map<AccountsStatus>(state.ToLower());
                int intStatus = (int)status;

                var accounts = await base.GetAll();
                switch (parameter)
                {
                    case 0:
                        accounts = accounts.Where(accounts => !accounts.IsDeleted).ToList();
                        return _mapper.Map<List<AccountsDTO>>(accounts);

                    case 1:
                        return _mapper.Map<List<AccountsDTO>>(accounts);
                    case 2:
                        accounts = accounts.Where(accounts => !accounts.IsDeleted && accounts.Status == (AccountsStatus)intStatus).ToList();
                        return _mapper.Map<List<AccountsDTO>>(accounts);
                    default:
                        return null;
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"An ArgumentException occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<AccountsDTO> GetAccountsById(int id, int parameter)
        {
            try
            {

                Accounts accountsFinding = await base.GetById(id);
                if (accountsFinding == null)
                {
                    return null;
                }
                if (accountsFinding.IsDeleted != true && parameter == 0)
                {
                    return _mapper.Map<AccountsDTO>(accountsFinding); ;
                }
                if (parameter == 1)
                {
                    return _mapper.Map<AccountsDTO>(accountsFinding); ;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAccountsById(int id, int parameter)
        {

            try
            {
                Accounts accountsFinding = await GetById(id);
                if (accountsFinding == null)
                {
                    return false;
                }

                if (parameter == 0)
                {
                    accountsFinding.IsDeleted = true;
                    accountsFinding.DeletedTimeUtc = DateTime.UtcNow;
                    return true;
                }
                if (parameter == 1)
                {
                    var relatedWork = _contextDB.Works.Where(work => work.AccountsId == id).ToList();
                    _contextDB.Works.RemoveRange(relatedWork);
                    _contextDB.Accounts.Remove(accountsFinding);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public virtual async Task<bool> InsertAccounts(AccountsDTO accountsDTO)
        {
            try
            {
                var accounts = _mapper.Map<Accounts>(accountsDTO);
                var response = await base.Insert(accounts);
                return response;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
