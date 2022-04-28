using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources
{
    public class FileModelDto
    {
        public string FileName { get; set; }
        public string Data { get; set; }
    }

    public class FileResponseDto
    {
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
}
