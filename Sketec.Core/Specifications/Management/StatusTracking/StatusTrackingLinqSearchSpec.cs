using Sketec.Core.Abstracts;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class StatusTrackingLinqSearchSpec : QuerySpecification<StatusTrackingSearchResultDto>
    {
        StatusTrackingFilter filter;
        string role;
        string team;
        string username;
        string email;
        string section;
        public StatusTrackingLinqSearchSpec(StatusTrackingFilter filter, string role = null, string team = null, string username = null, string email = null, string section = null)
        {
            this.filter = filter;
            this.role = role;
            this.team = team;
            this.username = username;
            this.email = email;
            this.section = section;
        }

        public override IQueryable<StatusTrackingSearchResultDto> OnQuery()
        {
            List<string> roleList = new List<string>(new string[] { "S", "SS", "M" });
            List<string> roleList2 = new List<string>(new string[] { "O1", "O2" });
            var query = from newReg in Set<NewRegist>()

                        join verifier in Set<User>() on newReg.Verifier equals verifier.Email into verifier2
                        from verifier in verifier2.DefaultIfEmpty()

                        join pic in Set<User>() on newReg.PIC equals pic.Email into pic2
                        from pic in pic2.DefaultIfEmpty()

                        join a in Set<Assumption>() on newReg.Id equals a.NewRegistId into a2
                        from a in a2.DefaultIfEmpty()

                        join f in Set<FileInfo>() on newReg.Id equals f.RefId into f2
                        from f in f2.Where(x => x.FileType == "NewRegist").DefaultIfEmpty()

                        where newReg.IsDelete == false
                        select new StatusTrackingSearchResultDto
                        {
                            InboxDay = DateTime.Now.Date.Subtract(newReg.AssignToDate.HasValue ? newReg.AssignToDate.Value.Date : DateTime.Now.Date).Days,
                            IsActive = newReg.IsActive,

                            Id = newReg.Id,
                            AssumptionId = a == null ? null : a.Id,
                            Title = newReg.Title,
                            RegistNo = newReg.RegistId,
                            ContractType = newReg.ContractType,
                            Team = newReg.Team,
                            Status = newReg.IsActive == false ? "Cancel" : newReg.Status,
                            Verifier = verifier == null ? newReg.Verifier : verifier.E_FullName,
                            VerifierEmail = newReg.Verifier,
                            PIC = pic == null ? newReg.PIC : pic.E_FullName,
                            PICEmail = newReg.PIC,

                            CreatedDate = newReg.CreatedDate,
                            UpdatedDate = newReg.UpdatedDate,
                            CreatedBy = newReg.CreatedBy,
                            UpdatedBy = newReg.UpdatedBy,
                            IsCanEdit = true,
                            FileId = f == null ? null : f.Id,
                            PriceAtPlant = newReg.PriceAtPlant
                        };


            if (!string.IsNullOrWhiteSpace(filter.RegistID))
                query = query.Where(m => m.RegistNo.Contains(filter.RegistID));

            if (!string.IsNullOrWhiteSpace(filter.Title))
                query = query.Where(m => m.Title.Contains(filter.Title));

            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                var status = filter.Status.Split(",");
                query = query.Where(m => status.Contains(m.Status));
            }

            if (!string.IsNullOrWhiteSpace(filter.ContractType))
            {
                var contractType = filter.ContractType.Split(",");
                query = query.Where(m => contractType.Contains(m.ContractType));
            }

            if (!string.IsNullOrWhiteSpace(filter.PIC))
                query = query.Where(m => m.PIC.Contains(filter.PIC));

            if (!string.IsNullOrWhiteSpace(filter.Verifier))
                query = query.Where(m => m.Verifier.Contains(filter.Verifier));

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (role == "O1" || role == "O2")
                {
                    query = query.Where(m => m.VerifierEmail == email || m.PICEmail == email);
                }
            }

            return query;
        }
    }

    public class StatusTrackingSearchResultDto
    {
        public Guid? Id { get; set; }
        public Guid? AssumptionId { get; set; }
        public string Title { get; set; }
        public string RegistNo { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string ContractType { get; set; }
        public string UpDownFile { get; set; }
        public int InboxDay { get; set; }
        public string PIC { get; set; }
        public string PICEmail { get; set; }
        public string Verifier { get; set; }
        public string VerifierEmail { get; set; }
        public bool IsActive { get; set; }
        public bool IsCanEdit { get; set; }
        public Guid? FileId { get; set; }
        public decimal PriceAtPlant { get; set; }
    }
}
