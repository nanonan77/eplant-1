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
    public class Match9999 : EntityTransaction, IAggregateRoot
    {
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }


        private List<MatchData> _matchDatas = new List<MatchData>();
        public IReadOnlyCollection<MatchData> MatchDatas => _matchDatas.AsReadOnly();

        private List<MatchPlantation> _matchPlantations = new List<MatchPlantation>();
        public IReadOnlyCollection<MatchPlantation> MatchPlantations => _matchPlantations.AsReadOnly();


        public void AddMatchData(MatchData item)
        {
            if (_matchDatas.Any(a => a.Mapping9999Id == item.Mapping9999Id))
            {
                throw new DomainException($"Mapping9999Id : {item.Mapping9999Id} is already existing.");
            }
            _matchDatas.Add(item);
        }

        public void RemoveMatchData(MatchData item)
        {
            _matchDatas.Remove(item);
        }

        public void AddMatchPlantation(MatchPlantation item)
        {
            if (_matchPlantations.Any(a => a.PlantationId == item.PlantationId))
            {
                throw new DomainException($"PlantationId : {item.PlantationId} is already existing.");
            }
            _matchPlantations.Add(item);
        }

        public void RemoveMatchPlantation(MatchPlantation item)
        {
            _matchPlantations.Remove(item);
        }
    }
}
