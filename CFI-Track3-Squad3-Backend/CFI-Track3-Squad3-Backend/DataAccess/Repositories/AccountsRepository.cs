using CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces;
using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories
{
    /// <summary>
    /// Clase de repositorio para la entidad Account, que hereda de la clase base Repository.
    /// </summary>
    public class AccountsRepository : Repository<Account>
    {
        private readonly IMapper _mapper;

        ///// <summary>
        ///// Constructor de la clase que recibe una instancia del contexto de base de datos.
        ///// </summary>
        ///// <param name="contextDB">Instancia del contexto de base de datos.</param>
        public AccountsRepository(ContextDB contextDB, IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todas las cuentas que no están bloqueadas.
        /// </summary>
        /// <returns>Lista de cuentas no bloqueadas.</returns>
        public virtual async Task<List<Account>> GetAllAccounts(int parameter)
        {
            try
            {
                return await _contextDB.Accounts.Where(x => x.IsBloqued == false).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las cuentas", ex);
            }
        }

        ///// <summary>
        ///// Obtiene una cuenta por su ID.
        ///// </summary>
        ///// <param name="id">ID de la cuenta a obtener.</param>
        ///// <returns>Instancia de Account o null si no se encuentra.</returns>
        public async Task<Account?> GetAccountById(int id, int parameter)
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

        ///// <summary>
        ///// Inserta una nueva cuenta en la base de datos a partir de un objeto AccountsDTO.
        ///// </summary>
        ///// <param name="accountsDTO">Objeto que contiene la información de la cuenta a insertar.</param>
        ///// <returns>true si la inserción es exitosa, false si hay un error.</returns>
        public async Task<bool> InsertAccount(AccountDTO accountsDTO)
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

        ///// <summary>
        ///// Actualiza una cuenta existente en la base de datos a partir de un objeto AccountsDTO y un ID.
        ///// </summary>
        ///// <param name="accountsDTO">Objeto que contiene la información de la cuenta a actualizar.</param>
        ///// <param name="id">ID de la cuenta a actualizar.</param>
        ///// <returns>true si la actualización es exitosa, false si hay un error.</returns>
        public virtual async Task<bool> UpdateAccount(Account account, int id, int parameter)
        {
            try
            {
                var accountFinding = await GetById(id);
                if ( accountFinding == null)
                {
                    return false;
                }
                if (parameter == 0)
                {
                    _mapper.Map(account, accountFinding);
                    _contextDB.Update(accountFinding);
                    return true;
                }
                if (accountFinding.IsBloqued != false && parameter == 1)
                {
                    accountFinding.IsBloqued = false;
                    accountFinding.BloquedTimeUtc = null;
                    _contextDB.Update(accountFinding);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cuenta", ex);
            }
        }

        ///// <summary>
        ///// Elimina una cuenta de forma lógica al establecer el indicador IsBlocked en true.
        ///// </summary>
        ///// <param name="id">ID de la cuenta a eliminar.</param>
        ///// <returns>true si la eliminación es exitosa, false si hay un error.</returns>
        public async Task<bool> DeleteAccountById(int id, int parameter)
        {
            try
            {
                Account accountFinding = await GetById(id);
               if (accountFinding == null)
                {
                    return false;
                }
               if (parameter == 0)
                {
                    accountFinding.IsBloqued = true;
                    accountFinding.BloquedTimeUtc = DateTime.UtcNow;
                    return true;
                }
               if (parameter == 1)
                {
                    _contextDB.Accounts.Remove(accountFinding);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cuenta", ex);
            }
        }
    }
}
