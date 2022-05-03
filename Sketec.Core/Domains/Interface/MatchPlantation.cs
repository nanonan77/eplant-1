using EnsureThat;
using Sketec.Core.Domains.Types;
using Sketec.Core.Exceptions;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class MatchPlantation : EntityTransaction, IAggregateRoot
    {
        public Guid Match9999Id { get; set; }
        public Match9999 Match9999 { get; set; }

        public Guid PlantationId { get; set; }
        public Plantation Plantation { get; set; }

        public int MasterActivityId { get; set; }
        public MasterActivity MasterActivity { get; set; }

        public decimal Amount { get; set; }
    }
}
