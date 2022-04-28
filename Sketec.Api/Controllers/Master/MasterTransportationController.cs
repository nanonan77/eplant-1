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
    [Route("master-transportation")]

    public class MasterTransportationController : ControllerBase
    {
        IMapper mapper;
        public IMasterTransportationService service;
        public BindPropertyCollection httpPatchBindPropertyCollection;
        public MasterTransportationController(IMasterTransportationService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public Task<MasterTransportationSearchResultDto> Get(int id) => service.GetMasterTransportation(id);

        //[HttpPost]
        //public Task Create(MasterTransportationCreateRequest request) => service.CreateMasterTransportation(request);


        [HttpPost("{id:int}")]
        public Task Update(int id, MasterTransportationUpdateRequest request) => service.UpdateMasterTransportation(id, request);

    }
}
