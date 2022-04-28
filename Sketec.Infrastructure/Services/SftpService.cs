using Microsoft.Extensions.Logging;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using Sketec.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Services
{
    public class WCSftpService : SftpService, IWCSftpService
    {
        public WCSftpService(FtpOptions options, ILogger<SftpService> logger) : base(options, logger)
        {

        }
    }
}
