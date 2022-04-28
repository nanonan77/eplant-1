using Sketec.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains.Types
{
    public enum NewRegistLevel
    {
        [Description("New Registration")]
        [StringValue("NewRegist")]
        NewRegist,


        [Description("Sub New Registration")]
        [StringValue("SubNewRegist")]
        SubNewRegist,


        [Description("Sub New Registration Test Plot")]
        [StringValue("SubNewRegistTestPlot")]
        SubNewRegistTestPlot
    }
}
