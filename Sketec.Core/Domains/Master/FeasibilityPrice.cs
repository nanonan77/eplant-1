using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class FeasibilityPrice : Entity, IAggregateRoot
    {
        public string Mill { get; set; }
        public string PriceType { get; set; }
        public decimal Price { get; set; }

        public FeasibilityPrice() { }
    }
}
