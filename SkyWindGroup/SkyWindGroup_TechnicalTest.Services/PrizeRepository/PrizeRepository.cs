using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public class PrizeRepository : IPrizeRepository
    {
        private readonly SkyWindTTContext _context;
        private readonly IMapper _mapper;
        public PrizeRepository(SkyWindTTContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddPrize(PrizeDTO_POST prize)
        {
            try
            {
                _context.Prises.Add(
                    _mapper.Map<Prize>(prize)
                    );
                _context.SaveChanges();
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public void DeletePrize(int prizeId)
        {
            try
            {
                _context.Prises.Remove(
                        _context.Prises.FirstOrDefault(prize => prize.Id == prizeId)
                    );
                _context.SaveChanges();
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public async Task<IEnumerable<PrizeDTO>> GetAllPrisesAsync()
        {
            return _mapper.Map<IEnumerable<PrizeDTO>>(
                await _context.Prises.ToListAsync()
                );
        }

        public async Task<IEnumerable<PrizeDTO>> GetPrisesByLotteryTypeIdAsync(int lotteryTypeId)
        {
            return _mapper.Map<IEnumerable<PrizeDTO>>(
                await _context.Prises.Where(prize => prize.LotteryTypeId == lotteryTypeId).ToListAsync()
                );
        }

        public async Task<PrizeDTO> GetPrizeByIdAsync(int prizeId)
        {
            return _mapper.Map<PrizeDTO>(
                await _context.Prises.FirstOrDefaultAsync(prize => prize.Id == prizeId)
                );
        }

        public void UpdatePrize(PrizeDTO_PUT prize)
        {
            try
            {
                var existingPrize = _context.Prises.FirstOrDefault(p => p.Id == prize.Id);
                if(existingPrize != null) { 
                    _context.Prises.Update(_mapper.Map(prize, existingPrize));
                    _context.SaveChanges();
                }
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }
    }
}
