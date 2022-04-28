using Sketec.Core.Domains;
using Sketec.Core.Resources;
using System;

namespace Sketec.Application.Resources
{
    public class FollowingPaymentUpdateDateRequest
    {
        public DateTime? NewDate { get; set; }
        //public BillingSource BillingSource { get; set; }
    }

    public class FollowingPaymentUpdateStatusRequest
    {
        public string Status { get; set; }
        //public BillingSource BillingSource { get; set; }
        public decimal? ConfirmAmount { get; set; }
    }
}
