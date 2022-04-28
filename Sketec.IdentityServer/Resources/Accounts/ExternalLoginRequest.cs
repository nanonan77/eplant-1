namespace Sketec.IdentityServer.Resources.Accounts
{
    public class ExternalLoginRequest
    {
        public string LoginHint { get; set; }
        public string RedirectUri { get; set; }
    }
}
