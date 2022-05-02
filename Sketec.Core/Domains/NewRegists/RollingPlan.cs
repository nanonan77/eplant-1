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
    public class RollingPlan : EntityTransaction, IAggregateRoot
    {
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? Area { get; set; }
        public decimal? ActualArea { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        public Guid? SubPlantationId { get; set; }
        public SubPlantation SubPlantation { get; private set; }

        public int? MasterActivityId { get; set; }
        public MasterActivity MasterActivity { get; private set; }

    }
}
