namespace CFI_Track3_Squad3_Backend.DTOs
{
    /// <summary>
    /// Clase que representa un objeto de transferencia de datos (DTO) para autenticación.
    /// Contiene propiedades que representan las credenciales de usuario para iniciar sesión.
    /// </summary>
    public class AuthenticateDTO
    {
        /// <summary>
        /// Obtiene o establece la dirección de correo electrónico asociada a las credenciales.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña asociada a las credenciales.
        /// </summary>
        public string Password { get; set; }
    }
}
