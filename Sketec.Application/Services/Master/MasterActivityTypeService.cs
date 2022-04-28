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
    public class MasterActivityTypeService : ApplicationService, IMasterActivityTypeService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<MasterActivityType> dataRepo;
        public MasterActivityTypeService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<MasterActivityType> dataRepo,
            IWCQueryRepository queryRepo)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.dataRepo = dataRepo;
        }
        public async Task<IEnumerable<MasterActivityTypeSearchResultDto>> GetMasterActivityType(MasterActivityTypeFilter filter)
        {
            var spec = new MasterActivityTypeSearchSpec(filter ?? new MasterActivityTypeFilter());
            var list = await dataRepo.ListAsync(spec);
            return mapper.Map<List<MasterActivityType>, IEnumerable<MasterActivityTypeSearchResultDto>>(list);
        }

    }
}
