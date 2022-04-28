using AutoMapper;
using EnsureThat;
using Sketec.Application.Filters;
using Sketec.Application.Interfaces;
using Sketec.Application.Utils;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using Sketec.FileWriter.Excels;
using Sketec.FileWriter.Resources;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.Core.Domains.Types;
using Sketec.FileWriter.Pdf;
using System.Globalization;
using Sketec.Application.Interfaces.Management;
using Sketec.Application.Resources.Management.Assumptions;
using System.IO;
using Sketec.Application.Resources.Users;
using Sketec.Core.Resources.Email;
using Sketec.Application.Shared;
using Microsoft.Extensions.Options;

namespace Sketec.Application.Services
{
    public class TestNewRegistService : ApplicationService, ITestNewRegistService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        ISharePointService sharePointService;
        IWCRepository<NewRegist> dataRepo;
        IWCRepository<SubNewRegist> dataSubRepo;
        IWCRepository<NewRegistImagePath> imgRepo;
        IWCRepository<Core.Domains.FileInfo> fileInfoRepo;
        IUserService userService;
        IAssumptionService assService;
        IMasterConfigurationService configService;
        IWCAzureBlobStorageService azureBlobStorageService;
        IFileInfoService fileService;
        IEmailService emailService;
        ApplicationSettings applicationSettings;
        public TestNewRegistService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            ISharePointService sharePointService,
            IWCRepository<NewRegist> dataRepo,
            IWCRepository<SubNewRegist> dataSubRepo,
            IWCRepository<NewRegistImagePath> imgRepo,
            IWCRepository<Core.Domains.FileInfo> fileInfoRepo,
            IWCQueryRepository queryRepo,
            IUserService userService,
            IAssumptionService assService,
            IMasterConfigurationService configService,
            IWCAzureBlobStorageService azureBlobStorageService,
            IFileInfoService fileService,
            IEmailService emailService,
            IOptions<ApplicationSettings> appOptions)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.sharePointService = sharePointService;
            this.queryRepo = queryRepo;
            this.dataRepo = dataRepo;
            this.dataSubRepo = dataSubRepo;
            this.imgRepo = imgRepo;
            this.userService = userService;
            this.assService = assService;
            this.azureBlobStorageService = azureBlobStorageService;
            this.configService = configService;
            this.fileService = fileService;
            this.fileInfoRepo = fileInfoRepo;
            this.emailService = emailService;
            applicationSettings = appOptions.Value;
        }

        public async Task<NewRegistDto> GetNewRegist(Guid newRegisID)
        {

            var spec = new NewRegistSearchByIdSpec(newRegisID).InCludeSubNewRegists();
            var data = await dataRepo.GetBySpecAsync(spec);
            var result = mapper.Map<NewRegistDto>(data);

            var picData = await userService.GetUserData(new UserFilter { Email = result.PIC });
            var user = new UserResultDto();

            if (picData.Any())
            {
                var pic = picData.FirstOrDefault();
                user = pic;
            }

            result.IsCanEdit = SketecUtils.IsCanEdit(result.Team, user.ManagerEmail, user.ReportToEmail2, user.ReportToEmail3, result.PIC, result.Verifier
                                                        , user.Sec_Name, Role, Team, Email, Section, Department, user.Dep_Name);


            var specImg = new NewRegistImagePathSearchByRegistIdSpec(result.RegistId);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);
            result.NewRegistImagePaths = resultImg;

            if (SketecUtils.RoleFilterDataNewRegist().Contains(Role) && result.IsCanEdit == false)
            {
                result = new NewRegistDto();
            }

            return result;
        }

        public async Task<IEnumerable<NewRegistImagePathDto>> GetImage(Guid id)
        {
            var result = await dataRepo.GetByIdAsync(id);
            var specImg = new NewRegistImagePathSearchByRegistIdSpec(result.RegistId);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);
            foreach (var item in resultImg)
            {
                try
                {
                    var fileName = $"{item.Name}.jpg";
                    var path = $"eplantation/NewRegist/{item.SurveyId}/{fileName}";
                    var img = await azureBlobStorageService.Download(path);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.CopyTo(ms);
                        item.Base64 = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return resultImg;
        }

        public async Task UpdateNewRegist(Guid newRegisID, NewRegistUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null)
        {
            Ensure.Any.IsNotNull(request, "NewRegistUpdateRequest");

            var spec = new NewRegistSearchByIdSpec(newRegisID);
            var data = await dataRepo.GetBySpecAsync(spec);

            if (data != null)
            {
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Title)))
                    data.Title = request.Title;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.RegistId)))
                    data.RegistId = request.RegistId;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Status)))
                    data.Status = request.Status;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.OwnerName)))
                    data.OwnerName = request.OwnerName;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.OwnerLastName)))
                    data.OwnerLastname = request.OwnerLastName;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.OwnerTel)))
                    data.OwnerTel = request.OwnerTel;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Province)))
                    data.Province = request.Province;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.District)))
                    data.District = request.District;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.SubDistrict)))
                    data.SubDistrict = request.SubDistrict;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Village)))
                    data.Village = request.Village;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Plot)))
                    data.Plot = request.Plot;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.TotalArea)))
                    data.TotalArea = request.TotalArea;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Rai)))
                    data.Rai = request.Rai;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Ngan)))
                    data.Ngan = request.Ngan;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Meter)))
                    data.Meter = request.Meter;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Latitude)))
                    data.Latitude = request.Latitude;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Longitude)))
                    data.Longitude = request.Longitude;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Clearing1)))
                    data.Clearing1 = request.Clearing1;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Clearing1Area)))
                    data.Clearing1Area = request.Clearing1Area;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Clearing2)))
                    data.Clearing2 = request.Clearing2;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Contract)))
                    data.Contract = request.Contract;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PIC)))
                    data.PIC = request.PIC;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Generated)))
                    data.Generated = request.Generated;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Interface)))
                    data.Interface = request.Interface;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ItemType)))
                    data.ItemType = request.ItemType;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Interface)))
                    data.Interface = request.Interface;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Path)))
                    data.Path = request.Path;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Zone)))
                    data.Zone = request.Zone;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Verifier)))
                    data.Verifier = request.Verifier;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.MOUType)))
                    data.MOUType = request.MOUType;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Seedling)))
                    data.Seedling = request.Seedling;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.HarvestingYear1)))
                    data.HarvestingYear1 = request.HarvestingYear1;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.HarvestingMonth1)))
                    data.HarvestingMonth1 = request.HarvestingMonth1;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.HarvestingYear2)))
                    data.HarvestingYear2 = request.HarvestingYear2;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.HarvestingMonth2)))
                    data.HarvestingMonth2 = request.HarvestingMonth2;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.MOUPrice)))
                    data.MOUPrice = request.MOUPrice;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PlanVolume)))
                    data.PlanVolume = request.PlanVolume;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Remark)))
                    data.Remark = request.Remark;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ContractType)))
                    data.ContractType = request.ContractType;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.IsActive)))
                    data.IsActive = request.IsActive ?? true;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.IsDelete)))
                    data.IsDelete = request.IsDelete ?? false;

                await uow.SaveAsync();

                if(request.IsStatus ?? false)
                {
                    var status = request.IsActive ?? false ? "Active" : "Cancel";
                    var emailCC = new List<string>();
                    emailCC.Add(data.Verifier);
                    emailCC.Add(Email);

                    var picData = await userService.GetUserData(new UserFilter { Email = data.PIC });
                    if (picData.Any())
                    {
                        var name = "";
                        var currentUser = await userService.GetUserData(new UserFilter { Email = Email });
                        if (currentUser != null)
                            name = currentUser.FirstOrDefault().E_FullName;

                        var content = $"เรียน : {picData.FirstOrDefault().E_FullName}<br/>";
                        content += $"แจ้งเตือน {status} แปลงสวนไม้ {data.ContractType} {data.Title}<br/>";
                        content += $"โดย {name}<br/><br/><br/>";
                        content += $"Best regards,<br/>";
                        content += $"{name}";

                        await emailService.SendEmailAsync(new SendEmailRequest
                        {
                            EmailsTo = new string[] { data.PIC },
                            EmailsCC = emailCC,
                            Subject = $"[New Registration] {status} {data.ContractType}",
                            Content = content
                        });
                        
                    }
                }
            }
        }

        public async Task<NewRegistDto> GetNewRegistForExportPdf(Guid newRegisID)
        {
            var spec = new NewRegistSearchByIdSpec(newRegisID).InCludeSubNewRegists().InCludeSubNewRegistTestPlots();
            var data = await dataRepo.GetBySpecAsync(spec);
            var result = mapper.Map<NewRegistDto>(data);

            var specImg = new NewRegistImagePathAllRegistIdSpec(result.RegistId);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);
            result.NewRegistImagePaths = resultImg;

            return result;
        }

        public async Task<IEnumerable<NewRegistImagePathDto>> GetNewRegistForExportPdfImage(Guid newRegisID)
        {
            var spec = new NewRegistSearchByIdSpec(newRegisID);
            var data = await dataRepo.GetBySpecAsync(spec);

            var specImg = new NewRegistImagePathAllRegistIdSpec(data.RegistId);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);

            foreach (var item in resultImg)
            {
                try
                {
                    var fileName = $"{item.Name}.jpg";
                    var path = $"eplantation/NewRegist/{item.SurveyId}/{fileName}";
                    var img = await azureBlobStorageService.Download(path);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.CopyTo(ms);
                        item.Base64 = ms.ToArray();
                    }
                }
                catch(Exception ex)
                {

                }
            }

            return resultImg;
        }
        
        public async Task<IEnumerable<FileInfoDto>> GetNewRegistForExportPdfImageOther(Guid newRegisID)
        {
            var other = await fileService.GetFileInfos(new FileInfoFilter { RefId = newRegisID, FileType = "Other" });
            foreach (var item in other)
            {
                try
                {
                    var img = await azureBlobStorageService.Download(item.Path);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.CopyTo(ms);
                        item.Base64 = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return other;
        }

        public async Task SavePDF(NewRegistDto request)
        {
            var data = await dataRepo.GetByIdAsync(request.Id);
            if (data != null)
            {
                data.ContractStart = request.ContractStart;
                data.ContractEnd = request.ContractEnd;
                data.PhysicalArea = request.PhysicalArea;

                var specImg = new NewRegistImagePathAllRegistIdSpec(data.RegistId);
                var dataImg = await imgRepo.ListAsync(specImg);
                foreach (var item in dataImg)
                {
                    item.IsSelectedStep2 = false;
                    item.IsSelectedStep3 = false;
                }

                foreach (var item in request.NewRegistImagePaths.Where(x => x.IsSelectedStep2 == true || x.IsSelectedStep3 == true))
                {
                    var detail = dataImg.FirstOrDefault(f => f.Id == item.Id);
                    if(detail != null)
                    {
                        detail.IsSelectedStep2 = item.IsSelectedStep2;
                        detail.IsSelectedStep3 = item.IsSelectedStep3;
                    }
                }

                var spec = new FileInfoSearchSpec(new FileInfoFilter { RefId = request.Id, FileType = "Other"});
                var list = await fileInfoRepo.ListAsync(spec);
                foreach (var item in list)
                {
                    item.IsActive = false;
                }

                foreach(var item in request.NewRegistImageOther)
                {
                    var detail = list.FirstOrDefault(f => f.Id == item.Id);
                    if(detail != null)
                    {
                        detail.IsActive = true;
                    }
                    else
                    {
                        var fileName = $"{Path.GetRandomFileName()}";
                        var path = $"eplantation/NewRegist/{data.RegistId}/Other/{fileName}";
                        await azureBlobStorageService.Upload(path, item.Base64);

                        detail = new Core.Domains.FileInfo(item.FileName)
                        {
                            FileType = "Other",
                            RefId = request.Id,
                            Path = path
                        };
                        await fileInfoRepo.AddAsync(detail);
                    }
                }

                await uow.SaveAsync();
            }
        }

        public async Task<byte[]> GetCashFlow(Guid id)
        {
            var data = await assService.GetAssumption(id);
            var dto = await ConvertToAssumptionPdfDto(data);
            
            CashFlowPdf cashflowService = new CashFlowPdf();
            return cashflowService.Pdf(dto);
        }

        public async Task<FileResponseDto> GetPDF(Guid id)
        {
            var data = await assService.GetAssumption(id);
            #region Load Img
            var specImg = new NewRegistImagePathAllRegistIdSpec(data.NewRegist.RegistId);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);
            foreach (var item in resultImg.Where(x => x.IsSelectedStep2 || x.IsSelectedStep3))
            {
                try
                {
                    var fileName = $"{item.Name}.jpg";
                    var path = $"eplantation/NewRegist/{item.SurveyId}/{fileName}";
                    var img = await azureBlobStorageService.Download(path);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.CopyTo(ms);
                        item.Base64 = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            data.NewRegist.NewRegistImagePaths = resultImg;
            #endregion Load Img

            #region Load Img Other
            data.NewRegist.NewRegistImageOther = await GetNewRegistForExportPdfImageOther(id);
            #endregion Load Img Other
            var dto = await ConvertToAssumptionPdfDto(data);

        
            IntroductionPdf pdfService = new IntroductionPdf();
            var intro = pdfService.Pdf();

            NewRegistPdf newRegistPdfService = new NewRegistPdf();
            var newregistPdf = newRegistPdfService.Pdf(dto);

            ActivityPdf activityPdfService = new ActivityPdf();
            var activityPdf = activityPdfService.Pdf(dto);

            ReturnOfInvestmentPdf returnPdfService = new ReturnOfInvestmentPdf();
            var returnPdf = returnPdfService.Pdf(dto);

            CashFlowPdf cashflowService = new CashFlowPdf();
            var cashflowPdf = cashflowService.Pdf(dto);

            SummaryPdf sumService = new SummaryPdf();
            var sumPdf = sumService.Pdf(dto);

            RiskDashboardPdf riskService = new RiskDashboardPdf();
            var riskPdf = riskService.Pdf(dto);

            var result = SketecUtils.Combine(intro, newregistPdf);
            result = SketecUtils.Combine(result, activityPdf);
            result = SketecUtils.Combine(result, returnPdf);
            result = SketecUtils.Combine(result, cashflowPdf);
            result = SketecUtils.Combine(result, sumPdf);
            result = SketecUtils.Combine(result, riskPdf);

            return new FileResponseDto
            {
                File = result,
                FileName = "Feasibility Plantation Project - " + data.NewRegist.Title
            };
        }

        public async Task<byte[]> Pdf()
        {
            var data = await assService.GetAssumption(new Guid("C1F26DE8-7BCB-4C1F-A551-08D9EE00A7F4"));
            #region Load Img
            var specImg = new NewRegistImagePathAllRegistIdSpec(data.NewRegist.RegistId);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);
            foreach (var item in resultImg.Where(x => x.IsSelectedStep2 || x.IsSelectedStep3))
            {
                try
                {
                    var fileName = $"{item.Name}.jpg";
                    var path = $"eplantation/NewRegist/{item.SurveyId}/{fileName}";
                    var img = await azureBlobStorageService.Download(path);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.CopyTo(ms);
                        item.Base64 = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            data.NewRegist.NewRegistImagePaths = resultImg;
            #endregion Load Img
            var dto = await ConvertToAssumptionPdfDto (data);

            IntroductionPdf pdfService = new IntroductionPdf();
            var intro = pdfService.Pdf();

            NewRegistPdf newRegistPdfService = new NewRegistPdf();
            var newregistPdf = newRegistPdfService.Pdf(dto);

            ActivityPdf activityPdfService = new ActivityPdf();
            var activityPdf = activityPdfService.Pdf(dto);

            ReturnOfInvestmentPdf returnPdfService = new ReturnOfInvestmentPdf();
            var returnPdf = returnPdfService.Pdf(dto);

            CashFlowPdf cashflowService = new CashFlowPdf();
            var cashflowPdf = cashflowService.Pdf(dto);

            SummaryPdf sumService = new SummaryPdf();
            var sumPdf = sumService.Pdf(dto);

            RiskDashboardPdf riskService = new RiskDashboardPdf();
            var riskPdf = riskService.Pdf(dto);

            var result = SketecUtils.Combine(intro, newregistPdf);
            result = SketecUtils.Combine(result, activityPdf);
            result = SketecUtils.Combine(result, returnPdf);
            result = SketecUtils.Combine(result, cashflowPdf);
            result = SketecUtils.Combine(result, sumPdf);
            result = SketecUtils.Combine(result, riskPdf);

            return result;
        }

        private async Task<AssumptionPdfDto> ConvertToAssumptionPdfDto(AssumptionDto data)
        {
            var result = new AssumptionPdfDto();
            result.Id = data.Id;
            result.NewRegistId = data.NewRegistId;
            result.ContractYear = data.ContractYear;
            result.ContractType = data.ContractType;
            result.RentalArea = data.RentalArea;
            result.ProductiveAreaPercent = data.ProductiveAreaPercent;
            result.ProductiveArea = data.ProductiveArea;
            result.Rainfall = data.Rainfall;
            result.SoilType = data.SoilType;
            result.CuttingRound = data.CuttingRound;
            result.DistanceToPlant = data.DistanceToPlant;
            result.Mill = data.Mill;
            result.AveragePrice = data.AveragePrice;
            result.MtpPrice = data.MtpPrice;
            result.FcPrice = data.FcPrice;
            result.CuttingCostTypeId = data.CuttingCostTypeId;
            result.CuttingCost = data.CuttingCost;
            result.FreightTypeId = data.FreightTypeId;
            result.Freight = data.Freight;
            result.InflationRate = data.InflationRate;
            result.PlanVolume = data.PlanVolume;

            result.NewRegist = new NewRegistPdfDto
            {
                Id = data.NewRegist.Id,
                Title = data.NewRegist.Title,
                RegistId = data.NewRegist.RegistId,
                Status = data.NewRegist.Status,
                OwnerName = data.NewRegist.OwnerName,
                OwnerLastName = data.NewRegist.OwnerLastName,
                OwnerTel = data.NewRegist.OwnerTel,
                Province = data.NewRegist.Province,
                District = data.NewRegist.District,
                SubDistrict = data.NewRegist.SubDistrict,
                Village = data.NewRegist.Village,
                Plot = data.NewRegist.Plot,
                TotalArea = data.NewRegist.TotalArea,
                Rai = data.NewRegist.Rai,
                Ngan = data.NewRegist.Ngan,
                Meter = data.NewRegist.Meter,
                Latitude = data.NewRegist.Latitude,
                Longitude = data.NewRegist.Longitude,
                Clearing1 = data.NewRegist.Clearing1,
                Clearing1Area = data.NewRegist.Clearing1Area,
                Clearing2 = data.NewRegist.Clearing2,
                Contract = data.NewRegist.Contract,

                PIC = data.NewRegist.PIC,
                Generated = data.NewRegist.Generated,
                Interface = data.NewRegist.Interface,
                ItemType = data.NewRegist.ItemType,
                Path = data.NewRegist.Path,
                Zone = data.NewRegist.Zone,
                Verifier = data.NewRegist.Verifier,
                MOUType = data.NewRegist.MOUType,
                Seedling = data.NewRegist.Seedling,
                HarvestingYear1 = data.NewRegist.HarvestingYear1,
                HarvestingMonth1 = data.NewRegist.HarvestingMonth1,
                HarvestingYear2 = data.NewRegist.HarvestingYear2,
                HarvestingMonth2 = data.NewRegist.HarvestingMonth2,
                MOUPrice = data.NewRegist.MOUPrice,
                PlanVolume = data.NewRegist.PlanVolume,
                Remark = data.NewRegist.Remark,
                ContractType = data.NewRegist.ContractType,
                IsActive = data.NewRegist.IsActive,
                Team = data.NewRegist.Team,
                ContractStart = data.NewRegist.ContractStart,
                ContractEnd = data.NewRegist.ContractEnd,
                PhysicalArea = data.NewRegist.PhysicalArea,
                AssignToDate = data.NewRegist.AssignToDate,
                NewRegistImagePaths = data.NewRegist.NewRegistImagePaths != null ? data.NewRegist.NewRegistImagePaths.Select(x => new NewRegistImagePathPdfDto
                {
                    Base64 = x.Base64,
                    IsSelectedStep2 = x.IsSelectedStep2,
                    IsSelectedStep3 = x.IsSelectedStep3
                }): new List<NewRegistImagePathPdfDto>(),
                NewRegistImageOther = data.NewRegist.NewRegistImageOther != null ? data.NewRegist.NewRegistImageOther.Select(x => new FileInfoPdfDto
                {
                    Base64 = x.Base64,
                    FileName = x.FileName,
                    RefId = x.RefId,
                    FileType = x.FileType,
                    FileData = x.FileData,
                    Path = x.Path
                }) : new List<FileInfoPdfDto>()
            };

            var cnt = 1;
            var maxRound = data.AssumptionYields.Max(x => x.Round);
            result.AssumptionYield = new List<AssumptionYieldPdfDto>();
            foreach (var item in data.AssumptionYields.OrderBy(x => x.Round))
            {
                var yearStart = (5 * (cnt - 1)) + 1;
                var yearEnd = cnt == maxRound ? data.ContractYear : (5 * cnt);
                result.AssumptionYield.Add(new AssumptionYieldPdfDto
                {
                    Id = item.Id,
                    AssumptionId = item.AssumptionId,
                    Round = item.Round,
                    Yield = item.Yield,
                    YearStart = yearStart,
                    YearEnd = yearEnd,
                    Year = yearEnd - yearStart + 1,
                    RentalFee = Math.Round(GetRentalFee(data.ExpenseGroupA, yearStart, yearEnd) / (yearEnd - yearStart + 1))
                });
                cnt++;
            }

            result.AssumptionClone = new List<AssumptionClonePdfDto>();
            foreach (var item in data.AssumptionClones)
            {
                result.AssumptionClone.Add(new AssumptionClonePdfDto
                {
                    Id = item.Id,
                    Area = item.Area,
                    AssumptionId = item.AssumptionId,
                    Clone = item.Clone,
                    Portion = item.Portion,
                    ProductTon = item.ProductTon
                });
            }

            result.Expense = new List<ExpensePdfDto>();
            result.Expense.AddRange(ConvertToExpensePdfDto(data.ExpenseGroupA));
            result.Expense.AddRange(ConvertToExpensePdfDto(data.ExpenseGroupB));
            result.Expense.AddRange(ConvertToExpensePdfDto(data.ExpenseGroupC));
            result.Expense.AddRange(ConvertToExpensePdfDto(data.ExpenseGroupD));
            result.Expense.AddRange(ConvertToExpensePdfDto(data.ExpenseGroupF));

            //public IEnumerable<AssumptionYieldDto> AssumptionYields
            //public IEnumerable<AssumptionCloneDto> AssumptionClones

            var criteria1 = await configService.GetMasterConfiguration(new MasterConfigurationFilter { ConfigurationKey = "Criteria 1" });
            var criteria2 = await configService.GetMasterConfiguration(new MasterConfigurationFilter { ConfigurationKey = "Criteria 2" });
            var criteria3 = await configService.GetMasterConfiguration(new MasterConfigurationFilter { ConfigurationKey = "Criteria 3" });

            result.AverageRate = Convert.ToDecimal(criteria1.FirstOrDefault().Value);
            result.MtpRate = Convert.ToDecimal(criteria2.FirstOrDefault().Value);
            result.FcRate = Convert.ToDecimal(criteria3.FirstOrDefault().Value);

            List<string> activityGroup = new List<string>(new string[] { "B", "C", "D", "F" });
            decimal cost = ((result.Expense.Where(x => x.ActivityGroup == "A").Sum(x => (x.YearCost1 ?? 0) + (x.YearCost2 ?? 0) + (x.YearCost3 ?? 0) + (x.YearCost4 ?? 0) + (x.YearCost5 ?? 0) + (x.YearCost6 ?? 0) + (x.YearCost7 ?? 0) + (x.YearCost8 ?? 0) + (x.YearCost9 ?? 0) + (x.YearCost10 ?? 0) + (x.YearCost11 ?? 0) + (x.YearCost12 ?? 0) + (x.YearCost13 ?? 0) + (x.YearCost14 ?? 0) + (x.YearCost15 ?? 0))) * (result.RentalArea ?? 0))
                        + ((result.Expense.Where(x => activityGroup.Contains(x.ActivityGroup)).Sum(x => (x.YearCost1 ?? 0) + (x.YearCost2 ?? 0) + (x.YearCost3 ?? 0) + (x.YearCost4 ?? 0) + (x.YearCost5 ?? 0) + (x.YearCost6 ?? 0) + (x.YearCost7 ?? 0) + (x.YearCost8 ?? 0) + (x.YearCost9 ?? 0) + (x.YearCost10 ?? 0) + (x.YearCost11 ?? 0) + (x.YearCost12 ?? 0) + (x.YearCost13 ?? 0) + (x.YearCost14 ?? 0) + (x.YearCost15 ?? 0))) * (result.ProductiveArea ?? 0));

            decimal yield = Math.Round(result.AssumptionYield.Sum(x => (x.Yield ?? 0) * (result.ProductiveArea ?? 0)) / 10) * 10;
            result.PriceAtPlant = Math.Round(((cost / yield) + (data.CuttingCost ?? 0)) / 10) * 10;


            return result;
        }

        private List<ExpensePdfDto> ConvertToExpensePdfDto(IEnumerable<ExpenseDto> list)
        {
            return list.Select(item => new ExpensePdfDto
            {
                Id = item.Id,
                AssumptionId = item.AssumptionId,
                ActivityId = item.ActivityId,
                ActivityGroup = item.ActivityGroup,
                ActivityName = item.ActivityName,
                ActivityTypeId = item.ActivityTypeId,
                ActivityTypeName = item.ActivityTypeName,
                ExpenseType = item.ExpenseType,
                BahtPerRai = item.BahtPerRai,
                YearCost1 = item.YearCost1,
                YearCost2 = item.YearCost2,
                YearCost3 = item.YearCost3,
                YearCost4 = item.YearCost4,
                YearCost5 = item.YearCost5,
                YearCost6 = item.YearCost6,
                YearCost7 = item.YearCost7,
                YearCost8 = item.YearCost8,
                YearCost9 = item.YearCost9,
                YearCost10 = item.YearCost10,
                YearCost11 = item.YearCost11,
                YearCost12 = item.YearCost12,
                YearCost13 = item.YearCost13,
                YearCost14 = item.YearCost14,
                YearCost15 = item.YearCost15,
            }).ToList();
        }

        private decimal GetRentalFee(IEnumerable<ExpenseDto> list, int yearStart, int yearEnd)
        {
            decimal data = list.Sum(x => ((yearStart <= 1 && yearEnd >= 1) ? (x.YearCost1 ?? 0) : 0)
                                        + ((yearStart <= 2 && yearEnd >= 2) ? (x.YearCost2 ?? 0) : 0)
                                        + ((yearStart <= 3 && yearEnd >= 3) ? (x.YearCost3 ?? 0) : 0)
                                        + ((yearStart <= 4 && yearEnd >= 4) ? (x.YearCost4 ?? 0) : 0)
                                        + ((yearStart <= 5 && yearEnd >= 5) ? (x.YearCost5 ?? 0) : 0)
                                        + ((yearStart <= 6 && yearEnd >= 6) ? (x.YearCost6 ?? 0) : 0)
                                        + ((yearStart <= 7 && yearEnd >= 7) ? (x.YearCost7 ?? 0) : 0)
                                        + ((yearStart <= 8 && yearEnd >= 8) ? (x.YearCost8 ?? 0) : 0)
                                        + ((yearStart <= 9 && yearEnd >= 9) ? (x.YearCost9 ?? 0) : 0)
                                        + ((yearStart <= 10 && yearEnd >= 10) ? (x.YearCost10 ?? 0) : 0)
                                        + ((yearStart <= 11 && yearEnd >= 11) ? (x.YearCost11 ?? 0) : 0)
                                        + ((yearStart <= 12 && yearEnd >= 12) ? (x.YearCost12 ?? 0) : 0)
                                        + ((yearStart <= 13 && yearEnd >= 13) ? (x.YearCost13 ?? 0) : 0)
                                        + ((yearStart <= 14 && yearEnd >= 14) ? (x.YearCost14 ?? 0) : 0)
                                        + ((yearStart <= 15 && yearEnd >= 15) ? (x.YearCost15 ?? 0) : 0)
                                    );
            return data;
        }
    }
}
