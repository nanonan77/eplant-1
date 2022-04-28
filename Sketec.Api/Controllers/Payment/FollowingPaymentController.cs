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

namespace Sketec.Api.Controllers
{
    [ApiController]
    [Route("following-payment")]
    public class FollowingPaymentController : ControllerBase
    {
        IMapper mapper;
        IFollowingPaymentService service;
        public BindPropertyCollection httpPatchBindPropertyCollection;

        public FollowingPaymentController(IFollowingPaymentService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }


        //[HttpGet]
        //public Task<IEnumerable<FollowingPaymentSearchResultDto>> Get([FromQuery] FollowingPaymentFilter filter) => service.GetFollowingPayment(filter);


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
