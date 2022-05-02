using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;

namespace Sketec.Core.Specifications
{
    public class NewRegistImagePathSearchByRegistIdSpec : Specification<NewRegistImagePath>
    {
        public NewRegistImagePathSearchByRegistIdSpec(string regisNoId) 
        {
            Query.Where(f => f.SurveyId == regisNoId && f.ImageLevel == NewRegistLevel.NewRegist);
            Query.AsSplitQuery();
        }
    }
    public class NewRegistImagePathSearchBySubRegistIdSpec : Specification<NewRegistImagePath>
    {
        public NewRegistImagePathSearchBySubRegistIdSpec(string subRegisId)
        {
            Query.Where(f => f.PlantationId == subRegisId && f.ImageLevel == NewRegistLevel.SubNewRegist);
            Query.AsSplitQuery();
        }
    }
    public class NewRegistImagePathSearchBySubRegistTestProtIdSpec : Specification<NewRegistImagePath>
    {
        public NewRegistImagePathSearchBySubRegistTestProtIdSpec(string subRegisTestPlotId)
        {
            Query.Where(f => f.ImageInfo2 == subRegisTestPlotId && f.ImageLevel == NewRegistLevel.SubNewRegistTestPlot);
            Query.AsSplitQuery();
        }
    }
    public class NewRegistImagePathAllRegistIdSpec : Specification<NewRegistImagePath>
    {
        public NewRegistImagePathAllRegistIdSpec(string regisNoId)
        {
            Query.Where(f => f.SurveyId == regisNoId);
            Query.AsSplitQuery();
        }
    }
}
