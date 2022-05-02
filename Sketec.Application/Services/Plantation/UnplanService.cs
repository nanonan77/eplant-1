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
using Sketec.Application.Interfaces.Plantation;

namespace Sketec.Application.Services
{
    public class UnplanService : ApplicationService, IUnplanService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<Plantation> plantRepo;
        public UnplanService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<Plantation> plantRepo,
            IWCQueryRepository queryRepo)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.plantRepo = plantRepo;
        }

        public async Task<List<UnplanSearchResult>> GetUnplan(UnplanSearchFilter filter)
        {

            var spec = new UnplanLinqSearchSpec(filter ?? new UnplanSearchFilter());
            var data = await queryRepo.ListAsync(spec);

            return data;
        }

    }
}
