using System.ComponentModel.DataAnnotations;

namespace SkyWindGroup_TechnicalTest.Entities
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Currency indicator is required!")]
        public string CurrencyIndicator { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Prize> Prises { get; set; }
    }
}
