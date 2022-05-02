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

namespace Sketec.Application.Services
{
    public class MasterActivityService : ApplicationService, IMasterActivityService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<MasterActivity> dataRepo;
        IWCRepository<MasterActivityType> dataTypeRepo;
        public MasterActivityService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<MasterActivity> dataRepo,
            IWCQueryRepository queryRepo,
            IWCRepository<MasterActivityType> dataTypeRepo)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.dataRepo = dataRepo;
            this.dataTypeRepo = dataTypeRepo;
        }
        public async Task<IEnumerable<MasterActivityResultDto>> GetMasterActivitys(MasterActivityFilter filter)
        {
            var spec = new MasterActivityLinqSearchSpec(filter ?? new MasterActivityFilter());
            var list = await queryRepo.ListAsync(spec);

            return list;
        }

        public async Task<MasterActivitySearchResultDto> GetMasterActivity(int id)
        {
            var spec = await dataRepo.GetByIdAsync(id);
            var result = mapper.Map<MasterActivitySearchResultDto>(spec);
            return result;
        }

        public async Task CreateMasterActivity(MasterActivityCreateRequest request)
        {
            Ensure.Any.IsNotNull(request, "MasterActivityCreateRequest");
            var data = await GetMasterActivitys(new MasterActivityFilter { MasterActivityTypeId = request.MasterActivityTypeId });
            var codeMax = data.OrderByDescending(x => x.ActivityCode).FirstOrDefault();
            request.ActivityCode = codeMax.ActivityGroup + (Convert.ToInt32(codeMax.ActivityCode.Substring(1)) + 1).ToString().PadRight(2, '0');

            // validate MasterActivity ห้ามเลือก Title TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบ
            var spec = new MasterActivityLinqSearchSpec(new MasterActivityFilter());
            var list = await queryRepo.ListAsync(spec);

            if (list.Where(m => m.MasterActivityTypeId == request.MasterActivityTypeId && m.ActivityTH == request.ActivityTH).Count() > 0) {
                throw new ApplicationException("ไม่สามารถเลือกTitle TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบได้");
            } 
            // validate MasterActivity ห้ามเลือก Title TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบ


            var activity = new MasterActivity
            {
                ActivityCode = request.ActivityCode,
                ActivityEN = request.ActivityEN,
                ActivityTH = request.ActivityTH,
                MasterActivityTypeId = request.MasterActivityTypeId,
                IsActive = true,
                IsDelete = false,
                IsExport = false
            };

            await dataRepo.AddAsync(activity);
            await uow.SaveAsync();
        }

        public async Task UpdateMasterActivity(int id, MasterActivityUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null)
        {
            Ensure.Any.IsNotNull(request, "MasterActivityUpdateRequest");

            // validate MasterActivity ห้ามเลือก Title TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบ
            var spec = new MasterActivityLinqSearchSpec(new MasterActivityFilter());
            var list = await queryRepo.ListAsync(spec);

            if (list.Where(m => m.MasterActivityTypeId == request.MasterActivityTypeId && m.ActivityTH == request.ActivityTH).Count() > 0)
            {
                throw new ApplicationException("ไม่สามารถเลือกTitle TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบได้");
            }
            // validate MasterActivity ห้ามเลือก Title TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบ

            var activity = await dataRepo.GetByIdAsync(id);
            if (activity != null)
            {
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ActivityCode)))
                    activity.ActivityCode = request.ActivityCode;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ActivityEN)))
                    activity.ActivityEN = request.ActivityEN;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ActivityTH)))
                    activity.ActivityTH = request.ActivityTH;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.MasterActivityTypeId)))
                    activity.MasterActivityTypeId = request.MasterActivityTypeId.Value;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.IsActive)))
                    activity.IsActive = request.IsActive.Value;

                activity.IsExport = false;
                await uow.SaveAsync();
            }
        }

        public async Task UpdateIsExportMasterActivity(IEnumerable<MasterActivityResultDto> data)
        {
            foreach(var item in data.Where(x => x.IsExportMain == false).Select(x => x.MasterActivityTypeId).Distinct())
            {
                var activity = await dataTypeRepo.GetByIdAsync(item);
                activity.IsExport = true;
            }
            foreach (var item in data.Where(x => x.IsExport == false).Select(x => x.Id))
            {
                var activity = await dataRepo.GetByIdAsync(item);
                activity.IsExport = true;
            }

            await uow.SaveAsync();
        }

        //private void ValidateMasterActivity(IEnumerable<AssumptionCloneDto> assumptionClones)
    }
}
