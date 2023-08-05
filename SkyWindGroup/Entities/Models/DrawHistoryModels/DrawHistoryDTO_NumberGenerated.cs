using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.LotteryNumberGenerator
{
    public  class DrawHistoryDTO_NumberGenerated
    {
        public int Id { get; set; }
        public DateTime DrawDate { get; set; }
        public string ExtractedNumbers { get; set; }
        public int LotteryTypeId { get; set; }
    }
}
