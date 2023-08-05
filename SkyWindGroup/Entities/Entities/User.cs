using System.ComponentModel.DataAnnotations;

namespace SkyWindGroup_TechnicalTest.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "Phone number is required!")]
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "Birth date is required!")]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Verification indicator is required!")]
        public bool EmailVerified { get; set; }
        [Required(ErrorMessage = "Eligibility indicator is required!")]
        public bool BannedAccount { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
