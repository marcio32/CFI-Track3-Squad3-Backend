namespace CFI_Track3_Squad3_Backend.Repository
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
    }
}
