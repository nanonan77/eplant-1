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

namespace Sketec.Application.Services
{
    public class RollingPlanService : ApplicationService, IRollingPlanService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<RollingPlan> dataRepo;
        public RollingPlanService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<RollingPlan> dataRepo,
            IWCQueryRepository queryRepo)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.dataRepo = dataRepo;
        }
        public async Task<IEnumerable<RollingPlanSearchResultDto>> GetRollingPlans(RollingPlanFilter filter)
        {
            var spec = new RollingPlanLinqSearchSpecLinqSearchSpec(filter ?? new RollingPlanFilter());
            var list = await queryRepo.ListAsync(spec);

            return list;

        }
        //public async Task<IEnumerable<StatusTrackingSearchResultDto>> GetStatusTracking(StatusTrackingFilter filter)
        //{
        //    var spec = new StatusTrackingSearchSpec(filter ?? new StatusTrackingFilter());
        //    var list = await dataRepo.ListAsync(spec);
        //    return mapper.Map<List<NewRegist>, IEnumerable<StatusTrackingSearchResultDto>>(list);
        //}

    }
}
