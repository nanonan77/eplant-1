using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class SubDistrict : Entity, IAggregateRoot
    {
        public string Title { get; set; }
        public string TambonID { get; set; }
        public string TambonThai { get; set; }
        public string DistrictID { get; set; }
        public string ProvinceID { get; set; }
        public string ZoneID { get; set; }

        public SubDistrict() { }
    }
}
