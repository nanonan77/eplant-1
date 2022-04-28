using AutoMapper;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources.Management
{
    public class UnplanHistoryProfile : Profile
    {
        public UnplanHistoryProfile()
        {
            CreateMap<Unplan, UnplanHistoryDto>()
                .ForMember(d => d.PurposeBy, o => o.MapFrom(s => s.CreatedBy))
                .ForMember(d => d.PurposeDate, o => o.MapFrom(s => s.CreatedDate))
                .ForMember(d => d.PlantationId, o => o.MapFrom(s => s.PlantationId))
                .ForMember(d => d.NewRegistId, o => o.MapFrom(s => s.Plantation.NewRegistId))
                .ForMember(d => d.UnplanId, o => o.MapFrom(s => s.Id));
        }
    }
    public class UnplanHistoryDto
    {
        public Guid PlantationId { get; set; }
        public Guid NewRegistId { get; set; }
        public Guid UnplanId { get; set; }
        public string UnplanNo { get; set; }
        public string Reason { get; set; }
        public string OverAllStatus { get; set; }
        public string Approver1 { get; set; }
        public string Remark1 { get; set; }
        public string StatusApprover1 { get; set; }
        public string Approver2 { get; set; }
        public string Remark2 { get; set; }
        public string StatusApprover2 { get; set; }
        public string Approver3 { get; set; }
        public string Remark3 { get; set; }
        public string StatusApprover3 { get; set; }
        public bool IsLatest { get; set; }
        public DateTime? PurposeDate { get; set; }
        public string PurposeBy { get; set; }

    }
}
