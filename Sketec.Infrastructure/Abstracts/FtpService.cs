using EnsureThat;
using FluentFTP;
using Microsoft.Extensions.Logging;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using Sketec.Core.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Abstracts
{
    public abstract class FtpService : IFtpService, IDisposable
    {
        bool _disposed = false;
        ILogger<FtpService> logger;
        protected FtpOptions options;
        protected FtpClient ftpClient;

        public FtpService(FtpOptions ftpOptions, ILogger<FtpService> logger)
        {
            EnsureArg.IsNotNull(ftpOptions, nameof(ftpOptions));
            options = ftpOptions;
            this.logger = logger;
            ftpClient = new FtpClient(options.Host, options.Port, options.Username, options.Password);
        }

        protected virtual void Dispose(bool disposting)
        {
            if (_disposed)
                return;

            if (disposting)
            {
                ftpClient?.Disconnect();
                ftpClient?.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public virtual void Connect()
        {
            logger.LogInformation(LogEvents.Ftp_Connecting, $"Connecting to FTP : {options.Host}:{options.Port}");

            try
            {
                ftpClient.Connect();
            }
            catch (Exception ex)
            {

                logger.LogError(LogEvents.Ftp_Connected_Exception, ex, $"Exception when try to connect to FTP Service");
                throw;
            }
            logger.LogInformation(LogEvents.Ftp_Connected_Success, "Connecting success");
        }

        public IEnumerable<string> ListDirectory(string path)
        {
            return ftpClient.GetListing(path).Select(s => s.FullName);
        }

        public bool Exists(string path)
        {
            throw new NotImplementedException();
        }

        public byte[] GetFile(string path)
        {
            throw new NotImplementedException();
        }   

        public Task Upload(string path, byte[] file, bool canOverwrite)
        {
            throw new NotImplementedException();
        }

        public Task Upload(string path, Stream file, bool canOverwrite)
        {
            throw new NotImplementedException();
        }
    }
}
