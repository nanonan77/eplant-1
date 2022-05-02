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
using Sketec.Application.Interfaces.Plantation;

namespace Sketec.Api.Controllers
{
    [ApiController]
    [Route("unplan")]
    public class UnplanController : ControllerBase
    {
        IMapper mapper;
        public IUnplanService service;

        public UnplanController(IUnplanService service)
        {
            this.service = service;
        }

        [HttpGet]
        public Task<List<UnplanSearchResult>> Get([FromQuery] UnplanSearchFilter filter) => service.GetUnplan(filter);


    }
}
