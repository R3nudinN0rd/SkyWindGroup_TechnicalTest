using System.ComponentModel.DataAnnotations;

namespace SkyWindGroup_TechnicalTest.Entities
{
    public class LotteryType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Total extracted number is required!")]
        public int ExtractedNumbers { get; set; }
        [Required(ErrorMessage = "Minimum number value is required!")]
        public int MinimumValue { get; set; }
        [Required(ErrorMessage = "Maximum number value is required")]
        public int MaximumValue { get; set; }
        public ICollection<DrawHistory> DrawsHistory { get; set; }
        public ICollection<Prize> Prises { get; set; }
    }
}
