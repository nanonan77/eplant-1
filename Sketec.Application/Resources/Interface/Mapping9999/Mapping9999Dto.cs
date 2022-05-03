using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class Mapping9999Profile : Profile
    {
        public Mapping9999Profile()
        {
            CreateMap<Mapping9999, Mapping9999Dto>();
        }
    }

    public class Mapping9999Dto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string CostCenter { get; set; }
        public string CostElement { get; set; }
        public string Name { get; set; }
        public string PurchaseOrderText { get; set; }
        public string RefDocumentNumber { get; set; }
        public int PostingRow { get; set; }
        public decimal ValCOAreaCrcy { get; set; }
        public string RefCompanyCode { get; set; }
        public int FiscalYear { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
