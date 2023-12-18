using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User> 
    {
        public Task<List<UserDTO>> GetAllUsers(int parameter);
        public Task<UserDTO> GetUserById(int id, int parameter);
        public Task<bool> DeleteUserById(int id, int parameter);
        public Task<bool> UpdateUser(UserRegisterDTO userRegisterDTO, int id, int parameter);
        public Task<bool> InsertUser(UserRegisterDTO userRegisterDTO);
        
    }
}
