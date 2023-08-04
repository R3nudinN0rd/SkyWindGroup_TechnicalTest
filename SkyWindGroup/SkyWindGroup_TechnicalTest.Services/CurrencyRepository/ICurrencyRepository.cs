using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.CurrencyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Services.CurrencyRepository
{
    public interface ICurrencyRepository
    {
        public Task<IEnumerable<CurrencyDTO>> GetAllCurrencyAsync();
        public Task<CurrencyDTO> GetCurrencyByIdAsync(int currencyId);
        public void AddCurrency(CurrencyDTO_POST currency);
        public void UpdateCurrency(CurrencyDTO_PUT currency);
        public void DeleteCurrency(int currencyId);
    }
}
