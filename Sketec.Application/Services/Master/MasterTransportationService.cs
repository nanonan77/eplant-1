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
    public class MasterTransportationService : ApplicationService, IMasterTransportationService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<MasterTransportationHeader> dataRepo;

        public MasterTransportationService(
           IMapper mapper,
           IWCUnitOfWork uow,
           IWCDapperRepository dapper,
           IWCRepository<MasterTransportationHeader> dataRepo,
           IWCQueryRepository queryRepo)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.dataRepo = dataRepo;
        }

        public async Task<MasterTransportationSearchResultDto> GetMasterTransportation(int id)
        {
            var spec = new MasterTransportationSearchByIdSpec(id).InCludeDetail();
            var list = await dataRepo.GetBySpecAsync(spec);
            var result = mapper.Map<MasterTransportationSearchResultDto>(list);
            return result;
        }

        public async Task CreateMasterTransportation(MasterTransportationCreateRequest request)
        {
            //Ensure.Any.IsNotNull(request, "MasterTransportationCreateRequest");
            //var transportation = new MasterTransportationHeader(request.TruckType)
            //{
            //    FreightMin = request.FreightMin,
            //    FreightMax = request.FreightMax
            //};

            //foreach (var item in request.MasterTransportationDetails)
            //{
            //    var data = new MasterTransportationDetail
            //    {
            //        Title = item.Title,
            //        UnitPrice = item.UnitPrice,
                    
            //    };
            //    transportation.AddMasterTransportationDetail(item);
            //}
            //await dataRepo.AddAsync(transportation);
            //await uow.SaveAsync();
        }


        public async Task UpdateMasterTransportation(int id, MasterTransportationUpdateRequest request)
        {
            var spec = new MasterTransportationSearchByIdSpec(id).InCludeDetail();
            var result = await dataRepo.GetBySpecAsync(spec);
            if (result == null) {
                return;
            }
            result.FreightMax = request.FreightMax;
            result.FreightMin = request.FreightMin;
            foreach (var item in result.MasterTransportationDetails)
            {
                item.IsActive = false;
            }
            foreach (var item in request.MasterTransportationDetails)
            {
                var detail = result.MasterTransportationDetails.FirstOrDefault(f => f.Id == item.Id);
                if (detail == null)
                {
                    detail = new MasterTransportationDetail
                    {
                       Title = item.Title,
                       UnitPrice = item.UnitPrice
                    };
                    result.AddMasterTransportationDetail(detail);
                }
                else
                {
                    detail.Title = item.Title;
                    detail.UnitPrice = item.UnitPrice;
                }

                detail.IsActive = true;
            }
            foreach (var item in result.MasterTransportationDetails.Where(r => r.IsActive == false).ToList())
            {
                result.RemoveMasterTransportationDetail(item);
            }

            await uow.SaveAsync();
        }

    }
}
