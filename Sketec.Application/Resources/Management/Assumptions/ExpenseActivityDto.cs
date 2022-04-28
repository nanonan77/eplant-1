using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources.Management.Assumptions
{
    public class ExpenseActivityDto: CostEachYearDto
    {
        public Guid Id { get; set; }
        public Guid ExpenseId { get; set; }

    }

    public class CostEachYearDto
    {
        public int Year { get; set; }
        public decimal? Cost { get; set; }
    }
}
