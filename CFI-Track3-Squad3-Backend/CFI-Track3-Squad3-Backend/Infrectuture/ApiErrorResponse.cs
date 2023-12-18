// Clase para representar una respuesta de error de la API

namespace CFI_Track3_Squad3_Backend.Infrectuture
{
    public class ApiErrorResponse
    {
        public int Status { get; set; }
        public List<ResponseError> Error { get; set; }

        /// <summary>
        /// Clase interna para representar un error en la respuesta.
        /// </summary>
        public class ResponseError
        {
            public string? Error { get; set; }
        }
    }
}
