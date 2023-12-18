namespace CFI_Track3_Squad3_Backend.DTOs
{
    /// <summary>
    /// Clase que representa un objeto de transferencia de datos (DTO) para la entidad Role.
    /// Contiene propiedades que reflejan los campos relevantes de la entidad Role.
    /// </summary>
    public class RoleDTO
    {
        /// <summary>
        /// Obtiene o establece el nombre del rol.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción asociada al rol.
        /// </summary>
        public string Description { get; set; }
    }
}
