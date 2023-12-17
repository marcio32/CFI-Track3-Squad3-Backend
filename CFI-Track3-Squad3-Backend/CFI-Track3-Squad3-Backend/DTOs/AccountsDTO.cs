using CFI_Track3_Squad3_Backend.Entities;
using System.Reflection.Metadata.Ecma335;

namespace CFI_Track3_Squad3_Backend.DTOs
{
    /// <summary>
    /// Clase que representa un objeto de transferencia de datos (DTO) para la entidad Account.
    /// Contiene propiedades que reflejan los campos relevantes de la entidad Account.
    /// </summary>
    public class AccountsDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador de la cuenta.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora asociada a la cuenta.
        /// </summary>
        public DateTime DataTime { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de dinero en la cuenta.
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si la cuenta está bloqueada.
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del usuario asociado a la cuenta.
        /// </summary>
        public int UserId { get; set; }
    }
}
