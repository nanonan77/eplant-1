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
    [AllowAnonymous]
    [Route("job")]
    public class JobController : ControllerBase
    {
        IMapper mapper;
        public IJobsService service;
        public INewRegistService newRegisService;

        public JobController(IJobsService service, INewRegistService newRegisService, IMapper mapper)
        {
            this.service = service;
            this.newRegisService = newRegisService;
            this.mapper = mapper;
        }

        [HttpGet("export-master-activity")]
        public Task ExportMasterActivity() => service.ExportMasterActivityToSharepoint();

        [HttpGet("importnewregist")]
        public Task ImportNewRegist() => service.ImportNewRegistrationFromSharepoint();

        [HttpGet("upload-image")]
        public Task UploadNewRegistImagePath() => newRegisService.UploadNewRegistImagePath();

        [HttpGet("noti-new-regist")]
        public Task NotiNewRegist() => service.NotiNewRegist();


        [HttpPost("ceateprq")]
        public void CeatePRQ() => service.CeatePRQ();
        [HttpPost("ceategr")]
        public void CeateGR() => service.CeateGR();
    }
}
