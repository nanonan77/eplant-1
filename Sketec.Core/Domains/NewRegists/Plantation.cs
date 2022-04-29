using EnsureThat;
using Sketec.Core.Domains.Types;
using Sketec.Core.Exceptions;
using Sketec.Core.Extensions;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class Plantation : EntityTransaction, IAggregateRoot
    {
        public string PlantationNo { get; set; }
        public int? ContractYear { get; set; }
        public int? ContractMonth { get; set; }
        public int? Contract { get; set; }
        public string Title { get; set; }
        public string ContractType { get; set; }
        public string Status { get; set; }
        public string PIC { get; set; }
        public string ContractId { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Village { get; set; }
        public decimal? RentalArea { get; set; }
        public decimal? ProductiveArea { get; set; }
        public decimal? PotentialArea { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Remark { get; set; }
        public string Verifier { get; set; }

        public string Zone { get; set; }
        public string MOUType { get; set; }
        public int? Seedling { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }


        public Guid NewRegistId { get; set; }
        public NewRegist NewRegist { get; set; }


        private List<SubPlantation> _subPlantations = new List<SubPlantation>();
        public IReadOnlyCollection<SubPlantation> SubPlantations => _subPlantations.AsReadOnly();

        private List<PlantationAmortized> _plantationAmortizeds = new List<PlantationAmortized>();
        public IReadOnlyCollection<PlantationAmortized> PlantationAmortizeds => _plantationAmortizeds.AsReadOnly();

        private List<Unplan> _unplans = new List<Unplan>();
        public IReadOnlyCollection<Unplan> Unplans => _unplans.AsReadOnly();


        private List<RollingPlan> _rollingPlans = new List<RollingPlan>();
        public IReadOnlyCollection<RollingPlan> RollingPlans => _rollingPlans.AsReadOnly();
        public void AddRollingPlan(RollingPlan item)
        {
            _rollingPlans.Add(item);
        }

        public void RemoveRollingPlan(RollingPlan item)
        {
            _rollingPlans.Remove(item);
        }

        public void AddSubPlantation(SubPlantation item)
        {
            if (_subPlantations.Any(a => a.SubPlantationNo == item.SubPlantationNo))
            {
                throw new DomainException($"SubPlantationId : {item.SubPlantationNo} is already existing.");
            }
            _subPlantations.Add(item);
        }

        public void RemoveSubPlantation(SubPlantation item)
        {
            _subPlantations.Remove(item);
        }

        public void AddPlantationAmortized(PlantationAmortized item) {
            //if (_plantationAmortizeds.Any(a => a.PlantationId == item.PlantationId)) {
            //    throw new DomainException($"PlantationId : {item.PlantationId} is already existing.");
            //}
            _plantationAmortizeds.Add(item);
        }
        public void RemovePlantationAmortized(PlantationAmortized item)
        {
            _plantationAmortizeds.Remove(item);
        }

        public void AddUnplan(Unplan item)
        {
            if (_unplans.Any(a => a.UnplanNo == item.UnplanNo))
            {
                throw new DomainException($"Unplan Id : {item.UnplanNo} is already existing.");
            }
            _unplans.Add(item);
        }

        public void RemoveUnplan(Unplan item)
        {
            _unplans.Remove(item);
        }

        public void ApproveUnplan(Guid unplanId, string approver, string status, string remark)
        {
            var item = _unplans.FirstOrDefault(f => f.Id == unplanId && (f.Approver1 == approver || f.Approver2 == approver || f.Approver3 == approver));
            if (item != null)
            {
                if (item.Approver1 == approver)
                {
                    item.StatusApprover1 = status;
                    item.Remark1 = remark;
                }
                else if (item.Approver2 == approver)
                {
                    item.StatusApprover2 = status;
                    item.Remark2 = remark;
                }
                if (item.Approver3 == approver)
                {
                    item.StatusApprover3 = status;
                    item.Remark3 = remark;
                }

                item.OverAllStatus = GetOverAllStatus(item.StatusApprover1, item.StatusApprover2, item.StatusApprover3);
            }
        }

        private string GetOverAllStatus(string status1, string status2, string status3) 
        {
            var status = UnplanStatusType.WaitforApprove.GetStringValue();
            if (!string.IsNullOrEmpty(status3))
            {
                status = status3;
            } else if (!string.IsNullOrEmpty(status2))
            {
                status = status3;
            }
            else if (!string.IsNullOrEmpty(status1))
            {
                status = status1;
            }
            return status;

        }
    }
}
