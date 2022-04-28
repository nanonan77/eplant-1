using Ardalis.Specification;
using Sketec.Core.Abstracts;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class NewRegistNotiSpec : DapperSpecification<NewRegistNotiDto>
    {
        public NewRegistNotiSpec(int days)
        {
            Query = @$"SELECT n.Id NewRegistId, n.Title, n.ContractType, n.Verifier VerifierEmail, n.PIC, u.E_FullName Verifier, DATEDIFF(DAY, n.AssignToDate, GETDATE()) days
                FROM dbo.NewRegist n
	                INNER JOIN dbo.[User] u ON n.Verifier = u.Email
                WHERE n.IsActive = 1
                AND n.IsDelete = 0
                AND n.Status NOT IN ('Contract Signed', 'Completed')
                AND DATEDIFF(DAY, n.AssignToDate, GETDATE()) > {days.ToString()}";
        }
    }
    public class NewRegistNotiDto
    {
        public Guid NewRegistId { get; set; }
        public string ContractType { get; set; }
        public string Title { get; set; }
        public string VerifierEmail { get; set; }
        public string Verifier { get; set; }
        public string PIC { get; set; }
        public int Days { get; set; }
    }

    //public class NewRegistNotiSpec : Specification<NewRegist>
    //{
    //    public NewRegistNotiSpec(int days)
    //    {
    //        List<string> status = new List<string>(new string[] { "Contract Signed", "Completed" });
    //        Query.Where(m => (DateTime.Now.Date - m.AssignToDate.Value.Date).Days > days);
    //        Query.Where(m => !status.Contains(m.Status));
    //        Query.Where(m => m.IsActive == true);

    //    }
    //}

}
