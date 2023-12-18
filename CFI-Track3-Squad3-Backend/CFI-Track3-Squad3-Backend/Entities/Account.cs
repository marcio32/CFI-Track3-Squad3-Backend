using CFI_Track3_Squad3_Backend.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_Track3_Squad3_Backend.Entities
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        [Required]
        [Column("Account_Id")]
        public int Id { get; set; }
        [Required]
        [Column("account_CreationDate")]
        public DateTime DateTime { get; set; }
        [Column("account_Money", TypeName = "DECIMAL")]
        public decimal Money { get; set; }
        [Column("account_IsBlocked")]
        public bool IsBloqued { get; set; }
        
        [Column("account_UserId")]
        public int UserId { get; set; }

        [Column("account_bloquedTimeUtc")]
        public DateTime? BloquedTimeUtc {  get; set; }

        public static implicit operator Account(AccountDTO accountsDTO)
        {
            var accounts = new Account();
            accountsDTO.UserId = accountsDTO.UserId;
            accountsDTO.DateTime = accountsDTO.DateTime;
            accountsDTO.Id = accountsDTO.Id;
            accountsDTO.Money = accountsDTO.Money;
            accountsDTO.IsBloqued = accountsDTO.IsBloqued;
            return accounts;
        }
    }
}