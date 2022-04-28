using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{ 
    public interface IMasterTransportationService : IApplicationService
    {
        Task<MasterTransportationSearchResultDto> GetMasterTransportation(int id);
        Task CreateMasterTransportation(MasterTransportationCreateRequest request);
        Task UpdateMasterTransportation(int id, MasterTransportationUpdateRequest request);
    }
}
