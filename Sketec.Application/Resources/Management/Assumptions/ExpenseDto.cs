using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources.Management.Assumptions
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseDto>()
                .ForMember(d => d.ActivityName, s => s.MapFrom(o => o.MasterActivity.ActivityTH))
                .ForMember(d => d.ActivityTypeId, s => s.MapFrom(o => o.MasterActivity.MasterActivityTypeId))
                .ForMember(d => d.ActivityGroup, s => s.MapFrom(o => o.MasterActivity.MasterActivityType.ActivityGroup))
                .ForMember(d => d.ActivityTypeName, s => s.MapFrom(o => o.MasterActivity.MasterActivityType.TitleTH));


        }

    }
    public class ExpenseDto
    {
        public Guid Id { get; set; }
        public Guid AssumptionId { get; set; }
        public int ActivityId { get; set; }
        public string ActivityGroup { get; set; }
        public string ActivityName { get; set; }
        public int ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public string ExpenseTypeValues => ExpenseType.GetStringValue();
        public string ExpenseTypeDescription => ExpenseType.GetDescription();
        public decimal? BahtPerRai { get; set; }
        public decimal? YearCost1 { get; set; }
        public decimal? YearCost2 { get; set; }
        public decimal? YearCost3 { get; set; }
        public decimal? YearCost4 { get; set; }
        public decimal? YearCost5 { get; set; }
        public decimal? YearCost6 { get; set; }
        public decimal? YearCost7 { get; set; }
        public decimal? YearCost8 { get; set; }
        public decimal? YearCost9 { get; set; }
        public decimal? YearCost10 { get; set; }
        public decimal? YearCost11 { get; set; }
        public decimal? YearCost12 { get; set; }
        public decimal? YearCost13 { get; set; }
        public decimal? YearCost14 { get; set; }
        public decimal? YearCost15 { get; set; }
        public bool IsUnplan { get; set; }
        public bool IsLatest { get; set; }
        public Guid? UnplanId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
