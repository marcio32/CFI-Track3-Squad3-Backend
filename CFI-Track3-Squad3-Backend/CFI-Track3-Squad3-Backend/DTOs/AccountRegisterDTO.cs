namespace CFI_Track3_Squad3_Backend.DTOs
{
    public class AccountRegisterDTO
    {
        public int Id {  get; set; }
        public DateTime DateTime { get; set; }
        public int Money { get; set; }
        public bool IsBloqued {  get; set; }
        public int UserId { get; set; }

    }
}
