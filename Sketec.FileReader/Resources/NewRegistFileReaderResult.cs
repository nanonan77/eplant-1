using Sketec.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.FileReader.Resources
{
    public class NewRegistFileReaderResult
    {
        public IEnumerable<SubNewRegistTestPlot> SubNewRegistTestPlot { get; set; }
        public IEnumerable<SubNewRegist> SubNewRegist { get; set; }
        public IEnumerable<NewRegist> NewRegist { get; set; }
        public IEnumerable<NewRegistImagePath> NewRegistImagePath { get; set; }
    }
}
