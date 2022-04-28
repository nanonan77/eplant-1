using Sketec.Core.Domains;
using System.Collections.Generic;

namespace Sketec.Application.Interfaces
{
    public interface IApplicationService
    {
        string UserName { get; set; }
        string Role { get; set; }
        string Name { get; set; }
        string Team { get; set; }
        string Email { get; set; }
        string Section { get; set; }
        string Department { get; set; }
    }
}
