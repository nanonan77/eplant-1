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
    [Route("master-configuration")]
    public class MasterConfigurationController : ControllerBase
    {
        IMapper mapper;
        public IMasterConfigurationService service;
        public BindPropertyCollection httpPatchBindPropertyCollection;

        public MasterConfigurationController(IMasterConfigurationService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }


        [HttpGet]
        public Task<IEnumerable<MasterConfigurationSearchResultDto>> Get([FromQuery] MasterConfigurationFilter filter) => service.GetMasterConfiguration(filter);

        [HttpGet("{id:int}")]
        public Task<MasterConfigurationSearchResultDto> Get(int id) => service.GetMasterConfiguration(id);

        [HttpPost]
        public Task Create(MasterConfigurationCreateRequest  request) => service.CreateMasterConfiguration(request);


        [HttpPatch("{id:int}")]
        [HttpPatchBindProperty]
        public Task UpdatePatch(int id, MasterConfigurationUpdateRequest request) => service.UpdateMasterConfiguration(id, request, httpPatchBindPropertyCollection);

        [HttpPut("{id:int}")]
        public Task Update(int id, MasterConfigurationUpdateRequest request) => service.UpdateMasterConfiguration(id, request);



        [HttpGet("province")]
        public Task<IEnumerable<ProvinceSearchResultDto>> GetProvince() => service.GetProvince();

        [HttpGet("district")]
        public Task<IEnumerable<DistrictSearchResultDto>> GetDistrict() => service.GetDistrict();

        [HttpGet("sub-district")]
        public Task<IEnumerable<SubDistrictSearchResultDto>> GetSubDistrict() => service.GetSubDistrict();

        [HttpGet("feasibility-price")]
        public Task<IEnumerable<FeasibilityPriceDto>> GetFeasibilityPrice() => service.GetFeasibilityPrice();

        [HttpGet("feasibility-yield")]
        public Task<IEnumerable<FeasibilityYieldDto>> GetFeasibilityYield() => service.GetFeasibilityYield();

    }
}
