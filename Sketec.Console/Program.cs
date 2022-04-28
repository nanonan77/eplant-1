using Microsoft.EntityFrameworkCore;
using Sketec.Infrastructure.Datas;
using System;

namespace Sketec.ConsoleApp
{
    class Program
    {
        static SketecContext CreateContext()
        {
            var option = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SketecContext>(), "Data Source=tcp:45.91.133.231;Initial Catalog=WebCredit;User Id=wcuser;Password=Ready123!").Options;
            var context = new SketecContext(option);
            return context;
        }

        static void Main(string[] args)
        {
            var loanAmount = 250000;
            var interest = 13.99 / 365;
            var month = 48;
            var minAmount = 6840;
            var date = new DateTime(2022, 02, 01);


            for (var i = 0; i < month; i++)
            {
                
                //var dayInMonth = DateTime.DaysInMonth(periodDate.Year, periodDate.Month);
            }
        }
    }
}
