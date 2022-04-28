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
    public class PlantationAmortized : EntityTransaction, IAggregateRoot
    {
        public DateTime? DueDate { get; set; }
        public decimal? CashPaid { get; set; }
        public decimal? MonthlyRental { get; set; }
        public decimal? Interest { get; set; }
        public decimal? Depreciation { get; set; }
        public Guid PlantationId { get; set; }
        public Plantation Plantation { get; set; }
    }
}
