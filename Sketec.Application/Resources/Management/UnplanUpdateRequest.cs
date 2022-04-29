using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources.Management
{
    public class UnplanUpdateRequest
    {
        public Guid PlantationId { get; set; }
        public Guid UnplanId { get; set; }
        public string Approver { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
    }
}
