using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class SubNewRegistTestPlot : EntityTransaction, IAggregateRoot
    {
        public string SubRegistId { get; set; }
        public string SubNewRegistTestId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? SoilType { get; set; }
        public string Depth { get; set; }
        public string SoillFloorDepth { get; set; }
        public string GravelDepth { get; set; }
        public decimal? PH30 { get; set; }
        public decimal? PH60 { get; set; }
        public decimal? EC30 { get; set; }
        public decimal? EC60 { get; set; }
        public string Dot { get; set; }

        public string ItemType { get; set; }
        public string Path { get; set; }




        public Guid SubNewRegistId { get; private set; }
        public SubNewRegist SubNewRegist { get; private set; }

    }
}
