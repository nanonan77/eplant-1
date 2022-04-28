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
using System.IO;
using Sketec.Application.Resources.Users;

namespace Sketec.Application.Services
{
    public class TestSubNewRegistPhysicalService : ApplicationService, ITestSubNewRegistPhysicalService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<NewRegist> dataRepo;
        ISharePointService sharePointService;
        IWCRepository<SubNewRegist> dataSubRepo;
        IWCRepository<SubNewRegistTestPlot> dataSubTestPlotRepo;
        IWCRepository<NewRegistImagePath> imgRepo;
        IUserService userService;
        IWCAzureBlobStorageService azureBlobStorageService;
        public TestSubNewRegistPhysicalService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<NewRegist> dataRepo,
            IWCRepository<SubNewRegist> dataSubRepo,
            IWCRepository<SubNewRegistTestPlot> dataSubTestPlotRepo,
            ISharePointService sharePointService,
            IWCRepository<NewRegistImagePath> imgRepo,
            IWCQueryRepository queryRepo,
            IUserService userService,
            IWCAzureBlobStorageService azureBlobStorageService)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.dataRepo = dataRepo;
            this.dataSubRepo = dataSubRepo;
            this.dataSubTestPlotRepo = dataSubTestPlotRepo;
            this.sharePointService = sharePointService;
            this.imgRepo = imgRepo;
            this.userService = userService;
            this.azureBlobStorageService = azureBlobStorageService;
        }

        public async Task<SubNewRegistTestPlotDto> GetSubNewRegistTestPlot(Guid subNewRegisTestPlotID)
        {

            var spec = new SubNewRegistTestPlotSearchByIdSpec(subNewRegisTestPlotID).InCludeNewRegist();
            var data = await dataSubTestPlotRepo.GetBySpecAsync(spec);
            var result = mapper.Map<SubNewRegistTestPlotDto>(data);

            var picData = await userService.GetUserData(new UserFilter { Email = data.SubNewRegist.NewRegist.PIC });
            var user = new UserResultDto();
            if (picData.Any())
            {
                var pic = picData.FirstOrDefault();
                user = pic;
            }
            result.IsCanEdit = SketecUtils.IsCanEdit(data.SubNewRegist.NewRegist.Team, user.ManagerEmail, user.ReportToEmail2, user.ReportToEmail3, data.SubNewRegist.NewRegist.PIC, data.SubNewRegist.NewRegist.Verifier
                                                    , user.Sec_Name, Role, Team, Email, Section, Department, user.Dep_Name);

            var specImg = new NewRegistImagePathSearchBySubRegistTestProtIdSpec(result.SubNewRegistTestId);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);
            result.SubNewRegistTestPlotImagePaths = resultImg;

            if (SketecUtils.RoleFilterDataNewRegist().Contains(Role) && result.IsCanEdit == false)
            {
                result = new SubNewRegistTestPlotDto();
            }

            return result;

        }

        public async Task<IEnumerable<NewRegistImagePathDto>> GetImage(Guid id)
        {
            var result = await dataSubTestPlotRepo.GetByIdAsync(id);
            var specImg = new NewRegistImagePathSearchBySubRegistTestProtIdSpec(result.SubNewRegistTestId);
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

        public async Task UpdateSubNewRegistTestPlot(Guid subNewRegistTestID, SubNewRegistTestPlotUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null)
        {
            Ensure.Any.IsNotNull(request, "SubNewRegistTestPlotUpdateRequest");

            var spec = new SubNewRegistTestPlotSearchByIdSpec(subNewRegistTestID);
            var data = await dataSubTestPlotRepo.GetBySpecAsync(spec);
            //var activity = await dataRepo.GetByIdAsync(request.Id);
            if (data != null)
            {
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.SubRegistId)))
                    data.SubRegistId = request.SubRegistId;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.SubNewRegistTestId)))
                    data.SubNewRegistTestId = request.SubNewRegistTestId;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Latitude)))
                    data.Latitude = request.Latitude;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Longitude)))
                    data.Longitude = request.Longitude;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.SoilType)))
                    data.SoilType = request.SoilType;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Depth)))
                    data.Depth = request.Depth;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.SoillFloorDepth)))
                    data.SoillFloorDepth = request.SoillFloorDepth;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.GravelDepth)))
                    data.GravelDepth = request.GravelDepth;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PH30)))
                    data.PH30 = request.PH30;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PH60)))
                    data.PH60 = request.PH60;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.EC30)))
                    data.EC30 = request.EC30;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.EC60)))
                    data.EC60 = request.EC60;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Dot)))
                    data.Dot = request.Dot;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ItemType)))
                    data.ItemType = request.ItemType;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Path)))
                    data.Path = request.Path;

                await uow.SaveAsync();
            }
        }
    }
}
