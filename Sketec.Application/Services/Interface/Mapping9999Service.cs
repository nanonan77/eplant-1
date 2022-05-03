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
    public class Mapping9999Service : ApplicationService, IMapping9999Service
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<MappingTrans> mappingTransRepo;
        IWCRepository<Mapping9999> mapping9999Repo;
        IWCRepository<Match9999> match9999Repo;
        IWCRepository<MatchData> matchDataRepo;
        IWCRepository<MatchPlantation> matchPlantationRepo;
        IRunningNumberService runningService;
        public Mapping9999Service(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCQueryRepository queryRepo,
            IWCRepository<MappingTrans> mappingTransRepo,
            IWCRepository<Mapping9999> mapping9999Repo,
            IWCRepository<Match9999> match9999Repo,
            IWCRepository<MatchData> matchDataRepo,
            IWCRepository<MatchPlantation> matchPlantationRepo,
            IRunningNumberService runningService
        )
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.mappingTransRepo = mappingTransRepo;
            this.mapping9999Repo = mapping9999Repo;
            this.match9999Repo = match9999Repo;
            this.matchDataRepo = matchDataRepo;
            this.matchPlantationRepo = matchPlantationRepo;
            this.runningService = runningService;
        }

        public async Task<IEnumerable<MappingTransDto>> GetMappingTrans(MappingTransFilter filter)
        {
            var spec = new MappingTransSearchSpec(filter ?? new MappingTransFilter());
            var list = await mappingTransRepo.ListAsync(spec);
            return mapper.Map<List<MappingTrans>, IEnumerable<MappingTransDto>>(list);
        }

        public async Task<IEnumerable<Mapping9999SearchDto>> GetMapping9999(Mapping9999Filter filter)
        {
            var spec = new Mapping9999QuerySpec(filter ?? new Mapping9999Filter());
            var list = dapper.Query(spec);

            return ConvertToGroupData(list);
        }

        private IEnumerable<Mapping9999SearchDto> ConvertToGroupData(IEnumerable<Mapping9999SearchDto> data)
        {
            return data
                .GroupBy(x => new { x.Year, x.Month, x.CostCenter, x.CostElement, x.RefCompanyCode, x.FiscalYear })
                .Select(x => new Mapping9999SearchDto
                {
                    Key = $"{x.Key.Year}_{x.Key.Month}_{x.Key.CostCenter}_{x.Key.CostElement}_{x.Key.RefCompanyCode}_{x.Key.FiscalYear}",
                    Year = x.Key.Year,
                    Month = x.Key.Month,
                    CostCenter = x.Key.CostCenter,
                    CostElement = x.Key.CostElement,
                    RefCompanyCode=  x.Key.RefCompanyCode,
                    FiscalYear = x.Key.FiscalYear,
                    ValCOAreaCrcy = x.Sum(y => y.ValCOAreaCrcy),
                    Children = x.Select(z => new Mapping9999SearchDto
                    {
                        KeyGroup = $"{x.Key.Year}_{x.Key.Month}_{x.Key.CostCenter}_{x.Key.CostElement}_{x.Key.RefCompanyCode}_{x.Key.FiscalYear}",
                        Key = $"{x.Key.Year}_{x.Key.Month}_{x.Key.CostCenter}_{x.Key.CostElement}_{x.Key.RefCompanyCode}_{x.Key.FiscalYear}_{z.RefDocumentNumber}",
                        Year = x.Key.Year,
                        Month = x.Key.Month,
                        CostCenter = x.Key.CostCenter,
                        CostElement = x.Key.CostElement,
                        RefCompanyCode = x.Key.RefCompanyCode,
                        FiscalYear = x.Key.FiscalYear,
                        Mapping9999Id = z.Mapping9999Id,
                        Name = z.Name,
                        PurchaseOrderText = z.PurchaseOrderText,
                        RefDocumentNumber = z.RefDocumentNumber,
                        PostingRow = z.PostingRow,
                        ValCOAreaCrcy = z.ValCOAreaCrcy,
                        Match9999Id = z.Match9999Id,
                        TransactionNo = z.TransactionNo,
                        TransactionDate = z.TransactionDate,
                        Status = z.Status,
                        CreatedBy = z.CreatedBy,
                        CreatedDate = z.CreatedDate,
                        UpdatedBy = z.UpdatedBy,
                        UpdatedDate = z.UpdatedDate
                    })
                });
        }


        public async Task<MappingTransDto> GetMappingTrans(Guid id)
        {
            var spec = new MappingTransSearchByIdSpec(id).IncludeAll();
            var list = await mappingTransRepo.GetBySpecAsync(spec);
            var result = mapper.Map<MappingTransDto>(list);
            return result;
        }

        public async Task<Match9999Dto> GetMatch9999(Guid id)
        {
            var spec = new Match9999SearchByIdSpec(id).IncludeAll();
            var list = await match9999Repo.GetBySpecAsync(spec);
            var result = mapper.Map<Match9999Dto>(list);
            return result;
        }


        public async Task<Guid> CreateMappingTrans()
        {
            var runningNumber = await runningService.GetRunningNumber("MappingTrans", DateTime.Now.Year, DateTime.Now.ToString("MM"));
            var data = new MappingTrans
            {
                TransactionNo = runningNumber,
                TransactionDate = DateTime.Now.Date,
                Status = "Created",
                IsActive = true,
                IsDelete = false
            };
            await mappingTransRepo.AddAsync(data);
            await uow.SaveAsync();

            return data.Id;
        }

        public async Task CreateMatch9999(Guid mappingTransId, Match9999Dto request)
        {
            var data = await mappingTransRepo.GetByIdAsync(mappingTransId);

            var match9999 = new Match9999
            {
                //TransactionNo = runningNumber,
                TransactionDate = DateTime.Now.Date,
                Status = request.Status,
                IsActive = true,
                IsDelete = false
            };

            foreach(var item in request.MatchDatas)
            {
                var matchData = new MatchData
                {
                    Mapping9999Id = item.Mapping9999Id,
                    ValCOAreaCrcy = item.ValCOAreaCrcy,
                    IsActive = true,
                    IsDelete = false
                };
                await matchDataRepo.AddAsync(matchData);
                match9999.AddMatchData(matchData);
            }

            foreach (var item in request.MatchPlantations)
            {
                var matchPlantation = new MatchPlantation
                {
                    PlantationId = item.PlantationId,
                    MasterActivityId = item.MasterActivityId,
                    Amount = item.Amount,
                    IsActive = true,
                    IsDelete = false
                };
                await matchPlantationRepo.AddAsync(matchPlantation);
                match9999.AddMatchPlantation(matchPlantation);
            }

            await match9999Repo.AddAsync(match9999);
            data.AddMatch9999(match9999);

            await uow.SaveAsync();
        }
        public async Task UpdateMatch9999(Match9999Dto request)
        {
            var spec = new Match9999SearchByIdSpec(request.Id).IncludeAll();
            var data = await match9999Repo.GetBySpecAsync(spec);
            if(data != null)
            {
                data.Status = request.Status;
                foreach(var item in data.MatchDatas)
                {
                    //item.IsActive = false;
                    data.RemoveMatchData(item);
                }
                foreach(var item in request.MatchDatas)
                {
                    var matchData = new MatchData
                    {
                        Mapping9999Id = item.Mapping9999Id,
                        ValCOAreaCrcy = item.ValCOAreaCrcy,
                        IsActive = true,
                        IsDelete = false
                    };
                    await matchDataRepo.AddAsync(matchData);

                    data.AddMatchData(matchData);
                }

                foreach (var item in data.MatchPlantations)
                {
                    //item.IsActive = false;
                    data.RemoveMatchPlantation(item);
                }
                foreach (var item in request.MatchPlantations)
                {
                    var matchPlantation = new MatchPlantation
                    {
                        PlantationId = item.PlantationId,
                        MasterActivityId = item.MasterActivityId,
                        Amount = item.Amount,
                        IsActive = true,
                        IsDelete = false
                    };
                    await matchPlantationRepo.AddAsync(matchPlantation);

                    data.AddMatchPlantation(matchPlantation);
                }
                await uow.SaveAsync();
            }
        }
            //public async Task CreateMasterActivity(MasterActivityCreateRequest request)
            //{
            //    Ensure.Any.IsNotNull(request, "MasterActivityCreateRequest");
            //    var data = await GetMasterActivitys(new MasterActivityFilter { MasterActivityTypeId = request.MasterActivityTypeId });
            //    var codeMax = data.OrderByDescending(x => x.ActivityCode).FirstOrDefault();
            //    request.ActivityCode = codeMax.ActivityGroup + (Convert.ToInt32(codeMax.ActivityCode.Substring(1)) + 1).ToString().PadRight(2, '0');

            //    // validate MasterActivity ห้ามเลือก Title TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบ
            //    var spec = new MasterActivityLinqSearchSpec(new MasterActivityFilter());
            //    var list = await queryRepo.ListAsync(spec);

            //    if (list.Where(m => m.MasterActivityTypeId == request.MasterActivityTypeId && m.ActivityTH == request.ActivityTH).Count() > 0) {
            //        throw new ApplicationException("ไม่สามารถเลือกTitle TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบได้");
            //    } 
            //    // validate MasterActivity ห้ามเลือก Title TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบ


            //    var activity = new MasterActivity
            //    {
            //        ActivityCode = request.ActivityCode,
            //        ActivityEN = request.ActivityEN,
            //        ActivityTH = request.ActivityTH,
            //        MasterActivityTypeId = request.MasterActivityTypeId,
            //        IsActive = true,
            //        IsDelete = false,
            //        IsExport = false
            //    };

            //    await dataRepo.AddAsync(activity);
            //    await uow.SaveAsync();
            //}

            //public async Task UpdateMasterActivity(int id, MasterActivityUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null)
            //{
            //    Ensure.Any.IsNotNull(request, "MasterActivityUpdateRequest");

            //    // validate MasterActivity ห้ามเลือก Title TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบ
            //    var spec = new MasterActivityLinqSearchSpec(new MasterActivityFilter());
            //    var list = await queryRepo.ListAsync(spec);

            //    if (list.Where(m => m.MasterActivityTypeId == request.MasterActivityTypeId && m.ActivityTH == request.ActivityTH).Count() > 0)
            //    {
            //        throw new ApplicationException("ไม่สามารถเลือกTitle TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบได้");
            //    }
            //    // validate MasterActivity ห้ามเลือก Title TH  และกรอก  Activity TH ค่าซ้ำกับที่มีในระบบ

            //    var activity = await dataRepo.GetByIdAsync(id);
            //    if (activity != null)
            //    {
            //        if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ActivityCode)))
            //            activity.ActivityCode = request.ActivityCode;

            //        if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ActivityEN)))
            //            activity.ActivityEN = request.ActivityEN;

            //        if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ActivityTH)))
            //            activity.ActivityTH = request.ActivityTH;

            //        if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.MasterActivityTypeId)))
            //            activity.MasterActivityTypeId = request.MasterActivityTypeId.Value;

            //        if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.IsActive)))
            //            activity.IsActive = request.IsActive.Value;

            //        activity.IsExport = false;
            //        await uow.SaveAsync();
            //    }
            //}

            //public async Task UpdateIsExportMasterActivity(IEnumerable<MasterActivityResultDto> data)
            //{
            //    foreach(var item in data.Where(x => x.IsExportMain == false).Select(x => x.MasterActivityTypeId).Distinct())
            //    {
            //        var activity = await dataTypeRepo.GetByIdAsync(item);
            //        activity.IsExport = true;
            //    }
            //    foreach (var item in data.Where(x => x.IsExport == false).Select(x => x.Id))
            //    {
            //        var activity = await dataRepo.GetByIdAsync(item);
            //        activity.IsExport = true;
            //    }

            //    await uow.SaveAsync();
            //}

            //private void ValidateMasterActivity(IEnumerable<AssumptionCloneDto> assumptionClones)
        }
}
