namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para definir operaciones de Repository.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad que se manejará en Repository.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtiene todas las entidades del tipo T.
        /// </summary>
        /// <returns>Una lista de todas las entidades.</returns>
        public Task<List<T>> GetAll();
       
    }
}
