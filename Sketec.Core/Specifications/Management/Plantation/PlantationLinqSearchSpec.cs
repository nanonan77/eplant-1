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
    public class PlantationLinqSearchSpecLinqSearchSpec : QuerySpecification<PlantationSearchResultDto>
    {
        PlantationFilter filter;
        public PlantationLinqSearchSpecLinqSearchSpec(PlantationFilter filter)
        {
            this.filter = filter;
        }

        public override IQueryable<PlantationSearchResultDto> OnQuery()
        {
            var query = from newReg in Set<NewRegist>()
                          
                        join plantaion in Set<Plantation>() on newReg.Id equals plantaion.NewRegistId into j1
                        from plantaion in j1.DefaultIfEmpty()

                            //join pic in Set<User>() on newReg.PIC equals pic.Email into pic2
                            //from pic in pic2.DefaultIfEmpty()
                        join f in Set<FileInfo>() on newReg.Id equals f.RefId into f2
                        from f in f2.Where(x => x.FileType == "NewPlantation").DefaultIfEmpty()

                        join g in Set<FileInfo>() on plantaion.Id equals g.RefId into f3
                        from g in f3.Where(x => x.FileType == "NewPlantationAmortized").DefaultIfEmpty()

                        join h in Set<FileInfo>() on plantaion.Id equals h.RefId into f4
                        from h in f4.Where(x => x.FileType == "NewPlantationPlanYield").DefaultIfEmpty()

                        where newReg.IsDelete == false 
                        select new PlantationSearchResultDto
                        {
                            Id = plantaion.Id,
                            NewRegistId = newReg.Id,
                            RegistNo = newReg.RegistId,
                            PlantationNo = plantaion.PlantationNo == null ? "" : plantaion.PlantationNo,
                            Title = newReg.Title,
                            ContractType = newReg.ContractType,
                            Status = newReg.IsActive == false ? "Cancel": plantaion.PlantationNo == null ? "Contract Signed" : "Completed",
                            PIC = plantaion.PIC == null ? newReg.PIC : plantaion.PIC,
                            Action = "del,ref,",
                            IsActive = newReg.IsActive,
                            CreatedDate = newReg.CreatedDate,
                            UpdatedDate = newReg.UpdatedDate,
                            CreatedBy = newReg.CreatedBy,
                            UpdatedBy = newReg.UpdatedBy,
                            IsCanEdit = true,
                            FileId = f == null ? null : f.Id,
                            FileAmortizedId = g == null ? null : g.Id,
                            FilePlanYieldId = h == null ? null : h.Id
                        };
            if (filter.NewRegistID != null) {
                query = query.Where(m => m.NewRegistId == filter.NewRegistID);
            }
            
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

            if (!string.IsNullOrWhiteSpace(filter.PlantationId))
                query = query.Where(m => m.PlantationNo.Contains(filter.PlantationId));

            return query;
        }
    }

    public class PlantationLinqSearchSpec : QuerySpecification<PlantationSearchResultDto>
    {
        PlantationFilter filter;
        public PlantationLinqSearchSpec(PlantationFilter filter)
        {
            this.filter = filter;
        }

        public override IQueryable<PlantationSearchResultDto> OnQuery()
        {
            var query = from plantaion in Set<Plantation>()
                        where plantaion.IsDelete == false
                        select new PlantationSearchResultDto
                        {
                            Id = plantaion.Id,
                            NewRegistId = plantaion.NewRegistId,
                            PlantationNo = plantaion.PlantationNo ,
                            Title = plantaion.Title,
                            ContractType = plantaion.ContractType,
                            Status = plantaion.IsActive == false ? "Cancel" : plantaion.PlantationNo == null ? "Contract Signed" : "Completed",
                            PIC = plantaion.PIC == null ? plantaion.PIC : plantaion.PIC,
                            Action = "del,ref,",
                            IsActive = plantaion.IsActive,
                            CreatedDate = plantaion.CreatedDate,
                            UpdatedDate = plantaion.UpdatedDate,
                            CreatedBy = plantaion.CreatedBy,
                            UpdatedBy = plantaion.UpdatedBy,
                            IsCanEdit = true
                        };
            if (filter.NewRegistID != null)
            {
                query = query.Where(m => m.NewRegistId == filter.NewRegistID);
            }

            return query;
        }
    }

    public class PlantationSearchResultDto
    {
        public Guid? Id { get; set; }
        public Guid? NewRegistId { get; set; }
        public string RegistNo { get; set; }
        public string PlantationNo { get; set; }
        public string Title { get; set; }
        public string ContractType { get; set; }
        public string Status { get; set; }
        public string PIC { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Action { get; set; }
        public bool IsActive { get; set; }
        public bool IsCanEdit { get; set; }
        public Guid? FileId { get; set; }
        public Guid? FileAmortizedId { get; set; }
        public Guid? FilePlanYieldId { get; set; }
    }
}
