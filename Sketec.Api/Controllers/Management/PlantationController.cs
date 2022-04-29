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
    [Route("management-plantation")]
    public class PlantationController : ControllerBase
    {
        IMapper mapper;
        public IPlantationService service;
        public BindPropertyCollection httpPatchBindPropertyCollection;

        public PlantationController(IPlantationService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }


        [HttpGet]
        public Task<IEnumerable<PlantationSearchResultDto>> Get([FromQuery] PlantationFilter filter) => service.GetPlantations(filter);

        [HttpPost("upload-excel/{id}")]
        public async Task UploadExcel(Guid id, UploadPlantationRequest request) => await service.UploadExcel(id, request);


        [HttpGet("download-file/{id}")]
        public async Task<ActionResult> DownloadFile(Guid id)
        {
            var resp = await service.DownloadFile(id);
            return File(resp.Data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", resp.Filename);
        }

        [HttpPost("uploadAmortized-excel/{id}")]
        public async Task UploadAmortizedExcel(Guid id, UploadPlantationRequest request) => await service.UploadAmortizedExcel(id, request);


        [HttpGet("downloadAmortized-file/{id}")]
        public async Task<ActionResult> DownloadAmortizedFile(Guid id)
        {
            var resp = await service.DownloadAmortizedFile(id);
            return File(resp.Data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", resp.Filename);
        }



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
