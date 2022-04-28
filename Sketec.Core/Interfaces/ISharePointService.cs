using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Interfaces
{
    public interface ISharePointService
    {
        byte[] GetMasterActivityFile();
        void ReplaceMasterActivityFile(byte[] file);

        byte[] GetNewRegistFile();
        void ReplaceNewRegistFile();
        byte[] GetImage(string url);
    }
}
