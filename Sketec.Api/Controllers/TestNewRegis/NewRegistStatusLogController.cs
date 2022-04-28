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
    [Route("New-Regist-StatusLog")]
    public class NewRegistStatusLogController : ControllerBase
    {
        IMapper mapper;
        public ITestNewRegistStatusLogService service;
        public BindPropertyCollection httpPatchBindPropertyCollection;

        public NewRegistStatusLogController(ITestNewRegistStatusLogService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public Task<IEnumerable<NewRegistStatusLogResultDto>> Get([FromQuery] NewRegistStatusLogFilter filter) => service.GetNewRegistStatusLogs(filter);

        [HttpPost]
        public Task Create(IEnumerable<NewRegistStatusLogCreateRequest> request) => service.CreateNewRegistStatusLog(request);

    }
}
