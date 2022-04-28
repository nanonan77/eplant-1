using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class AssumptionYield : EntityTransaction, IAggregateRoot
    {
        public Guid AssumptionId { get; set; }
        public int Round { get; set; }
        public decimal? Yield { get; set; }


        public Assumption Assumption { get; private set; }
    }
}
