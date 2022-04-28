using Sketec.Application.Interfaces;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Services
{
    public abstract class ApplicationService : IApplicationService
    {
        public string UserName { get; set; }
        public string Role { get; set; }

        public string Name { get; set; }
        public string Team { get; set; }
        public string Email { get; set; }
        public string Section { get; set; }
        public string Department { get; set; }
    }
}
