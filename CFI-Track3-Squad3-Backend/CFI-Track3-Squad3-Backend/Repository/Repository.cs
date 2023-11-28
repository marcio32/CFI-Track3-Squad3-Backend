using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insert(T id) 
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(T id) 
        {
            throw new NotImplementedException();
        }

    }
}
