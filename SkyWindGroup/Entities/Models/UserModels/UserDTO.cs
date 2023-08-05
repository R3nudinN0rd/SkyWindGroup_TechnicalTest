using SkyWindGroup_TechnicalTest.Entities;
using System.ComponentModel.DataAnnotations;

namespace SkyWindGroup_TechnicalTest.Models.UserModels
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool EmailVerified { get; set; }
        public bool BannedAccount { get; set; }
    }
}
