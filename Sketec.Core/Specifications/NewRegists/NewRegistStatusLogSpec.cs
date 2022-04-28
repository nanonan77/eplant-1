using Ardalis.Specification;
using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class NewRegistStatusLogSpec : Specification<Sketec.Core.Domains.NewRegistStatusLog>, ISingleResultSpecification
    {
        public NewRegistStatusLogSpec InCludeNewRegists()
        {
            Query.Include(b => b.NewRegist);

            return this;
        }
    }


    public class NewRegistStatusLogCreateRequest
    {
        public string AssignTo { get; set; }
        public string CcTo { get; set; }
        public string Action { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public string Team { get; set; }
        public Guid? NewRegistId { get; set; }
        public string NewRegistNo { get; set; }


        public string Status2 { get; set; }
        public string Team2 { get; set; }

    }

    public class NewRegistStatusLogResultDto
    {
        public Guid Id { get; set; }
        public Guid? NewRegistId { get; set; }
        public string AssignTo { get; set; }
        public string CcTo { get; set; }
        public string Action { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public int? InboxDay { get; set; }
        public string NewRegistStatus { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class NewRegistStatusLogFilter
    {
        public Guid? Id { get; set; }
        public Guid? NewRegistId { get; set; }
        public string AssignTo { get; set; }
        public string CCTo { get; set; }
        public string Action { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public int? InboxDay { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
