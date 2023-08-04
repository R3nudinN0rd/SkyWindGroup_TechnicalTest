using SkyWindGroup_TechnicalTest.Entities;
using SkyWindGroup_TechnicalTest.Entities.Models.UserModels;
using SkyWindGroup_TechnicalTest.Models.UserModels;

namespace SkyWindGroup_TechnicalTest.Repository.UserRepository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        public Task<IEnumerable<UserDTO>> GetWinnersForLastDrawAsync();
        public Task<IEnumerable<UserDTO>> GetWinnersBySelectedDateAsync(DateTime dateTime);
        public Task<UserDTO> GetUserByIdAsync(int userId);
        public void AddUser(UserDTO_POST user);
        public void UpdateUser(UserDTO_PUT user);
        public void DeleteUser(int userId);
        public bool UserExists(UserDTO_POST user);
    }
}
