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
    public class RollingPlanLinqSearchSpecLinqSearchSpec : QuerySpecification<RollingPlanSearchResultDto>
    {
        RollingPlanFilter filter;
        public RollingPlanLinqSearchSpecLinqSearchSpec(RollingPlanFilter filter)
        {
            this.filter = filter;
        }

        public override IQueryable<RollingPlanSearchResultDto> OnQuery()
        {
            var query = from plantaion in Set<Plantation>()
                        //where plantaion.IsDelete == false
                        select new RollingPlanSearchResultDto
                        {
                            Id = plantaion.Id,
                            PlantationNo = plantaion.PlantationNo == null ? "" : plantaion.PlantationNo,
                            Title = plantaion.Title,
                            ContractType = plantaion.ContractType,
                            PIC = plantaion.PIC == null ? "" : plantaion.PIC,
                            Action = "del,ref,",
                            IsActive = plantaion.IsActive,
                            CreatedDate = plantaion.CreatedDate,
                            UpdatedDate = plantaion.UpdatedDate,
                            CreatedBy = plantaion.CreatedBy,
                            UpdatedBy = plantaion.UpdatedBy
                        };


            if (!string.IsNullOrWhiteSpace(filter.Title))
                query = query.Where(m => m.Title.Contains(filter.Title));

            if (!string.IsNullOrWhiteSpace(filter.PIC))
                query = query.Where(m => m.PIC.Contains(filter.PIC));

            if (!string.IsNullOrWhiteSpace(filter.PlantationNo))
                query = query.Where(m => m.PlantationNo.Contains(filter.PlantationNo));

            return query;
        }
    }

    public class RollingPlanSearchResultDto
    {
        public Guid? Id { get; set; }
        public string PlantationNo { get; set; }
        public string Title { get; set; }
        public string ContractType { get; set; }
        public string PIC { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Action { get; set; }
        public bool IsActive { get; set; }
    }
}
