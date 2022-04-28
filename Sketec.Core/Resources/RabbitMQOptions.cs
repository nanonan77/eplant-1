using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources
{
    public class RabbitMQOptions
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UseSsl { get; set; }
        public string VirtualHost { get; set; }
        public string CreatePaymentQueue { get; set; }
        public string CreatePaymentExchange { get; set; }
        public string CreatePaymentDll { get; set; }
        public string NotifyStatusQueue { get; set; }
        public string NotifyStatusExchange { get; set; }
        public string NotifyStatusDll { get; set; }


        public string AllPayName { get; set; }
        public string AllPayCompany { get; set; }
        public string AllPayUsername { get; set; }
        public string AllPayPassword { get; set; }
    }
}
