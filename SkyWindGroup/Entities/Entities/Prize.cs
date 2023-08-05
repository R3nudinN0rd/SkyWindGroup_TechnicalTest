using System.ComponentModel.DataAnnotations;

namespace SkyWindGroup_TechnicalTest.Entities
{
    public class Prize
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Matching numbers is required!")]
        public int MatchedNumbers { get; set; }
        [Required(ErrorMessage = "Lottery prize value is required!")]
        public int LotteryPrizeValue { get; set; }
        [Required(ErrorMessage = "Currency indicator is required!")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        [Required(ErrorMessage = "Lottery type is required!")]
        public int LotteryTypeId { get; set; }
        public LotteryType LotteryType { get; set;}
    }
}
