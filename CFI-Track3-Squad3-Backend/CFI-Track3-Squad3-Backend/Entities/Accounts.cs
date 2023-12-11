using CFI_Track3_Squad3_Backend.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_Track3_Squad3_Backend.Entities
{
    [Table("Accounts")]
    public class Accounts
    {
        [Column("Account_Id")]
        public int Id { get; set; }
        [Column("account_CreationDate", TypeName = "DATETIME")]
        public DateTime DateTime { get; set; }
        [Column("account_Money", TypeName = "DECIMAL")]
        public decimal Money { get; set; }
        [Column("account_IsBlocked")]
        public bool IsBlocked { get; set; }
        [Key]
        [Column("account_UserId")]
        public int UserId { get; set; }

        public static implicit operator Accounts(AccountsDTO accountsDTO)
        {
            var accounts = new Accounts();
            accountsDTO.UserId = accountsDTO.UserId;
            accountsDTO.DataTime = accountsDTO.DataTime;
            accountsDTO.Id = accountsDTO.Id;
            accountsDTO.Money = accountsDTO.Money;
            accountsDTO.IsBlocked = accountsDTO.IsBlocked;
            return accounts;
        }
    }
}