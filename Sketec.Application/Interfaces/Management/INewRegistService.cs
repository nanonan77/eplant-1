using Sketec.Application.Migrations;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface INewRegistService : IApplicationService
    {
        Task ImportNewRegist(IEnumerable<Core.Domains.NewRegist> newRegists);
        Task ImportSubNewRegist(IEnumerable<SubNewRegist> subNewRegists);
        Task ImportSubNewRegistTestPlot(IEnumerable<SubNewRegistTestPlot> subNewRegistTestPlots);
        Task ImportNewRegistImagePath(IEnumerable<NewRegistImagePath> imagePaths);

        Task UploadNewRegistImagePath();
    }
}
