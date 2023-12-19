using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Helper;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_Track3_Squad3_Backend.Entities
{
    [Table("Users")]
    public class User
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

        [Column("IsDelete")]
        public bool IsDelete { get; set; }

        [Column("DeletedTimeUtc")]
        public DateTime? DeletedTimeUtc { get; set; }

        
        [Column("RolId")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }


        public static implicit operator User(UserRegisterDTO userRegisterDTO)
        {
            var user = new User();
            user.Id = userRegisterDTO.Id;
            user.FirstName = userRegisterDTO.FirstName;
            user.LastName = userRegisterDTO.LastName;
            user.Password = PasswordEncryptHelper.EncryptPassword(userRegisterDTO.Password, userRegisterDTO.Email);
            user.Email = userRegisterDTO.Email;
            return user;
        }
    }
}
