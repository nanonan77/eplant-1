using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public class BeneficiaryMessage
    {
        public string BeneficiaryCode { get; set; }
        public string BeneficiaryName { get; set; }
        public string CountryCode { get; set; }
        public string AccountNo { get; set; }
        public string BSBNO { get; set; }
        public string BeneficiaryBankName { get; set; }
        public string BeneficiaryBankSwiftCode { get; set; }
        public string INTERMEDIATEBANKNAME { get; set; }
        public string INTERMEDIATEBANKSWIFTCODE { get; set; }
        public string BeneficiaryAddress { get; set; }
        public string ABANO { get; set; }
        public string IBANNo { get; set; }
        public string IFSCCODE { get; set; }
        public string BeneficiaryBankAddress { get; set; }
        public string BankCountryCode { get; set; }
        public string INTERMEDIATEBANKADDRESS { get; set; }
        public string INTERMEDIATEBANKCOUNTRYCode { get; set; }
    }
}
