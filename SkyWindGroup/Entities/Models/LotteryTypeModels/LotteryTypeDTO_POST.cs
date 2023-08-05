using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Models.LotteryTypeModels
{
    public class LotteryTypeDTO_POST
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ExtractedNumbers { get; set; }
        public int MinimumValue { get; set; }
        public int MaximumValue { get; set; }
    }
}
