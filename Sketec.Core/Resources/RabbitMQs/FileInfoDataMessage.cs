using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Resources.RabbitMQs
{
    public class FileInfoDataMessage
    {
        /// <summary>
        /// ชื่อเอกสาร
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] FileByteData { get; set; }
    }
}
