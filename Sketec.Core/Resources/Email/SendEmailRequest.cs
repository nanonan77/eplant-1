using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.Email
{
    public class SendEmailRequest
    {
        public IEnumerable<string> EmailsTo { get; set; }
        public IEnumerable<string> EmailsCC { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public class Attachment
        {
            public string Name { get; set; }
            public byte[] Data { get; set; }
        }
    }
}
