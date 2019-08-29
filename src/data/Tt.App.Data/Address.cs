using System;

namespace Tt.App.Data
{
    public class Address
    {
        public Guid Id { get; set; }

        public int AddressStateId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }
    }
}
