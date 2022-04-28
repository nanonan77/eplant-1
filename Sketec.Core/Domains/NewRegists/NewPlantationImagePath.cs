using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class NewPlantationImagePath : EntityTransaction, IAggregateRoot
    {
        public string Name { get; set; }
        public string SurveyId { get; set; }
        public string PlantationId { get; set; }
        public string ImageInfo { get; set; }
        public string ImageInfo2 { get; set; }
        public string ImageInfo3 { get; set; }
        public string ItemType { get; set; }
        public string Path { get; set; }
        public Guid NewRegistId { get; set; }
        public Guid? SubNewRegistId { get; set; }
        public Guid? SubNewRegistTestPlotId { get; set; }
        public NewRegistLevel ImageLevel { get; set; }
        public bool IsSelectedStep2 { get; set; }
        public bool IsSelectedStep3 { get; set; }
    }
}
