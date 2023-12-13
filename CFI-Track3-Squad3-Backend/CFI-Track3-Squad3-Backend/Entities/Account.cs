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
        [Column("Account_Id")]
        public int Id { get; set; }
        [Column("account_CreationDate", TypeName = "DATETIME")]
        public DateTime DateTime { get; set; }
        [Column("account_Money", TypeName = "DECIMAL")]
        public decimal Money { get; set; }
        [Column("account_IsBlocked")]
        public bool IsBlocked { get; set; }
        
        [Column("account_UserId")]
        public int UserId { get; set; }

        public static implicit operator Account(AccountsDTO accountsDTO)
        {
            var accounts = new Account();
            accountsDTO.UserId = accountsDTO.UserId;
            accountsDTO.DataTime = accountsDTO.DataTime;
            accountsDTO.Id = accountsDTO.Id;
            accountsDTO.Money = accountsDTO.Money;
            accountsDTO.IsBlocked = accountsDTO.IsBlocked;
            return accounts;
        }
    }
}