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
using Sketec.FileReader.Excels;

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
            var spec = new MappingTransSearchSpec(filter ?? new MappingTransFilter()).IncludeAll();
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
                        Key = $"{x.Key.Year}_{x.Key.Month}_{x.Key.CostCenter}_{x.Key.CostElement}_{x.Key.RefCompanyCode}_{x.Key.FiscalYear}_{z.RefDocumentNumber}_{z.PostingRow?.ToString()}",
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

        //public async Task<Match9999Dto> GetMatch9999ForCreate(IEnumerable<Mapping9999ForCreate> request)
        //{
        //    var spec = new Mapping9999SearchByListIdSpec(request.Select(x => x.Id));
        //    var list = await mapping9999Repo.ListAsync(spec);
        //    var result = mapper.Map<List<Mapping9999>, IEnumerable<Mapping9999Dto>>(list);
        //    return new Match9999Dto
        //    {
        //        MatchDatas = result.Select(x => new MatchDataDto
        //        {
        //            Mapping9999Id = x.Id,
        //            Mapping9999s = x,
        //            ValCOAreaCrcy = x.ValCOAreaCrcy
        //        })
        //    };
        //}

        public async Task CreateMacth9999(Mapping9999CreateRequest request)
        {
            var spec = new MappingTransSearchByIdSpec(request.MappingTransId);
            var trans = await mappingTransRepo.GetBySpecAsync(spec);
            if (trans != null)
            {
                var match9999 = new Match9999
                {
                    TransactionDate = DateTime.Now.Date,
                    Status = request.type,
                    IsActive = true,
                    IsDelete = false
                };

                foreach(var item in request.Match9999s.MatchDatas)
                {
                    var matchData = new MatchData
                    {
                        Mapping9999Id = item.Mapping9999Id,
                        ValCOAreaCrcy = item.ValCOAreaCrcy,
                        IsActive = true,
                        IsDelete = false
                    };
                    match9999.AddMatchData(matchData);
                }

                foreach (var item in request.Match9999s.MatchPlantations)
                {
                    var matchPlantation = new MatchPlantation
                    {
                        PlantationId = item.PlantationId,
                        MasterActivityId = item.MasterActivityId,
                        Amount = item.Amount,
                        IsActive = true,
                        IsDelete = false
                    };
                    match9999.AddMatchPlantation(matchPlantation);
                }

                trans.AddMatch9999(match9999);
                await uow.SaveAsync();
            }
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

        public async Task UploadMapping99999Excel(Mapping99999UploadExcel request)
        {
            EnsureArg.IsInt(request.Year, "Year");
            EnsureArg.IsInt(request.Month, "Month");

            // Read File into Table Mapping99999
            var mapping9999 = Mapping99999FileReader.ReadMapping9999(request.Data);
            if (mapping9999.Any())
            {
                foreach (var item in mapping9999)
                {
                    var spec = new Mapping9999SearchSpec(new Mapping9999Filter 
                    { 
                        CostCenter = item.CostCenter, 
                        CostElement = item.CostElement,
                        RefCompanyCode = item.RefCompanyCode,
                        RefDocumentNumber = item.RefDocumentNumber,
                        PostingRow =  item.PostingRow,
                        FiscalYear = item.FiscalYear
                    });

                    var data = await mapping9999Repo.GetBySpecAsync(spec);
                    if(data != null)
                    {
                        data.Year = request.Year;
                        data.Month = request.Month;
                    }
                    else
                    {
                        data = new Mapping9999
                        {
                            Year = request.Year,
                            Month = request.Month,
                            CostCenter = item.CostCenter,
                            CostElement = item.CostElement,
                            RefCompanyCode = item.RefCompanyCode,
                            RefDocumentNumber = item.RefDocumentNumber,
                            PostingRow = item.PostingRow,
                            FiscalYear = item.FiscalYear,
                            ValCOAreaCrcy = item.ValCOAreaCrcy,
                            Name = item.Name,
                            PurchaseOrderText = item.PurchaseOrderText,
                            IsActive = true,
                            IsDelete = false
                        };

                        await mapping9999Repo.AddAsync(data);
                    }
                }
                await uow.SaveAsync();
            }
        }

    }
}
