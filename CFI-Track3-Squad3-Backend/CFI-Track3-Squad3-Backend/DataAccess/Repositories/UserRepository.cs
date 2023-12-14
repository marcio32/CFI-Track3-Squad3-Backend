using AutoMapper;
using CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces;
using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;
using CFI_Track3_Squad3_Backend.Helper;
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(ContextDB contextDB, IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }

        public virtual async Task<List<UserDTO>> GetAllUsers(int parameter) 
        {
            try
            {
                if (parameter == 0) 
                {
                    List<User> users = await _contextDB.Users.Include(user => user.Role).Where(user => user.IsDelete != true).ToListAsync();
                    return _mapper.Map<List<UserDTO>>(users);
                }
                else if (parameter == 1) 
                {
                    List<User> users = await _contextDB.Users.Include(user => user.Role).ToListAsync();
                    return _mapper.Map<List<UserDTO>>(users);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserDTO> GetUserById(int id, int parameter) 
        {
            try
            {
                User user = await _contextDB.Users.Include(x => x.Role).Where(x => x.Id == id).FirstOrDefaultAsync();
                
                if (user == null)
                {
                    return null;
                }

                if (user.IsDelete != true && parameter == 0)
                {
                    return _mapper.Map<UserDTO>(user);
                }
                if (parameter == 1)
                {
                    return _mapper.Map<UserDTO>(user);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual async Task<bool> InsertUser(UserRegisterDTO userRegisterDTO) 
        {
            try
            {
                var user = _mapper.Map<User>(userRegisterDTO);
                var response = await base.Insert(user);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(UserRegisterDTO userRegisterDTO, int id,int parameter) 
        {
            try
            {
                var userFinding = await GetById(id);
                if (userFinding == null) 
                {
                    return false;
                }
                if (parameter == 0) 
                {
                    var user = _mapper.Map<User>(userRegisterDTO);
                    _mapper.Map(user, userFinding);
                    _contextDB.Update(userFinding);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserById(int id,int parameter) 
        {
            try
            {
                User userFinding = await base.GetById(id);
                if (userFinding == null)
                {
                    return false;
                }
                if(parameter == 0) 
                {
                    userFinding.IsDelete = true;
                    userFinding.DeletedTimeUtc = DateTime.UtcNow;
                    _contextDB.Update(userFinding);
                    return true;
                }
                if (parameter == 1)
                {
                    _contextDB.Users.Remove(userFinding);
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public async Task<User?> AuthenticateCredentials(AuthenticateDTO authenticateDTO) 
        {
            try
            {
                return await _contextDB.Users.Include(user => user.Role).SingleOrDefaultAsync
                    (user => user.Email == authenticateDTO.Email && user.Password == PasswordEncryptHelper.EncryptPassword(authenticateDTO.Password, authenticateDTO.Email));
            }
            catch (Exception ex)
            {

                return null;
            }
        }

    }
}
