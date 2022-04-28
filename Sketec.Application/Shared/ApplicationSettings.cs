namespace Sketec.Application.Shared
{
    public class ApplicationSettings
    {
        public const string Key = "ApplicationSettings";
        public string BaseUrl { get; set; }
        public string ApiUrl { get; set; }
        public string IdentityServerUrl { get; set; }
    }
}
