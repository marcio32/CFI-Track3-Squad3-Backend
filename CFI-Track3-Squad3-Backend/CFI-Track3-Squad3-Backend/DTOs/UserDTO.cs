namespace CFI_Track3_Squad3_Backend.DTOs
{
    /// <summary>
    /// Clase que representa un objeto de transferencia de datos (DTO) para la entidad User.
    /// Contiene propiedades que reflejan los campos relevantes de la entidad User.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Obtiene o establece el primer nombre del usuario.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del usuario.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Obtiene o establece el número de identificación del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección de correo electrónico del usuario.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del rol asociado al usuario.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Obtiene o establece un objeto de transferencia de datos (DTO) para la entidad Role asociada al usuario.
        /// </summary>
        public RoleDTO? RoleDTO { get; set; }
    }
}
