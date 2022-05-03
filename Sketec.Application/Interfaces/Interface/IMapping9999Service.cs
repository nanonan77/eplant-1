using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IMapping9999Service : IApplicationService
    {
        Task<MappingTransDto> GetMappingTrans(Guid id);
        Task<IEnumerable<MappingTransDto>> GetMappingTrans(MappingTransFilter filter);
        Task<IEnumerable<Mapping9999SearchDto>> GetMapping9999(Mapping9999Filter filter);

        Task<Match9999Dto> GetMatch9999(Guid id);
        Task CreateMatch9999(Guid mappingTransId, Match9999Dto request);
        Task UpdateMatch9999(Match9999Dto request);

        Task<Guid> CreateMappingTrans();
    }
}
