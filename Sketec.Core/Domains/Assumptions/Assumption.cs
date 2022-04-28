using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class Assumption : EntityTransaction, IAggregateRoot
    {
        public Guid NewRegistId { get; set; }
        public int ContractYear { get; set; }
        public decimal? RentalArea { get; set; }
        public int? ProductiveAreaPercent { get; set; }
        public decimal? ProductiveArea { get; set; }
        public int CuttingRound { get; set; }
        public decimal? DistanceToPlant { get; set; }
        public string Mill { get; set; }
        public decimal? AveragePrice { get; set; }
        public decimal? MtpPrice { get; set; }
        public decimal? FcPrice { get; set; }
        public int? CuttingCostTypeId { get; set; }
        public decimal? CuttingCost{ get; set; }
        public int? FreightTypeId { get; set; }
        public decimal? Freight { get; set; }


        public NewRegist NewRegist { get; private set; }

        public MasterActivity MasterCuttingCostType { get; private set; }
        public MasterActivity MasterFreightType { get; private set; }

        private List<AssumptionYield> _assumptionYields = new List<AssumptionYield>();
        public IReadOnlyCollection<AssumptionYield> AssumptionYields => _assumptionYields.AsReadOnly();

        private List<AssumptionClone> _assumptionClones = new List<AssumptionClone>();
        public IReadOnlyCollection<AssumptionClone> AssumptionClones => _assumptionClones.AsReadOnly();


        private List<Expense> _expenses = new List<Expense>();
        public IReadOnlyCollection<Expense> Expenses => _expenses.AsReadOnly();


        public void AddAssumptionYield(AssumptionYield item)
        {
            _assumptionYields.Add(item);
        }
        public void RemoveAssumptionYield(AssumptionYield item)
        {
            _assumptionYields.Remove(item);
        }

        public void RemoveAssumptionClone(AssumptionClone item)
        {
            _assumptionClones.Remove(item);
        }
        public void AddAssumptionClone(AssumptionClone item)
        {
            _assumptionClones.Add(item);
        }

        public void RemoveExpense(Expense item)
        {
            _expenses.Remove(item);
        }
        public void AddExpense(Expense item)
        {
            _expenses.Add(item);
        }
    }
}
