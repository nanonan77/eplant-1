using AutoMapper;
using Sketec.Application.Resources.Management.Assumptions;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources
{
    public class AssumptionProfile : Profile
    {
        public AssumptionProfile()
        {
            CreateMap<Assumption, AssumptionDto>()
                .ForMember(d => d.AssumptionYields, o => o.MapFrom(s => s.AssumptionYields))
                .ForMember(d => d.AssumptionClones, o => o.MapFrom(s => s.AssumptionClones))
                .ForMember(d => d.ExpenseGroupA, o => o.MapFrom(s => s.Expenses.Where(p => p.ExpenseType == ExpenseType.ActivityGroupA && !p.IsUnplan)))
                .ForMember(d => d.ExpenseGroupB, o => o.MapFrom(s => s.Expenses.Where(p => p.ExpenseType == ExpenseType.ActivityGroupB && !p.IsUnplan)))
                .ForMember(d => d.ExpenseGroupC, o => o.MapFrom(s => s.Expenses.Where(p => p.ExpenseType == ExpenseType.ActivityGroupC && !p.IsUnplan)))
                .ForMember(d => d.ExpenseGroupD, o => o.MapFrom(s => s.Expenses.Where(p => p.ExpenseType == ExpenseType.ActivityGroupD && !p.IsUnplan)))
                .ForMember(d => d.ExpenseGroupF, o => o.MapFrom(s => s.Expenses.Where(p => p.ExpenseType == ExpenseType.ActivityGroupF && !p.IsUnplan)))
                .ForMember(d => d.CostIncreaseYear, o => o.MapFrom(s => s.Expenses.Where(p => p.ExpenseType == ExpenseType.CostIncrease && !p.IsUnplan)))
                .ForMember(d => d.ContractType, s => s.MapFrom(o => o.NewRegist.ContractType))
                .ForMember(d => d.RegistNo, s => s.MapFrom(o => o.NewRegist.RegistId))
                .ForMember(d => d.RegistName, s => s.MapFrom(o => o.NewRegist.Title))
                .ForMember(d => d.Rainfall, s => s.MapFrom(o => string.Join("/", o.NewRegist.SubNewRegists.Where(x => x.Rainfall.HasValue && x.Rainfall != 0).Select(x => x.Rainfall.Value.ToString("#,##0.00")))))
                .ForMember(d => d.SoilType, s => s.MapFrom(o => string.Join(",", o.NewRegist.SubNewRegists.Where(x => !string.IsNullOrWhiteSpace(x.SoilType)).Select(x => x.SoilType))))
                .ForMember(d => d.PlanVolume, s => s.MapFrom(o => o.NewRegist.PlanVolume))
                .IncludeAllDerived();

            CreateMap<AssumptionYield, AssumptionYieldDto>();
            CreateMap<AssumptionClone, AssumptionCloneDto>();
            CreateMap<NewRegist, NewRegistDto>();
            CreateMap<Expense, ExpenseDto>()
                .ForMember(d => d.ActivityName, s => s.MapFrom(o => o.MasterActivity.ActivityTH))
                .ForMember(d => d.ActivityTypeId, s => s.MapFrom(o => o.MasterActivity.MasterActivityTypeId))
                .ForMember(d => d.ActivityGroup, s => s.MapFrom(o => o.MasterActivity.MasterActivityType.ActivityGroup))
                .ForMember(d => d.ActivityTypeName, s => s.MapFrom(o => o.MasterActivity.MasterActivityType.TitleTH));


        }

    }
    public class AssumptionDto
    {
        public Guid Id { get; set; }
        public Guid NewRegistId { get; set; }
        public string RegistNo { get; set; }
        public string RegistName { get; set; }
        public int ContractYear { get; set; }
        public string ContractType { get; set; }
        public decimal? RentalArea { get; set; }
        public int? ProductiveAreaPercent { get; set; }
        public decimal? ProductiveArea { get; set; }
        public string Rainfall { get; set; }
        public string SoilType { get; set; }
        public int CuttingRound { get; set; }
        public decimal? DistanceToPlant { get; set; }
        public string Mill { get; set; }
        public decimal? AveragePrice { get; set; }
        public decimal? MtpPrice { get; set; }
        public decimal? FcPrice { get; set; }
        public int? CuttingCostTypeId { get; set; }
        public decimal? CuttingCost { get; set; }
        public int? FreightTypeId { get; set; }
        public decimal? Freight { get; set; }
        public decimal? InflationRate { get; set; }
        public decimal? PlanVolume { get; set; }


        public IEnumerable<AssumptionYieldDto> AssumptionYields { get; set; }
        public IEnumerable<AssumptionCloneDto> AssumptionClones { get; set; }
        public IEnumerable<ExpenseDto> ExpenseGroupA { get; set; }
        public IEnumerable<ExpenseDto> ExpenseGroupB { get; set; }
        public IEnumerable<ExpenseDto> ExpenseGroupC { get; set; }
        public IEnumerable<ExpenseDto> ExpenseGroupD { get; set; }
        public IEnumerable<ExpenseDto> ExpenseGroupF { get; set; }
        public IEnumerable<ExpenseDto> CostIncreaseYear { get; set; }
        public NewRegistDto NewRegist { get; set; }
    }
}
