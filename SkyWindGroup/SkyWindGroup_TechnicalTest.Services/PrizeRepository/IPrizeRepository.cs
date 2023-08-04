using SkyWindGroup_TechnicalTest.Context;
using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.PrizeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Services.PrizeRepository
{
    public interface IPrizeRepository
    {
        public Task<IEnumerable<PrizeDTO>> GetAllPrisesAsync();
        public Task<IEnumerable<PrizeDTO>> GetPrisesByLotteryTypeIdAsync(int lotteryTypeId);
        public Task<PrizeDTO> GetPrizeByIdAsync(int prizeId);
        public void AddPrize(PrizeDTO_POST prize);
        public void UpdatePrize(PrizeDTO_PUT prize);
        public void DeletePrize(int prizeId);
    }
}
