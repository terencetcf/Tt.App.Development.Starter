namespace Tt.App.WebMvc.Configuration
{
    public interface IApiConfiguration
    {
        string TtApiUrl { get; set; }
    }

    public class ApiConfiguration : IApiConfiguration
    {
        public string TtApiUrl { get; set; }
    }
}