using EnsureThat;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Sketec.Core.Exceptions;
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
    public abstract class SftpService : IFtpService, IDisposable
    {
        bool _disposed = false;
        ILogger<SftpService> logger;
        protected FtpOptions options;
        protected SftpClient sftpClient;
        public SftpService(FtpOptions options, ILogger<SftpService> logger)
        {
            this.options = options;
            this.logger = logger;
        }

        public virtual void Connect()
        {
            logger.LogInformation(LogEvents.Sftp_Connecting, $"Connecting to SFTP : {options.Host}:{options.Port}");
            sftpClient = new SftpClient(options.Host, options.Port, options.Username, options.Password);
            try
            {
                sftpClient.Connect();
            }
            catch (Exception ex)
            {

                logger.LogError(LogEvents.Sftp_Connected_Exception, ex, $"Exception when try to connect to SFTP Service");
                throw;
            }
            logger.LogInformation(LogEvents.Sftp_Connected_Success, "Connecting success");
        }

        public ConnectionInfo GetConnectionInfo()
        {
            return sftpClient.ConnectionInfo;
        }

        public IEnumerable<string> ListDirectory(string path)
        {
            if (sftpClient == null)
                throw new InfrastructureException("Please open connection before use.");

            return sftpClient.ListDirectory(path).Select(s => s.FullName);
        }

        protected virtual void Dispose(bool disposting)
        {
            if (_disposed)
                return;

            if (disposting)
            {
                sftpClient?.Disconnect();
                sftpClient?.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public bool Exists(string path)
        {
            EnsureArg.IsNotNullOrWhiteSpace(path, nameof(path));
            if (sftpClient == null)
                throw new InfrastructureException("Please open connection before use.");

            return sftpClient.Exists(path);
        }

        public byte[] GetFile(string path)
        {
            if (!Exists(path))
            {
                return null;
            }

            byte[] downloadBytes = null;

            using (var mem = new MemoryStream())
            {
                sftpClient.DownloadFile(path, mem);
                downloadBytes = mem.ToArray();
            }

            return downloadBytes;
        }

        public Task Upload(string path, byte[] file, bool canOverwrite)
        {
            using (var mem = new MemoryStream(file))
            {
                return Upload(path, mem, canOverwrite);
            }
        }

        public Task Upload(string path, Stream file, bool canOverwrite)
        {
            if (sftpClient == null)
                throw new InfrastructureException("Please open connection before use.");
            EnsureArg.IsNotNullOrWhiteSpace(path);

            sftpClient.UploadFile(file, path, canOverwrite);

            return Task.CompletedTask;
        }
    }
}
