using Microsoft.EntityFrameworkCore;
using Sketec.Core.Domains.SystemLogs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Datas.WebCreditLog
{
    public class WebCreditLogContext : DbContext
    {
        public DbSet<SystemLog> SystemLogs { get; set; }

        public WebCreditLogContext([NotNull] DbContextOptions<WebCreditLogContext> options) : base(options)
        {

        }
    }
}
