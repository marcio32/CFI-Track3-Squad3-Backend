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
        [Column("account_CreationDate")]
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
            accounts.UserId = accountsDTO.UserId;
            accounts.DateTime = accountsDTO.DataTime;
            accounts.Id = accountsDTO.Id;
            accounts.Money = accountsDTO.Money;
            accounts.IsBlocked = accountsDTO.IsBlocked;
            return accounts;
        }
    }
}