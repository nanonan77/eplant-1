using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class Unplan : EntityTransaction, IAggregateRoot
    {
        public Guid PlantationId { get; set; }
        public Guid NewRegistId { get; set; }
        public string UnplanNo { get; set; }
        public string Reason { get; set; }
        public string OverAllStatus { get; set; }
        public string Approver1 { get; set; }
        public string Remark1 { get; set; }
        public string StatusApprover1 { get; set; }
        public string Approver2 { get; set; }
        public string Remark2 { get; set; }
        public string StatusApprover2 { get; set; }
        public string Approver3 { get; set; }
        public string Remark3 { get; set; }
        public string StatusApprover3 { get; set; }
        public bool IsLatest { get; set; }
        public decimal? TotalCost { get; set; }


        public Plantation Plantation { get; private set; }
        public NewRegist NewRegist { get; private set; }
    }
}
