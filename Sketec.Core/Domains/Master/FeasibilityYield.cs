using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class FeasibilityYield : Entity, IAggregateRoot
    {
        public string SoilType { get; set; }
        public int? RainfallStart { get; set; }
        public int? RainfallEnd { get; set; }
        public decimal Yield { get; set; }

        public FeasibilityYield() { }
    }
}
