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
    public class MatchData : EntityTransaction, IAggregateRoot
    {
        public Guid Match9999Id { get; set; }
        public Match9999 Match9999 { get; set; }

        public Guid Mapping9999Id { get; set; }
        public Mapping9999 Mapping9999 { get; set; }

        public decimal ValCOAreaCrcy { get; set; }
    }
}
