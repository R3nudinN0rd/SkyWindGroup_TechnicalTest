using Microsoft.AspNetCore.Mvc;
using SkyWindGroup_TechnicalTest.Entities.Models.UserModels;
using SkyWindGroup_TechnicalTest.Models.UserModels;
using SkyWindGroup_TechnicalTest.Repository.UserRepository;
using SkyWindGroup_TechnicalTest.Validators.UserValidator;
using System.Collections.Generic;

namespace SkyWindGroup_TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return Ok(_userRepository.GetAllUsersAsync().GetAwaiter().GetResult());   
        }

        [HttpGet("{userId}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"userId"})]
        public ActionResult<UserDTO> GetUserByIdAsync(int userId)
        {
            var user =_userRepository.GetUserByIdAsync(userId).GetAwaiter().GetResult();
            return user == null ? NotFound("User not found!") : Ok(user);
            
        }

        [HttpGet("winners")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public ActionResult<IEnumerable<UserDTO>> GetWinnersForLastDrawAsync()
        {
            var winners = _userRepository.GetWinnersForLastDrawAsync().GetAwaiter().GetResult();
            return winners.Count() == 0 ? NotFound() : Ok(winners);

        }

        [HttpGet("winners/{date}")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] {"date"})]
        public ActionResult<IEnumerable<UserDTO>> GetWinnersByDateAsync(DateTime date)
        {
            return Ok(_userRepository.GetWinnersBySelectedDateAsync(date).GetAwaiter().GetResult());
        }

        [HttpPost]
        public ActionResult AddUser(UserDTO_POST user)
        {
            switch (UserValidator.ValidateUserModel(user)){
                case true:
                    {
                        if(_userRepository.UserExists(user))
                        {
                            return BadRequest("A user with the identification number/email/phonenumber already exists!");
                        }
                        _userRepository.AddUser(user);
                        return Ok("Users added!");
                    }
                case false:
                    {
                        return BadRequest("User properties format incorrect!");
                    }
            } 

        }

        [HttpPut]
        public ActionResult UpdateUser(UserDTO_PUT user)
        {
            switch (UserValidator.ValidateUserModel(user))
            {
                case true:
                    {
                        _userRepository.UpdateUser(user);
                        return Ok("User updated!");
                    }
                case false:
                    {
                        return BadRequest("User properties format incorrect!");
                    }
            }
        }

        [HttpDelete]
        public ActionResult DeleteUser(int userId)
        {
            var user = _userRepository.GetUserByIdAsync(userId).GetAwaiter().GetResult();
            if (user == null)
            {
                return NotFound("User not found!");
            }
            else
            {
                _userRepository.DeleteUser(userId);
                return Ok("User deleted!");
            }
        }

    }
}
