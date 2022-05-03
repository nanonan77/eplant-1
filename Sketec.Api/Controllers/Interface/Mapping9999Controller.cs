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
    [Route("mapping9999")]
    public class Mapping9999Controller : ControllerBase
    {
        IMapper mapper;
        public IMapping9999Service service;
        public BindPropertyCollection httpPatchBindPropertyCollection;

        public Mapping9999Controller(IMapping9999Service service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("trans/{id}")]
        public Task<MappingTransDto> GetTransId(Guid id) => service.GetMappingTrans(id);

        [HttpGet("trans")]
        public Task<IEnumerable<MappingTransDto>> GetTrans([FromQuery] MappingTransFilter filter) => service.GetMappingTrans(filter);


        [HttpPost("trans")]
        public Task<Guid> PostTrans() => service.CreateMappingTrans();


        //[HttpGet("{id:int}")]
        //public Task<MasterActivitySearchResultDto> Get(int id) => service.GetMasterActivity(id);

        //[HttpPost]
        //public Task Create(MasterActivityCreateRequest request) => service.CreateMasterActivity(request);


        //[HttpPatch("{id:int}")]
        //[HttpPatchBindProperty]
        //public Task UpdatePatch(int id, MasterActivityUpdateRequest request) => service.UpdateMasterActivity(id, request, httpPatchBindPropertyCollection);

        //[HttpPut("{id:int}")]
        //public Task Update(int id, MasterActivityUpdateRequest request) => service.UpdateMasterActivity(id, request);

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
