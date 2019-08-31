namespace Tt.App.WebMvc.Configuration
{
    public interface IIdpConfiguration
    {
        string Authority { get; set; }

        string ClientId { get; set; }

        string ClientSecret { get; set; }
    }

    public class IdpConfiguration : IIdpConfiguration
    {
        public string Authority { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}