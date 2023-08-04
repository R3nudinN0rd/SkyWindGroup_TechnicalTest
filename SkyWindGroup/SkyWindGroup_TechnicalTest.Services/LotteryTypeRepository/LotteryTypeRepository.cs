using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkyWindGroup_TechnicalTest.Context;
using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.LotteryTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Services.LotteryTypeRepository
{
    public class LotteryTypeRepository : ILotteryTypeRepository
    {
        private readonly SkyWindTTContext _context;
        private readonly IMapper _mapper;
        public LotteryTypeRepository(SkyWindTTContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddLotteryType(LotteryTypeDTO_POST lotteryType)
        {
            try
            {
                _context.LotteryTypes.Add(
                    _mapper.Map<LotteryType>(lotteryType)
                    );
                _context.SaveChanges();
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public void DeleteLotteryType(int lotteryTypeId)
        {
            try
            {
                _context.LotteryTypes.Remove(
                    _context.LotteryTypes.FirstOrDefault(lotteryType => lotteryType.Id == lotteryTypeId)
                    );
                _context.SaveChanges();
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public async Task<LotteryTypeDTO> GetLotteryTypeByIdAsync(int lotteryTypeId)
        {
            return _mapper.Map<LotteryTypeDTO>(
                await _context.LotteryTypes.FirstOrDefaultAsync(lotteryType => lotteryType.Id == lotteryTypeId)
                );
        }

        public async Task<IEnumerable<LotteryTypeDTO>> GetLotteryTypesAsync()
        {
            return _mapper.Map<IEnumerable<LotteryTypeDTO>>(
                await _context.LotteryTypes.ToListAsync()
                );
        }

        public void UpdateLotteryType(LotteryTypeDTO_PUT lotteryType)
        {
            try
            {
                var existingLotteryType = _context.LotteryTypes.FirstOrDefault(lt => lt.Id == lotteryType.Id);
                if (existingLotteryType != null)
                {
                    _context.LotteryTypes.Update(_mapper.Map(lotteryType, existingLotteryType));
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
