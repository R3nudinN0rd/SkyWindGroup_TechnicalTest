using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.DrawHistoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Services.DrawHistoryRepository
{
    public interface IDrawHistoryRepository
    {
        public Task<IEnumerable<DrawHistoryDTO>> GetAllDrawHistoryAsync();
        public Task<IEnumerable<DrawHistoryDTO>> GetDrawHistoryByLotteryTypeIdAsync(int lotteryTypeId);
        public Task<IEnumerable<DrawHistoryDTO>> GetDrawHistoryByDrawDateIntervalAsync(DateTime date1,  DateTime date2);
        public Task<DrawHistoryDTO> GetDrawHistoryByIdAsync(int drawHistoryId);
        public void AddDrawHistory(DrawHistoryDTO_POST drawHistory);
        public void UpdateDrawHistory(DrawHistoryDTO_PUT drawHistory);
        public void DeleteDrawHistory(int drawHistoryId);
    }
}
