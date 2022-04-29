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
    [Route("New-Plantation")]
    public class NewPlantationController : ControllerBase
    {
        IMapper mapper;
        public INewPlantationService service;
        public BindPropertyCollection httpPatchBindPropertyCollection;

        public NewPlantationController(INewPlantationService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public Task<NewPlantationDto> Get([FromQuery] NewRegistFilter filter) => service.GetNewPlantation(filter.Id);

        [HttpGet("list")]
        public Task<IEnumerable<NewPlantationDto>> GetPlantation([FromQuery] PlantationFilter filter) => service.GetPlantation(filter);

        [HttpPatch]
        [HttpPatchBindProperty]
        public Task UpdatePatch(NewPlantationDto request) => service.UpdateNewPlantation(request.Id.Value , request, httpPatchBindPropertyCollection);

        [HttpPut]
        public Task Update(NewPlantationDto request) => service.UpdateNewPlantation(request.Id.Value, request);

        [HttpGet("export-image-other")]
        public Task<IEnumerable<FileInfoDto>> GetNewPlantationForExportPdfImageOther([FromQuery] NewRegistFilter filter) => service.GetNewPlantationForExportPdfImageOther(filter.Id);



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
