using Ardalis.Specification;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class RollingPlanSearchSpec : Specification<RollingPlan>
    {
        //public StatusTrackingSearchSpec(StatusTrackingFilter filter)
        //{
        //    if (!string.IsNullOrWhiteSpace(filter.Title))
        //        Query.Where(m => m.Title == filter.Title);

        //    if (!string.IsNullOrWhiteSpace(filter.RegistID))
        //        Query.Where(m => m.RegistId == filter.RegistID);

        //    if (!string.IsNullOrWhiteSpace(filter.Status))
        //    {
        //        var status = filter.ContractType.Split(",");
        //        Query.Where(m => status.Contains(m.Status));
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.ContractType))
        //    {
        //        var contractType = filter.ContractType.Split(",");
        //        Query.Where(m => contractType.Contains(m.Contract.GetValueOrDefault().ToString())); 
        //    }

        //    if (!string.IsNullOrWhiteSpace(filter.PIC))
        //        Query.Where(m => m.PIC == filter.PIC);

        //    if (!string.IsNullOrWhiteSpace(filter.Verifier))
        //        Query.Where(m => m.Verifier == filter.Verifier);

        //}
    }

    public class RollingPlanFilter
    {
        public string Title { get; set; }
        public string PlantationNo { get; set; }
        public string PIC { get; set; }
    }
}
