using Microsoft.Extensions.Logging;
using Sketec.Core.Resources;
using Sketec.Infrastructure.Abstracts;

namespace Sketec.Infrastructure.Services
{
    public class ETaxFtpService : FtpService
    {
        public ETaxFtpService(FtpOptions ftpOptions, ILogger<ETaxFtpService> logger) : base(ftpOptions, logger)
        {

        }

        public override void Connect()
        {
            ftpClient.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
            ftpClient.EncryptionMode = FluentFTP.FtpEncryptionMode.Implicit;
            ftpClient.ValidateAnyCertificate = true;
            base.Connect();
        }
    }
}
