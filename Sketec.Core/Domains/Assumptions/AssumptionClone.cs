using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class AssumptionClone : EntityTransaction, IAggregateRoot
    {
        public Guid AssumptionId { get; set; }
        public string Clone { get; set; }
        public decimal? Portion { get; set; }
        public decimal? Area { get; set; }
        public decimal? ProductTon { get; set; }


        public Assumption Assumption { get; private set; }
    }
}
