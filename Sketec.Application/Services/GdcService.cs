using AutoMapper;
using EnsureThat;
using Microsoft.Extensions.Logging;
using Sketec.Application.Interfaces;
using Sketec.Application.Resources.Gdc;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources.Gdc;
using Sketec.Core.Shared;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Services
{
    public class GdcService : IGdcService
    {
        ILogger<GdcService> logger;
        IGdcApiService gdcApiService;
        GdcApiOptions gdcOption;
        public GdcService(
            ILogger<GdcService> logger,
            IGdcApiService gdcApiService,
            GdcApiOptions gdcOption)
        {
            this.logger = logger;
            this.gdcApiService = gdcApiService;
            this.gdcOption = gdcOption;
        }
        public async Task<EmployeeInfoByADAccount> GetEmployeeInfoByADAccount(string userName)
        {
            try
            {
                var token = await gdcApiService.GetAccessToken();
                var request = new EmployeeInfoByADAccountRequest
                {
                    Username = userName,
                    ReferenceToken = token
                };
                var path = $"/Api/GDCEmployeeInfo/EmployeeInfoByADUser"; // ?api_key=da0e0de7062945219df595902fd990e7
                var resp = await gdcApiService.Post<EmployeeInfoByADAccountRequest, EmployeeInfoByADAccountResponse>(path, request);

                Ensure.Any.IsNotNull(resp, "EmployeeInfoByADAccountResponse");
                Ensure.Any.IsNotNull(resp.ResponseBase, "ResponseBase");
                Ensure.Any.IsNotNull(resp.ResponseData, "ResponseData");
                if (resp.ResponseBase.MessageType != 0)
                {
                    throw new Exception(resp.ResponseBase.MessageTypeName);
                }
                return resp.ResponseData?.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<MembersInfoByADAccount> GetMembersInfoByADAccount(string userName)
        {
            try
            {
                var token = await gdcApiService.GetAccessToken();
                var request = new MembersInfoByADAccountRequest
                {
                    Domain = gdcOption.Domain,
                    AdAccount = userName,
                    ReferenceToken = token
                };
                var path = $"/Api/GDCEmployeeInfo/MembersInfoByADAccount"; // ?api_key=da0e0de7062945219df595902fd990e7
                var resp = await gdcApiService.Post<MembersInfoByADAccountRequest, MembersInfoByADAccountResponse>(path, request);

                Ensure.Any.IsNotNull(resp, "MembersInfoByADAccountResponse");
                Ensure.Any.IsNotNull(resp.ResponseBase, "ResponseBase");
                Ensure.Any.IsNotNull(resp.ResponseData, "ResponseData");
                if (resp.ResponseBase.MessageType != 0) 
                {
                    throw new Exception(resp.ResponseBase.MessageTypeName);
                }
                return resp.ResponseData?.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<EmployeeOrgChartByOrganizationId>> GetEmployeeOrgChartByOrganizationId(int organizationId)
        {
            try
            {
                var token = await gdcApiService.GetAccessToken();
                var request = new EmployeeOrgChartByOrganizationIdDoaIdRequest
                {
                    ReferenceToken = token,
                    OrganizationId = organizationId
                };
                var resp = await gdcApiService.Post<EmployeeOrgChartByOrganizationIdDoaIdRequest, EmployeeOrgChartByOrganizationIdDoaIdResponse>("/Api/GDCEmployeeInfo/EmployeeOrgChartByOrganizationIdDoaId", request);

                Ensure.Any.IsNotNull(resp, "EmployeeOrgChartByOrganizationIdDoaIdResponse");
                Ensure.Any.IsNotNull(resp.ResponseBase, "ResponseBase");
                Ensure.Any.IsNotNull(resp.ResponseData, "ResponseData");
                if (resp.ResponseBase.MessageType != 0)
                {
                    throw new Exception(resp.ResponseBase.MessageTypeName);
                }
                return resp.ResponseData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<EmployeesByPersonnelNumberList>> GetEmployeesByPersonnelNumberList(string personnelNumberList)
        {
            try
            {
                var token = await gdcApiService.GetAccessToken();
                var request = new EmployeesByPersonnelNumberListRequest
                {
                    ReferenceToken = token,
                    PersonnelNumberList = personnelNumberList
                };
                var resp = await gdcApiService.Post<EmployeesByPersonnelNumberListRequest, EmployeesByPersonnelNumberListResponse>("/Api/GDCEmployeeInfo/EmployeesByPersonnelNumberList", request);

                Ensure.Any.IsNotNull(resp, "EmployeesByPersonnelNumberListResponse");
                Ensure.Any.IsNotNull(resp.ResponseBase, "ResponseBase");
                Ensure.Any.IsNotNull(resp.ResponseData, "ResponseData");
                if (resp.ResponseBase.MessageType != 0)
                {
                    throw new Exception(resp.ResponseBase.MessageTypeName);
                }
                return resp.ResponseData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
