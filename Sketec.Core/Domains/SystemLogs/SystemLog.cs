using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains.SystemLogs
{
    public class SystemLog
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Topic { get; set; }
        public LogType Type { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
