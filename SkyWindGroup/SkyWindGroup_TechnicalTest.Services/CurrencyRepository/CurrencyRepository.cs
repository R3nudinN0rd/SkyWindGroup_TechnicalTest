using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkyWindGroup_TechnicalTest.Context;
using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.CurrencyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Services.CurrencyRepository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly SkyWindTTContext _context;
        private readonly IMapper _mapper;
        public CurrencyRepository(SkyWindTTContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddCurrency(CurrencyDTO_POST currency)
        {
            try
            {
                _context.Currencies.Add(
                    _mapper.Map<Currency>(currency)
                    );
                _context.SaveChanges();
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public void DeleteCurrency(int currencyId)
        {
            try
            {
                _context.Currencies.Remove(
                        _context.Currencies.FirstOrDefault(currency => currency.Id == currencyId)
                    );
                _context.SaveChanges();
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public async Task<IEnumerable<CurrencyDTO>> GetAllCurrencyAsync()
        {
            return _mapper.Map<IEnumerable<CurrencyDTO>>(
                await _context.Currencies.ToListAsync()
                );
        }

        public async Task<CurrencyDTO> GetCurrencyByIdAsync(int currencyId)
        {
            return _mapper.Map<CurrencyDTO>(
                await _context.Currencies.FirstOrDefaultAsync(currency => currency.Id == currencyId)
                );
        }

        public void UpdateCurrency(CurrencyDTO_PUT currency)
        {
            try
            {
                var existingCurrency = _context.Currencies.FirstOrDefault(c => c.Id == currency.Id);
                if(existingCurrency != null)
                {
                    _context.Currencies.Update(_mapper.Map(currency,existingCurrency));
                    _context.SaveChanges();
                }
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
        }
    }
}
