using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Models.PrizeModels
{
    public class PrizeDTO_POST
    {
        public int Id { get; set; }
        public int MatchedNumbers { get; set; }
        public int LotteryPrizeValue { get; set; }
        public int CurrencyId { get; set; }
        public int LotteryTypeId { get; set; }
    }
}
