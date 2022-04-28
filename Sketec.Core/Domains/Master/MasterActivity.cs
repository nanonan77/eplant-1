using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class MasterActivity : Entity, IAggregateRoot
    {
        public string ActivityEN { get; set; }
        public string ActivityTH { get; set; }
        public string ActivityCode { get; set; }
        public bool IsExport { get; set; }

        public int MasterActivityTypeId { get; set; }
        public MasterActivityType MasterActivityType { get; set; }

        public MasterActivity() { }

    }
}
