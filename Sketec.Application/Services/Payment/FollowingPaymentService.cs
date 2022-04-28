using AutoMapper;
using EnsureThat;
using Sketec.Application.Filters;
using Sketec.Application.Interfaces;
using Sketec.Application.Utils;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using Sketec.FileWriter.Excels;
using Sketec.FileWriter.Resources;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.Core.Domains.Types;

namespace Sketec.Application.Services
{
    //public class FollowingPaymentService : IFollowingPaymentService
    //{
    //    IMapper mapper;
    //    IWCRepository<Billing> billRepo;
    //    IWCUnitOfWork uow;
    //    IWCDapperRepository dapper;
    //    IWCRepository<BillingTemp> billTempRepo;
    //    IWCRepository<DeliveryFlowDomestic> delRepo;
    //    IWCRepository<FiCashSales> cashSaleRepo;
    //    IWCRepository<FiCashSalesCommentLog> cashLogRepo;
    //    IMasterPaymentTypeService masterPaymentTypeService;
    //    IWCRepository<BillPresentmentDocumentControl> billDocRepo;
    //    IWCRepository<ReceiptDocumentControl> receiptDocRepo;
    //    ICustomerSalesOrgService custSalesOrgService;
    //    IMasterCcaService ccaService;
    //    IMasterBusinessUnitService buService;
    //    IWCReadRepository<BillingItem> billItemRepo;
    //    IConfigurationService configService;
    //    IWCQueryRepository queryRepo;
    //    IWCRepository<OutsourceOtherDoc> otherDocRepo;
    //    public FollowingPaymentService(
    //        IMapper mapper,
    //        IWCRepository<Billing> billRepo,
    //        IWCUnitOfWork uow,
    //        IWCDapperRepository dapper,
    //        IWCRepository<BillingTemp> billTempRepo,
    //        IWCRepository<DeliveryFlowDomestic> delRepo,
    //        IWCRepository<FiCashSales> cashSaleRepo,
    //        IWCRepository<FiCashSalesCommentLog> cashLogRepo,
    //        IMasterPaymentTypeService masterPaymentTypeService,
    //        IWCRepository<BillPresentmentDocumentControl> billDocRepo,
    //        IWCRepository<ReceiptDocumentControl> receiptDocRepo,
    //        ICustomerSalesOrgService custSalesOrgService,
    //        IMasterCcaService ccaService,
    //        IMasterBusinessUnitService buService,
    //        IWCReadRepository<BillingItem> billItemRepo,
    //        IConfigurationService configService,
    //        IWCRepository<OutsourceOtherDoc> otherDocRepo,
    //        IWCQueryRepository queryRepo)
    //    {
    //        this.mapper = mapper;
    //        this.uow = uow;
    //        this.billRepo = billRepo;
    //        this.dapper = dapper;
    //        this.billTempRepo = billTempRepo;
    //        this.delRepo = delRepo;
    //        this.cashSaleRepo = cashSaleRepo;
    //        this.cashLogRepo = cashLogRepo;
    //        this.masterPaymentTypeService = masterPaymentTypeService;
    //        this.billDocRepo = billDocRepo;
    //        this.receiptDocRepo = receiptDocRepo;
    //        this.custSalesOrgService = custSalesOrgService;
    //        this.ccaService = ccaService;
    //        this.buService = buService;
    //        this.billItemRepo = billItemRepo;
    //        this.configService = configService;
    //        this.queryRepo = queryRepo;
    //        this.otherDocRepo = otherDocRepo;
    //    }
    //    public async Task<IEnumerable<FollowingPaymentSearchResultDto>> GetFollowingPayment(FollowingPaymentFilter filter)
    //    {
    //        var spec = new FollowingPaymentBillingLinqSearchSpec(filter ?? new FollowingPaymentFilter());
    //        var list = await queryRepo.ListAsync(spec);

    //        var spec2 = new FollowingPaymentFICashSaleLinqSearchSpec(filter ?? new FollowingPaymentFilter());
    //        var list2 = await queryRepo.ListAsync(spec2);

    //        var data = ConvertToDto(list.Concat(list2).Take(1000));
    //        return data;
    //    }
        


    //    private IEnumerable<FollowingPaymentSearchResultDto> ConvertToDto(IEnumerable<FollowingPayment> data)
    //    {
    //        var result = data
    //                    .GroupBy(o => new { o.SalesOrg, o.CustomerCode, o.CustomerName, o.CusDue, o.PayDate, o.PlanCash })
    //                    .Select(o => new FollowingPaymentSearchResultDto
    //                    {
    //                        Key = $"{o.Key.SalesOrg}_{o.Key.CustomerCode}_{o.Key.CusDue?.ToString("yyyyMMdd")}_{o.Key.PayDate?.ToString("yyyyMMdd")}_{o.Key.PlanCash?.ToString("yyyyMMdd")}",
    //                        SalesOrg = o.Key.SalesOrg,
    //                        CustomerCode = o.Key.CustomerCode,
    //                        CustomerName = o.Key.CustomerName,
    //                        CusDue = o.Key.CusDue,
    //                        PayDate = o.Key.PayDate,
    //                        PlanCash = o.Key.PlanCash,
    //                        NetAmount = o.Sum(x => x.NetAmount),
    //                        ConfirmAmount = o.Sum(x => x.ConfirmAmount),
    //                        BillingNo = o.Min(x => x.BillingNo) == o.Max(x => x.BillingNo) ? o.Max(x => x.BillingNo) : (o.Min(x => x.BillingNo) + " - " + o.Max(x => x.BillingNo)),
    //                        BillingDateStr = o.Min(x => x.BillingDate) == o.Max(x => x.BillingDate) ? o.Max(x => x.BillingDate)?.ToString("dd/MM/yyyy") : (o.Min(x => x.BillingDate)?.ToString("dd/MM/yyyy") + " - " + o.Max(x => x.BillingDate)?.ToString("dd/MM/yyyy")),
    //                        Children = o.Select(x => new FollowingPaymentSearchResultDto
    //                        {
    //                            Key = $"{x.SalesOrg}_{x.CustomerCode}_{x.CusDue?.ToString("yyyyMMdd")}_{x.PayDate?.ToString("yyyyMMdd")}_{x.PlanCash?.ToString("yyyyMMdd")}_{x.BillingNo}",
    //                            KeyGroup = $"{x.SalesOrg}_{x.CustomerCode}_{x.CusDue?.ToString("yyyyMMdd")}_{x.PayDate?.ToString("yyyyMMdd")}_{x.PlanCash?.ToString("yyyyMMdd")}",
    //                            CusDue = x.CusDue,
    //                            PayDate = x.PayDate,
    //                            PlanCash = x.PlanCash,
    //                            CustomerCode = x.CustomerCode,
    //                            CustomerName = x.CustomerName,
    //                            CompanyCode = x.CompanyCode,
    //                            CompanyName = x.CompanyName,
    //                            NetAmount = x.NetAmount,
    //                            ConfirmAmount = x.ConfirmAmount,
    //                            ContactPayment = x.ContactPayment,
    //                            BillPresentmentId = x.BillPresentmentId,
    //                            BillPresentmentNo = x.BillPresentmentNo,
    //                            BillPresentmentDate = x.BillPresentmentDate,
    //                            BillPresentmentPrintDate = x.BillPresentmentPrintDate,
    //                            ReceiptId = x.ReceiptId,
    //                            ReceiptNo = x.ReceiptNo,
    //                            IssueDate = x.IssueDate,
    //                            BillingId = x.BillingId,
    //                            BillingNo = x.BillingNo,
    //                            BillingAmount = x.BillingAmount,
    //                            BillingDate = x.BillingDate,
    //                            BillingSource = x.BillingSource,
    //                            PaymentRule = x.PaymentRule,
    //                            PaymentRemarks = x.PaymentRemarks,
    //                            PaymentBank = x.PaymentBank,
    //                            PaymentMethod = x.PaymentMethod,
    //                            PaymentMethodName = x.PaymentMethodName,
    //                            Comment = x.Comment,
    //                            StatusBill = x.StatusBill,
    //                            StatusCallingPayment = x.StatusCallingPayment,
    //                            PlanCashStatus = x.PlanCashStatus,
    //                            CallingPayment = x.CallingPayment,
    //                            OverallStatus = x.OverallStatus,
    //                            AddressPayment = x.AddressPayment,
    //                            SplitPayment = x.SplitPayment,
    //                            SplitCount = x.SplitCount,
    //                            SplitAmount = x.SplitAmount,
    //                            BankFeeFix1 = x.BankFeeFix1,
    //                            BankFeeFix2 = x.BankFeeFix2,
    //                            BankFeePercent = x.BankFeePercent,
    //                            IncomingGL = x.IncomingGL,
    //                            DueDate = x.DueDate,
    //                            YBill = x.YBill,
    //                            YCol = x.YCol,
    //                            YColNotifyDate = x.YColNotifyDate,
    //                            YCal = x.YCal,
    //                            YCalNotifyDate = x.YCalNotifyDate,
    //                            CreditRepDoc = x.CreditRepDoc,
    //                            CreditRepBill = x.CreditRepBill,
    //                            CreditRepPayment = x.CreditRepPayment,
    //                            SalesName = x.SalesName,
    //                            SalesOrg = x.SalesOrg,
    //                            Plant = x.Plant,
    //                            ShippingPoint = x.ShippingPoint,
    //                            PaymentTerm = x.PaymentTerm,
    //                            BillingRule = x.BillingRule,
    //                            PDCCondition = x.PDCCondition,
    //                            BillCollector = x.BillCollector,
    //                            UpdatedBy = x.UpdatedBy,
    //                            UpdatedDate = x.UpdatedDate
    //                        })
    //                    });
    //        return result;
    //    }

    //    public async Task UpdateDate(int id, string type, FollowingPaymentUpdateDateRequest request, BindPropertyCollection httpPatchBindProperty = null)
    //    {
    //        EnsureArg.IsNotNull(request, nameof(FollowingPaymentUpdateDateRequest));

    //        if (request.BillingSource == BillingSource.Billing)
    //        {
    //            var data = await billRepo.GetByIdAsync(id);
    //            if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.NewDate)))
    //            {
    //                if (type == "Pay Date")
    //                {
    //                    data.PayDate = request.NewDate;
    //                }
    //                else if (type == "Cus Due")
    //                {
    //                    if(data.YColDate != null)
    //                        data.YColDate = request.NewDate;
    //                    else 
    //                        data.YCalDate = request.NewDate;
    //                }
    //                else if (type == "Plan Cash")
    //                {
    //                    data.PlanCash = request.NewDate;
    //                }
    //            }

    //        }
    //        else
    //        {
    //            var data = await cashSaleRepo.GetByIdAsync(id);
    //            if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.NewDate)))
    //            {
    //                if (type == "Pay Date")
    //                {
    //                    data.PayDate = request.NewDate;
    //                }
    //                else if (type == "Cus Due")
    //                {
    //                    if (data.YColDate != null)
    //                        data.YColDate = request.NewDate;
    //                    else
    //                        data.YCalDate = request.NewDate;
    //                }
    //                else if (type == "Plan Cash")
    //                {
    //                    data.PlanCash = request.NewDate;
    //                }
    //            }
    //        }
    //        await uow.SaveAsync();
    //    }

    //    public async Task UpdateStatusCalling(int id, FollowingPaymentUpdateStatusRequest request, BindPropertyCollection httpPatchBindProperty = null)
    //    {
    //        EnsureArg.IsNotNull(request, nameof(FollowingPaymentUpdateStatusRequest));
    //        var status = EnumStringValueExtension.GetEnumFromStringValue<StatusCallingPayment>(request.Status);
    //        if (request.BillingSource == BillingSource.Billing)
    //        {
    //            var data = await billRepo.GetByIdAsync(id);
    //            if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Status)))
    //            {
    //                data.StatusCallingPayment = status;
    //                data.ConfirmAmount = request.ConfirmAmount;
    //            }
    //        }
    //        else
    //        {
    //            var data = await cashSaleRepo.GetByIdAsync(id);
    //            if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Status)))
    //            {
    //                data.StatusCallingPayment = status;
    //                data.ConfirmAmount = request.ConfirmAmount;
    //            }
    //        }
    //        await uow.SaveAsync();
    //    }

    //    public async Task UpdatePlanCashStatus(int id, FollowingPaymentUpdateStatusRequest request, BindPropertyCollection httpPatchBindProperty = null)
    //    {
    //        EnsureArg.IsNotNull(request, nameof(FollowingPaymentUpdateStatusRequest));
    //        var status = EnumStringValueExtension.GetEnumFromStringValue<PlanCashStatus>(request.Status);
    //        if (request.BillingSource == BillingSource.Billing)
    //        {
    //            var data = await billRepo.GetByIdAsync(id);
    //            if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Status)))
    //            {
    //                data.PlanCashStatus = status;
    //            }
    //        }
    //        else
    //        {
    //            var data = await cashSaleRepo.GetByIdAsync(id);
    //            if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Status)))
    //            {
    //                data.PlanCashStatus = status;
    //            }
    //        }
    //        await uow.SaveAsync();
    //    }
    //}
}
