using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class MasterTransportationDetail : Entity, IAggregateRoot
    {
        public int Title { get; set; }
        public decimal UnitPrice { get; set; }

        public int MasterTransportationHeaderId { get; set; }
        public MasterTransportationHeader MasterTransportationHeader { get; private set; }

    }
}
