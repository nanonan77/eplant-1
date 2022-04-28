using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public class AlternativePayeeMessage
    {
        public decimal Amount { get; set; }
        public string VendorCode { get; set; }
    }
}
