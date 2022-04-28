using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public class TaxMessage
    {
        /// <summary>
        /// Rat ต้องเป็น Rat ที่มีในฐานข้อมูลของระบบ AllPay
        /// </summary>
        public decimal Rate { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal VatAmount { get; set; }
    }
}
