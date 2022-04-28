using Sketec.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains.Types
{
    public enum ExpenseType
    {
        [Description("ActivityGroupA")]
        [StringValue("ActivityGroupA")]
        ActivityGroupA,

        [Description("ActivityGroupB")]
        [StringValue("ActivityGroupB")]
        ActivityGroupB,

        [Description("ActivityGroupC")]
        [StringValue("ActivityGroupC")]
        ActivityGroupC,

        [Description("ActivityGroupD")]
        [StringValue("ActivityGroupD")]
        ActivityGroupD,

        [Description("ActivityGroupF")]
        [StringValue("ActivityGroupF")]
        ActivityGroupF,

        [Description("CostIncrease")]
        [StringValue("CostIncrease")]
        CostIncrease,
    }
}
