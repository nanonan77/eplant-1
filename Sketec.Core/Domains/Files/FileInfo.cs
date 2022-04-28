using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Domains
{
    public class FileInfo : EntityTransaction, IAggregateRoot
    {
        public int? Sequence { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
        public string Path { get; set; }
        public Guid? RefId { get; set; }

        private FileInfo() { }
        public FileInfo(string fileName) 
        {
            FileName = fileName;
            IsActive = true;
            IsDelete = false;
        }
    }
}
