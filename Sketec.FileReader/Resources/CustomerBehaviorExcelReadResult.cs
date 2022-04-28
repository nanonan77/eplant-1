using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.FileReader.Resources
{
    public class CustomerBehaviorExcelReadResult
    {
        public string RuleType { get; set; }
        public string CustomerCode { get; set; }
        public string SalesOrg { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public int? Id { get; set; }
        public string PaymentTerm { get; set; }
        public DateTime? ValidDateFrom { get; set; }
        public DateTime? ValidDateTo { get; set; }
        public string ConditionDate { get; set; }
        public int? XDayFromConditionDate { get; set; }
        public int? ConditionPeriodFrom { get; set; }
        public int? ConditionPeriodTo { get; set; }
        public bool IsAllPaymentTerm { get; set; }
        public bool IsCountTerm { get; set; }
        public string TermType { get; set; }
        public string BehaviorDescription { get; set; }
        public bool IsCustomerHoliday { get; set; }
        public bool IsScgHoliday { get; set; }
        public string BusinessDay { get; set; }
        public string PosepontType { get; set; }
        public string CalculationConditionBy { get; set; }
        public string FixDayType { get; set; } // เงินเข้าทันที/หลัง  เฉพาะ ycal
        public int? FixDay { get; set; }
        public bool IsFixBusinessDay { get; set; }
        public string DateDayConditionBy { get; set; }
        public int? DateFrom { get; set; }
        public int? DateTo { get; set; }
        public string CustomDate { get; set; }
        public string CustomDay { get; set; }
        public int? LastXDay { get; set; }
        public int? LastXDayBusiness { get; set; }
        public int? FirstXDay { get; set; }
        public int? FirstXDayBusiness { get; set; }
        public string WeekConditionBy { get; set; }
        public string CountWeekBy { get; set; }
        public int? CountWeekStartDay { get; set; }
        public string WeekFor4 { get; set; }
        public string WeekFor5 { get; set; }
        public int? NextWeek { get; set; }
        public string MonthConditionBy { get; set; }
        public string CustomMonth { get; set; }
        public int? NextMonth { get; set; }
        public DateTime? CustomDatePeriodFrom { get; set; }
        public DateTime? CustomDatePeriodTo { get; set; }
        public DateTime? CustomDateFrom { get; set; }
        public DateTime? CustomDateTo { get; set; }
        public int? NotifyDate { get; set; }
        public int Group { get; set; }
        public int? DayFrom { get; set; }
        public int? DayTo { get; set; }
        public int? Day { get; set; }
        public int? NextDayPeriod { get; set; }
    }


}
