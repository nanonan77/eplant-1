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
    public class RollingPlanDetailLinqSearchSpecLinqSearchSpec : QuerySpecification<RollingPlanDetailSearchResultDto>
    {
        RollingPlanDetailFilter filter;
        public RollingPlanDetailLinqSearchSpecLinqSearchSpec(RollingPlanDetailFilter filter)
        {
            this.filter = filter;
        }

        public override IQueryable<RollingPlanDetailSearchResultDto> OnQuery()
        {
            var query = from plantaion in Set<Plantation>()

                        join subPlantation in Set<SubPlantation>() on plantaion.Id equals subPlantation.PlantationId into subPlantation2
                        from subPlantation in subPlantation2.Where(q => q.IsDelete == false).DefaultIfEmpty()

                        join rollingPlan in Set<RollingPlan>() on plantaion.Id equals rollingPlan.PlantationId into rollingPlan2
                        from rollingPlan in rollingPlan2.Where(x => x.IsActive && x.IsDelete == false).DefaultIfEmpty()

                        join masterActivity in Set<MasterActivity>() on rollingPlan.MasterActivityId equals masterActivity.Id into masterActivity2
                        from masterActivity in masterActivity2.DefaultIfEmpty()

                        join masterActivityType in Set<MasterActivityType>() on masterActivity.MasterActivityTypeId equals masterActivityType.Id into masterActivityType2
                        from masterActivityType in masterActivityType2.DefaultIfEmpty()

                        where plantaion.IsDelete == false

                        select new RollingPlanDetailSearchResultDto
                        {
                            PlantationId = plantaion.Id,
                            PlantationNo = plantaion.PlantationNo,
                            PlanTitle = plantaion.Title,
                            Contract = plantaion.Contract,
                            ActivityGroup = masterActivityType != null ? masterActivityType.ActivityGroup : "",
                            ActivityTypeTitleEN = masterActivityType != null ? masterActivityType.TitleEN : "",
                            ActivityTypeTitleTH = masterActivityType != null ? masterActivityType.TitleTH : "",
                            SubPlantationTitle = subPlantation != null ? subPlantation.Title : "",
                            ActivityEN = masterActivity != null ? masterActivity.ActivityEN : "",
                            ActivityTH = masterActivity != null ? masterActivity.ActivityTH : "",
                            ActivityCode = masterActivity != null ? masterActivity.ActivityCode : "",
                            StartDate = rollingPlan != null ? rollingPlan.StartDate : null,
                            DueDate = rollingPlan != null ? rollingPlan.DueDate : null,
                            Area = subPlantation != null ? subPlantation.Area : null,
                            ActualArea = rollingPlan != null ? rollingPlan.ActualArea : null,
                            Status = rollingPlan != null ? rollingPlan.Status : "",
                            Note = rollingPlan != null ? rollingPlan.Note : "",
                            Action = "del,ref,",
                            IsActive = rollingPlan != null ? rollingPlan.IsActive : false,
                            CreatedDate = rollingPlan != null ? rollingPlan.CreatedDate : null,
                            UpdatedDate = rollingPlan != null ? rollingPlan.UpdatedDate : null,
                            CreatedBy = rollingPlan != null ? rollingPlan.CreatedBy : "",
                            UpdatedBy = rollingPlan != null ? rollingPlan.UpdatedBy : ""
                        };

            if (filter.Id.HasValue)
                query = query.Where(m => m.PlantationId == filter.Id);

            if (filter.Contract.HasValue)
                query = query.Where(m => m.Contract == filter.Contract);

            if (filter.StartDate.HasValue)
                query = query.Where(m => m.StartDate >= filter.StartDate);
            if (filter.DueDate.HasValue)
            {
                var dueDateTemp = filter.DueDate.Value.AddDays(1).Date;
                query = query.Where(m => m.DueDate < dueDateTemp); 
            }

            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                var status = filter.Status.Split(",");
                query = query.Where(m => status.Contains(m.Status));
            }

            return query;
        }
    }
    public class ActivityLinqSearchSpec : QuerySpecification<RollingPlanLookupFilterDto>
    {
        RollingPlanFilter filter;
        public ActivityLinqSearchSpec(RollingPlanFilter filter)
        {
            this.filter = filter;
        }

        public override IQueryable<RollingPlanLookupFilterDto> OnQuery()
        {
            var query = from plantaion in Set<Plantation>()
                        
                        join assumption in Set<Assumption>() on plantaion.NewRegistId equals assumption.NewRegistId
                        join expense in Set<Expense>() on assumption.Id equals expense.AssumptionId
                        join activity in Set<MasterActivity>() on expense.ActivityId equals activity.Id
                        //join activityType in Set<MasterActivityType>() on activity.MasterActivityTypeId equals activityType.Id

                        where plantaion.Id == filter.PlanId && !plantaion.IsDelete

                        select new RollingPlanLookupFilterDto
                        {
                            ActivityId = activity.Id ,
                            ActivityTypeId = activity != null ? activity.MasterActivityTypeId : null , 
                            IsActive = activity != null ? activity.IsActive : false
                        };



            if (filter.IsActive.HasValue)
            {
                query = query.Where(m => m.IsActive == filter.IsActive);
            }
            //if (filter.PlanId.HasValue)
            //    query = query.Where(m => m.PlantationId == filter.PlanId);

            //if (filter.Contract.HasValue)
            //    query = query.Where(m => m.Contract == filter.Contract);

            //if (filter.StartDate.HasValue)
            //    query = query.Where(m => m.StartDate >= filter.StartDate);
            //if (filter.DueDate.HasValue)
            //{
            //    var dueDateTemp = filter.DueDate.Value.AddDays(1).Date;
            //    query = query.Where(m => m.DueDate < dueDateTemp);
            //}

            //if (!string.IsNullOrWhiteSpace(filter.Status))
            //{
            //    var status = filter.Status.Split(",");
            //    query = query.Where(m => status.Contains(m.Status));
            //}

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

    public class RollingPlanDetailSearchResultDto
    {
        public Guid? RollingId { get; set; }
        public Guid? PlantationId { get; set; }
        public string PlantationNo { get; set; }
        public string PlanTitle { get; set; }
        public int? Contract { get; set; }
        public string ContractType { get; set; }
        public string PIC { get; set; }

        public int? ActivityTypeId { get; set; }
        public string ActivityTypeTitleEN { get; set; }
        public string ActivityTypeTitleTH { get; set; }
        public string ActivityGroup { get; set; }

        public string SubPlantationTitle { get; set; }
        public string SubPlantationNo { get; set; }
        public int? ActivityId { get; set; }
        public string ActivityEN { get; set; }
        public string ActivityTH { get; set; }
        public string ActivityCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? Area { get; set; }
        public decimal? ActualArea { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Action { get; set; }
        public bool IsActive { get; set; }
        public string Key { get; set; }

        public List<RollingPlanDetailSearchResultDto> Child { get; set; }

        public RollingPlanDetailSearchResultDto()
        {
            Child = new List<RollingPlanDetailSearchResultDto>();
        }
    }
    public class RollingPlanActivityTypeDto
    {
        public int Id { get; set; }
        public string PlantationNo { get; set; }
        public string Action { get; set; }
        public string TitleEN { get; set; }
        public string TitleTH { get; set; }
        public string ActivityGroup { get; set; }

        public bool IsActive { get; set; }

        public RollingPlanActivityDto RollingPlanActivityDto { get; set; }
        public RollingPlanActivityTypeDto()
        {
            RollingPlanActivityDto = new RollingPlanActivityDto();
        }
    }
    public class RollingPlanActivityDto
    {
        public Guid? RollingPlanId { get; set; }
        public Guid? PlantationId { get; set; }
        public string PlantationNo { get; set; }
        public string SubPlantationTitle { get; set; }
        public string ActivityEN { get; set; }
        public string ActivityTH { get; set; }
        public string ActivityCode { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? Area { get; set; }
        public decimal? ActualArea { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        public string Action { get; set; }
        public bool IsActive { get; set; }
    }

    public class RollingPlanLookupFilterDto
    {
        public int? ActivityTypeId { get; set; }
        public int? ActivityId { get; set; }
        public bool IsActive { get; set; }
    }
}
