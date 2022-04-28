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
    public class SubNewRegist : EntityTransaction, IAggregateRoot
    {
        public string Title { get; set; }
        public string RegistId { get; set; }
        public string SubRegistId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal? Area { get; set; }
        public int? NumSoilType { get; set; }
        public string SoilType { get; set; }
        public string LandUse { get; set; }
        public string Accessibility { get; set; }
        public string Water { get; set; }
        public int? NumSoilTest { get; set; }

        public decimal? Rainfall { get; set; }
        public decimal? DeedArea { get; set; }
        public string ItemType { get; set; }

        public string Path { get; set; }
        public int? PlantYear { get; set; }
        public int? HarvestingMonth { get; set; }
        public int? HarvestingYear { get; set; }
        public decimal? Volume { get; set; }
        public decimal? VipPrice { get; set; }
        public string Remark { get; set; }



        public Guid NewRegistId { get; private set; }
        public NewRegist NewRegist { get; private set; }


        private List<SubNewRegistTestPlot> _subNewRegistTestPlots = new List<SubNewRegistTestPlot>();
        public IReadOnlyCollection<SubNewRegistTestPlot> SubNewRegistTestPlots => _subNewRegistTestPlots.AsReadOnly();

        public void AddSubNewRegistTestPlot(SubNewRegistTestPlot item)
        {
            if (_subNewRegistTestPlots.Any(a => a.SubNewRegistTestId == item.SubNewRegistTestId))
            {
                throw new DomainException($"Title : {item.SubNewRegistTestId} is already existing.");
            }
            _subNewRegistTestPlots.Add(item);
        }
        
        public void RemoveSubNewRegist(SubNewRegistTestPlot item)
        {
            _subNewRegistTestPlots.Remove(item);
        }
    }
}
