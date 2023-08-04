using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.LotteryTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Services.LotteryTypeRepository
{
    public interface ILotteryTypeRepository
    {
        public Task<IEnumerable<LotteryTypeDTO>> GetLotteryTypesAsync();
        public Task<LotteryTypeDTO> GetLotteryTypeByIdAsync(int lotteryTypeId);
        public void AddLotteryType(LotteryTypeDTO_POST lotteryType);
        public void UpdateLotteryType(LotteryTypeDTO_PUT lotteryType);
        public void DeleteLotteryType(int lotteryTypeId);
    }
}
