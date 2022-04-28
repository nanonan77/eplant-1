using IdentityServer4.Validation;

namespace Sketec.IdentityServer.Resources.Oidc
{
    public class AuthorizationConsentRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public string ClientUri { get; set; }
        public string LogoUri { get; set; }
        public ResourceValidationResult ValidatedResources { get; set; }
    }
}
