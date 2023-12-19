using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories
{
    public class UserRepository2 : Repository<User>
    {
        protected readonly ContextDB _contextDB;

        public UserRepository2(ContextDB contextDB) : base(contextDB) 
        {
            _contextDB = contextDB;
        }

        public async Task<List<User>>GetAllUsers2() 
        {
            try
            {
                return await _contextDB.Users.Where(x => x.IsDelete != true).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User?>GetUser2ById(int id) 
        {
            try
            {
                return await _contextDB.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> RegisterUser2(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var user = new User();
                user = userRegisterDTO;
                return await base.Insert(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Insertar usuario.", ex);
            }
        }

        public async Task<bool> UpdateUser2(int id, UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var userFinding = await GetUser2ById(id);
                if (userFinding == null)
                {
                    return false;
                }
                else 
                {
                    var user = new User();
                    user = userRegisterDTO;
                    user.Id = id;
                    user.FirstName = userRegisterDTO.FirstName;
                    user.LastName = userRegisterDTO.LastName;
                    user.Email = userRegisterDTO.Email;
                    var result = await base.Update(user);
                    return result;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cuenta", ex);
            }
        }

        public async Task<bool> DeleteUser2(int id) 
        {
            try
            {
                var user = await GetUser2ById(id);
                user.IsDelete = true;
                return await base.Delete(user);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        internal Task<User> AuthenticateCredentials(AuthenticateDTO authenticateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
