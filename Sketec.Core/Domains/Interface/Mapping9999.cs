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
    public class Mapping9999 : EntityTransaction, IAggregateRoot
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string CostCenter { get; set; }
        public string CostElement { get; set; }
        public string Name { get; set; }
        public string PurchaseOrderText { get; set; }
        public string RefDocumentNumber { get; set; }
        public int PostingRow { get; set; }
        public decimal ValCOAreaCrcy { get; set; }
        public string RefCompanyCode { get; set; }
        public int FiscalYear { get; set; }
    }
}
