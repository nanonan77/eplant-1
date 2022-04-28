namespace Sketec.Core.Resources.Email
{
    public class EmailSettings
    {
        public const string Key = "EmailSettings";
        public string Smtp { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Environment { get; set; }
    }
}
