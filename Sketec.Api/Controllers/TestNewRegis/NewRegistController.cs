using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sketec.Application.Filters;
using Sketec.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Sketec.Api.Controllers
{
    [ApiController]
    [Route("New-Regist")]
    public class NewRegistController : ControllerBase
    {
        IMapper mapper;
        public ITestNewRegistService service;
        public BindPropertyCollection httpPatchBindPropertyCollection;

        public NewRegistController(ITestNewRegistService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public Task<NewRegistDto> Get([FromQuery] NewRegistFilter filter) => service.GetNewRegist(filter.Id);

        [HttpGet("image")]
        public Task<IEnumerable<NewRegistImagePathDto>> GetImage([FromQuery] NewRegistFilter filter) => service.GetImage(filter.Id);

        [HttpPatch]
        [HttpPatchBindProperty]
        public Task UpdatePatch(NewRegistUpdateRequest request) => service.UpdateNewRegist(request.Id, request, httpPatchBindPropertyCollection);

        [HttpPut]
        public Task Update(NewRegistUpdateRequest request) => service.UpdateNewRegist(request.Id, request);



        [HttpPost("save-pdf")]
        public async Task SavePDF(NewRegistDto request) => await service.SavePDF(request);


        [HttpPost("pdf")]
        public ActionResult Pdf() => File(service.Pdf().Result, "application/pdf", "pdf_file_name.pdf");

        [HttpPost("cash-flow/{id}")]
        public ActionResult GetCashFlow(Guid id) => File(service.GetCashFlow(id).Result, "application/pdf", "cash_flow.pdf");

        [HttpPost("get-pdf/{id}")]
        public ActionResult GetPDF(Guid id)
        {
            var res = service.GetPDF(id).Result;
            return File(res.File, "application/pdf", res.FileName+".pdf");
        }

        [HttpGet("export")]
        public Task<NewRegistDto> GetNewRegistForExportPdf([FromQuery] NewRegistFilter filter) => service.GetNewRegistForExportPdf(filter.Id);

        [HttpGet("export-image")]
        public Task<IEnumerable<NewRegistImagePathDto>> GetNewRegistForExportPdfImage([FromQuery] NewRegistFilter filter) => service.GetNewRegistForExportPdfImage(filter.Id);

        [HttpGet("export-image-other")]
        public Task<IEnumerable<FileInfoDto>> GetNewRegistForExportPdfImageOther([FromQuery] NewRegistFilter filter) => service.GetNewRegistForExportPdfImageOther(filter.Id);
        //[HttpPatchBindProperty]
        //[HttpPatch("update-date/{id:int}/{type}")]
        //public async Task<ActionResult> UpdatePayDate(int id, string type, FollowingPaymentUpdateDateRequest request)
        //{
        //    await service.UpdateDate(id, type, request, httpPatchBindPropertyCollection);
        //    return NoContent();
        //}

        //[HttpPatchBindProperty]
        //[HttpPatch("update-status-calling/{id:int}")]
        //public async Task<ActionResult> UpdateStatusCalling(int id, FollowingPaymentUpdateStatusRequest request)
        //{
        //    await service.UpdateStatusCalling(id, request, httpPatchBindPropertyCollection);
        //    return NoContent();
        //}
        //[HttpPatchBindProperty]
        //[HttpPatch("update-status-plan-cash/{id:int}")]
        //public async Task<ActionResult> UpdatePlanCashStatus(int id, FollowingPaymentUpdateStatusRequest request)
        //{
        //    await service.UpdatePlanCashStatus(id, request, httpPatchBindPropertyCollection);
        //    return NoContent();
        //}

    }
}
