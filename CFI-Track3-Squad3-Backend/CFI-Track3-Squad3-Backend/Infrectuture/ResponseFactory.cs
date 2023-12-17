// Clase para fabricar respuestas de la API, ya sea exitosas o con errores

using Microsoft.AspNetCore.Mvc;

namespace CFI_Track3_Squad3_Backend.Infrectuture
{
    public class ResponseFactory
    {
        // Método para crear una respuesta exitosa
        public static IActionResult CreateSuccessResponse(int statusCode, object? data)
        {
            var response = new ApiSuccessResponse()
            {
                Status = statusCode,
                Data = data
            };

            return new ObjectResult(response)
            {
                StatusCode = statusCode,
            };
        }

        // Método para crear una respuesta con errores
        public static IActionResult CreateErrorResponse(int statusCode, params string[] errors)
        {
            var response = new ApiErrorResponse()
            {
                Status = statusCode,
                Error = new List<ApiErrorResponse.ResponseError>()
            };

            foreach (var error in errors)
            {
                response.Error.Add(new ApiErrorResponse.ResponseError() { Error = error });
            };

            return new ObjectResult(response)
            {
                StatusCode = statusCode,
            };
        }
    }
}
