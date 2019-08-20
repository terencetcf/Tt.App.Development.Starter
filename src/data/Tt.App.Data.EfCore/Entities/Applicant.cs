namespace Tt.App.Data.EfCore.Entities
{
    public class Applicant
    {
        public int Id { get; set; }

        public int PersonTitleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int AddressId { get; set; }
    }
}
