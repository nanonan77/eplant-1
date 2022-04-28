using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface ISubNewPlantationService : IApplicationService
    {
        Task<SubNewPlantationDto> GetSubNewPlantation(Guid newRegisID);

        Task CreateSubNewPlantation(SubNewPlantationDto request);

        Task UpdateSubNewPlantation(Guid subNewRegisID, SubNewPlantationDto request, BindPropertyCollection httpPatchBindProperty = null);

        Task<IEnumerable<FileInfoDto>> GetSubNewPlantationForExportPdfImageOther(Guid newRegisID);

    }
}
