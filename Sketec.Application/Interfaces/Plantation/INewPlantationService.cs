using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface INewPlantationService : IApplicationService
    {
        Task<IEnumerable<NewPlantationDto>> GetPlantation(PlantationFilter filter);
        Task<NewPlantationDto> GetNewPlantation(Guid newRegisID);

        Task UpdateNewPlantation(Guid newRegisID, NewPlantationDto request, BindPropertyCollection httpPatchBindProperty = null);

        Task<IEnumerable<FileInfoDto>> GetNewPlantationForExportPdfImageOther(Guid newRegisID);
    }
}
