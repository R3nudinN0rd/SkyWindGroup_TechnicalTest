using System.ComponentModel.DataAnnotations;

namespace SkyWindGroup_TechnicalTest.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Numbers combination is required!")]
        public string NumbersCombination { get; set; }
        [Required(ErrorMessage = "Bought date is required!")]
        public DateTime BoughtDate { get; set; }
        [Required(ErrorMessage = "Played indicator is required!")]
        public bool PlayedTicket { get; set; }
        [Required(ErrorMessage = "Ticket value is required!")]
        public int TicketValue { get; set; }
        [Required(ErrorMessage = "Draw history is required!")]
        public int DrawHistoryId { get; set; }
        public DrawHistory DrawHistory { get; set; }
        [Required(ErrorMessage = "Currency is required!")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        [Required(ErrorMessage = "User is required!")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
