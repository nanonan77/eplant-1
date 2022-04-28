using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class MasterConfiguration : Entity, IAggregateRoot
    {
        public string ConfigurationKey { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Remarks { get; set; }

        public MasterConfiguration() { }
    }
}
