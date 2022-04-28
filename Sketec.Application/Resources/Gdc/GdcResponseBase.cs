using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources.Gdc
{
    public class GdcResponseBase
    {
        public DateTime ReferenceTime { get; set; }
        public int MessageType { get; set; }
        public string MessageTypeName { get; set; }
        public object Exception { get; set; }
        public string ReferenceToken { get; set; }
    }
}
