using System;
using CFI_Track3_Squad3_Backend.Entities;
using System.Reflection.Metadata.Ecma335;

namespace CFI_Track3_Squad3_Backend.DTOs
{
    public class RoleDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTimeUtc { get; set; }
    }
}
