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
    [Route("management-statustracking")]
    public class StatusTrackingController : ControllerBase
    {
        IMapper mapper;
        public IStatusTrackingService service;
        public BindPropertyCollection httpPatchBindPropertyCollection;

        public StatusTrackingController(IStatusTrackingService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }


        [HttpGet]
        public Task<IEnumerable<StatusTrackingSearchResultDto>> Get([FromQuery] StatusTrackingFilter filter) => service.GetStatusTrackings(filter);


        [HttpPost("upload-excel/{id}")]
        public async Task UploadExcel(Guid id, UploadNewRegistRequest request) => await service.UploadExcel(id, request);

        [AllowAnonymous]
        [HttpGet("download-file/{id}")]
        public async Task<ActionResult> DownloadFile(Guid id)
        {
            var resp = await service.DownloadFile(id);
            return File(resp.Data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", resp.Filename);
        }

    }
}
