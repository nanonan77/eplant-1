using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class MasterActivityType : Entity, IAggregateRoot
    {
        public string TitleEN { get; set; }
        public string TitleTH { get; set; }
        public string ActivityGroup { get; set; }
        public int Seq { get; set; }
        public bool IsExport { get; set; }

        public MasterActivityType() { }
    }
}
