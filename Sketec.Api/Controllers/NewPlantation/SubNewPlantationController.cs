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

namespace Sketec.Api.Controllers
{
    [ApiController]
    [Route("SubNew-Plantation")]
    public class SubNewPlantationController : ControllerBase
    {
        IMapper mapper;
        public ISubNewPlantationService service;
        public BindPropertyCollection httpPatchBindPropertyCollection;

        public SubNewPlantationController(ISubNewPlantationService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public Task<SubNewPlantationDto> Get([FromQuery] SubNewPlantationFilter filter) => service.GetSubNewPlantation(filter.Id);

        [HttpPost]
        public Task Create(SubNewPlantationDto request) => service.CreateSubNewPlantation(request);

        [HttpPut]
        public Task Update(SubNewPlantationDto request) => service.UpdateSubNewPlantation(request.Id, request);

        [HttpGet("export-image-other")]
        public Task<IEnumerable<FileInfoDto>> GetSubNewPlantationForExportPdfImageOther([FromQuery] NewRegistFilter filter) => service.GetSubNewPlantationForExportPdfImageOther(filter.Id);



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
