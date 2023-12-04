using CFI_Track3_Squad3_Backend.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_Track3_Squad3_Backend.Entites
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

        //descomentar cuando se agrege AccountDTO.

        //public static implicit operator Accounts(UserAccountDTO dto) 
        //{
        //    var account = new Accounts();
        //    account.Id = dto.Id;
        //    account.DateTime = dto.DateTime;
        //    account.Money = dto.Money;
        //    account.IsBlocked = dto.IsBlocked;
        //    return account;
        //}




    }

}