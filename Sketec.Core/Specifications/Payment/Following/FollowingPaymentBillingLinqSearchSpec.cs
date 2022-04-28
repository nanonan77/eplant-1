using Sketec.Core.Abstracts;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    //public class FollowingPaymentBillingLinqSearchSpec : QuerySpecification<FollowingPayment>
    //{
    //    FollowingPaymentFilter filter;
    //    public FollowingPaymentBillingLinqSearchSpec(FollowingPaymentFilter filter)
    //    {
    //        this.filter = filter;
    //    }

        //public override IQueryable<FollowingPayment> OnQuery()
        //{
        //    var paymentMethod = Utils.Cheque();
        //    var query = from billing in Set<Billing>()
        //                join org in Set<MasterSalesOrg>() on billing.SalesOrg equals org.Code into org2
        //                from org in org2.DefaultIfEmpty()

        //                join mc in Set<MasterCustomer>() on billing.CustomerCode equals mc.Code into mc2
        //                from mc in mc2.DefaultIfEmpty()

        //                join cs in Set<CustomerSalesOrg>() on new { billing.CustomerCode, billing.SalesOrg } equals new { CustomerCode = cs.CustomerCode, SalesOrg = cs.SalesOrgCode } into cs2
        //                from cs in cs2.DefaultIfEmpty()

        //                join bm in Set<MasterBillMethod>() on billing.BillMethodStatus == BillMethodStatus.Manual ? billing.BillMethod : cs.BillMethod equals bm.Code into bm2
        //                from bm in bm2.DefaultIfEmpty()

        //                join pm in Set<MasterPaymentType>() on billing.PaymentMethodStatus == PaymentMethodStatus.Manual ? billing.PaymentMethod : cs.PaymentMethod equals pm.Code into pm2
        //                from pm in pm2.DefaultIfEmpty()

        //                join com in Set<MasterCompany>() on billing.CompanyCode equals com.Code into com2
        //                from com in com2.DefaultIfEmpty()

        //                join docItem in Set<BillPresentmentDocumentControlItem>() on billing.Id equals docItem.BillingSource == BillingSource.Billing ? docItem.BillingId : null into docItem2
        //                from docItem in docItem2.DefaultIfEmpty()

        //                join doc in Set<BillPresentmentDocumentControl>() on docItem.BillPresentmentId equals doc.Id into doc2
        //                from doc in doc2.DefaultIfEmpty()

        //                join recItem in Set<ReceiptDocumentControlItem>() on billing.Id equals recItem.BillingSource == BillingSource.Billing ? recItem.BillingId : null into recItem2
        //                from recItem in recItem2.DefaultIfEmpty()

        //                join rec in Set<ReceiptDocumentControl>() on recItem.ReceiptId equals rec.Id into rec2
        //                from rec in rec2.DefaultIfEmpty()

        //                join cca in Set<MasterCustomerCCA>() on new { billing.CustomerCode, billing.CustomerSalesOrg.SalesOrg.CCA } equals new { CustomerCode = cca.CustomerPayer, CCA = cca.Cca } into cca2
        //                from cca in cca2.DefaultIfEmpty()

        //                join ccaB in Set<MasterCCAAndBusinessPlace>() on new { SalesOrg = billing.SalesOrg, CompanyCode = billing.CompanyCode } equals new { SalesOrg = ccaB.SalesOrg, CompanyCode = ccaB.CompanyCode } into ccaB2
        //                from ccaB in ccaB2.DefaultIfEmpty()


        //                select new FollowingPayment
        //                {
        //                    CusDue = paymentMethod.Contains(billing.PaymentMethodStatus == PaymentMethodStatus.Manual ? billing.PaymentMethod : billing.CustomerSalesOrg.PaymentMethod) ? billing.YColDate : billing.YCalDate,
        //                    PayDate = billing.PayDate == null ? (paymentMethod.Contains(billing.PaymentMethodStatus == PaymentMethodStatus.Manual ? billing.PaymentMethod : billing.CustomerSalesOrg.PaymentMethod) ? billing.YColDate : billing.YCalDate) : billing.PayDate,
        //                    // PlanCash = billing.PlanCash != null ? billing.PlanCash : billing.PayDate != null ? billing.PayDate : (paymentMethod.Contains(billing.PaymentMethodStatus == PaymentMethodStatus.Manual ? billing.PaymentMethod : billing.CustomerSalesOrg.PaymentMethod) ? billing.YColDate : billing.YCalDate)
        //                    // StatusPlanCash = billing.StatusPlanCash
        //                    NetAmount = billing.NetAmount,
        //                    ConfirmAmount = billing.BalanceAmount == null ? billing.NetAmount : billing.BalanceAmount,

        //                    CustomerCode = billing.CustomerCode,
        //                    CustomerName = mc == null ? string.Empty : mc.Name,
                            
        //                    BillPresentmentId = doc == null ? null : doc.Id,
        //                    BillPresentmentNo = doc == null ? string.Empty : doc.BillPresentmentNo,
        //                    BillPresentmentDate = doc == null ? null : doc.BillPresentmentDate,
        //                    BillPresentmentPrintDate = doc == null ? null : doc.CreatedDate,
        //                    ReceiptId = rec == null ? null : rec.Id,
        //                    ReceiptNo = rec == null ? null : rec.ReceiptNo,
        //                    IssueDate = rec == null ? null : rec.IssueDate,

        //                    BillingSource = BillingSource.Billing,
        //                    BillingId = billing.Id,
        //                    BillingNo = billing.BillingNo,
        //                    BillingDate = billing.BillingDate,
        //                    DueDate = billing.CustomerDueDate,
        //                    BillingAmount = billing.NetAmount,
        //                    BillingRule = cs == null ? null : cs.BillingRule,
        //                    PaymentRule = cs == null ? null : cs.PaymentRule,
        //                    Plant = billing.Plant,
        //                    ShippingPoint = billing.ShippingPoint,

        //                    BillCollector = cca == null ? null : cca.BillCollector,
        //                    SalesOrg = billing.SalesOrg,
        //                    SalesName = billing.SalesEmployeeName,
        //                    PaymentTerm = billing.PaymentTerm,
        //                    PaymentMethod = pm == null ? null : pm.Code,
        //                    PaymentMethodName = pm == null ? null : pm.Description,

        //                    YBill = billing.YBillDate,
        //                    YCol = billing.YColDate,
        //                    YCal = billing.YCalDate,
        //                    YColNotifyDate = billing.YColNotificationDate,
        //                    YCalNotifyDate = billing.YCalNotificationDate,

        //                    Comment = string.Empty,
        //                    BankFeeFix1 = cca == null ? null : cca.BankFeeFixes1,
        //                    BankFeeFix2 = cca == null ? null : cca.BankFeeFixes2,
        //                    BankFeePercent = cca == null ? null : cca.BankFeePercent,
        //                    UpdatedBy = billing.UpdatedBy,
        //                    UpdatedDate = billing.UpdatedDate,

        //                    AddressPayment = (cca == null || cca.AddressReceiptCheque1 == null ? "" : cca.AddressReceiptCheque1) 
        //                                + (cca == null || cca.AddressReceiptCheque2 == null ? "" : cca.AddressReceiptCheque2) 
        //                                + (cca == null || cca.AddressReceiptCheque3 == null ? "" : cca.AddressReceiptCheque3) 
        //                                + (cca == null || cca.AddressReceiptCheque4 == null ? "" : cca.AddressReceiptCheque4) 
        //                                + (cca == null || cca.AddressReceiptCheque5 == null ? "" : cca.AddressReceiptCheque5) 
        //                                + (cca == null || cca.AddressReceiptCheque6 == null ? "" : cca.AddressReceiptCheque6),
        //                    IncomingGL = (cca == null || cca.IncommingGl1 == null ? "" : cca.IncommingGl1)
        //                                + (cca == null || cca.IncommingGl2 == null ? "" : cca.IncommingGl2),
        //                    PaymentBank = (cca == null || cca.PaymentBank1 == null ? "" : cca.PaymentBank1)
        //                                + (cca == null || cca.PaymentBank2 == null ? "" : cca.PaymentBank2),
        //                    PaymentRemarks = (cca == null || cca.RemarkChqRule1 == null ? "" : cca.RemarkChqRule1)
        //                                + (cca == null || cca.RemarkChqRule2 == null ? "" : cca.RemarkChqRule2)
        //                                + (cca == null || cca.RemarkChqRule3 == null ? "" : cca.RemarkChqRule3)
        //                                + (cca == null || cca.RemarkChqRule4 == null ? "" : cca.RemarkChqRule4)
        //                                + (cca == null || cca.RemarkChqRule5 == null ? "" : cca.RemarkChqRule5),
        //                    ContactPayment = (cca == null || cca.ContactPayment1 == null ? "" : cca.ContactPayment1)
        //                                + (cca == null || cca.ContactPayment2 == null ? "" : cca.ContactPayment2)
        //                                + (cca == null || cca.ContactPayment3 == null ? "" : cca.ContactPayment3),
        //                    PDCCondition = (cca == null || cca.PdcBeDlcCondition == null ? "" : cca.PdcBeDlcCondition),
        //                    CompanyCode = billing.CompanyCode,
        //                    CompanyName = com == null ? null : com.Name,
        //                    CreditRepBill = (cca == null || cca.CreditRepresentativeGroupBill1 == null ? "" : cca.CreditRepresentativeGroupBill1)
        //                                + (cca == null || cca.CreditRepresentativeGroupBill2 == null ? "" : cca.CreditRepresentativeGroupBill2)
        //                                + (cca == null || cca.CreditRepresentativeGroupBill3 == null ? "" : cca.CreditRepresentativeGroupBill3),
        //                    CreditRepDoc = (cca == null || cca.CreditRepresentativeGroupDocument1 == null ? "" : cca.CreditRepresentativeGroupDocument1)
        //                                + (cca == null || cca.CreditRepresentativeGroupDocument2 == null ? "" : cca.CreditRepresentativeGroupDocument2)
        //                                + (cca == null || cca.CreditRepresentativeGroupDocument3 == null ? "" : cca.CreditRepresentativeGroupDocument3),
        //                    CreditRepPayment = (cca == null || cca.CreditRepresentativeGroupPayment1 == null ? "" : cca.CreditRepresentativeGroupPayment1)
        //                                + (cca == null || cca.CreditRepresentativeGroupPayment2 == null ? "" : cca.CreditRepresentativeGroupPayment2)
        //                                + (cca == null || cca.CreditRepresentativeGroupPayment3 == null ? "" : cca.CreditRepresentativeGroupPayment3),
        //                    SplitPayment = billing.CustomerSalesOrg.SplitPayment,
        //                    SplitCount = billing.CustomerSalesOrg.SplitPaymentCount,
        //                    SplitAmount = billing.CustomerSalesOrg.SplitPaymentAmount,
        //                    StatusCallingPayment = billing.StatusCallingPayment,
        //                    StatusBill = billing.Status,
        //                    OverallStatus = billing.OverallStatus,
        //                    PlanCashStatus = billing.PlanCashStatus,
        //                    PlanCash = billing.PlanCash,
        //                    CallingPayment = string.IsNullOrWhiteSpace(billing.CustomerSalesOrg.CallingPayment) ? "No" : billing.CustomerSalesOrg.CallingPayment,
        //                    StatusOverdue = DateTime.Now.Date < (paymentMethod.Contains(billing.PaymentMethodStatus == PaymentMethodStatus.Manual ? billing.PaymentMethod : billing.CustomerSalesOrg.PaymentMethod) ? billing.YColDate : billing.YCalDate) ? "Overdue" :
        //                                    DateTime.Now.AddDays(-1).Date <= (paymentMethod.Contains(billing.PaymentMethodStatus == PaymentMethodStatus.Manual ? billing.PaymentMethod : billing.CustomerSalesOrg.PaymentMethod) ? billing.YColDate : billing.YCalDate) ? "Waiting Overdue" : "No"
        //                };


        //    if (!string.IsNullOrEmpty(filter.SalesOrg))
        //    {
        //        var keyList = filter.SalesOrg.Split(',');
        //        if (keyList.Length == 1)
        //        {
        //            query = query.Where(m => m.SalesOrg == filter.SalesOrg);
        //        }
        //        else
        //        {
        //            query = query.Where(m => keyList.Contains(m.SalesOrg));
        //        }

        //    }
            
        //    if (!string.IsNullOrEmpty(filter.CompanyCode))
        //    {
        //        var keyList = filter.CompanyCode.Split(',');
        //        if (keyList.Length == 1)
        //        {
        //            query = query.Where(m => m.CompanyCode == filter.CompanyCode);
        //        }
        //        else
        //        {
        //            query = query.Where(m => keyList.Contains(m.CompanyCode));
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(filter.Plant))
        //    {
        //        var keyList = filter.Plant.Split(',');
        //        if (keyList.Length == 1)
        //        {
        //            query = query.Where(m => m.Plant == filter.Plant);
        //        }
        //        else
        //        {
        //            query = query.Where(m => keyList.Contains(m.Plant));
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(filter.ShippingPoint))
        //    {
        //        var keyList = filter.ShippingPoint.Split(',');
        //        if (keyList.Length == 1)
        //        {
        //            query = query.Where(m => m.ShippingPoint == filter.ShippingPoint);
        //        }
        //        else
        //        {
        //            query = query.Where(m => keyList.Contains(m.ShippingPoint));
        //        }
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.CustomerCode))
        //    {
        //        var keyList = filter.CustomerCode.Split(',');
        //        if (keyList.Length == 1)
        //        {
        //            query = query.Where(m => m.CustomerCode == filter.CustomerCode);
        //        }
        //        else
        //        {
        //            query = query.Where(m => keyList.Contains(m.CustomerCode));
        //        }
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.DocumentType))
        //    {
        //        var keyList = filter.DocumentType.Split(',');
        //        foreach(var item in keyList)
        //        {
        //            if (!string.IsNullOrWhiteSpace(filter.DocumentNoFrom) && !string.IsNullOrWhiteSpace(filter.DocumentNoTo))
        //            {
        //                query = query.Where(m => (keyList.Contains("InvoiceNo") && m.BillingNo.CompareTo(filter.DocumentNoFrom) >= 0 && m.BillingNo.CompareTo(filter.DocumentNoTo) <= 0)
        //                                        || (keyList.Contains("BillPresentmentNo") && m.BillPresentmentNo.CompareTo(filter.DocumentNoFrom) >= 0 && m.BillPresentmentNo.CompareTo(filter.DocumentNoTo) <= 0)
        //                                        || (keyList.Contains("ReceiptNo") && m.ReceiptNo.CompareTo(filter.DocumentNoFrom) >= 0 && m.ReceiptNo.CompareTo(filter.DocumentNoTo) <= 0)
        //                                        );
        //            }
        //            else if (!string.IsNullOrWhiteSpace(filter.DocumentNoFrom))
        //            {
        //                query = query.Where(m => (keyList.Contains("InvoiceNo") && m.BillingNo.Contains(filter.DocumentNoFrom))
        //                                        || (keyList.Contains("BillPresentmentNo") && m.BillPresentmentNo.Contains(filter.DocumentNoFrom))
        //                                        || (keyList.Contains("ReceiptNo") && m.ReceiptNo.Contains(filter.DocumentNoFrom))
        //                                        );
        //            }
        //            else if (!string.IsNullOrWhiteSpace(filter.DocumentNoTo))
        //            {
        //                query = query.Where(m => (keyList.Contains("InvoiceNo") && m.BillingNo.Contains(filter.DocumentNoTo))
        //                                        || (keyList.Contains("BillPresentmentNo") && m.BillPresentmentNo.Contains(filter.DocumentNoTo))
        //                                        || (keyList.Contains("ReceiptNo") && m.ReceiptNo.Contains(filter.DocumentNoTo))
        //                                        );
        //            }
        //        }
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.SelectTypeDate1) && filter.SelectDate1 != null)
        //    {
        //        var keyList = filter.SelectTypeDate1.Split(',');

        //        if (filter.SelectDate1.Length > 0)
        //        {
        //            query = query.Where(m => (
        //                                    keyList.Contains("YBill") && m.YBill >= filter.SelectDate1[0].Date)
        //                                    || (keyList.Contains("YCol") && m.YCol >= filter.SelectDate1[0].Date)
        //                                    || (keyList.Contains("YCal") && m.YCal >= filter.SelectDate1[0].Date)
        //                                    || (keyList.Contains("YCol Notify Date") && m.YColNotifyDate >= filter.SelectDate1[0].Date)
        //                                    || (keyList.Contains("YCal Notify Date") && m.YCalNotifyDate >= filter.SelectDate1[0].Date)
        //                                    || (keyList.Contains("Cus Due") && m.CusDue >= filter.SelectDate1[0].Date)
        //                                    || (keyList.Contains("Pay Date") && m.PayDate >= filter.SelectDate1[0].Date)
        //                                    || (keyList.Contains("Bill Presentment Date") && m.BillPresentmentDate >= filter.SelectDate1[0].Date)
        //                                    || (keyList.Contains("Invoice Date") && m.BillingDate >= filter.SelectDate1[0].Date)
        //                                    || (keyList.Contains("Bill Presentment Print Date") && m.BillPresentmentPrintDate >= filter.SelectDate1[0].Date)
        //                                    || (keyList.Contains("Due Date") && m.DueDate >= filter.SelectDate1[0].Date)
        //                                    );
        //        }
        //        if (filter.SelectDate1.Length > 1)
        //        {
        //            query = query.Where(m => (
        //                                    keyList.Contains("YBill") && m.YBill <= filter.SelectDate1[1].Date)
        //                                    || (keyList.Contains("YCol") && m.YCol <= filter.SelectDate1[1].Date)
        //                                    || (keyList.Contains("YCal") && m.YCal <= filter.SelectDate1[1].Date)
        //                                    || (keyList.Contains("YCol Notify Date") && m.YColNotifyDate <= filter.SelectDate1[1].Date)
        //                                    || (keyList.Contains("YCal Notify Date") && m.YCalNotifyDate <= filter.SelectDate1[1].Date)
        //                                    || (keyList.Contains("Cus Due") && m.CusDue <= filter.SelectDate1[1].Date)
        //                                    || (keyList.Contains("Pay Date") && m.PayDate <= filter.SelectDate1[1].Date)
        //                                    || (keyList.Contains("Bill Presentment Date") && m.BillPresentmentDate <= filter.SelectDate1[1].Date)
        //                                    || (keyList.Contains("Invoice Date") && m.BillingDate <= filter.SelectDate1[1].Date)
        //                                    || (keyList.Contains("Bill Presentment Print Date") && m.BillPresentmentPrintDate <= filter.SelectDate1[1].Date)
        //                                    || (keyList.Contains("Due Date") && m.DueDate <= filter.SelectDate1[1].Date)
        //                                    );
        //        }
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.SelectTypeDate2) && filter.SelectDate2 != null)
        //    {
        //        var keyList = filter.SelectTypeDate2.Split(',');

        //        if (filter.SelectDate2.Length > 0)
        //        {
        //            query = query.Where(m => (
        //                                    keyList.Contains("YBill") && m.YBill >= filter.SelectDate2[0].Date)
        //                                    || (keyList.Contains("YCol") && m.YCol >= filter.SelectDate2[0].Date)
        //                                    || (keyList.Contains("YCal") && m.YCal >= filter.SelectDate2[0].Date)
        //                                    || (keyList.Contains("YCol Notify Date") && m.YColNotifyDate >= filter.SelectDate2[0].Date)
        //                                    || (keyList.Contains("YCal Notify Date") && m.YCalNotifyDate >= filter.SelectDate2[0].Date)
        //                                    || (keyList.Contains("Cus Due") && m.CusDue >= filter.SelectDate2[0].Date)
        //                                    || (keyList.Contains("Pay Date") && m.PayDate >= filter.SelectDate2[0].Date)
        //                                    || (keyList.Contains("Bill Presentment Date") && m.BillPresentmentDate >= filter.SelectDate2[0].Date)
        //                                    || (keyList.Contains("Invoice Date") && m.BillingDate >= filter.SelectDate2[0].Date)
        //                                    || (keyList.Contains("Bill Presentment Print Date") && m.BillPresentmentPrintDate >= filter.SelectDate2[0].Date)
        //                                    || (keyList.Contains("Due Date") && m.DueDate >= filter.SelectDate2[0].Date)
        //                                    );
        //        }
        //        if (filter.SelectDate2.Length > 1)
        //        {
        //            query = query.Where(m => (
        //                                    keyList.Contains("YBill") && m.YBill <= filter.SelectDate2[1].Date)
        //                                    || (keyList.Contains("YCol") && m.YCol <= filter.SelectDate2[1].Date)
        //                                    || (keyList.Contains("YCal") && m.YCal <= filter.SelectDate2[1].Date)
        //                                    || (keyList.Contains("YCol Notify Date") && m.YColNotifyDate <= filter.SelectDate2[1].Date)
        //                                    || (keyList.Contains("YCal Notify Date") && m.YCalNotifyDate <= filter.SelectDate2[1].Date)
        //                                    || (keyList.Contains("Cus Due") && m.CusDue <= filter.SelectDate2[1].Date)
        //                                    || (keyList.Contains("Pay Date") && m.PayDate <= filter.SelectDate2[1].Date)
        //                                    || (keyList.Contains("Bill Presentment Date") && m.BillPresentmentDate <= filter.SelectDate2[1].Date)
        //                                    || (keyList.Contains("Invoice Date") && m.BillingDate <= filter.SelectDate2[1].Date)
        //                                    || (keyList.Contains("Bill Presentment Print Date") && m.BillPresentmentPrintDate <= filter.SelectDate2[1].Date)
        //                                    || (keyList.Contains("Due Date") && m.DueDate <= filter.SelectDate2[1].Date)
        //                                    );
        //        }
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.SelectTypeDate3) && filter.SelectDate3 != null)
        //    {
        //        var keyList = filter.SelectTypeDate3.Split(',');

        //        if (filter.SelectDate3.Length > 0)
        //        {
        //            query = query.Where(m => (
        //                                    keyList.Contains("YBill") && m.YBill >= filter.SelectDate3[0].Date)
        //                                    || (keyList.Contains("YCol") && m.YCol >= filter.SelectDate3[0].Date)
        //                                    || (keyList.Contains("YCal") && m.YCal >= filter.SelectDate3[0].Date)
        //                                    || (keyList.Contains("YCol Notify Date") && m.YColNotifyDate >= filter.SelectDate3[0].Date)
        //                                    || (keyList.Contains("YCal Notify Date") && m.YCalNotifyDate >= filter.SelectDate3[0].Date)
        //                                    || (keyList.Contains("Cus Due") && m.CusDue >= filter.SelectDate3[0].Date)
        //                                    || (keyList.Contains("Pay Date") && m.PayDate >= filter.SelectDate3[0].Date)
        //                                    || (keyList.Contains("Bill Presentment Date") && m.BillPresentmentDate >= filter.SelectDate3[0].Date)
        //                                    || (keyList.Contains("Invoice Date") && m.BillingDate >= filter.SelectDate3[0].Date)
        //                                    || (keyList.Contains("Bill Presentment Print Date") && m.BillPresentmentPrintDate >= filter.SelectDate3[0].Date)
        //                                    || (keyList.Contains("Due Date") && m.DueDate >= filter.SelectDate3[0].Date)
        //                                    );
        //        }
        //        if (filter.SelectDate3.Length > 1)
        //        {
        //            query = query.Where(m => (
        //                                    keyList.Contains("YBill") && m.YBill <= filter.SelectDate3[1].Date)
        //                                    || (keyList.Contains("YCol") && m.YCol <= filter.SelectDate3[1].Date)
        //                                    || (keyList.Contains("YCal") && m.YCal <= filter.SelectDate3[1].Date)
        //                                    || (keyList.Contains("YCol Notify Date") && m.YColNotifyDate <= filter.SelectDate3[1].Date)
        //                                    || (keyList.Contains("YCal Notify Date") && m.YCalNotifyDate <= filter.SelectDate3[1].Date)
        //                                    || (keyList.Contains("Cus Due") && m.CusDue <= filter.SelectDate3[1].Date)
        //                                    || (keyList.Contains("Pay Date") && m.PayDate <= filter.SelectDate3[1].Date)
        //                                    || (keyList.Contains("Bill Presentment Date") && m.BillPresentmentDate <= filter.SelectDate3[1].Date)
        //                                    || (keyList.Contains("Invoice Date") && m.BillingDate <= filter.SelectDate3[1].Date)
        //                                    || (keyList.Contains("Bill Presentment Print Date") && m.BillPresentmentPrintDate <= filter.SelectDate3[1].Date)
        //                                    || (keyList.Contains("Due Date") && m.DueDate <= filter.SelectDate3[1].Date)
        //                                    );
        //        }
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.CreditRepPayment))
        //    {
        //        query = query.Where(m => m.CreditRepPayment.Contains(filter.CreditRepPayment));
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.CallingPayment))
        //    {
        //        query = query.Where(m => m.CallingPayment == filter.CallingPayment);
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.PaymentMethod))
        //    {
        //        var keyList = filter.PaymentMethod.Split(',');
        //        if (keyList.Length == 1)
        //        {
        //            query = query.Where(m => m.PaymentMethod == filter.PaymentMethod);
        //        }
        //        else
        //        {
        //            query = query.Where(m => keyList.Contains(m.PaymentMethod));
        //        }
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.StatusBill))
        //    {
        //        var keyList = filter.StatusBill.Split(',');
        //        List<BillingStatus> list = new List<BillingStatus>();
        //        foreach (var item in keyList)
        //        {
        //            var billingStatus = EnumStringValueExtension.GetEnumFromStringValue<BillingStatus>(item, "Waiting");
        //            list.Add(billingStatus);
        //        }
        //        query = query.Where(m => list.Contains(m.StatusBill));
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.StatusCallingPayment))
        //    {
        //        var keyList = filter.StatusCallingPayment.Split(',');
        //        List<StatusCallingPayment> list = new List<StatusCallingPayment>();
        //        foreach (var item in keyList)
        //        {
        //            var calling = EnumStringValueExtension.GetEnumFromStringValue<StatusCallingPayment>(item, "Open");
        //            list.Add(calling);
        //        }
        //        query = query.Where(m => list.Contains(m.StatusCallingPayment));
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.StatusOverdue))
        //    {
        //        var keyList = filter.StatusOverdue.Split(',');
        //        query = query.Where(m => keyList.Contains(m.StatusOverdue));
        //    }

        //    return query.Take(50);
        //}
    //}

    //public class FollowingPaymentFilter
    //{
    //    public string CompanyCode { get; set; }
    //    public string SalesOrg { get; set; }
    //    public string Plant { get; set; }
    //    public string ShippingPoint { get; set; }
    //    public string CustomerCode { get; set; }
    //    public string DocumentType { get; set; }
    //    public string DocumentNoFrom { get; set; }
    //    public string DocumentNoTo { get; set; }
    //    public string SelectTypeDate1 { get; set; }
    //    public DateTime[] SelectDate1 { get; set; }
    //    public string SelectTypeDate2 { get; set; }
    //    public DateTime[] SelectDate2 { get; set; }
    //    public string SelectTypeDate3 { get; set; }
    //    public DateTime[] SelectDate3 { get; set; }

    //    public string CreditRepPayment { get; set; }
    //    public string CallingPayment { get; set; }
    //    public string PaymentMethod { get; set; }
    //    public string StatusCallingPayment { get; set; }
    //    public string StatusBill { get; set; }
    //    public string StatusOverdue { get; set; }
    //    public string OverallStatus { get; set; }


    //}
    //public class FollowingPayment
    //{
    //    public DateTime? CusDue { get; set; }
    //    public DateTime? PayDate { get; set; }
    //    public DateTime? PlanCash { get; set; }
    //    public PlanCashStatus PlanCashStatus { get; set; }
    //    public string CustomerCode { get; set; }
    //    public string CustomerName { get; set; }
    //    public string CompanyCode { get; set; }
    //    public string CompanyName { get; set; }
    //    public decimal? NetAmount { get; set; }
    //    public decimal? ConfirmAmount { get; set; }
    //    public string ContactPayment { get; set; }
    //    public int? BillPresentmentId { get; set; }
    //    public string BillPresentmentNo { get; set; }
    //    public DateTime? BillPresentmentDate { get; set; }
    //    public int? ReceiptId { get; set; }
    //    public string ReceiptNo { get; set; }
    //    public DateTime? IssueDate { get; set; }
    //    public int? BillingId { get; set; }
    //    public string BillingNo { get; set; }
    //    public decimal? BillingAmount { get; set; }
    //    public DateTime? BillingDate { get; set; }
    //    public BillingSource BillingSource { get; set; }
    //    public string PaymentRule { get; set; }
    //    public string PaymentRemarks { get; set; }
    //    public string PaymentBank { get; set; }
    //    public string PaymentMethod { get; set; }
    //    public string PaymentMethodName { get; set; }
    //    public string Comment { get; set; }
    //    public BillingStatus StatusBill { get; set; }
    //    public string CallingPayment { get; set; }
    //    public StatusCallingPayment StatusCallingPayment { get; set; }
    //    public string StatusOverdue { get; set; }
    //    public OverallStatus OverallStatus { get; set; }
    //    public string AddressPayment { get; set; }
    //    public string SplitPayment { get; set; }
    //    public int? SplitCount { get; set; }
    //    public decimal? SplitAmount { get; set; }
    //    public string BankFeeFix1 { get; set; }
    //    public string BankFeeFix2 { get; set; }
    //    public string BankFeePercent { get; set; }
    //    public string IncomingGL { get; set; }
    //    public DateTime? BillPresentmentPrintDate { get; set; }
    //    public DateTime? DueDate { get; set; }
    //    public DateTime? YBill { get; set; }
    //    public DateTime? YCol { get; set; }
    //    public DateTime? YColNotifyDate { get; set; }
    //    public DateTime? YCal { get; set; }
    //    public DateTime? YCalNotifyDate { get; set; }
    //    public string CreditRepDoc { get; set; }
    //    public string CreditRepBill { get; set; }
    //    public string CreditRepPayment { get; set; }
    //    public string SalesName { get; set; }
    //    public string SalesOrg { get; set; }
    //    public string Plant { get; set; }
    //    public string ShippingPoint { get; set; }
    //    public string PaymentTerm { get; set; }
    //    public string BillingRule { get; set; }
    //    public string PDCCondition { get; set; }
    //    public string BillCollector { get; set; }
    //    public string UpdatedBy { get; set; }
    //    public DateTime? UpdatedDate { get; set; }
    //}
}
