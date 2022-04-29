using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IPlantationService : IApplicationService
    {
        Task<IEnumerable<PlantationSearchResultDto>> GetPlantations(PlantationFilter filter);

        Task UploadExcel(Guid id, UploadPlantationRequest request);
        Task<DownloadFileResponse> DownloadFile(Guid id);

        Task UploadAmortizedExcel(Guid id, UploadPlantationRequest request);
        Task<DownloadFileResponse> DownloadAmortizedFile(Guid id);

        Task UploadPlanYieldExcel(Guid id, UploadPlantationRequest request);
        Task<DownloadFileResponse> DownloadPlanYieldFile(Guid id);
        //Task UpdateDate(int id, string type, FollowingPaymentUpdateDateRequest request, BindPropertyCollection httpPatchBindProperty = null);
        //Task UpdateStatusCalling(int id, FollowingPaymentUpdateStatusRequest request, BindPropertyCollection httpPatchBindProperty = null);
        //Task UpdatePlanCashStatus(int id, FollowingPaymentUpdateStatusRequest request, BindPropertyCollection httpPatchBindProperty = null);
    }
}
