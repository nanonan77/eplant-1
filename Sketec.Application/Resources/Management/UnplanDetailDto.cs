using Sketec.Application.Resources.Management.Assumptions;
using Sketec.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources.Management
{
    public class UnplanDetailDto
    {
        public string UserMode { get; set; } // creator, approver, viewer
        public string EmpUserName { get; set; }
        public string PicUserName { get; set; }
        public Guid UnplanId { get; set; }
        public Guid PlantationId { get; set; }
        public Guid NewRegistId { get; set; }
        public string UnplanNo { get; set; }
        public string Reason { get; set; }
        public string PlantationNo { get; set; }
        public int ContractStartYear { get; set; }
        public int ContractStartMonth { get; set; }
        public int ContractYear { get; set; }
        public int CurrentYear { get; set; }
        public string ContractType { get; set; }
        public decimal? RentalArea { get; set; }
        public int? ProductiveAreaPercent { get; set; }
        public decimal? ProductiveArea { get; set; }
        public string OverAllStatus { get; set; }
        public string ApproveStatus { get; set; }
        public string ApproveRemark { get; set; }
        public IEnumerable<UnplanHistoryDto> HistoryLog { get; set; }
        public IEnumerable<ExpenseDto> ExpenseGroupA { get; set; }
        public IEnumerable<ExpenseDto> ExpenseGroupB { get; set; }
        public IEnumerable<ExpenseDto> ExpenseGroupC { get; set; }
        public IEnumerable<ExpenseDto> ExpenseGroupD { get; set; }
        public IEnumerable<ExpenseDto> ExpenseGroupF { get; set; }
        public IEnumerable<UnplanSummary> UnplanSummary { get; set; }
    }

    public class UnplanSummary 
    { 
        public string ActivityName { get; set; }
        public decimal? TotalCost { get; set; }

    }
}
