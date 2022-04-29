using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public class PaymentRequestItemMessage
    {
        public PaymentRequestItemMessage()
        {
            Po = new List<string>();
            FileRelationDataList = new List<FileInfoDataMessage>();
            WHTDataList = new List<TaxMessage>();
            PaymentRequestSubItemList = new List<PaymentRequestSubItemMessage>();
        }
        /// <summary>
        /// DocumentType Code
        /// </summary>
        public string DocumentType { get; set; }
        public List<string> Po { get; set; }
        public string DocumentNo { get; set; }
        public DateTimeOffset DocumentDate { get; set; }
        public decimal Amount { get; set; }
        public string Reference1 { get; set; }
        public List<FileInfoDataMessage> FileRelationDataList { get; set; }
        public bool IsOneTimeVendor { get; set; }
        public string VendorCode { get; set; }
        /// <summary>
        /// ใส่ข้อมูลกรณีเป็น Vendor Onetime
        /// </summary>
        public VendorOneTimeMessage VendorData { get; set; }
        /// <summary>
        /// กรณีไม่มีข้อมูลมาให้ส่วนจัดการ VAT ของ invoice นั้นจะถูกปิดไว้
        /// </summary>
        public TaxMessage VatData { get; set; }
        public List<TaxMessage> WHTDataList { get; set; }
        public List<PaymentRequestSubItemMessage> PaymentRequestSubItemList { get; set; }
    }
}
