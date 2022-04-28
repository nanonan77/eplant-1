namespace Sketec.IdentityServer.Resources.Accounts
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginProvider Provider { get; set; }
        public bool Remember { get; set; }
    }

    public enum LoginProvider
    {
        Scg,
        Local
    }
}
