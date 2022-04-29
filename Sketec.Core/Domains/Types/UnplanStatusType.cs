using Sketec.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains.Types
{
    public enum UnplanStatusType
    {
        [Description("Draft")]
        [StringValue("Draft")]
        Draft,

        [Description("Wait for Approve")]
        [StringValue("Wait for Approve")]
        WaitforApprove,

        [Description("Wait for Approve (My Task)")]
        [StringValue("Wait for Approve (My Task)")]
        WaitforApproveMyTask,

        [Description("Approved")]
        [StringValue("Approved")]
        Approved,

        [Description("Rejected")]
        [StringValue("Rejected")]
        Rejected,

        [Description("Deleted")]
        [StringValue("Deleted")]
        Deleted,
    }
    public enum UnplanApproveStatusType
    {
        [Description("Wait for Approve")]
        [StringValue("Wait for Approve")]
        WaitforApprove,

        [Description("Approved")]
        [StringValue("Approved")]
        Approved,

        [Description("Rejected")]
        [StringValue("Rejected")]
        Rejected,
    }
}
