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
    public class UnplanLinqSearchSpec : QuerySpecification<UnplanSearchResult>
    {
        UnplanSearchFilter filter;
        string pic;
        string sectionName;
        string approver;
        public UnplanLinqSearchSpec(UnplanSearchFilter filter, string pic, string sectionName, string approver)
        {
            this.filter = filter;
            this.pic = pic;
            this.sectionName = sectionName;
            this.approver = approver;
        }

        public override IQueryable<UnplanSearchResult> OnQuery()
        {
            var defaultContractType = new List<string> { "MOU", "Rental" };
            var query = from plantaion in Set<Plantation>()
                        join newReg in Set<NewRegist>() on plantaion.NewRegistId equals newReg.Id

                        join pic in Set<User>() on plantaion.PIC equals pic.Email into pic2
                        from pic in pic2.DefaultIfEmpty()
                        where newReg.IsDelete == false
                                && defaultContractType.Contains(plantaion.ContractType)
                                && plantaion.IsActive
                                && !plantaion.IsDelete
                                && plantaion.ContractStartDate != null
                        select new UnplanSearchResult
                        {
                            Id = plantaion.Id,
                            NewRegistId = newReg.Id,
                            PlantationId = plantaion.PlantationNo,
                            Title = newReg.Title,
                            ContractType = newReg.ContractType,
                            Status = plantaion.Unplans == null || plantaion.Unplans.Count() == 0 ? string.Empty : plantaion.Unplans.OrderBy(o => o.CreatedDate).LastOrDefault().OverAllStatus, // string.IsNullOrEmpty(plantaion.OverAllStatus) ? "Wait for Approve" : plantaion.OverAllStatus,
                            PIC = string.IsNullOrEmpty(plantaion.PIC) ? newReg.PIC : plantaion.PIC,
                            Approver1 = plantaion.Unplans == null || plantaion.Unplans.Count() == 0 ? string.Empty : plantaion.Unplans.OrderBy(o => o.CreatedDate).LastOrDefault().Approver1, //plantaion.Approver1,
                            Approver2 = plantaion.Unplans == null || plantaion.Unplans.Count() == 0 ? string.Empty : plantaion.Unplans.OrderBy(o => o.CreatedDate).LastOrDefault().Approver2, //plantaion.Approver2,
                            Approver3 = plantaion.Unplans == null || plantaion.Unplans.Count() == 0 ? string.Empty : plantaion.Unplans.OrderBy(o => o.CreatedDate).LastOrDefault().Approver3, //plantaion.Approver3,
                            StatusApprover1 = plantaion.Unplans == null || plantaion.Unplans.Count() == 0 ? string.Empty : plantaion.Unplans.OrderBy(o => o.CreatedDate).LastOrDefault().StatusApprover1, //plantaion.StatusApprover1,
                            StatusApprover2 = plantaion.Unplans == null || plantaion.Unplans.Count() == 0 ? string.Empty : plantaion.Unplans.OrderBy(o => o.CreatedDate).LastOrDefault().StatusApprover2, //plantaion.StatusApprover2,
                            StatusApprover3 = plantaion.Unplans == null || plantaion.Unplans.Count() == 0 ? string.Empty : plantaion.Unplans.OrderBy(o => o.CreatedDate).LastOrDefault().StatusApprover3, //plantaion.StatusApprover3,
                            IsActive = newReg.IsActive,
                            CreatedDate = newReg.CreatedDate,
                            UpdatedDate = newReg.UpdatedDate,
                            CreatedBy = newReg.CreatedBy,
                            UpdatedBy = newReg.UpdatedBy,
                            SectionName = pic.Sec_Name
                        };
          

            if (!string.IsNullOrWhiteSpace(filter.Title))
                query = query.Where(m => m.Title.Contains(filter.Title));

            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                if (filter.Status == UnplanStatusType.WaitforApproveMyTask.GetStringValue())
                {
                    query = query.Where(m => m.Status == UnplanStatusType.WaitforApprove.GetStringValue() && (approver == m.Approver1 || approver == m.Approver2 || approver == m.Approver3));
                }
                else
                {
                    query = query.Where(m => m.Status == filter.Status);
                }
            }

            if (!string.IsNullOrWhiteSpace(filter.ContractType))
            {
                var contractType = filter.ContractType.Split(",");
                query = query.Where(m => contractType.Contains(m.ContractType));
            }

            if (!string.IsNullOrWhiteSpace(filter.PIC))
                query = query.Where(m => m.PIC.Contains(filter.PIC));

            if (!string.IsNullOrWhiteSpace(filter.PlantationId))
                query = query.Where(m => m.PlantationId.Contains(filter.PlantationId));


            // Role เป็น Operation 
            if (!string.IsNullOrWhiteSpace(pic))
                query = query.Where(m => m.PIC == pic);
            // role เป็น Document
            if (!string.IsNullOrWhiteSpace(sectionName))
                query = query.Where(m => m.SectionName == sectionName);
            ////  criteria for Approver
            //if (!string.IsNullOrWhiteSpace(approver))
            //    query = query.Where(m => (m.PIC != approver && (m.Approver1 == approver || m.Approver2 == approver || m.Approver3 == approver)) || m.PIC == approver);


            return query;
        }
    }

    public class UnplanSearchFilter
    {
        public string PlantationId { get; set; }
        public string Title { get; set; }
        public string ContractType { get; set; }
        public string Status { get; set; }
        public string PIC { get; set; }
    }
    public class UnplanSearchResult
    {
        public Guid? Id { get; set; }
        public Guid? NewRegistId { get; set; }
        public string PlantationId { get; set; }
        public string Title { get; set; }
        public string ContractType { get; set; }
        public string Status { get; set; }
        public string PIC { get; set; }

        public string Approver1 { get; set; }
        public string StatusApprover1 { get; set; }
        public string Approver2 { get; set; }
        public string StatusApprover2 { get; set; }
        public string Approver3 { get; set; }
        public string StatusApprover3 { get; set; }

        public string SectionName { get; set; }

        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsMyTask { get; set; }
    }
}
