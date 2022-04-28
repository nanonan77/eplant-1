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
    public class NewRegistStatusLogLinqSearchSpec : QuerySpecification<NewRegistStatusLogResultDto>
    {
        NewRegistStatusLogFilter filter;
        public NewRegistStatusLogLinqSearchSpec(NewRegistStatusLogFilter filter)
        {
            this.filter = filter;
        }

        public override IQueryable<NewRegistStatusLogResultDto> OnQuery()
        {
            var query = from newRegStaLog in Set<NewRegistStatusLog>()
                        //join newReg in Set<NewRegist>() on newRegStaLog.NewRegistId equals newReg.Id into j1
                        //from result in j1.DefaultIfEmpty()

                        select new NewRegistStatusLogResultDto
                        {
                            Id = newRegStaLog.Id,
                            NewRegistId = newRegStaLog.NewRegistId,
                            IsActive = newRegStaLog.IsActive,
                            AssignTo = newRegStaLog.AssignTo,
                            CcTo = newRegStaLog.CCTo,
                            Action = newRegStaLog.Action,
                            Comment = newRegStaLog.Comment,
                            InboxDay = newRegStaLog.InboxDay,
                            CreatedBy = newRegStaLog.CreatedBy,
                            CreatedDate = newRegStaLog.CreatedDate,
                            UpdatedBy = newRegStaLog.UpdatedBy,
                            UpdatedDate = newRegStaLog.UpdatedDate,
                            //NewRegistStatus = result == null ? "" : result.Status
                        };

            if (filter.Id.HasValue)
            {
                query = query.Where(m => m.Id == filter.Id);
            }
            if (filter.NewRegistId.HasValue)
            {
                query = query.Where(m => m.NewRegistId == filter.NewRegistId);
            }

            //if (!string.IsNullOrWhiteSpace(filter.Status))
            //{
            //    query = query.Where(m => m.Status.Contains(filter.Status));
            //}

            if (!string.IsNullOrWhiteSpace(filter.AssignTo))
            {
                query = query.Where(m => m.AssignTo.Contains(filter.AssignTo));
            }

            if (!string.IsNullOrWhiteSpace(filter.CCTo))
            {
                query = query.Where(m => m.CcTo.Contains(filter.CCTo));
            }

            if (filter.IsActive.HasValue)
            {
                query = query.Where(m => m.IsActive == filter.IsActive);
            }

            return query;
        }
    }
}
