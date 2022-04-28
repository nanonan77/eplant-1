using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface ITestNewRegistService : IApplicationService
    {
        Task<NewRegistDto> GetNewRegist(Guid newRegisID);
        Task<IEnumerable<NewRegistImagePathDto>> GetImage(Guid id);

        Task UpdateNewRegist(Guid newRegisID, NewRegistUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null);
        Task SavePDF(NewRegistDto request);
        Task<NewRegistDto> GetNewRegistForExportPdf(Guid newRegisID);
        Task<IEnumerable<NewRegistImagePathDto>> GetNewRegistForExportPdfImage(Guid newRegisID);
        Task<IEnumerable<FileInfoDto>> GetNewRegistForExportPdfImageOther(Guid newRegisID);
        Task<byte[]> Pdf();

        Task<FileResponseDto> GetPDF(Guid id);
        Task<byte[]> GetCashFlow(Guid id);
    }
}
