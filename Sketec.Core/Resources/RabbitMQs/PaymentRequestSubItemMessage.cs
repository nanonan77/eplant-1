using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public class PaymentRequestSubItemMessage
    {
        public string ExpenseCode { get; set; }
        public string CostCenterCode { get; set; }
        public string InternalOrderNumber { get; set; }
        public string Assignment { get; set; }
        public decimal Amount { get; set; }
        public string Explanation { get; set; }
    }
}
