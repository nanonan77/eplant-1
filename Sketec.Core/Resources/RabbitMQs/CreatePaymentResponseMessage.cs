using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public class CreatePaymentResponseMessage
    {
        public Guid Id { get; set; }
        /// <summary>
        /// หมายเลขเอกสาร
        /// </summary>
        public string RequestNo { get; set; }
        public string RefNo { get; set; }
        /// <summary>
        /// สถานะเอกสารที่สร้างได้ได้ในระบบ
        /// </summary>
        public string Status { get; set; }
        public bool IsSuccess { get; set; }
        /// <summary>
        /// ข้อความตอบกลับกรณีสร้างเอกสารไม่สำเร็จหรือมี error
        /// </summary>
        public string Message { get; set; }
    }
}
