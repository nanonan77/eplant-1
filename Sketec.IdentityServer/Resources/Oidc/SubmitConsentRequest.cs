namespace Sketec.IdentityServer.Resources.Oidc
{
    public class SubmitConsentRequest
    {
        public string ReturnUrl { get; set; }
        public bool Accept { get; set; }
    }
}
