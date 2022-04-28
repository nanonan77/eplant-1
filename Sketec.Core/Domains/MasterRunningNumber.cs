using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class MasterRunningNumber : Entity, IAggregateRoot
    {
        public string Topic { get; set; }
        public string Template { get; set; }
        public int Digit { get; set; }

        public MasterRunningNumber() { }
    }
}
