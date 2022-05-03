using Sketec.Application.Filters;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.FileWriter.Excels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IMapping9999Service : IApplicationService
    {
        Task<IEnumerable<Mapping9999SearchDto>> GetMapping9999(Mapping9999Filter filter);
    }
}
