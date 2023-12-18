namespace CFI_Track3_Squad3_Backend.DTOs
{
    /// <summary>
    /// Clase que representa un objeto de transferencia de datos (DTO) para la paginación de resultados.
    /// Contiene propiedades que describen la información de paginación y una lista de elementos.
    /// </summary>
    /// <typeparam name="T">Tipo de elemento contenido en la lista.</typeparam>
    public class PaginateDataDto<T>
    {
        /// <summary>
        /// Obtiene o establece el número de página actual.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Obtiene o establece el tamaño de la página (número de elementos por página).
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Obtiene o establece el número total de páginas disponibles.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Obtiene o establece el número total de elementos en la lista.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Obtiene o establece la URL de la página anterior.
        /// </summary>
        public string PrevUrl { get; set; }

        /// <summary>
        /// Obtiene o establece la URL de la página siguiente.
        /// </summary>
        public string NextUrl { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de elementos paginados.
        /// </summary>
        public List<T> Items { get; set; }
    }
}
