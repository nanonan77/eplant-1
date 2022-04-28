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
    public class MappingTrans : EntityTransaction, IAggregateRoot
    {
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }


        private List<Match9999> _match9999s = new List<Match9999>();
        public IReadOnlyCollection<Match9999> Match9999s => _match9999s.AsReadOnly();

        public void AddMatch9999(Match9999 item)
        {
            //if (_match9999s.Any(a => a.Mapping9999Id == item.Mapping9999Id))
            //{
            //    throw new DomainException($"Mapping9999Id : {item.Mapping9999Id} is already existing.");
            //}
            _match9999s.Add(item);
        }

        public void RemoveMatch9999(Match9999 item)
        {
            _match9999s.Remove(item);
        }

        
    }
}
