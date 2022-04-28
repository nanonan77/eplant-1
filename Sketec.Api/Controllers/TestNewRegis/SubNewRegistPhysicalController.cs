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
    [Route("SubNew-RegistTestPlot")]
    public class SubNewRegistPhysicalController : ControllerBase
    {
        IMapper mapper;
        public ITestSubNewRegistPhysicalService service;
        public BindPropertyCollection httpPatchBindPropertyCollection;

        public SubNewRegistPhysicalController(ITestSubNewRegistPhysicalService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public Task<SubNewRegistTestPlotDto> Get([FromQuery] SubNewRegistTestPlotFilter filter) => service.GetSubNewRegistTestPlot(filter.Id);

        [HttpGet("image")]
        public Task<IEnumerable<NewRegistImagePathDto>> GetImage([FromQuery] SubNewRegistTestPlotFilter filter) => service.GetImage(filter.Id);


        [HttpPut]
        public Task Update(SubNewRegistTestPlotUpdateRequest request) => service.UpdateSubNewRegistTestPlot(request.Id, request);

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
