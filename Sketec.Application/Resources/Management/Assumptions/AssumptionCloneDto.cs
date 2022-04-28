using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources
{
    public class AssumptionCloneDto
    {
        public Guid Id { get; set; }
        public Guid AssumptionId { get; set; }
        public string Clone { get; set; }
        public decimal? Portion { get; set; }
        public decimal? Area { get; set; }
        public decimal? ProductTon { get; set; }

    }
}
