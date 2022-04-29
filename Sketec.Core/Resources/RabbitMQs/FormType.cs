using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public enum FormType : byte
    {
        /// <summary>
        /// GR Approval Form
        /// </summary>
        GR = 1,
        /// <summary>
        /// GR and Payment Approval Form 
        /// </summary>
        PRQ = 3,
        /// <summary>
        /// Payment Approval Form 
        /// </summary>
        GRPRQ = 4
    }
}
