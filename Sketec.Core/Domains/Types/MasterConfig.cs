using Sketec.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains.Types
{
    public enum StatusTrackingType
    {
        [Description("Submitted")]
        [StringValue("Submitted")]
        Submitted,

        [Description("Verify Cost")]
        [StringValue("Verify Cost")]
        VerifyCost,

        [Description("Verify Feas.")]
        [StringValue("Verify Feas.")]
        VerifyFeas,

        [Description("Final Negotiate")]
        [StringValue("Final Negotiate")]
        FinalNegotiate,

        [Description("Contract Signed")]
        [StringValue("Contract Signed")]
        ContractSigned,

        [Description("Completed")]
        [StringValue("Completed")]
        Completed
    }

    public enum TeamType
    {
        [Description("ทีมหาพื้นที่")]
        [StringValue("ทีมหาพื้นที่")]
        Office,

        [Description("ทีมปลูก")]
        [StringValue("ทีมปลูก")]
        Plan,

        [Description("ทีม QC")]
        [StringValue("ทีม QC")]
        QC
    }
}
