using CFI_Track3_Squad3_Backend.Entities;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        public Task<List<Role>> GetAllRoles(int parameter);
        public Task<Role> GetRoleById(int id, int parameter);
        public Task<bool> DeleteRoleById(int id, int parameter);
        public Task<bool> UpdateRole(Role role, int id, int paramater);

    }
}
