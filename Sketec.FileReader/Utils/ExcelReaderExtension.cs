using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.FileReader.Utils
{
    public static class ExcelReaderExtension
    {
        public static DateTime? GetDate(this ExcelRange cell, string format = "dd/MM/yyyy")
        {
            var val = cell.Value;
            if (val == null)
            {
                return null;
            }

            string str;
            if (val is DateTime)
            {
                return (DateTime)val;
            }
            else
            {
                str = cell.Text;
            }

            if (DateTime.TryParseExact(str, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }

            return null;
        }

        public static string GetString(this ExcelRange cell)
        {
            var str = cell.Text;
            if (string.IsNullOrWhiteSpace(str) || str.ToLower() == "null")
            {
                return null;
            }

            return str.Trim();
        }

        public static decimal? GetDecimal(this ExcelRange cell)
        {
            var val = cell.Value;
            if (val == null)
            {
                return null;
            }

            if (val is decimal)
            {
                return (decimal)val;
            }

            var str = val.ToString();
            if (decimal.TryParse(str, out decimal result))
            {
                return result;
            }

            return null;
        }

        public static int? GetInt(this ExcelRange cell)
        {
            var val = cell.Value;
            if (val == null)
            {
                return null;
            }

            if (val is int)
            {
                return (int)val;
            }

            var str = val.ToString();
            if (int.TryParse(str, out int result))
            {
                return result;
            }

            return null;
        }

        public static bool? GetBoolFromInt(this ExcelRange cell)
        {
            var val = cell.Value;
            if (val == null)
            {
                return null;
            }

            if (val is int)
            {
                var i = (int)val;
                return i > 0;
            }

            var str = val.ToString();
            if (int.TryParse(str, out int result))
            {
                return result > 0;
            }

            return null;
        }
    }
}
