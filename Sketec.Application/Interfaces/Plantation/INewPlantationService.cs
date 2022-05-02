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
        Task<NewPlantationDto> GetNewPlantation(Guid newRegisID);

        Task UpdateNewPlantation(Guid newRegisID, NewPlantationUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null);
    }
}
