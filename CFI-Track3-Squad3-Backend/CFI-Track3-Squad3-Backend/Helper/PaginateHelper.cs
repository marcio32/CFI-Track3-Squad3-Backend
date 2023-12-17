// Clase de utilidad para paginación de datos

using CFI_Track3_Squad3_Backend.DTOs;

namespace CFI_Track3_Squad3_Backend.Helper
{
    public static class PaginateHelper
    {
        /// <summary>
        /// Realiza la paginación de una lista de elementos genéricos.
        /// </summary>
        /// <typeparam name="T">Tipo de los elementos en la lista.</typeparam>
        /// <param name="itemsToPaginate">Lista de elementos a paginar.</param>
        /// <param name="currentPage">Número de la página actual.</param>
        /// <param name="url">URL base para construir enlaces de paginación.</param>
        /// <param name="pageSizeUser">Número de elementos por página especificado por el usuario.</param>
        /// <returns>Objeto PaginateDataDto que contiene la información de paginación.</returns>
        public static PaginateDataDto<T> Paginate<T>(List<T> itemsToPaginate, int currentPage, string url, int pageSizeUser)
        {
            try
            {
                if (itemsToPaginate == null || itemsToPaginate.Count == 0)
                {
                    return null;
                }

                int pageSize = pageSizeUser;
                double totalItems = itemsToPaginate.Count;
                int totalPages = (int)Math.Ceiling(totalItems / pageSize);

                // Realiza la paginación en base a la página actual y el tamaño de la página
                List<T> paginateItems = itemsToPaginate.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                // Construye los enlaces para las páginas previas y siguientes
                string prevUrl = currentPage > 1 ? $"{url}?page={currentPage - 1}" : null;
                string nextUrl = currentPage < totalPages ? $"{url}?page={currentPage + 1}" : null;

                return new PaginateDataDto<T>()
                {
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalItems = (int)totalItems,
                    TotalPages = totalPages,
                    PrevUrl = prevUrl,
                    NextUrl = nextUrl,
                    Items = paginateItems
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
