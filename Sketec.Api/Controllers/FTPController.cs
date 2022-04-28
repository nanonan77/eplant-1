using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Sketec.Core.Resources;
using Sketec.Infrastructure.Abstracts;
using Sketec.Infrastructure.Services;
using System.Collections.Generic;

namespace Sketec.Api.Controllers
{
    [Route("ftp")]
    [ApiController]
    public class FTPController : Controller
    {
        [HttpGet("sftp-test-connect")]
        public IEnumerable<string> SFtpTestServerConnect()
        {
            var option = new FtpOptions()
            {
                Host = "ftptest.scg.com",
                Port = 22,
                Username = "scgpwcsket01qa",
                Password = "kpw8qbKU"
            };

            var mockLogger = new Mock<ILogger<SftpService>>();
            var mockService = new Mock<SftpService>(option, mockLogger.Object);
            mockService.CallBase = true;
            var service = mockService.Object;
            service.Connect();

            var directory = service.ListDirectory("/");
            service.Dispose();
            return directory;
        }

        [HttpGet("etax-connect")]
        public IEnumerable<string> ETaxConnect()
        {
            var option = new FtpOptions()
            {
                Host = "172.30.190.77",
                Port = 990,
                Username = "uftppa",
                Password = "et@X2018"
            };

            var logger = Mock.Of<ILogger<ETaxFtpService>>();
            var service = new ETaxFtpService(option, logger);
            service.Connect();

            var directory = service.ListDirectory("/");
            service.Dispose();
            return directory;
        }
    }
}
