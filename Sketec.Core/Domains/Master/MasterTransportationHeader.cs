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
    public class MasterTransportationHeader : Entity, IAggregateRoot
    {
        public string TruckType { get; set; }
        public decimal? FreightMin { get; set; }
        public decimal? FreightMax { get; set; }

        private List<MasterTransportationDetail> _masterTransportationDetails = new List<MasterTransportationDetail>();
        public IReadOnlyCollection<MasterTransportationDetail> MasterTransportationDetails => _masterTransportationDetails.AsReadOnly();

        private MasterTransportationHeader() { }

        public MasterTransportationHeader(string truckType) 
        {
            EnsureArg.IsNotNullOrWhiteSpace(truckType, nameof(truckType));

            TruckType = truckType;
            IsActive = true;
            IsDelete = false;
        }

        public void AddMasterTransportationDetail(MasterTransportationDetail item)
        {
            if (_masterTransportationDetails.Any(a => a.Title == item.Title))
            {
                throw new DomainException($"Title : {item.Title} is already existing.");
            }
            _masterTransportationDetails.Add(item);
        }

        public void RemoveMasterTransportationDetail(MasterTransportationDetail item)
        {
            _masterTransportationDetails.Remove(item);
        }
    }
}
