using EnsureThat;
using Sketec.Core.Domains.Types;
using Sketec.Core.Exceptions;
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

        public string Zone { get; set; }
        public string MOUType { get; set; }
        public int? Seedling { get; set; }

        public string OverAllStatus { get; set; }
        public string Approver1 { get; set; }
        public string StatusApprover1 { get; set; }
        public string Approver2 { get; set; }
        public string StatusApprover2 { get; set; }
        public string Approver3 { get; set; }
        public string StatusApprover3 { get; set; }

        public Guid NewRegistId { get; set; }
        public NewRegist NewRegist { get; set; }


        private List<SubPlantation> _subPlantations = new List<SubPlantation>();
        public IReadOnlyCollection<SubPlantation> SubPlantations => _subPlantations.AsReadOnly();


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

        private List<PlantationAmortized> _plantationAmortizeds = new List<PlantationAmortized>();
        public IReadOnlyCollection<PlantationAmortized> PlantationAmortizeds => _plantationAmortizeds.AsReadOnly();

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
    }
}
