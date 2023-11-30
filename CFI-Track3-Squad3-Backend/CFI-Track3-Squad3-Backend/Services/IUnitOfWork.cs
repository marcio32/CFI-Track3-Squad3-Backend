namespace CFI_Track3_Squad3_Backend.Services
{
    public interface IUnitOfWork
    {
        public Task<int> Complete();
    }
}
