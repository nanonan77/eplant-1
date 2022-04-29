using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public class CreatePaymentRequestMessage
    {
        public CreatePaymentRequestMessage()
        {
            AlternativePayeeList = new List<AlternativePayeeMessage>();
            Approvers = new List<RequestApproverMessage>();
            FileRelationDataList = new List<FileInfoDataMessage>();
            FileReceiptList = new List<FileInfoDataMessage>();
            PaymentRequestItems = new List<PaymentRequestItemMessage>();
        }
        #region 1. General Information
        public FormType FormType { get; set; }
        public string CompanyCode { get; set; }
        public bool IsOneTimeVendor { get; set; }
        /// <summary>
        /// กรณีเป็น Vendor Onetime
        /// </summary>
        public VendorOneTimeMessage VendorOneTime { get; set; }
        public string VendorCode { get; set; }
        public string GrApprovalForCode { get; set; }
        public string Subject { get; set; }
        /// <summary>
        /// สถานะของเอกสารที่ส่งมาสร้างในระบบ
        /// </summary>
        public StandartStatus Status { get; set; }
        #endregion
        #region 2. Payment & Budget Information
        public DateTimeOffset DueDate { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// ประเภทการจ่ายเงิน
        /// </summary>
        public string VPPaymentTypeCode { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        public string PaymentDescription { get; set; }
        public string ServiceTeamCode { get; set; }
        public bool IsAlternativePayee { get; set; }
        /// <summary>
        /// ใส่ข้อมูลกรณีมี Alternative Payee
        /// </summary>
        public List<AlternativePayeeMessage> AlternativePayeeList { get; set; }
        public bool IsPurchaseOrder { get; set; }
        public string AddinalData { get; set; }
        #endregion
        #region 3. Invoice / Tax Invoice / Other Information
        public List<PaymentRequestItemMessage> PaymentRequestItems { get; set; }
        /// <summary>
        /// other wht in Vpay
        /// </summary>
        public List<OtherInformationMessage> OthersInformation { get; set; }
        #endregion
        # region  4. User & Approval Information        
        public string RequestorUserName { get; set; }
        /// <summary>
        /// รายชื่อของ Reviewer / CC / Approver สามารถแยกจากกันโดย RequestApproveType <Enum>
        /// </summary>
        public List<RequestApproverMessage> Approvers { get; set; }
        public bool IsParallelApprove { get; set; }
        #endregion
        #region Orther

        public DateTime CreateDate { get; set; }
        public string CreatorUserName { get; set; }
        public List<FileInfoDataMessage> FileRelationDataList { get; set; }
        public List<FileInfoDataMessage> FileReceiptList { get; set; }
        /// <summary>
        /// เลขสำหรับตรวจสอบว่ามีในระบบหรือยัง
        /// </summary>
        public string RefNo { get; set; }
        public string VendorEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountExchangeRete { get; set; }
        public decimal AmountExcludeVat { get; set; }

        public string UserLogin { get; set; }
        public string PasswordLogin { get; set; }
        #endregion
        public BeneficiaryMessage Ben { get; set; }
        #region Foreign
        public bool IsForeignPayment { get; set; }
        public string RemittedCurrencyCode { get; set; }
        public string RemittedToCurrencyCode { get; set; }
        public string PaidForCode { get; set; }
        public string PreAdviceCode { get; set; }
        public string PurposeDetail { get; set; }
        public string ForwardContractNo { get; set; }
        public string BankChargeOutside { get; set; }
        public string BankChargeInside { get; set; }
        public string SpecialMessage { get; set; }
        public string IntenalMessage { get; set; }
        #endregion
    }
}
