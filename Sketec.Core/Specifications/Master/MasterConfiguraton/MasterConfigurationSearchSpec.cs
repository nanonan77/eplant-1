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
    public class MasterConfigurationSearchSpec : Specification<MasterConfiguration>
    {
        public MasterConfigurationSearchSpec(MasterConfigurationFilter filter)
        {
            if (filter.Id != null)
                Query.Where(m => m.Id == filter.Id);

            if (!string.IsNullOrWhiteSpace(filter.ConfigurationKey))
                Query.Where(m => m.ConfigurationKey == filter.ConfigurationKey);

            if (!string.IsNullOrWhiteSpace(filter.Code))
                Query.Where(m => m.Code == filter.Code);

            if (!string.IsNullOrWhiteSpace(filter.Value))
                Query.Where(m => m.Value == filter.Value);

            //if(filter.IsActive != null)
            //    Query.Where(m => m.IsActive == filter.IsActive);

            Query.Where(m => m.IsActive == true);
            Query.Where(m => m.IsDelete == false);

        }
    }

    public class MasterConfigurationFilter
    {
        public int? Id { get; set; }
        public string ConfigurationKey { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public bool? IsActive { get; set; }
    }

    public class MasterConfigurationCreateRequest
    {
        public int? Id { get; set; }
        public string ConfigurationKey { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }

    public class MasterConfigurationUpdateRequest
    {
        public int? Id { get; set; }
        public string ConfigurationKey { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }

}
