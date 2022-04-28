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
    public class MasterActivityLinqSearchSpec : QuerySpecification<MasterActivityResultDto>
    {
        MasterActivityFilter filter;
        public MasterActivityLinqSearchSpec(MasterActivityFilter filter)
        {
            this.filter = filter;
        }

        public override IQueryable<MasterActivityResultDto> OnQuery()
        {
            var query = from ma in Set<MasterActivity>()
                        join mt in Set<MasterActivityType>() on ma.MasterActivityTypeId equals mt.Id into mt2
                        from mt in mt2.DefaultIfEmpty()

                        select new MasterActivityResultDto
                        {
                            Id = ma.Id,
                            MasterActivityTypeId = mt == null ? null : mt.Id,
                            IsActive = ma.IsActive,
                            TitleEN = mt == null ? null : mt.TitleEN,
                            TitleTH = mt == null ? null : mt.TitleTH,
                            ActivityCode = ma.ActivityCode,
                            ActivityEN = ma.ActivityEN,
                            ActivityTH = ma.ActivityTH,
                            CreatedBy = ma.CreatedBy,
                            CreatedDate = ma.CreatedDate,
                            UpdatedBy = ma.UpdatedBy,
                            UpdatedDate = ma.UpdatedDate,
                            ActivityGroup = mt == null ? null : mt.ActivityGroup,
                            IsExport = ma.IsExport,
                            IsExportMain = mt == null ? true : mt.IsExport,
                        };


            if (filter.MasterActivityTypeId != null)
            {
                query = query.Where(m => m.MasterActivityTypeId == filter.MasterActivityTypeId);
            }

            if (!string.IsNullOrWhiteSpace(filter.ActivityCode))
            {
                query = query.Where(m => m.ActivityCode.Contains(filter.ActivityCode));
            }

            if (!string.IsNullOrWhiteSpace(filter.ActivityEN))
            {
                query = query.Where(m => m.ActivityEN.Contains(filter.ActivityEN));
            }

            if (!string.IsNullOrWhiteSpace(filter.ActivityTH))
            {
                query = query.Where(m => m.ActivityTH.Contains(filter.ActivityTH));
            }

            if (filter.IsActive != null)
            {
                query = query.Where(m => m.IsActive == filter.IsActive);
            }

            if (filter.IsExport != null)
            {
                query = query.Where(m => m.IsExport == filter.IsExport || m.IsExportMain == filter.IsExport);
            }

            return query;
        }
    }

    public class MasterActivityResultDto
    {
        public int Id { get; set; }
        public int? MasterActivityTypeId { get; set; }
        public string TitleEN { get; set; }
        public string TitleTH { get; set; }
        public string ActivityGroup { get; set; }
        public int Seq { get; set; }
        public string ActivityEN { get; set; }
        public string ActivityTH { get; set; }
        public string ActivityCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsExport { get; set; }
        public bool IsExportMain { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
