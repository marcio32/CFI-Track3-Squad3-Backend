﻿using CFI_Track3_Squad3_Backend.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_Track3_Squad3_Backend.Entities
{
    [Table("Users")]
    public class Users
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("FirstName", TypeName = "VARCHAR(100)")]
        public string? FirstName { get; set; }
        [Column("LastName", TypeName = "VARCHAR(100)")]
        public string? LastName { get; set; }
        [Column("Password", TypeName = "VARCHAR(100)")]
        public string? Password { get; set; }
        [Column("Email", TypeName = "VARCHAR(100)")]
        public string? Email { get; set; }
        [Column("Points", TypeName = "NUMBER")]
        public int Points { get; set; }
        [Key]
        [Column("RolId")]
        public int RolId { get; set; }
    }
}
