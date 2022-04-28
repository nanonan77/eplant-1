using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public class VendorOneTimeMessage
    {
        /// <summary>
        /// กรณีมี TAX Id ต้องใส่ตัวอักษร 13 ตัว
        /// </summary>
        public string TAXId { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
    }
}
