using SkyWindGroup_TechnicalTest.Entities.Models.DrawHistoryModels;
using SkyWindGroup_TechnicalTest.Entities.Models.LotteryTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.LotteryNumberGenerator
{
    public static class LotteryNumberGenerator
    {
        public static DrawHistoryDTO_NumberGenerated GenerateFinalDTO(DrawHistoryDTO_POST drawHistoryModel, LotteryTypeDTO lotteryModel)
        {
            var r = new Random();
            List<int> extractedNumbers = new List<int>();
            while (lotteryModel.ExtractedNumbers > 0)
            {
                var randomNumber = r.Next(lotteryModel.MinimumValue, lotteryModel.MaximumValue);
                if (!extractedNumbers.Contains(randomNumber))
                {
                    extractedNumbers.Add(randomNumber);
                    lotteryModel.ExtractedNumbers--;
                }
            }

            extractedNumbers.Sort();

            DrawHistoryDTO_NumberGenerated drawHistoryDTO_NumberGenerated = new DrawHistoryDTO_NumberGenerated
            {
                Id = drawHistoryModel.Id,
                DrawDate = DateTime.Now,
                ExtractedNumbers = string.Join(",",extractedNumbers.ConvertAll<string>(n => n.ToString())),
                LotteryTypeId = drawHistoryModel.LotteryTypeId
            };

            return drawHistoryDTO_NumberGenerated;
        }
    }
}
