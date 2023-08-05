using System.ComponentModel.DataAnnotations;

namespace SkyWindGroup_TechnicalTest.Entities
{
    public class DrawHistory
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Draw date is required!")]
        public DateTime DrawDate { get; set; }
        [Required(ErrorMessage = "Extracted numbers is required!")]
        public string ExtractedNumbers { get; set; }
        [Required(ErrorMessage = "Lottery type is required!")]
        public int LotteryTypeId { get; set; }
        public LotteryType LotteryType { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
