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
    public class FileInfoService : IFileInfoService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<FileInfo> fileInfoRepo;
        public FileInfoService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<FileInfo> fileInfoRepo,
            IWCQueryRepository queryRepo)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.fileInfoRepo = fileInfoRepo;
        }

        public async Task<IEnumerable<FileInfoDto>> GetFileInfos(FileInfoFilter filter)
        {
            var spec = new FileInfoSearchSpec(filter ?? new FileInfoFilter());
            var list = await fileInfoRepo.ListAsync(spec);

            return mapper.Map<List<FileInfo>, IEnumerable<FileInfoDto>>(list);
        }
        //public async Task<IEnumerable<StatusTrackingSearchResultDto>> GetStatusTracking(StatusTrackingFilter filter)
        //{
        //    var spec = new StatusTrackingSearchSpec(filter ?? new StatusTrackingFilter());
        //    var list = await dataRepo.ListAsync(spec);
        //    return mapper.Map<List<NewRegist>, IEnumerable<StatusTrackingSearchResultDto>>(list);
        //}

    }
}
