using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class Expense : EntityTransaction, IAggregateRoot
    {
        public Guid AssumptionId { get; set; }
        public int? ActivityId { get; set; }
        public ExpenseType ExpenseType { get; set; }
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
        

        public Assumption Assumption { get; private set; }
        public MasterActivity MasterActivity { get; private set; }
    }
}
