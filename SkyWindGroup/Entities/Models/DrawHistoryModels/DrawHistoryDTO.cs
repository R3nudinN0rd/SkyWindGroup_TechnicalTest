using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Entities.Models.DrawHistoryModels
{
    public class DrawHistoryDTO
    {
        public int Id { get; set; }
        public DateTime DrawDate { get; set; }
        public string ExtractedNumbers { get; set; }
        public int LotteryTypeId { get; set; }
    }
}
