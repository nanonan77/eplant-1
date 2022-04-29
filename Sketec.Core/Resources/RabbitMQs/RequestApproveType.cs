using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public enum RequestApproveType : byte
    {
        Approver = 1,
        Cc = 2,
        Reviewer = 3,
        PaymentApprover = 4
    }
}
