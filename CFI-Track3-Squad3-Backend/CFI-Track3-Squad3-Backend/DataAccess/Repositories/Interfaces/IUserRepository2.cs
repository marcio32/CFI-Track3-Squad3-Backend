using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository2<T> where T : class
    {
        public Task<List<UserDTO>> GetUsers2();
        public Task<UserDTO> GetUser2ById(int id);
        public Task<bool> RegisterUser2(UserRegisterDTO userRegisterDTO);
        public Task<bool> UpdateUser2(int id, UserRegisterDTO unregisterDTO);
        public Task<bool> DeleteUser2(int id);

    }
}
