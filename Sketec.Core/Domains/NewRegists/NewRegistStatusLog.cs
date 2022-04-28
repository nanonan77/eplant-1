using EnsureThat;
using Sketec.Core.Domains.Types;
using Sketec.Core.Exceptions;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class NewRegistStatusLog : EntityTransaction, IAggregateRoot
    {
        public string AssignTo { get; set; }
        public string CCTo { get; set; }
        public string Action { get; set; }
        public string Comment { get; set; }
        public int? InboxDay { get; set; }
        public string Status { get; set; }

        public Guid? NewRegistId { get; set; }
        public NewRegist NewRegist { get; private set; }

    }
}
