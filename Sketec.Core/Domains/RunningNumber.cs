using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class RunningNumber : Entity, IAggregateRoot
    {
        public string Topic { get; set; }
        public int? Year { get; set; }
        public string Temp1 { get; set; }
        public string Temp2 { get; set; }
        public string Temp3 { get; set; }
        public int Running { get; set; }

        private RunningNumber() { }

        public RunningNumber(string topic)
        {
            Topic = topic;
        }
    }
}
