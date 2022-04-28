using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class MasterCostCenter : Entity, IAggregateRoot
    {
        public ContractType ContractType { get; set; }
        public string Zone { get; set; }
        public string Plant { get; set; }
        public string CostCenter { get; set; }

        public MasterCostCenter() { }

    }
}
