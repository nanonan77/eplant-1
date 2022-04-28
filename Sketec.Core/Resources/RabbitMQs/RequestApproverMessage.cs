using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public class RequestApproverMessage
    {
        /// <summary>
        /// username สำหรับ login
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// กรณีมีผู้อนุมัติหรือผู้ตรวจสสอบในกลุ่มเดียวกันมากว่า 1 คนต้องใส่ข้อมูลลำดับ
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// สำหรับจำแนกว่าเป็นผู้ตรวจสอบ,ผู้อนุมัติ หรืออื่นๆที่กำหนดให้
        /// </summary>
        public RequestApproveType Type { get; set; }
        public DateTimeOffset ActionDate { get; set; }
    }
}
