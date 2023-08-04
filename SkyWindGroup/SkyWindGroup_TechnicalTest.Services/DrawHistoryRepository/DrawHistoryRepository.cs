using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkyWindGroup_TechnicalTest.Context;
using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.DrawHistoryModels;
using SkyWindGroup_TechnicalTest.Entities.Models.LotteryTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWindGroup_TechnicalTest.Services.DrawHistoryRepository
{
    public class DrawHistoryRepository : IDrawHistoryRepository
    {
        private readonly SkyWindTTContext _context;
        private readonly IMapper _mapper;
        public DrawHistoryRepository(SkyWindTTContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddDrawHistory(DrawHistoryDTO_POST drawHistory)
        {
            var lotteryTypeModel = _mapper.Map<LotteryTypeDTO>(_context.LotteryTypes.FirstOrDefault(lotteryType => lotteryType.Id == drawHistory.LotteryTypeId));
            try
            {
                _context.DrawsHistory.Add(
                    _mapper.Map<DrawHistory>(
                            LotteryNumberGenerator.LotteryNumberGenerator.GenerateFinalDTO(drawHistory, lotteryTypeModel)
                        )
                    );
                _context.SaveChanges();
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public void DeleteDrawHistory(int drawHistoryId)
        {
            try
            {
                _context.DrawsHistory.Remove(
                    _context.DrawsHistory.FirstOrDefault(drawHistory => drawHistory.Id == drawHistoryId)
                    );
                _context.SaveChanges();
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public async Task<IEnumerable<DrawHistoryDTO>> GetAllDrawHistoryAsync()
        {
            return _mapper.Map<IEnumerable<DrawHistoryDTO>>(
                await _context.DrawsHistory.ToListAsync()
                );
        }

        public async Task<IEnumerable<DrawHistoryDTO>> GetDrawHistoryByDrawDateIntervalAsync(DateTime date1, DateTime date2)
        {
            return _mapper.Map<IEnumerable<DrawHistoryDTO>>(
                await _context.DrawsHistory.Where(drawHistory => drawHistory.DrawDate >= date1 && drawHistory.DrawDate <= date2).ToListAsync()
                );
        }

        public async Task<DrawHistoryDTO> GetDrawHistoryByIdAsync(int drawHistoryId)
        {
            return _mapper.Map<DrawHistoryDTO>(
                await _context.DrawsHistory.FirstOrDefaultAsync(drawHistory => drawHistory.Id == drawHistoryId)
                );
        }

        public async Task<IEnumerable<DrawHistoryDTO>> GetDrawHistoryByLotteryTypeIdAsync(int lotteryTypeId)
        {
            return _mapper.Map<IEnumerable<DrawHistoryDTO>>(
                await _context.DrawsHistory.Where(drawHistory => drawHistory.LotteryTypeId == lotteryTypeId).ToListAsync()
                );
        }

        public void UpdateDrawHistory(DrawHistoryDTO_PUT drawHistory)
        {
            try
            {
                var existingDrawHistory = _context.DrawsHistory.FirstOrDefault(dh => dh.Id == drawHistory.Id);
                if(existingDrawHistory != null) { 
                    _context.DrawsHistory.Update(_mapper.Map(drawHistory, existingDrawHistory));
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
