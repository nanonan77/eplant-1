using OfficeOpenXml;
using OfficeOpenXml.Style;
using Sketec.Core.Domains;
using Sketec.FileWriter.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.FileWriter.Excels
{
    public static class CoversheetOs
    {

        //public static List<ConversheetOsResult> GenerateCoversheetOS(List<string> buList, List<CoversheetOsDto> allInvoiceList, List<CoversheetOsDto> allList
        //    , List<CoversheetOsBillAttachDto> billAttachList, List<CoversheetOsAllDocDto> allDocList
        //    , List<CoversheetOsConfigDto> attachDpConfig, List<CoversheetOsConfigDto> attachPoConfig, List<CoversheetOsConfigDto> attachBillingConfig)
        //{
        //    var result = new List<ConversheetOsResult>();

        //    foreach (var bu in buList)
        //    {

        //        if (bu.ToLower() == "cip")
        //        {
        //            var salesOrg1 = allInvoiceList.Where(o => o.Bu == bu).Select(o => o.SalesOrg).ToList();
        //            var salesOrg2 = allList.Where(o => o.Bu == bu).Select(o => o.SalesOrg).ToList();
        //            var salesOrg3 = billAttachList.Where(o => o.Bu == bu).Select(o => o.SalesOrg).ToList();
        //            var salesOrg4 = allDocList.Where(o => o.Bu == bu).Select(o => o.SalesOrg).ToList();
        //            var salesOrgList = salesOrg1.Union(salesOrg2).Union(salesOrg3).Union(salesOrg4).Distinct().ToList();
        //            foreach (var salesOrg in salesOrgList)
        //            {
        //                byte[] bytes = null;
        //                var allInvoice = allInvoiceList.Where(o => o.Bu == bu && o.SalesOrg == salesOrg).ToList();
        //                var invNoAttach = allList.Where(o => o.Bu == bu && o.SalesOrg == salesOrg && (o.BillCondition == "1" || o.IsCN)).ToList();
        //                var invAttach = allList.Where(o => o.Bu == bu && o.SalesOrg == salesOrg && o.BillCondition == "2").ToList();
        //                var billAttach = billAttachList.Where(o => o.Bu == bu && o.SalesOrg == salesOrg).ToList();
        //                var allDoc = allDocList.Where(o => o.Bu == bu && o.SalesOrg == salesOrg).ToList();
        //                if (!allInvoice.Any() && !invNoAttach.Any() && !invAttach.Any() && !billAttach.Any() && !allDoc.Any())
        //                {
        //                    continue;
        //                }
        //                var company1 = allInvoice.Select(o => new CompanyDto { CompanyCode = o.CompanyCode, CompanyName = o.CompanyName }).ToList();
        //                var company2 = allList.Select(o => new CompanyDto { CompanyCode = o.CompanyCode, CompanyName = o.CompanyName }).ToList();
        //                var company3 = billAttachList.Select(o => new CompanyDto { CompanyCode = o.CompanyCode, CompanyName = o.CompanyName }).ToList();
        //                var company4 = allDocList.Select(o => new CompanyDto { CompanyCode = o.CompanyCode, CompanyName = o.CompanyName }).ToList();
        //                var companyList = company1.Union(company2).Union(company3).Union(company4).ToList();
        //                var companyName = GetCompanyName(companyList);
        //                var sendDate = DateTime.Now.ToString("dd/MM/yyyy");
        //                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#8eaadb"); //green d2d1cc
        //                using (var st = new MemoryStream())
        //                {
        //                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //                    ExcelPackage ExcelPkg = new ExcelPackage(st);


        //                    ExcelWorksheet wsSheet = ExcelPkg.Workbook.Worksheets.Add("All_Softfile_Invoice");

        //                    SetAllSoftFileInvoice(ExcelPkg, wsSheet, colFromHex, bu, companyName, sendDate, allInvoice, attachDpConfig, attachPoConfig, attachBillingConfig);
        //                    SetInvoiceNoAttachSheet(ExcelPkg, wsSheet, colFromHex, bu, companyName, sendDate, invNoAttach, attachDpConfig, attachPoConfig, attachBillingConfig);
        //                    SetInvoiceAttachSheet(ExcelPkg, wsSheet, colFromHex, bu, companyName, sendDate, invAttach, attachDpConfig, attachPoConfig, attachBillingConfig);
        //                    SetBillAttachSheet(ExcelPkg, wsSheet, colFromHex, bu, companyName, sendDate, billAttach, attachDpConfig, attachPoConfig);
        //                    SetAllDocSheet(ExcelPkg, wsSheet, colFromHex, bu, companyName, sendDate, allDoc, attachDpConfig, attachPoConfig);

        //                    ExcelPkg.Save();
        //                    bytes = st.ToArray();
        //                }

        //                var fileName = $"CoversheetOS_{bu}_{DateTime.Now.ToString("yyMMdd")}_01.xlsx";
        //                result.Add(new ConversheetOsResult { FileName = fileName, Files = bytes, Bu = bu, SalesOrg = salesOrg });
        //            }
        //        }
        //        else
        //        {
        //            byte[] bytes = null;
        //            var allInvoice = allInvoiceList.Where(o => o.Bu == bu).ToList();
        //            var invNoAttach = allList.Where(o => o.Bu == bu && (o.BillCondition == "1" || o.IsCN)).ToList();
        //            var invAttach = allList.Where(o => o.Bu == bu && o.BillCondition == "2").ToList();
        //            var billAttach = billAttachList.Where(o => o.Bu == bu).ToList();
        //            var allDoc = allDocList.Where(o => o.Bu == bu).ToList();
        //            if (!allInvoice.Any() && !invNoAttach.Any() && !invAttach.Any() && !billAttach.Any() && !allDoc.Any())
        //            {
        //                continue;
        //            }
        //            var company1 = allInvoice.Select(o => new CompanyDto { CompanyCode = o.CompanyCode, CompanyName = o.CompanyName }).ToList();
        //            var company2 = allList.Select(o => new CompanyDto { CompanyCode = o.CompanyCode, CompanyName = o.CompanyName }).ToList();
        //            var company3 = billAttachList.Select(o => new CompanyDto { CompanyCode = o.CompanyCode, CompanyName = o.CompanyName }).ToList();
        //            var company4 = allDocList.Select(o => new CompanyDto { CompanyCode = o.CompanyCode, CompanyName = o.CompanyName }).ToList();
        //            var companyList = company1.Union(company2).Union(company3).Union(company4).ToList();
        //            var companyName = GetCompanyName(companyList);
        //            var sendDate = DateTime.Now.ToString("dd/MM/yyyy");
        //            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#8eaadb"); //green d2d1cc
        //            using (var st = new MemoryStream())
        //            {
        //                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //                ExcelPackage ExcelPkg = new ExcelPackage(st);


        //                ExcelWorksheet wsSheet = ExcelPkg.Workbook.Worksheets.Add("All_Softfile_Invoice");

        //                SetAllSoftFileInvoice(ExcelPkg, wsSheet, colFromHex, bu, companyName, sendDate, allInvoice, attachDpConfig, attachPoConfig, attachBillingConfig);
        //                SetInvoiceNoAttachSheet(ExcelPkg, wsSheet, colFromHex, bu, companyName, sendDate, invNoAttach, attachDpConfig, attachPoConfig, attachBillingConfig);
        //                SetInvoiceAttachSheet(ExcelPkg, wsSheet, colFromHex, bu, companyName, sendDate, invAttach, attachDpConfig, attachPoConfig, attachBillingConfig);
        //                SetBillAttachSheet(ExcelPkg, wsSheet, colFromHex, bu, companyName, sendDate, billAttach, attachDpConfig, attachPoConfig);
        //                SetAllDocSheet(ExcelPkg, wsSheet, colFromHex, bu, companyName, sendDate, allDoc, attachDpConfig, attachPoConfig);

        //                #region old code
        //                //#region All_Softfile_Invoice Sheet

        //                //ExcelWorksheet wsSheet = ExcelPkg.Workbook.Worksheets.Add("All_Softfile_Invoice");
        //                //wsSheet.Cells[1, 1].Value = "All Tax Invoice (Soft Files)";
        //                //wsSheet.Cells[2, 1].Value = companyName;
        //                //wsSheet.Cells[3, 1].Value = $"Send Date";
        //                //wsSheet.Cells[3, 2].Value = $"{sendDate}";
        //                //wsSheet.Cells[1, 1, 3, 3].Style.Font.Bold = true;

        //                //#region set header
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = CoversheetOsColumnName.InvoiceNo;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = CoversheetOsColumnName.IssueingDate;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillCollector].Value = CoversheetOsColumnName.BillCollector;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = CoversheetOsColumnName.CustomerCode;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerName].Value = CoversheetOsColumnName.CustomerName;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = CoversheetOsColumnName.PaymentTerm;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = CoversheetOsColumnName.AmountInvoice;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPoNumber].Value = CoversheetOsColumnName.PoNumber;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachDp].Value = CoversheetOsColumnName.AttachDp;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachPo].Value = CoversheetOsColumnName.AttachPo;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = CoversheetOsColumnName.DistributionChannel;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBilingType].Value = CoversheetOsColumnName.BilingType;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = CoversheetOsColumnName.CustomerDueDate;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = CoversheetOsColumnName.InvoiceType;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsOutputName].Value = CoversheetOsColumnName.OutputName;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillMethod].Value = CoversheetOsColumnName.BillMethod;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = CoversheetOsColumnName.NoOfCopies;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPDType].Value = CoversheetOsColumnName.PDType;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = CoversheetOsColumnName.BillPresentmentDate;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = CoversheetOsColumnName.CompanyCode;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = CoversheetOsColumnName.SalesOrg;

        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.BackgroundColor.SetColor(colFromHex);
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Font.Bold = true;
        //                //#endregion

        //                //#region set detail
        //                //var row = AllInvoiceColumnHeader.RowDetail;
        //                //if (allInvoice.Any()) 
        //                //{
        //                //    foreach (var item in allInvoice)
        //                //    {
        //                //        var attachDp = attachDpConfig.FirstOrDefault(o => o.Code == item.AttachDPType);
        //                //        var attachPo = attachPoConfig.FirstOrDefault(o => o.Code == item.AttachPOType);
        //                //        var attachBillingList = string.IsNullOrEmpty(item.AttachForBilling) ? new List<string>() : item.AttachForBilling.Split(",").ToList();
        //                //        var attachBillingName = (from a in attachBillingList
        //                //                  join c in attachBillingConfig on a equals c.Code
        //                //                  select c.Name
        //                //                  ).Distinct().ToList();
        //                //        var attachForBilling = string.Join(",", attachBillingName);
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = Util.GetBillingNo(item.BillingNo, bu);
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = item.IssueDate.HasValue ? item.IssueDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillCollector].Value = item.BillCollector;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = item.CustomerCode;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerName].Value = item.CustomerName;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = item.PaymentTerm;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = (item.BillingAmount ?? 0).ToString();
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPoNumber].Value = item.PoNumber;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachDp].Value = attachDp?.Name;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachPo].Value = attachPo?.Name;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = item.Channel;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBilingType].Value = item.BillingType;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = item.DueDate.HasValue ? item.DueDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = item.InvoiceType;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsOutputName].Value = item.OutputName;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillMethod].Value = item.BillMethod;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = (item.NoOfCopies ?? 0).ToString();
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPDType].Value = attachForBilling;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = item.BillPresentmentDate.HasValue ? item.BillPresentmentDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = item.CompanyCode;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = item.SalesOrg;

        //                //        row += 1;
        //                //    }

        //                //}
        //                //#endregion

        //                //using (ExcelRange Rng = wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, row, AllInvoiceColumnHeader.ColumnsSalesOrg])
        //                //{
        //                //    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //                //}
        //                //wsSheet.Protection.IsProtected = false;
        //                //wsSheet.Protection.AllowSelectLockedCells = false;

        //                //#endregion

        //                //#region Invoice_NoAttach Sheet

        //                //wsSheet = ExcelPkg.Workbook.Worksheets.Add("Invoice_NoAttach");
        //                //wsSheet.Cells[1, 1].Value = "Invoice_NoAttach";
        //                //wsSheet.Cells[2, 1].Value = companyName;
        //                //wsSheet.Cells[3, 1].Value = $"Send Date";
        //                //wsSheet.Cells[3, 2].Value = $"{sendDate}";
        //                //wsSheet.Cells[1, 1, 3, 3].Style.Font.Bold = true;

        //                //#region set header
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = CoversheetOsColumnName.InvoiceNo;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = CoversheetOsColumnName.IssueingDate;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillCollector].Value = CoversheetOsColumnName.BillCollector;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = CoversheetOsColumnName.CustomerCode;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerName].Value = CoversheetOsColumnName.CustomerName;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = CoversheetOsColumnName.PaymentTerm;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = CoversheetOsColumnName.AmountInvoice;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPoNumber].Value = CoversheetOsColumnName.PoNumber;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachDp].Value = CoversheetOsColumnName.AttachDp;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachPo].Value = CoversheetOsColumnName.AttachPo;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = CoversheetOsColumnName.DistributionChannel;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBilingType].Value = CoversheetOsColumnName.BilingType;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = CoversheetOsColumnName.CustomerDueDate;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = CoversheetOsColumnName.InvoiceType;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsOutputName].Value = CoversheetOsColumnName.OutputName;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillMethod].Value = CoversheetOsColumnName.BillMethod;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = CoversheetOsColumnName.NoOfCopies;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPDType].Value = CoversheetOsColumnName.PDType;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = CoversheetOsColumnName.BillPresentmentDate;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = CoversheetOsColumnName.CompanyCode;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = CoversheetOsColumnName.SalesOrg;

        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.BackgroundColor.SetColor(colFromHex);
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Font.Bold = true;
        //                //#endregion

        //                //row = AllInvoiceColumnHeader.RowDetail;
        //                //#region set detail
        //                //if (invNoAttach.Any())
        //                //{

        //                //    foreach (var item in invNoAttach)
        //                //    {
        //                //        var attachDp = attachDpConfig.FirstOrDefault(o => o.Code == item.AttachDPType);
        //                //        var attachPo = attachPoConfig.FirstOrDefault(o => o.Code == item.AttachPOType);
        //                //        var attachBillingList = string.IsNullOrEmpty(item.AttachForBilling) ? new List<string>() : item.AttachForBilling.Split(",").ToList();
        //                //        var attachBillingName = (from a in attachBillingList
        //                //                                 join c in attachBillingConfig on a equals c.Code
        //                //                                 select c.Name
        //                //                  ).Distinct().ToList();
        //                //        var attachForBilling = string.Join(",", attachBillingName);
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = Util.GetBillingNo(item.BillingNo, bu);
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = item.IssueDate.HasValue ? item.IssueDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillCollector].Value = item.BillCollector;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = item.CustomerCode;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerName].Value = item.CustomerName;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = item.PaymentTerm;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = (item.BillingAmount ?? 0).ToString();
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPoNumber].Value = item.PoNumber;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachDp].Value = attachDp?.Name;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachPo].Value = attachPo?.Name;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = item.Channel;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBilingType].Value = item.BillingType;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = item.DueDate.HasValue ? item.DueDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = item.InvoiceType;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsOutputName].Value = item.OutputName;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillMethod].Value = item.BillMethod;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = (item.NoOfCopies ?? 0).ToString();
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPDType].Value = attachForBilling;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = item.BillPresentmentDate.HasValue ? item.BillPresentmentDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = item.CompanyCode;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = item.SalesOrg;

        //                //        row += 1;
        //                //    }

        //                //}
        //                //using (ExcelRange Rng = wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, row, AllInvoiceColumnHeader.ColumnsSalesOrg])
        //                //{
        //                //    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //                //}
        //                //wsSheet.Protection.IsProtected = false;
        //                //wsSheet.Protection.AllowSelectLockedCells = false;
        //                //#endregion

        //                //#endregion

        //                //#region Invoice_Attach Sheet

        //                //wsSheet = ExcelPkg.Workbook.Worksheets.Add("Invoice_Attach");
        //                //wsSheet.Cells[1, 1].Value = "Invoice_Attach";
        //                //wsSheet.Cells[2, 1].Value = companyName;
        //                //wsSheet.Cells[3, 1].Value = $"Send Date";
        //                //wsSheet.Cells[3, 2].Value = $"{sendDate}";
        //                //wsSheet.Cells[1, 1, 3, 3].Style.Font.Bold = true;

        //                //#region set header
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = CoversheetOsColumnName.InvoiceNo;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = CoversheetOsColumnName.IssueingDate;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillCollector].Value = CoversheetOsColumnName.BillCollector;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = CoversheetOsColumnName.CustomerCode;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerName].Value = CoversheetOsColumnName.CustomerName;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = CoversheetOsColumnName.PaymentTerm;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = CoversheetOsColumnName.AmountInvoice;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPoNumber].Value = CoversheetOsColumnName.PoNumber;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachDp].Value = CoversheetOsColumnName.AttachDp;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachPo].Value = CoversheetOsColumnName.AttachPo;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = CoversheetOsColumnName.DistributionChannel;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBilingType].Value = CoversheetOsColumnName.BilingType;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = CoversheetOsColumnName.CustomerDueDate;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = CoversheetOsColumnName.InvoiceType;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsOutputName].Value = CoversheetOsColumnName.OutputName;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillMethod].Value = CoversheetOsColumnName.BillMethod;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = CoversheetOsColumnName.NoOfCopies;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPDType].Value = CoversheetOsColumnName.PDType;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = CoversheetOsColumnName.BillPresentmentDate;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = CoversheetOsColumnName.CompanyCode;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = CoversheetOsColumnName.SalesOrg;

        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.BackgroundColor.SetColor(colFromHex);
        //                //wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Font.Bold = true;
        //                //#endregion

        //                //#region set detail
        //                //row = AllInvoiceColumnHeader.RowDetail;
        //                //if (invAttach.Any())
        //                //{
        //                //    foreach (var item in invAttach)
        //                //    {
        //                //        var attachDp = attachDpConfig.FirstOrDefault(o => o.Code == item.AttachDPType);
        //                //        var attachPo = attachDpConfig.FirstOrDefault(o => o.Code == item.AttachPOType);
        //                //        var attachBillingList = string.IsNullOrEmpty(item.AttachForBilling) ? new List<string>() : item.AttachForBilling.Split(",").ToList();
        //                //        var attachBillingName = (from a in attachBillingList
        //                //                                 join c in attachBillingConfig on a equals c.Code
        //                //                                 select c.Name
        //                //                  ).Distinct().ToList();
        //                //        var attachForBilling = string.Join(",", attachBillingName);
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = Util.GetBillingNo(item.BillingNo, bu);
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = item.IssueDate.HasValue ? item.IssueDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillCollector].Value = item.BillCollector;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = item.CustomerCode;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerName].Value = item.CustomerName;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = item.PaymentTerm;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = (item.BillingAmount ?? 0).ToString();
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPoNumber].Value = item.PoNumber;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachDp].Value = attachDp?.Name;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachPo].Value = attachPo?.Name;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = item.Channel;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBilingType].Value = item.BillingType;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = item.DueDate.HasValue ? item.DueDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = item.InvoiceType;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsOutputName].Value = item.OutputName;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillMethod].Value = item.BillMethod;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = (item.NoOfCopies ?? 0).ToString();
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPDType].Value = attachForBilling;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = item.BillPresentmentDate.HasValue ? item.BillPresentmentDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = item.CompanyCode;
        //                //        wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = item.SalesOrg;

        //                //        row += 1;
        //                //    }
        //                //}

        //                //#endregion

        //                //using (ExcelRange Rng = wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, row, AllInvoiceColumnHeader.ColumnsSalesOrg])
        //                //{
        //                //    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //                //}
        //                //wsSheet.Protection.IsProtected = false;
        //                //wsSheet.Protection.AllowSelectLockedCells = false;
        //                //#endregion

        //                //#region Bill_Attach Sheet

        //                //wsSheet = ExcelPkg.Workbook.Worksheets.Add("Bill_Attach");
        //                //wsSheet.Cells[1, 1].Value = "Bill_Attach";
        //                //wsSheet.Cells[2, 1].Value = companyName;
        //                //wsSheet.Cells[3, 1].Value = $"Send Date";
        //                //wsSheet.Cells[3, 2].Value = $"{sendDate}";
        //                //wsSheet.Cells[1, 1, 3, 3].Style.Font.Bold = true;

        //                //#region set header
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillNo].Value = CoversheetOsColumnName.BillNo;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillDate].Value = CoversheetOsColumnName.BillDate;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillCollector].Value = CoversheetOsColumnName.BillCollector;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsCustomerCode].Value = CoversheetOsColumnName.CustomerCode;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsCustomerName].Value = CoversheetOsColumnName.CustomerName;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsPaymentTerm].Value = CoversheetOsColumnName.PaymentTerm;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsAmountOfBill].Value = CoversheetOsColumnName.AmountOfBill;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillPresentmentDate].Value = CoversheetOsColumnName.BillPresentmentDate;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsInvoiceNo].Value = CoversheetOsColumnName.InvoiceNo;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsInvoiceDate].Value = CoversheetOsColumnName.InvoiceDate;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsInvoiceAmount].Value = CoversheetOsColumnName.AmountInvoice;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBilingType].Value = CoversheetOsColumnName.BilingType;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsAttachDp].Value = CoversheetOsColumnName.AttachDp;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsAttachPo].Value = CoversheetOsColumnName.AttachPo;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsRemark].Value = CoversheetOsColumnName.Remark;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsCompanyCode].Value = CoversheetOsColumnName.CompanyCode;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsSalesOrg].Value = CoversheetOsColumnName.SalesOrg;

        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillNo, BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsSalesOrg].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillNo, BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsSalesOrg].Style.Fill.BackgroundColor.SetColor(colFromHex);
        //                //wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillNo, BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsSalesOrg].Style.Font.Bold = true;
        //                //#endregion

        //                //#region set detail
        //                //row = AllInvoiceColumnHeader.RowDetail;

        //                //if (billAttach.Any())
        //                //{
        //                //    foreach (var item in billAttach)
        //                //    {
        //                //        var attachDp = attachDpConfig.FirstOrDefault(o => o.Code == item.AttachDP);
        //                //        var attachPo = attachPoConfig.FirstOrDefault(o => o.Code == item.AttachPO);
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsBillNo].Value = item.BillPresentmentNo;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsBillDate].Value = item.BillDate.HasValue ? item.BillDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsBillCollector].Value = item.BillCollector;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsCustomerCode].Value = item.CustomerCode;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsCustomerName].Value = item.CustomerName;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsPaymentTerm].Value = item.PaymentTerm;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsAmountOfBill].Value = (item.TotalAmount ?? 0).ToString();
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsBillPresentmentDate].Value = item.BillPresentmentDate.HasValue ? item.BillPresentmentDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsInvoiceNo].Value = item.BillingNo.Count() <= 1 ? Util.GetBillingNo(item.BillingNo.FirstOrDefault(), bu) : $"{Util.GetBillingNo(item.BillingNo.OrderBy(s => s).FirstOrDefault(), bu)}-{Util.GetBillingNo(item.BillingNo.OrderBy(s => s).LastOrDefault(), bu)}";
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsInvoiceDate].Value = item.BillingDate.Count() <= 1
        //                //                                ? item.BillingDate.Where(s => s.HasValue).Select(s => s.Value.ToString("dd/MM/yyyy")).FirstOrDefault()
        //                //                                : $"{item.BillingDate.Where(s => s.HasValue).OrderBy(s=> s).Select(s => s.Value.ToString("dd/MM/yyyy")).FirstOrDefault()}-{item.BillingDate.Where(s => s.HasValue).OrderBy(s => s).Select(s => s.Value.ToString("dd/MM/yyyy")).LastOrDefault()}";
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsInvoiceAmount].Value = (item.BillingAmount ?? 0).ToString();
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsBilingType].Value = item.BillingType;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsAttachDp].Value = attachDp?.Name ;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsAttachPo].Value = attachPo?.Name;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsRemark].Value = item.Remark;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsCompanyCode].Value = item.CompanyCode;
        //                //        wsSheet.Cells[row, BillAttachColumnHeader.ColumnsSalesOrg].Value = item.SalesOrg;

        //                //        row += 1;
        //                //    }
        //                //}
        //                //#endregion

        //                //using (ExcelRange Rng = wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillNo, row, BillAttachColumnHeader.ColumnsSalesOrg])
        //                //{
        //                //    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //                //}
        //                //wsSheet.Protection.IsProtected = false;
        //                //wsSheet.Protection.AllowSelectLockedCells = false;

        //                //#endregion

        //                //#region All_Document Sheet

        //                //wsSheet = ExcelPkg.Workbook.Worksheets.Add("All_Document");
        //                //wsSheet.Cells[1, 1].Value = "All_Document";
        //                //wsSheet.Cells[2, 1].Value = companyName;
        //                //wsSheet.Cells[3, 1].Value = $"Send Date";
        //                //wsSheet.Cells[3, 2].Value = $"{sendDate}";
        //                //wsSheet.Cells[1, 1, 3, 3].Style.Font.Bold = true;

        //                //#region set header
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsNo].Value = CoversheetOsColumnName.No;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSendToCustomerDate].Value = CoversheetOsColumnName.SendCustomerDate;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsBillCollector].Value = CoversheetOsColumnName.BillCollector;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsCustomerCode].Value = CoversheetOsColumnName.CustomerCode;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsCustomerName].Value = CoversheetOsColumnName.CustomerName;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSalesArea].Value = CoversheetOsColumnName.SalesArea;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSalesOrg].Value = CoversheetOsColumnName.SalesOrg;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsInvoiceNo].Value = CoversheetOsColumnName.InvoiceNo;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsInvoiceDate].Value = CoversheetOsColumnName.InvoiceDate;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsChequeNo].Value = CoversheetOsColumnName.ChequeNo;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsChequeDate].Value = CoversheetOsColumnName.ChequeDate;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsBillNo].Value = CoversheetOsColumnName.BillNo;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsBENo].Value = CoversheetOsColumnName.BENo;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsReceiptNo].Value = CoversheetOsColumnName.ReceiptNo;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsDpNo].Value = CoversheetOsColumnName.DPNo;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsPoNo].Value = CoversheetOsColumnName.PONo;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsAmount].Value = CoversheetOsColumnName.Amount;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsAddress].Value = CoversheetOsColumnName.Addtess;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsTelContact].Value = CoversheetOsColumnName.TelContact;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsRemark].Value = CoversheetOsColumnName.Remark;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSendTime].Value = CoversheetOsColumnName.SendTime;

        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsNo, AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSendTime].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsNo, AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSendTime].Style.Fill.BackgroundColor.SetColor(colFromHex);
        //                //wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsNo, AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSendTime].Style.Font.Bold = true;
        //                //#endregion

        //                //#region set detail
        //                //row = AllDocColumnHeader.RowDetail;

        //                //if (allDoc.Any())
        //                //{
        //                //    var index = 1;
        //                //    foreach (var item in allDoc)
        //                //    {
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsNo].Value = index;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsSendToCustomerDate].Value = item.SendDate.HasValue ? item.SendDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsBillCollector].Value = item.BillCollector;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsCustomerCode].Value = item.CustomerCode;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsCustomerName].Value = item.CustomerName;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsSalesArea].Value = item.SalesArea;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsSalesOrg].Value = item.SalesOrg;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsInvoiceNo].Value = Util.GetBillingNo(item.BillingNo, bu);
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsInvoiceDate].Value = item.BillingDate.HasValue ? item.BillingDate.Value.ToString("dd/MM/yyyy") : null;
        //                //        //wsSheet.Cells[row, AllDocColumnHeader.ColumnsInvoiceNo].Value = item.BillingNo.Count() <= 1 ? item.BillingNo.FirstOrDefault() : $"{item.BillingNo.OrderBy(s => s).FirstOrDefault()}-{item.BillingNo.OrderBy(s => s).LastOrDefault()}";
        //                //        //wsSheet.Cells[row, AllDocColumnHeader.ColumnsInvoiceDate].Value = item.BillingDate.Count() <= 1
        //                //        //                        ? item.BillingDate.Where(s => s.HasValue).Select(s => s.Value.ToString("dd/MM/yyyy")).FirstOrDefault()
        //                //        //                        : $"{item.BillingDate.Where(s => s.HasValue).Select(s => s.Value.ToString("dd/MM/yyyy")).OrderBy(s => s).FirstOrDefault()}-{item.BillingDate.Where(s => s.HasValue).Select(s => s.Value.ToString("dd/MM/yyyy")).OrderBy(s => s).OrderBy(s => s).LastOrDefault()}";
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsChequeNo].Value = item.ChequeNo;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsChequeDate].Value = item.ChequeDate;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsBillNo].Value = item.DocumentType == OutsourceDocumentType.BillPresentment ? item.DocumentNo : string.Empty;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsBENo].Value = item.DocumentType == OutsourceDocumentType.BE ? item.DocumentNo : string.Empty;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsReceiptNo].Value = item.DocumentType == OutsourceDocumentType.Receipt ? item.TransactionNo : string.Empty;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsDpNo].Value = item.DocumentType == OutsourceDocumentType.DP ? item.DocumentNo : string.Empty;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsPoNo].Value = item.DocumentType == OutsourceDocumentType.PO ? item.DocumentNo : string.Empty;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsAmount].Value = (item.DocumentAmount ?? 0).ToString();
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsAddress].Value = item.Address;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsTelContact].Value = item.TelContact;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsRemark].Value = item.Remark;
        //                //        wsSheet.Cells[row, AllDocColumnHeader.ColumnsSendTime].Value = item.SendTime;

        //                //        row += 1;
        //                //        index += 1;
        //                //    }
        //                //}

        //                //#endregion

        //                //using (ExcelRange Rng = wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsNo, row, AllDocColumnHeader.ColumnsSendTime])
        //                //{
        //                //    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //                //    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //                //}
        //                //wsSheet.Protection.IsProtected = false;
        //                //wsSheet.Protection.AllowSelectLockedCells = false;

        //                //#endregion

        //                #endregion

        //                ExcelPkg.Save();
        //                bytes = st.ToArray();
        //            }

        //            var fileName = $"CoversheetOS_{bu}_{DateTime.Now.ToString("yyMMdd")}_01.xlsx";
        //            result.Add(new ConversheetOsResult { FileName = fileName, Files = bytes, Bu = bu, });
        //        }
        //    }

        //    return result;
        //}
        //private static void SetAllSoftFileInvoice(ExcelPackage ExcelPkg, ExcelWorksheet wsSheet, Color colFromHex, string bu, string companyName, string sendDate
        //    , List<CoversheetOsDto> allInvoice, List<CoversheetOsConfigDto> attachDpConfig, List<CoversheetOsConfigDto> attachPoConfig, List<CoversheetOsConfigDto> attachBillingConfig)
        //{
        //    wsSheet.Cells[1, 1].Value = "All Tax Invoice (Soft Files)";
        //    wsSheet.Cells[2, 1].Value = companyName;
        //    wsSheet.Cells[3, 1].Value = $"Send Date";
        //    wsSheet.Cells[3, 2].Value = $"{sendDate}";
        //    wsSheet.Cells[1, 1, 3, 3].Style.Font.Bold = true;

        //    #region set header
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = CoversheetOsColumnName.InvoiceNo;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = CoversheetOsColumnName.IssueingDate;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillCollector].Value = CoversheetOsColumnName.BillCollector;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = CoversheetOsColumnName.CustomerCode;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerName].Value = CoversheetOsColumnName.CustomerName;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = CoversheetOsColumnName.PaymentTerm;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = CoversheetOsColumnName.AmountInvoice;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPoNumber].Value = CoversheetOsColumnName.PoNumber;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachDp].Value = CoversheetOsColumnName.AttachDp;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachPo].Value = CoversheetOsColumnName.AttachPo;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = CoversheetOsColumnName.DistributionChannel;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBilingType].Value = CoversheetOsColumnName.BilingType;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = CoversheetOsColumnName.CustomerDueDate;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = CoversheetOsColumnName.InvoiceType;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsOutputName].Value = CoversheetOsColumnName.OutputName;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillMethod].Value = CoversheetOsColumnName.BillMethod;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = CoversheetOsColumnName.NoOfCopies;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPDType].Value = CoversheetOsColumnName.PDType;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = CoversheetOsColumnName.BillPresentmentDate;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = CoversheetOsColumnName.CompanyCode;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = CoversheetOsColumnName.SalesOrg;

        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.BackgroundColor.SetColor(colFromHex);
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Font.Bold = true;
        //    #endregion

        //    #region set detail
        //    var row = AllInvoiceColumnHeader.RowDetail;
        //    if (allInvoice.Any())
        //    {
        //        foreach (var item in allInvoice)
        //        {
        //            var attachDp = attachDpConfig.FirstOrDefault(o => o.Code == item.AttachDPType);
        //            var attachPo = attachPoConfig.FirstOrDefault(o => o.Code == item.AttachPOType);
        //            var attachBillingList = string.IsNullOrEmpty(item.AttachForBilling) ? new List<string>() : item.AttachForBilling.Split(",").ToList();
        //            var attachBillingName = (from a in attachBillingList
        //                                     join c in attachBillingConfig on a equals c.Code
        //                                     select c.Name
        //                      ).Distinct().ToList();
        //            var attachForBilling = string.Join(",", attachBillingName);
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = Util.GetBillingNo(item.BillingNo, bu);
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = item.IssueDate.HasValue ? item.IssueDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillCollector].Value = item.BillCollector;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = item.CustomerCode;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerName].Value = item.CustomerName;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = item.PaymentTerm;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = (item.BillingAmount ?? 0).ToString();
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPoNumber].Value = item.PoNumber;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachDp].Value = attachDp?.Name;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachPo].Value = attachPo?.Name;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = item.Channel;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBilingType].Value = item.BillingType;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = item.DueDate.HasValue ? item.DueDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = item.InvoiceType;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsOutputName].Value = item.OutputName;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillMethod].Value = item.BillMethod;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = (item.NoOfCopies ?? 0).ToString();
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPDType].Value = attachForBilling;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = item.BillPresentmentDate.HasValue ? item.BillPresentmentDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = item.CompanyCode;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = item.SalesOrg;

        //            row += 1;
        //        }

        //    }
        //    #endregion

        //    using (ExcelRange Rng = wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, row, AllInvoiceColumnHeader.ColumnsSalesOrg])
        //    {
        //        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //    }
        //    wsSheet.Protection.IsProtected = false;
        //    wsSheet.Protection.AllowSelectLockedCells = false;
        //}
        //private static void SetInvoiceNoAttachSheet(ExcelPackage ExcelPkg, ExcelWorksheet wsSheet, Color colFromHex, string bu, string companyName, string sendDate
        //    , List<CoversheetOsDto> invNoAttach, List<CoversheetOsConfigDto> attachDpConfig, List<CoversheetOsConfigDto> attachPoConfig, List<CoversheetOsConfigDto> attachBillingConfig) 
        //{
        //    #region Invoice_NoAttach Sheet

        //    wsSheet = ExcelPkg.Workbook.Worksheets.Add("Invoice_NoAttach");
        //    wsSheet.Cells[1, 1].Value = "Invoice_NoAttach";
        //    wsSheet.Cells[2, 1].Value = companyName;
        //    wsSheet.Cells[3, 1].Value = $"Send Date";
        //    wsSheet.Cells[3, 2].Value = $"{sendDate}";
        //    wsSheet.Cells[1, 1, 3, 3].Style.Font.Bold = true;

        //    #region set header
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = CoversheetOsColumnName.InvoiceNo;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = CoversheetOsColumnName.IssueingDate;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillCollector].Value = CoversheetOsColumnName.BillCollector;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = CoversheetOsColumnName.CustomerCode;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerName].Value = CoversheetOsColumnName.CustomerName;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = CoversheetOsColumnName.PaymentTerm;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = CoversheetOsColumnName.AmountInvoice;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPoNumber].Value = CoversheetOsColumnName.PoNumber;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachDp].Value = CoversheetOsColumnName.AttachDp;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachPo].Value = CoversheetOsColumnName.AttachPo;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = CoversheetOsColumnName.DistributionChannel;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBilingType].Value = CoversheetOsColumnName.BilingType;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = CoversheetOsColumnName.CustomerDueDate;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = CoversheetOsColumnName.InvoiceType;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsOutputName].Value = CoversheetOsColumnName.OutputName;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillMethod].Value = CoversheetOsColumnName.BillMethod;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = CoversheetOsColumnName.NoOfCopies;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPDType].Value = CoversheetOsColumnName.PDType;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = CoversheetOsColumnName.BillPresentmentDate;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = CoversheetOsColumnName.CompanyCode;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = CoversheetOsColumnName.SalesOrg;

        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.BackgroundColor.SetColor(colFromHex);
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Font.Bold = true;
        //    #endregion

        //    var row = AllInvoiceColumnHeader.RowDetail;
        //    #region set detail
        //    if (invNoAttach.Any())
        //    {

        //        foreach (var item in invNoAttach)
        //        {
        //            var attachDp = attachDpConfig.FirstOrDefault(o => o.Code == item.AttachDPType);
        //            var attachPo = attachPoConfig.FirstOrDefault(o => o.Code == item.AttachPOType);
        //            var attachBillingList = string.IsNullOrEmpty(item.AttachForBilling) ? new List<string>() : item.AttachForBilling.Split(",").ToList();
        //            var attachBillingName = (from a in attachBillingList
        //                                     join c in attachBillingConfig on a equals c.Code
        //                                     select c.Name
        //                      ).Distinct().ToList();
        //            var attachForBilling = string.Join(",", attachBillingName);
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = Util.GetBillingNo(item.BillingNo, bu);
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = item.IssueDate.HasValue ? item.IssueDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillCollector].Value = item.BillCollector;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = item.CustomerCode;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerName].Value = item.CustomerName;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = item.PaymentTerm;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = (item.BillingAmount ?? 0).ToString();
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPoNumber].Value = item.PoNumber;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachDp].Value = attachDp?.Name;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachPo].Value = attachPo?.Name;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = item.Channel;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBilingType].Value = item.BillingType;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = item.DueDate.HasValue ? item.DueDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = item.InvoiceType;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsOutputName].Value = item.OutputName;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillMethod].Value = item.BillMethod;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = (item.NoOfCopies ?? 0).ToString();
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPDType].Value = attachForBilling;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = item.BillPresentmentDate.HasValue ? item.BillPresentmentDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = item.CompanyCode;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = item.SalesOrg;

        //            row += 1;
        //        }

        //    }
        //    using (ExcelRange Rng = wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, row, AllInvoiceColumnHeader.ColumnsSalesOrg])
        //    {
        //        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //    }
        //    wsSheet.Protection.IsProtected = false;
        //    wsSheet.Protection.AllowSelectLockedCells = false;
        //    #endregion

        //    #endregion
        //}

        //private static void SetInvoiceAttachSheet(ExcelPackage ExcelPkg, ExcelWorksheet wsSheet, Color colFromHex, string bu, string companyName, string sendDate
        //    , List<CoversheetOsDto> invAttach, List<CoversheetOsConfigDto> attachDpConfig, List<CoversheetOsConfigDto> attachPoConfig, List<CoversheetOsConfigDto> attachBillingConfig)
        //{
        //    wsSheet = ExcelPkg.Workbook.Worksheets.Add("Invoice_Attach");
        //    wsSheet.Cells[1, 1].Value = "Invoice_Attach";
        //    wsSheet.Cells[2, 1].Value = companyName;
        //    wsSheet.Cells[3, 1].Value = $"Send Date";
        //    wsSheet.Cells[3, 2].Value = $"{sendDate}";
        //    wsSheet.Cells[1, 1, 3, 3].Style.Font.Bold = true;

        //    #region set header
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = CoversheetOsColumnName.InvoiceNo;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = CoversheetOsColumnName.IssueingDate;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillCollector].Value = CoversheetOsColumnName.BillCollector;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = CoversheetOsColumnName.CustomerCode;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerName].Value = CoversheetOsColumnName.CustomerName;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = CoversheetOsColumnName.PaymentTerm;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = CoversheetOsColumnName.AmountInvoice;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPoNumber].Value = CoversheetOsColumnName.PoNumber;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachDp].Value = CoversheetOsColumnName.AttachDp;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsAttachPo].Value = CoversheetOsColumnName.AttachPo;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = CoversheetOsColumnName.DistributionChannel;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBilingType].Value = CoversheetOsColumnName.BilingType;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = CoversheetOsColumnName.CustomerDueDate;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = CoversheetOsColumnName.InvoiceType;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsOutputName].Value = CoversheetOsColumnName.OutputName;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillMethod].Value = CoversheetOsColumnName.BillMethod;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = CoversheetOsColumnName.NoOfCopies;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsPDType].Value = CoversheetOsColumnName.PDType;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = CoversheetOsColumnName.BillPresentmentDate;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = CoversheetOsColumnName.CompanyCode;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = CoversheetOsColumnName.SalesOrg;

        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Fill.BackgroundColor.SetColor(colFromHex);
        //    wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsSalesOrg].Style.Font.Bold = true;
        //    #endregion

        //    #region set detail
        //    var row = AllInvoiceColumnHeader.RowDetail;
        //    if (invAttach.Any())
        //    {
        //        foreach (var item in invAttach)
        //        {
        //            var attachDp = attachDpConfig.FirstOrDefault(o => o.Code == item.AttachDPType);
        //            var attachPo = attachPoConfig.FirstOrDefault(o => o.Code == item.AttachPOType);
        //            var attachBillingList = string.IsNullOrEmpty(item.AttachForBilling) ? new List<string>() : item.AttachForBilling.Split(",").ToList();
        //            var attachBillingName = (from a in attachBillingList
        //                                     join c in attachBillingConfig on a equals c.Code
        //                                     select c.Name
        //                      ).Distinct().ToList();
        //            var attachForBilling = string.Join(",", attachBillingName);
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceNo].Value = Util.GetBillingNo(item.BillingNo, bu);
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsIssueingDate].Value = item.IssueDate.HasValue ? item.IssueDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillCollector].Value = item.BillCollector;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerCode].Value = item.CustomerCode;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerName].Value = item.CustomerName;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPaymentTerm].Value = item.PaymentTerm;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAmountInvoice].Value = (item.BillingAmount ?? 0).ToString();
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPoNumber].Value = item.PoNumber;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachDp].Value = attachDp?.Name;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsAttachPo].Value = attachPo?.Name;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsDistributionChannel].Value = item.Channel;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBilingType].Value = item.BillingType;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCustomerDueDate].Value = item.DueDate.HasValue ? item.DueDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsInvoiceType].Value = item.InvoiceType;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsOutputName].Value = item.OutputName;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillMethod].Value = item.BillMethod;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsNoOfCopies].Value = (item.NoOfCopies ?? 0).ToString();
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsPDType].Value = attachForBilling;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsBillPresentmentDate].Value = item.BillPresentmentDate.HasValue ? item.BillPresentmentDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsCompanyCode].Value = item.CompanyCode;
        //            wsSheet.Cells[row, AllInvoiceColumnHeader.ColumnsSalesOrg].Value = item.SalesOrg;

        //            row += 1;
        //        }
        //    }

        //    #endregion

        //    using (ExcelRange Rng = wsSheet.Cells[AllInvoiceColumnHeader.RowHeader, AllInvoiceColumnHeader.ColumnsInvoiceNo, row, AllInvoiceColumnHeader.ColumnsSalesOrg])
        //    {
        //        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //    }
        //    wsSheet.Protection.IsProtected = false;
        //    wsSheet.Protection.AllowSelectLockedCells = false;
        //}

        //private static void SetBillAttachSheet(ExcelPackage ExcelPkg, ExcelWorksheet wsSheet, Color colFromHex, string bu, string companyName, string sendDate
        //    , List<CoversheetOsBillAttachDto> billAttach, List<CoversheetOsConfigDto> attachDpConfig, List<CoversheetOsConfigDto> attachPoConfig)
        //{
        //    wsSheet = ExcelPkg.Workbook.Worksheets.Add("Bill_Attach");
        //    wsSheet.Cells[1, 1].Value = "Bill_Attach";
        //    wsSheet.Cells[2, 1].Value = companyName;
        //    wsSheet.Cells[3, 1].Value = $"Send Date";
        //    wsSheet.Cells[3, 2].Value = $"{sendDate}";
        //    wsSheet.Cells[1, 1, 3, 3].Style.Font.Bold = true;

        //    #region set header
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillNo].Value = CoversheetOsColumnName.BillNo;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillDate].Value = CoversheetOsColumnName.BillDate;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillCollector].Value = CoversheetOsColumnName.BillCollector;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsCustomerCode].Value = CoversheetOsColumnName.CustomerCode;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsCustomerName].Value = CoversheetOsColumnName.CustomerName;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsPaymentTerm].Value = CoversheetOsColumnName.PaymentTerm;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsAmountOfBill].Value = CoversheetOsColumnName.AmountOfBill;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillPresentmentDate].Value = CoversheetOsColumnName.BillPresentmentDate;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsInvoiceNo].Value = CoversheetOsColumnName.InvoiceNo;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsInvoiceDate].Value = CoversheetOsColumnName.InvoiceDate;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsInvoiceAmount].Value = CoversheetOsColumnName.AmountInvoice;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBilingType].Value = CoversheetOsColumnName.BilingType;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsAttachDp].Value = CoversheetOsColumnName.AttachDp;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsAttachPo].Value = CoversheetOsColumnName.AttachPo;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsRemark].Value = CoversheetOsColumnName.Remark;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsCompanyCode].Value = CoversheetOsColumnName.CompanyCode;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsSalesOrg].Value = CoversheetOsColumnName.SalesOrg;

        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillNo, BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsSalesOrg].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillNo, BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsSalesOrg].Style.Fill.BackgroundColor.SetColor(colFromHex);
        //    wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillNo, BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsSalesOrg].Style.Font.Bold = true;
        //    #endregion

        //    #region set detail
        //    var row = AllInvoiceColumnHeader.RowDetail;

        //    if (billAttach.Any())
        //    {
        //        foreach (var item in billAttach)
        //        {
        //            var attachDp = attachDpConfig.FirstOrDefault(o => o.Code == item.AttachDP);
        //            var attachPo = attachPoConfig.FirstOrDefault(o => o.Code == item.AttachPO);
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsBillNo].Value = item.BillPresentmentNo;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsBillDate].Value = item.BillDate.HasValue ? item.BillDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsBillCollector].Value = item.BillCollector;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsCustomerCode].Value = item.CustomerCode;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsCustomerName].Value = item.CustomerName;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsPaymentTerm].Value = item.PaymentTerm;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsAmountOfBill].Value = (item.TotalAmount ?? 0).ToString();
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsBillPresentmentDate].Value = item.BillPresentmentDate.HasValue ? item.BillPresentmentDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsInvoiceNo].Value = item.BillingNo.Count() <= 1 ? Util.GetBillingNo(item.BillingNo.FirstOrDefault(), bu) : $"{Util.GetBillingNo(item.BillingNo.OrderBy(s => s).FirstOrDefault(), bu)}-{Util.GetBillingNo(item.BillingNo.OrderBy(s => s).LastOrDefault(), bu)}";
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsInvoiceDate].Value = item.BillingDate.Count() <= 1
        //                                    ? item.BillingDate.Where(s => s.HasValue).Select(s => s.Value.ToString("dd/MM/yyyy")).FirstOrDefault()
        //                                    : $"{item.BillingDate.Where(s => s.HasValue).OrderBy(s => s).Select(s => s.Value.ToString("dd/MM/yyyy")).FirstOrDefault()}-{item.BillingDate.Where(s => s.HasValue).OrderBy(s => s).Select(s => s.Value.ToString("dd/MM/yyyy")).LastOrDefault()}";
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsInvoiceAmount].Value = (item.BillingAmount ?? 0).ToString();
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsBilingType].Value = item.BillingType;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsAttachDp].Value = attachDp?.Name;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsAttachPo].Value = attachPo?.Name;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsRemark].Value = item.Remark;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsCompanyCode].Value = item.CompanyCode;
        //            wsSheet.Cells[row, BillAttachColumnHeader.ColumnsSalesOrg].Value = item.SalesOrg;

        //            row += 1;
        //        }
        //    }
        //    #endregion

        //    using (ExcelRange Rng = wsSheet.Cells[BillAttachColumnHeader.RowHeader, BillAttachColumnHeader.ColumnsBillNo, row, BillAttachColumnHeader.ColumnsSalesOrg])
        //    {
        //        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //    }
        //    wsSheet.Protection.IsProtected = false;
        //    wsSheet.Protection.AllowSelectLockedCells = false;

        //}
        //private static void SetAllDocSheet(ExcelPackage ExcelPkg, ExcelWorksheet wsSheet, Color colFromHex, string bu, string companyName, string sendDate
        //  , List<CoversheetOsAllDocDto> allDoc, List<CoversheetOsConfigDto> attachDpConfig, List<CoversheetOsConfigDto> attachPoConfig)
        //{
        //    wsSheet = ExcelPkg.Workbook.Worksheets.Add("All_Document");
        //    wsSheet.Cells[1, 1].Value = "All_Document";
        //    wsSheet.Cells[2, 1].Value = companyName;
        //    wsSheet.Cells[3, 1].Value = $"Send Date";
        //    wsSheet.Cells[3, 2].Value = $"{sendDate}";
        //    wsSheet.Cells[1, 1, 3, 3].Style.Font.Bold = true;

        //    #region set header
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsNo].Value = CoversheetOsColumnName.No;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSendToCustomerDate].Value = CoversheetOsColumnName.SendCustomerDate;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsBillCollector].Value = CoversheetOsColumnName.BillCollector;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsCustomerCode].Value = CoversheetOsColumnName.CustomerCode;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsCustomerName].Value = CoversheetOsColumnName.CustomerName;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSalesArea].Value = CoversheetOsColumnName.SalesArea;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSalesOrg].Value = CoversheetOsColumnName.SalesOrg;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsInvoiceNo].Value = CoversheetOsColumnName.InvoiceNo;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsInvoiceDate].Value = CoversheetOsColumnName.InvoiceDate;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsChequeNo].Value = CoversheetOsColumnName.ChequeNo;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsChequeDate].Value = CoversheetOsColumnName.ChequeDate;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsBillNo].Value = CoversheetOsColumnName.BillNo;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsBENo].Value = CoversheetOsColumnName.BENo;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsReceiptNo].Value = CoversheetOsColumnName.ReceiptNo;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsDpNo].Value = CoversheetOsColumnName.DPNo;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsPoNo].Value = CoversheetOsColumnName.PONo;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsAmount].Value = CoversheetOsColumnName.Amount;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsAddress].Value = CoversheetOsColumnName.Addtess;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsTelContact].Value = CoversheetOsColumnName.TelContact;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsRemark].Value = CoversheetOsColumnName.Remark;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSendTime].Value = CoversheetOsColumnName.SendTime;

        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsNo, AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSendTime].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsNo, AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSendTime].Style.Fill.BackgroundColor.SetColor(colFromHex);
        //    wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsNo, AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsSendTime].Style.Font.Bold = true;
        //    #endregion

        //    #region set detail
        //    var row = AllDocColumnHeader.RowDetail;

        //    if (allDoc.Any())
        //    {
        //        var index = 1;
        //        foreach (var item in allDoc)
        //        {
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsNo].Value = index;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsSendToCustomerDate].Value = item.SendDate.HasValue ? item.SendDate.Value.ToString("dd/MM/yyyy") : null;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsBillCollector].Value = item.BillCollector;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsCustomerCode].Value = item.CustomerCode;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsCustomerName].Value = item.CustomerName;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsSalesArea].Value = item.SalesArea;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsSalesOrg].Value = item.SalesOrg;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsInvoiceNo].Value = Util.GetBillingNo(item.BillingNo, bu);
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsInvoiceDate].Value = item.BillingDate.HasValue ? item.BillingDate.Value.ToString("dd/MM/yyyy") : null;
        //            //wsSheet.Cells[row, AllDocColumnHeader.ColumnsInvoiceNo].Value = item.BillingNo.Count() <= 1 ? item.BillingNo.FirstOrDefault() : $"{item.BillingNo.OrderBy(s => s).FirstOrDefault()}-{item.BillingNo.OrderBy(s => s).LastOrDefault()}";
        //            //wsSheet.Cells[row, AllDocColumnHeader.ColumnsInvoiceDate].Value = item.BillingDate.Count() <= 1
        //            //                        ? item.BillingDate.Where(s => s.HasValue).Select(s => s.Value.ToString("dd/MM/yyyy")).FirstOrDefault()
        //            //                        : $"{item.BillingDate.Where(s => s.HasValue).Select(s => s.Value.ToString("dd/MM/yyyy")).OrderBy(s => s).FirstOrDefault()}-{item.BillingDate.Where(s => s.HasValue).Select(s => s.Value.ToString("dd/MM/yyyy")).OrderBy(s => s).OrderBy(s => s).LastOrDefault()}";
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsChequeNo].Value = item.ChequeNo;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsChequeDate].Value = item.ChequeDate;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsBillNo].Value = item.DocumentType == OutsourceDocumentType.BillPresentment ? item.DocumentNo : string.Empty;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsBENo].Value = item.DocumentType == OutsourceDocumentType.BE ? item.DocumentNo : string.Empty;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsReceiptNo].Value = item.DocumentType == OutsourceDocumentType.Receipt ? item.TransactionNo : string.Empty;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsDpNo].Value = item.DocumentType == OutsourceDocumentType.DP ? item.DocumentNo : string.Empty;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsPoNo].Value = item.DocumentType == OutsourceDocumentType.PO ? item.DocumentNo : string.Empty;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsAmount].Value = (item.DocumentAmount ?? 0).ToString();
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsAddress].Value = item.Address;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsTelContact].Value = item.TelContact;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsRemark].Value = item.Remark;
        //            wsSheet.Cells[row, AllDocColumnHeader.ColumnsSendTime].Value = item.SendTime;

        //            row += 1;
        //            index += 1;
        //        }
        //    }

        //    #endregion

        //    using (ExcelRange Rng = wsSheet.Cells[AllDocColumnHeader.RowHeader, AllDocColumnHeader.ColumnsNo, row, AllDocColumnHeader.ColumnsSendTime])
        //    {
        //        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //    }
        //    wsSheet.Protection.IsProtected = false;
        //    wsSheet.Protection.AllowSelectLockedCells = false;

        //}
        //private static string GetCompanyName(List<CompanyDto> company) 
        //{
        //    var com = company.Where(o=> !string.IsNullOrEmpty(o.CompanyCode))
        //                        .GroupBy(o => new { o.CompanyCode, o.CompanyName })
        //                        .Select(o => new CompanyDto { CompanyCode = o.Key.CompanyCode, CompanyName = o.Key.CompanyName }).ToList();
        //    var name = string.Join(" & ", com.Select(o => o.CompanyName));
        //    var code = string.Join(" & ", com.Select(o => o.CompanyCode));
        //    return $"{name} {code}";
        //}

    }

    public class ConversheetOsResult 
    { 
        public string Bu { get; set; }
        public string SalesOrg { get; set; }
        public string FileName { get; set; }
        public byte[] Files { get; set; }
     
    }
    public class CompanyDto
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
    }

    public static class CoversheetOsColumnName
    {
        public const string InvoiceNo = "Invoice No.";
        public const string InvoiceDate = "Invoice Date";
        public const string IssueingDate = "Issuing Date";
        public const string BillCollector = "Bill Collector";
        public const string CustomerCode = "Customer Code";
        public const string CustomerName = "Customer Name";
        public const string PaymentTerm = "Payment Term";
        public const string AmountInvoice = "Amount Invoice";
        public const string PoNumber = "PO Number";
        public const string AttachDp = "Attach_DP";
        public const string AttachPo = "Attach_PO";
        public const string DistributionChannel = "Distribution Channel";
        public const string BilingType = "Billing Type";
        public const string CustomerDueDate = "Customer Due Date";
        public const string InvoiceType = "Invoice Type";
        public const string OutputName = "Output Name";
        public const string BillMethod = "Bill Method";
        public const string NoOfCopies = "Number Of Copies";
        public const string PDType = "ประเภทเอกสารที่ส่ง PD";
        public const string BillPresentmentDate = "Bill Presentment Date";
        public const string CompanyCode = "Company Code";
        public const string SalesOrg = "Sales Organization";
        public const string BillNo = "Bill No.";
        public const string BillDate = "Bill Date";
        public const string AmountOfBill = "Amount of Bill";
        public const string Remark = "Remark";
        public const string No = "No";
        public const string SendCustomerDate = "Send Customer Date";
        public const string SalesArea = "Sales Area";
        public const string ChequeNo = "Cheque No.";
        public const string ChequeDate = "Cheque Date";
        public const string BENo = "ตั๋ว B/E No.";
        public const string ReceiptNo = "Receipt No.";
        public const string DPNo = "DP No.";
        public const string PONo = "PO No.";
        public const string Amount = "Amount";
        public const string Addtess = "Address Receipt/Send Doc";
        public const string TelContact = "Tel Contact Receipt/Send Doc";
        public const string SendTime = "รอบส่ง";
    }
    public static class AllInvoiceColumnHeader
    {
        public const int RowHeader = 6;
        public const int RowDetail = 7;

        public const int ColumnsInvoiceNo = 1;
        public const int ColumnsIssueingDate = 2;
        public const int ColumnsBillCollector = 3;
        public const int ColumnsCustomerCode = 4;
        public const int ColumnsCustomerName = 5;
        public const int ColumnsPaymentTerm = 6;
        public const int ColumnsAmountInvoice = 7;
        public const int ColumnsPoNumber = 8;
        public const int ColumnsAttachDp = 9;
        public const int ColumnsAttachPo = 10;
        public const int ColumnsDistributionChannel = 11;
        public const int ColumnsBilingType = 12;
        public const int ColumnsCustomerDueDate = 13;
        public const int ColumnsInvoiceType = 14;
        public const int ColumnsOutputName = 15;
        public const int ColumnsBillMethod = 16;
        public const int ColumnsNoOfCopies = 17;
        public const int ColumnsPDType = 18;
        public const int ColumnsBillPresentmentDate = 19;
        public const int ColumnsCompanyCode = 20;
        public const int ColumnsSalesOrg = 21;
    }
    public static class BillAttachColumnHeader
    {
        public const int RowHeader = 6;
        public const int RowDetail = 7;

        public const int ColumnsBillNo = 1;
        public const int ColumnsBillDate = 2;
        public const int ColumnsBillCollector = 3;
        public const int ColumnsCustomerCode = 4;
        public const int ColumnsCustomerName = 5;
        public const int ColumnsPaymentTerm = 6;
        public const int ColumnsAmountOfBill = 7;
        public const int ColumnsBillPresentmentDate = 8;
        public const int ColumnsInvoiceNo = 9;
        public const int ColumnsInvoiceDate = 10;
        public const int ColumnsInvoiceAmount = 11;
        public const int ColumnsBilingType = 12;
        public const int ColumnsAttachDp = 13;
        public const int ColumnsAttachPo = 14;
        public const int ColumnsRemark = 15;
        public const int ColumnsCompanyCode = 15;
        public const int ColumnsSalesOrg = 16;
    }
    public static class AllDocColumnHeader
    {
        public const int RowHeader = 6;
        public const int RowDetail = 7;

        public const int ColumnsNo = 1;
        public const int ColumnsSendToCustomerDate = 2;
        public const int ColumnsBillCollector = 3;
        public const int ColumnsCustomerCode = 4;
        public const int ColumnsCustomerName = 5;
        public const int ColumnsSalesArea = 6;
        public const int ColumnsSalesOrg = 7;
        public const int ColumnsInvoiceNo = 8;
        public const int ColumnsInvoiceDate = 9;
        public const int ColumnsChequeNo = 10;
        public const int ColumnsChequeDate = 11;
        public const int ColumnsBillNo = 12;
        public const int ColumnsBENo = 13;
        public const int ColumnsReceiptNo = 14;
        public const int ColumnsDpNo = 15;
        public const int ColumnsPoNo = 16;
        public const int ColumnsAmount = 17;
        public const int ColumnsAddress = 18;
        public const int ColumnsTelContact = 19;
        public const int ColumnsRemark = 20;
        public const int ColumnsSendTime = 21;
    }
}
