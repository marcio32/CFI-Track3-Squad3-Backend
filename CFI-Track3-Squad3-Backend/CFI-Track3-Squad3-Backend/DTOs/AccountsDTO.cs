using CFI_Track3_Squad3_Backend.Entities;
using System.Reflection.Metadata.Ecma335;

namespace CFI_Track3_Squad3_Backend.DTOs
{
    public class AccountsDTO
    {
        public int Id { get; set; }
        public DateTime DataTime { get; set; }
        public int Money { get; set; }
        public bool IsBlocked { get; set; }
        public int UserId { get; set; } 
    }
}
