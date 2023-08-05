
namespace SkyWindGroup_TechnicalTest.Entities.Models.UserModels
{
    public class UserDTO_PUT
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool EmailVerified { get; set; }
        public bool BannedAccount { get; set; }
    }
}
