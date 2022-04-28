using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using Sketec.Core.Interfaces;
using Sketec.FileReader.Utils;
using Sketec.Infrastructure.Interfaces;

namespace Sketec.FileWriter.Textfile
{
    public class ExcelService
    {
        public ExcelService()
        {
        }

        public void Write(List<ITextModel> modelList, string fileName)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add(DateTime.Now.ToString("sheet1"));

                var template = modelList.First().PropertyList;
                for (int i = 1; i <= template.Count; i++)
                {
                    workSheet.Cells[1, i].Value = template[i - 1];
                }

                int recordIndex = 2;
                foreach (var model in modelList)
                {
                    for (int i = 1; i <= model.PropertyList.Count; i++)
                    {
                        System.Reflection.PropertyInfo pi = model.GetType().GetProperty(model.PropertyList[i - 1]);
                        workSheet.Cells[recordIndex, i].Value = (String)pi.GetValue(model, null) ?? "";
                    }

                    recordIndex++;
                }

                FileStream objFileStrm = File.Create(fileName);
                objFileStrm.Close();

                File.WriteAllBytes(fileName, excel.GetAsByteArray());
                excel.Dispose();
            }
        }

        public List<T> Read<T>(FileStream stream, bool skipHeader) where T : ITextModel, new()
        {
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
                int colCount = worksheet.Dimension.End.Column; //get Column Count
                int rowCount = worksheet.Dimension.End.Row; //get row count

                var list = new List<T>();

                var r = skipHeader ? 2 : 1;

                for (int row = r; row <= rowCount; row++)
                {
                    T model = new T();

                    for (int i = 1; i <= model.PropertyList.Count; i++)
                    {
                        System.Reflection.PropertyInfo pi = model.GetType().GetProperty(model.PropertyList[i - 1]);

                        var val = worksheet.Cells[row, i].Value?.ToString().Trim();

                        pi.SetValue(model, val, null);
                    }

                    list.Add(model);
                }

                return list;
            }
        }
    }


    public class TextFileManager
    {
        //private readonly IWCRepository<BaseLineRequest> _baseLinRepository;
        //private readonly IWCRepository<WhtRequest> _whtRepository;
        //private readonly IWCRepository<RpaRequest> _rpaRepository;
        //private readonly IWCRepository<RpaArRequest> _rpaArRepository;
        //private readonly IWCRepository<WhtResponse> _whtResponseRepository;
        //private readonly IWCRepository<PostClearingRequestHeader> _postClearingRequestRepository;
        //private readonly IWCRepository<PostClearingResponse> _postClearingResponseRepository;
        //private readonly IWCRepository<RpaResponse> _rpaResponseRepository;

        private readonly IHostingEnvironment _env;
        private readonly TextFileWriter _textFileWriter;
        private readonly IWCUnitOfWork _uow;
        private readonly ISftpService _sftpService;
        private readonly IWCAzureBlobStorageService _azureBlobStorageService;
        private readonly IWCQueryRepository _queryRepo;
        private readonly ExcelService _excelService;

        private static string WHT_OUTBOUND = "/Interface/Outbound/WHT";
        private static string WHT_INBOUND = "/Interface/Inbound/WHT";
        private static string POST_CLEAR_OUTBOUND = "/Interface/Outbound/PostClear";
        private static string POST_CLEAR_INBOUND = "/Interface/Inbound/PostClear";
        private static string BASELINE_OUTBOUND = "/Interface/Outbound/UpdateCusdue";
        private static string RPA_OUTBOUND = "/RPA_MatchingAR/Outbound";

        private static List<string> RPA_INBOUND = new List<string>()
        {
            "/RPA_MatchingAR/Inbound/CIP/Confirmlist",
            "/RPA_MatchingAR/Inbound/FC/Confirmlist",
            "/RPA_MatchingAR/Inbound/PP/Confirmlist",
        };

        private static List<string> RPA_PDF_INBOUND = new List<string>()
        {
            "/RPA_MatchingAR/Inbound/CIP/Statement",
            "/RPA_MatchingAR/Inbound/FC/Statement",
            "/RPA_MatchingAR/Inbound/PP/Statement",
        };

        private static string LOCAL_WHT_OUTBOUND = "WHT_OUTBOUND";
        private static string LOCAL_WHT_INBOUND = "WHT_INBOUND";
        private static string LOCAL_POST_CLEAR_OUTBOUND = "POST_CLEAR_OUTBOUND";
        private static string LOCAL_POST_CLEAR_INBOUND = "POST_CLEAR_INBOUND";
        private static string LOCAL_BASELINE_OUTBOUND = "LOCAL_BASELINE_OUTBOUND";
        private static string LOCAL_RPA_OUTBOUND = "LOCAL_RPA_OUTBOUND";
        private static string LOCAL_RPA_INBOUND = "LOCAL_RPA_INBOUND";
        private static string LOCAL_RPA_PDF_INBOUND = "LOCAL_RPA_PDF_INBOUND";


        private readonly string _whFolder;
        private readonly string _whFolderArchive;
        private readonly string _whFolderInbound;
        private readonly string _postClearingFolder;
        private readonly string _postClearingFolderArchive;
        private readonly string _postClearingInbound;
        private readonly string _baseLineFolder;
        private readonly string _baseLineFolderArchive;
        private readonly string _rpaFolder;
        private readonly string _rpaInboundFolder;
        private readonly string _rpaPdfInboundFolder;
        private readonly string _rpaFolderArchive;
        private string _webrootFolder;


        //public TextFileManager(IWCRepository<BaseLineRequest> baseLinRepository,
        //    IWCRepository<WhtRequest> whtRepository,
        //    IWCRepository<WhtResponse> whtResponseRepository,
        //    IWCRepository<PostClearingRequestHeader> postClearingRequestRepository,
        //    IWCRepository<PostClearingResponse> postClearingResponseRepository,
        //    IWCRepository<RpaRequest> rpaRepository,
        //    IWCRepository<RpaArRequest> rpaArRepository,
        //    IWCRepository<RpaResponse> rpaResponseRepository,
        //    IHostingEnvironment env,
        //    TextFileWriter textFileWriter,
        //    IWCUnitOfWork uow,
        //    ISftpService sftpService,
        //    IWCAzureBlobStorageService azureBlobStorageService,
        //    IWCQueryRepository queryRepo,
        //    ExcelService excelService)
        //{
        //    _baseLinRepository = baseLinRepository;
        //    _whtRepository = whtRepository;
        //    _whtResponseRepository = whtResponseRepository;
        //    _postClearingRequestRepository = postClearingRequestRepository;
        //    _postClearingResponseRepository = postClearingResponseRepository;
        //    _rpaRepository = rpaRepository;
        //    _rpaArRepository = rpaArRepository;
        //    _rpaResponseRepository = rpaResponseRepository;
        //    _env = env;
        //    _textFileWriter = textFileWriter;
        //    _uow = uow;
        //    _sftpService = sftpService;
        //    _azureBlobStorageService = azureBlobStorageService;
        //    _queryRepo = queryRepo;
        //    _excelService = excelService;

        //    if (string.IsNullOrWhiteSpace(_env.WebRootPath))
        //    {
        //        _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        //    }

        //    _webrootFolder = _env.WebRootPath;

        //    _whFolder = Path.Combine(_webrootFolder, LOCAL_WHT_OUTBOUND);
        //    _whFolderArchive = Path.Combine(_webrootFolder, LOCAL_WHT_OUTBOUND);
        //    _whFolderInbound = Path.Combine(_webrootFolder, LOCAL_WHT_INBOUND);
        //    _postClearingFolder = Path.Combine(_webrootFolder, LOCAL_POST_CLEAR_OUTBOUND);
        //    _postClearingFolderArchive = Path.Combine(_webrootFolder, LOCAL_POST_CLEAR_OUTBOUND);
        //    _postClearingInbound = Path.Combine(_webrootFolder, LOCAL_POST_CLEAR_INBOUND);
        //    _baseLineFolder = Path.Combine(_webrootFolder, LOCAL_BASELINE_OUTBOUND);
        //    _baseLineFolderArchive = Path.Combine(_webrootFolder, LOCAL_BASELINE_OUTBOUND);
        //    _rpaFolder = Path.Combine(_webrootFolder, LOCAL_RPA_OUTBOUND);
        //    _rpaInboundFolder = Path.Combine(_webrootFolder, LOCAL_RPA_INBOUND);
        //    _rpaPdfInboundFolder = Path.Combine(_webrootFolder, LOCAL_RPA_PDF_INBOUND);

        //    CreateFolder();
        //}

        private void CreateFolder()
        {
            if (!Directory.Exists(_whFolder))
            {
                Directory.CreateDirectory(_whFolder);
            }

            if (!Directory.Exists(_whFolderArchive))
            {
                Directory.CreateDirectory(_whFolderArchive);
            }

            if (!Directory.Exists(_whFolderInbound))
            {
                Directory.CreateDirectory(_whFolderInbound);
            }

            if (!Directory.Exists(_postClearingFolder))
            {
                Directory.CreateDirectory(_postClearingFolder);
            }

            if (!Directory.Exists(_postClearingFolderArchive))
            {
                Directory.CreateDirectory(_postClearingFolderArchive);
            }

            if (!Directory.Exists(_postClearingInbound))
            {
                Directory.CreateDirectory(_postClearingInbound);
            }

            if (!Directory.Exists(_postClearingFolderArchive))
            {
                Directory.CreateDirectory(_postClearingFolderArchive);
            }

            if (!Directory.Exists(_baseLineFolder))
            {
                Directory.CreateDirectory(_baseLineFolder);
            }

            if (!Directory.Exists(_rpaFolder))
            {
                Directory.CreateDirectory(_rpaFolder);
            }

            if (!Directory.Exists(_rpaInboundFolder))
            {
                Directory.CreateDirectory(_rpaInboundFolder);
            }

            if (!Directory.Exists(_rpaPdfInboundFolder))
            {
                Directory.CreateDirectory(_rpaPdfInboundFolder);
            }
        }


    }


    public class TextFileWriter
    {
        public async Task<bool> WriteFile(List<string> items, string fileName)
        {
            try
            {
                using (StreamWriter streamWriter = File.CreateText(fileName))
                {
                    foreach (var item in items)
                    {
                        await streamWriter.WriteLineAsync(item);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }

    public class SftpConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public interface ISftpService
    {
        IEnumerable<SftpFile> ListAllFiles(string remoteDirectory = ".");
        void UploadFile(string localFilePath, string remoteFilePath);
        void DownloadFile(string remoteFilePath, string localFilePath);
        void DeleteFile(string remoteFilePath);
    }

    public class SftpService : ISftpService
    {
        private readonly ILogger<SftpService> _logger;
        private readonly SftpConfig _config;

        public SftpService(ILogger<SftpService> logger, IOptions<SftpConfig> sftpConfig)
        {
            _logger = logger;
            _config = sftpConfig.Value;
        }

        public IEnumerable<SftpFile> ListAllFiles(string remoteDirectory = ".")
        {
            using var client = new SftpClient(_config.Host, _config.Port == 0 ? 22 : _config.Port, _config.UserName,
                _config.Password);
            try
            {
                client.Connect();
                return client.ListDirectory(remoteDirectory);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed in listing files under [{remoteDirectory}]");
                return null;
            }
            finally
            {
                client.Disconnect();
            }
        }

        public void UploadFile(string localFilePath, string remoteFilePath)
        {
            using var client = new SftpClient(_config.Host, _config.Port == 0 ? 22 : _config.Port, _config.UserName,
                _config.Password);
            try
            {
                client.Connect();
                using var s = File.OpenRead(localFilePath);
                client.UploadFile(s, remoteFilePath);
                _logger.LogInformation($"Finished uploading file [{localFilePath}] to [{remoteFilePath}]");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed in uploading file [{localFilePath}] to [{remoteFilePath}]");
            }
            finally
            {
                client.Disconnect();
            }
        }

        public void DownloadFile(string remoteFilePath, string localFilePath)
        {
            using var client = new SftpClient(_config.Host, _config.Port == 0 ? 22 : _config.Port, _config.UserName,
                _config.Password) {OperationTimeout = TimeSpan.FromMinutes(1)};
            try
            {
                client.Connect();
                using var s = File.Create(localFilePath);
                client.DownloadFile(remoteFilePath, s);
                _logger.LogInformation($"Finished downloading file [{localFilePath}] from [{remoteFilePath}]");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed in downloading file [{localFilePath}] from [{remoteFilePath}]");
            }
            finally
            {
                client.Disconnect();
            }
        }

        public void DeleteFile(string remoteFilePath)
        {
            using var client = new SftpClient(_config.Host, _config.Port == 0 ? 22 : _config.Port, _config.UserName,
                _config.Password);
            try
            {
                client.Connect();
                client.DeleteFile(remoteFilePath);
                _logger.LogInformation($"File [{remoteFilePath}] deleted.");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed in deleting file [{remoteFilePath}]");
            }
            finally
            {
                client.Disconnect();
            }
        }
    }
}