using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkyWindGroup_TechnicalTest.Context;
using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.UserModels;
using SkyWindGroup_TechnicalTest.Models.UserModels;
namespace SkyWindGroup_TechnicalTest.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly SkyWindTTContext _context;
        private readonly IMapper _mapper;
        public UserRepository(SkyWindTTContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddUser(UserDTO_POST user)
        {
            if (!UserExists(user))
            { 
                try
                {
                    user.CreatedDate = DateTime.Now;
                    _context.Users.Add(_mapper.Map<User>(user));
                    _context.SaveChanges();        
                }
                catch(SqlException SqlEx)
                {
                    throw SqlEx;
                }
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                _context.Users.Remove(
                    _context.Users.FirstOrDefault(user => user.Id == userId)
                    );
                _context.SaveChanges();
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
             return _mapper.Map<IEnumerable<UserDTO>>(
                 await _context.Users.ToListAsync()
                 );
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            return _mapper.Map<UserDTO>(
                    await _context.Users.FirstOrDefaultAsync(user => user.Id == userId)
                );
        }

        public async Task<IEnumerable<UserDTO>> GetWinnersBySelectedDateAsync(DateTime dateTime)
        {
            return _mapper.Map<IEnumerable<UserDTO>>(
                       await (from user in _context.Users
                             join ticket in _context.Tickets on user.Id equals ticket.UserId
                             join drawHistory in _context.DrawsHistory on ticket.DrawHistoryId equals drawHistory.Id
                             where drawHistory.ExtractedNumbers.Contains(ticket.NumbersCombination) && drawHistory.DrawDate == dateTime
                             select user).ToListAsync()
                    );
        }

        public async Task<IEnumerable<UserDTO>> GetWinnersForLastDrawAsync()
        {
            var latestDrawDate = _context.DrawsHistory
                .OrderByDescending(dh => dh.DrawDate)
                .Select(dh => dh.DrawDate)
                .FirstOrDefault();

            return _mapper.Map<IEnumerable<UserDTO>>(
                        await (from user in _context.Users
                               join ticket in _context.Tickets on user.Id equals ticket.UserId
                               join drawHistory in _context.DrawsHistory on ticket.DrawHistoryId equals drawHistory.Id
                               where ticket.NumbersCombination.Contains(drawHistory.ExtractedNumbers)
                                    && drawHistory.DrawDate == latestDrawDate
                               select user).ToListAsync()
                    );
        }

        public void UpdateUser(UserDTO_PUT user)
        {
            try
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser != null) { 
                    _context.Users.Update(_mapper.Map(user, existingUser));
                    _context.SaveChanges();
                }
            }
            catch(SqlException SqlEx)
            {
                throw SqlEx;
            }
        }

        public bool UserExists(UserDTO_POST user)
        {
            return _context.Users.FirstOrDefault(u => u.IdentificationNumber == user.IdentificationNumber || u.Email == user.Email || u.PhoneNumber == user.PhoneNumber) != null;
        }
    }
}
