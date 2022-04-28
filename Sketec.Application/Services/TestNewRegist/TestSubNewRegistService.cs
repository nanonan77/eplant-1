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
    public class TestSubNewRegistService : ApplicationService, ITestSubNewRegistService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        ISharePointService sharePointService;
        IWCRepository<NewRegist> dataRepo;
        IWCRepository<SubNewRegist> dataSubRepo;
        IWCRepository<NewRegistImagePath> imgRepo;
        IUserService userService;
        IWCAzureBlobStorageService azureBlobStorageService;
        public TestSubNewRegistService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            ISharePointService sharePointService,
            IWCRepository<NewRegist> dataRepo,
            IWCRepository<SubNewRegist> dataSubRepo,
            IWCRepository<NewRegistImagePath> imgRepo,
            IWCQueryRepository queryRepo,
            IUserService userService,
            IWCAzureBlobStorageService azureBlobStorageService)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.sharePointService = sharePointService;
            this.dataRepo = dataRepo;
            this.dataSubRepo = dataSubRepo;
            this.imgRepo = imgRepo;
            this.userService = userService;
            this.azureBlobStorageService = azureBlobStorageService;
        }

        public async Task<SubNewRegistDto>  GetSubNewRegist(Guid subNewRegisID)
        {

            var spec = new SubNewRegistSearchByIdSpec(subNewRegisID).InCludeSubNewRegistTestPlots().InCludeNewRegist();
            var data = await dataSubRepo.GetBySpecAsync(spec);
            var result = mapper.Map<SubNewRegistDto>(data);

            var picData = await userService.GetUserData(new UserFilter { Email = data.NewRegist.PIC });
            var user = new UserResultDto();
            if (picData.Any())
            {
                var pic = picData.FirstOrDefault();
                user = pic;
            }
            result.IsCanEdit = SketecUtils.IsCanEdit(data.NewRegist.Team, user.ManagerEmail, user.ReportToEmail2, user.ReportToEmail3, data.NewRegist.PIC, data.NewRegist.Verifier
                                                    , user.Sec_Name, Role, Team, Email, Section, Department, user.Dep_Name);

            var specImg = new NewRegistImagePathSearchBySubRegistIdSpec(result.SubRegistId);
            var dataImg = await imgRepo.ListAsync(specImg);
            var resultImg = mapper.Map<List<NewRegistImagePath>, IEnumerable<NewRegistImagePathDto>>(dataImg);
            result.SubNewRegistImagePaths = resultImg;

            if (SketecUtils.RoleFilterDataNewRegist().Contains(Role) && result.IsCanEdit == false)
            {
                result = new SubNewRegistDto();
            }

            return result;

        }

        public async Task<IEnumerable<NewRegistImagePathDto>> GetImage(Guid id)
        {
            var result = await dataSubRepo.GetByIdAsync(id);
            var specImg = new NewRegistImagePathSearchBySubRegistIdSpec(result.SubRegistId);
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

        public async Task UpdateSubNewRegist(Guid subNewRegisID, SubNewRegistUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null)
        {
            Ensure.Any.IsNotNull(request, "SubNewRegistUpdateRequest");

            var spec = new SubNewRegistSearchByIdSpec(subNewRegisID);
            var data = await dataSubRepo.GetBySpecAsync(spec);

            if (data != null)
            {
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Title)))
                    data.Title = request.Title;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.RegistId)))
                    data.RegistId = request.RegistId;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.SubRegistId)))
                    data.SubRegistId = request.SubRegistId;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Latitude)))
                    data.Latitude = request.Latitude;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Area)))
                    data.Area = request.Area;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.NumSoilType)))
                    data.NumSoilType = request.NumSoilType;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.SoilType)))
                    data.SoilType = request.SoilType;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.LandUse)))
                    data.LandUse = request.LandUse;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Accessibility)))
                    data.Accessibility = request.Accessibility;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Water)))
                    data.Water = request.Water;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.NumSoilTest)))
                    data.NumSoilTest = request.NumSoilTest;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Rainfall)))
                    data.Rainfall = request.Rainfall;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.DeedArea)))
                    data.DeedArea = request.DeedArea;


                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ItemType)))
                    data.ItemType = request.ItemType;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Path)))
                    data.Path = request.Path;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PlantYear)))
                    data.PlantYear = request.PlantYear;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.HarvestingMonth)))
                    data.HarvestingMonth = request.HarvestingMonth;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.HarvestingYear)))
                    data.HarvestingYear = request.HarvestingYear;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Volume)))
                    data.Volume = request.Volume;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.VipPrice)))
                    data.VipPrice = request.VipPrice;
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Remark)))
                    data.Remark = request.Remark;

                await uow.SaveAsync();
            }
        }
    }
}
