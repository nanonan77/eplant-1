using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    /// <summary>
    /// รายการสถานะที่สามารถส่งเข้ามาเพื่อสร้างเอกสารในระบบ VendorPayment
    /// </summary>
    public enum StandartStatus
    {
        Draft,
        WaitforApproverApprove,
        PRQ_WaitforAccountantVerify,
    }
}
