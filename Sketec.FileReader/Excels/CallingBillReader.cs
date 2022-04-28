using OfficeOpenXml;
using Sketec.FileReader.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.FileReader.Excels
{
    //public static class CallingBillReader
    //{
    //    public static List<CallingBillDetail> GetCallingBillDetails(byte[] byteArray) 
    //    {
    //        using (Stream stream = new MemoryStream(byteArray))
    //        {
    //            var callingBillDetailList = new List<CallingBillDetail>();
    //            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    //            ExcelPackage package = new ExcelPackage(stream);
    //            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

    //            for (var row = 1; row <= worksheet.Dimension.End.Row; row++)
    //            {
    //                if (row < CallingBillColumns.RowDetailStart)
    //                {
    //                    continue;
    //                }
    //                var companyCode = worksheet.Cells[row, CallingBillColumns.ColumnCompanyCode].Value?.ToString();
    //                var salesOrgCode = worksheet.Cells[row, CallingBillColumns.ColumnSalesOrgCode].Value?.ToString();
    //                var customerCode = worksheet.Cells[row, CallingBillColumns.ColumnCustomerCode].Value?.ToString();
    //                var customerName = worksheet.Cells[row, CallingBillColumns.ColumnCustomerName].Value?.ToString();
    //                var invoiceNo = worksheet.Cells[row, CallingBillColumns.ColumnInvoiceNo].Value?.ToString();
    //                var invoiceDate = worksheet.Cells[row, CallingBillColumns.ColumnInvoiceDate].GetDate();
    //                var invoiceAmount = worksheet.Cells[row, CallingBillColumns.ColumnInvoiceAmount].GetDecimal();
    //                var dueDate = worksheet.Cells[row, CallingBillColumns.ColumnDueDate].GetDate();
    //                var inst = worksheet.Cells[row, CallingBillColumns.ColumnInst].Value?.ToString();
    //                var remark = worksheet.Cells[row, CallingBillColumns.ColumnRemark].Value?.ToString();
    //                var chequeDate = worksheet.Cells[row, CallingBillColumns.ColumnChequeDate].GetDate();
    //                var tDate = worksheet.Cells[row, CallingBillColumns.ColumnTDate].GetDate();
    //                var date = worksheet.Cells[row, CallingBillColumns.ColumnDate].GetDate();
    //                var status = worksheet.Cells[row, CallingBillColumns.ColumnStatus].Value?.ToString();
    //                //var resultRemark = worksheet.Cells[row, CallingBillColumns.ColumnResultRemark].Value?.ToString();
    //                var salesArea = worksheet.Cells[row, CallingBillColumns.ColumnSalesArea].Value?.ToString();
    //                var refNo = worksheet.Cells[row, CallingBillColumns.ColumnRefNo].Value?.ToString();
    //                var bcName = worksheet.Cells[row, CallingBillColumns.ColumnBCName].Value?.ToString();

    //                if (string.IsNullOrEmpty(customerCode) && string.IsNullOrEmpty(invoiceNo))
    //                {
    //                    break;
    //                }

    //                var callingBill = new CallingBillDetail
    //                {
    //                    CompanyCode = companyCode,
    //                    SalesOrgCode = salesOrgCode,
    //                    CustomerCode = customerCode,
    //                    CustomerName = customerName,
    //                    InvoiceNo = invoiceNo,
    //                    InvoiceDate = invoiceDate,
    //                    InvoiceAmount = invoiceAmount,
    //                    DueDate = dueDate,
    //                    Inst = inst,
    //                    Remark = remark,
    //                    ChequeDate = chequeDate,
    //                    TDate = tDate,
    //                    Date = date,
    //                    Status = status,
    //                    SalesArea = salesArea,
    //                    RefNo = refNo,
    //                    BCName = bcName
    //                };
    //                callingBillDetailList.Add(callingBill);
    //            }

    //            return callingBillDetailList;
    //        }
    //    }
    //}

    //public static class CallingBillColumns 
    //{
    //    public const int RowDetailStart = 2;

    //    public const int ColumnNo = 1;
    //    public const int ColumnCompanyCode = 2;
    //    public const int ColumnSalesOrgCode = 3;
    //    public const int ColumnCustomerCode = 4;
    //    public const int ColumnCustomerName = 5;
    //    public const int ColumnInvoiceNo = 6;
    //    public const int ColumnInvoiceDate = 7;
    //    public const int ColumnInvoiceAmount = 8;
    //    public const int ColumnDueDate = 9;
    //    public const int ColumnInst = 10;
    //    public const int ColumnChequeDate = 11;
    //    public const int ColumnTDate = 12;
    //    public const int ColumnDate = 13;
    //    public const int ColumnStatus = 14;
    //    public const int ColumnRemark = 15;
    //    public const int ColumnSalesArea = 16;
    //    public const int ColumnRefNo = 17;
    //    public const int ColumnBCName = 18;
    //    public const int ColumnScgConfirm = 19;
    //    public const int ColumnScgRemark = 20;
    //}
}
