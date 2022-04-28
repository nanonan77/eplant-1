using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Shared
{
    public class BlobSettings
    {
        public static string GetBlobContainerByBu(string bu)
        {
            if (string.IsNullOrWhiteSpace(bu))
                return null;

            switch (bu.ToLower())
            {
                case "cip":
                    return "cip";
                case "fc":
                    return "fc1";
                case "pp":
                    return "pp1";
            }

            return null;
        }
    }
}
