using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CFI_Track3_Squad3_Backend.Entities
{
    [Table("roles")]

    public class Role
    {

        [Key]
        [Column("role_id")]
        public int Id { get; set; }

        [Required]
        [Column("role_name")]
        public string Name { get; set; }

        [Required]
        [Column("role_description")]
        public string Description { get; set; }

        [Required]
        [Column("role_isBloqued")]
        public bool IsBloqued { get; set; }

        [Column("role_deletedTimeUtc")]
        public DateTime? DeletedTimeUtc { get; set; }

    }
}