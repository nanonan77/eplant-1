using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class ExpenseActivity : EntityTransaction, IAggregateRoot
    {
        public Guid ExpenseId { get; set; }
        public int Year { get; set; }
        public decimal? Cost { get; set; }

        public Expense Expense { get; private set; }
    }
}
