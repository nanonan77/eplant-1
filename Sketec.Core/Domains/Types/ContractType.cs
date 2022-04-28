using Sketec.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains.Types
{
    public enum ContractType
    {
        [Description("Rental")]
        [StringValue("Rental")]
        Rental,

        [Description("MOU")]
        [StringValue("MOU")]
        MOU,

        [Description("VIP")]
        [StringValue("VIP")]
        VIP
    }
}
