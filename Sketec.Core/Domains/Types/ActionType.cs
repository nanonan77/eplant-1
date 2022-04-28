using Sketec.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains.Types
{
    public enum ActionType
    {
        [Description("Assign To")]
        [StringValue("Assign To")]
        AssignTo,

        [Description("Send Back")]
        [StringValue("Send Back")]
        SendBack,

        [Description("Change PIC")]
        [StringValue("Change PIC")]
        ChangePIC
    }
    
}
