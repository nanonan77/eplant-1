using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources
{
    public class AssumptionYieldDto
    {
        public Guid Id { get; set; }
        public Guid AssumptionId { get; set; }
        public int Round { get; set; }
        public decimal? Yield { get; set; }
    }
}
