using System.ComponentModel.DataAnnotations;

namespace Tt.App.Contracts
{
    public class Applicant
    {
        public int Id { get; set; }

        public int PersonTitleId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int AddressId { get; set; }
    }
}
