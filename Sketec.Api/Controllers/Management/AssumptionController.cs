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
using Sketec.Application.Interfaces.Management;
using System;

namespace Sketec.Api.Controllers
{
    [ApiController]
    [Route("management-assumption")]
    public class AssumptionController : ControllerBase
    {
        IMapper mapper;
        public IAssumptionService service;

        public AssumptionController(IAssumptionService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }


        [HttpGet("{id}")]
        public Task<AssumptionDto> Get(Guid id) => service.GetAssumption(id);



        [HttpPost]
        public Task Create(AssumptionDto request) => service.CreateAssumption(request);

        [HttpPut("{id}")]
        public Task Update(Guid newRegistId, AssumptionDto request) => service.UpdateAssumption(newRegistId, request);

        [AllowAnonymous]
        [HttpGet("re-cal")]
        public Task ReCalData() => service.ReCalData();
    }
}
