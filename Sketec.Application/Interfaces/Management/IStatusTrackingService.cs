using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IStatusTrackingService : IApplicationService
    {
        Task<IEnumerable<StatusTrackingSearchResultDto>> GetStatusTrackings(StatusTrackingFilter filter);
        Task UploadExcel(Guid id, UploadNewRegistRequest request);
        Task<DownloadFileResponse> DownloadFile(Guid id);
        //Task UpdateDate(int id, string type, FollowingPaymentUpdateDateRequest request, BindPropertyCollection httpPatchBindProperty = null);
        //Task UpdateStatusCalling(int id, FollowingPaymentUpdateStatusRequest request, BindPropertyCollection httpPatchBindProperty = null);
        //Task UpdatePlanCashStatus(int id, FollowingPaymentUpdateStatusRequest request, BindPropertyCollection httpPatchBindProperty = null);
    }
} 
