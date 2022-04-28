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
    public class NewPlantationImagePathSearchByPlantationIdSpec : Specification<NewRegistImagePath>
    {
        public NewPlantationImagePathSearchByPlantationIdSpec(string plantationId) 
        {
            Query.Where(f => f.SurveyId == plantationId && f.ImageLevel == NewRegistLevel.NewRegist && f.ItemType == "plantaion");
            Query.AsSplitQuery();
        }
    }
    public class NewPlantationImagePathSearchBySubPlantationIdSpec : Specification<NewRegistImagePath>
    {
        public NewPlantationImagePathSearchBySubPlantationIdSpec(string subPlantationId)
        {
            Query.Where(f => f.PlantationId == subPlantationId && f.ImageLevel == NewRegistLevel.SubNewRegist && f.ItemType == "subplantaion");
            Query.AsSplitQuery();
        }
    }
}
