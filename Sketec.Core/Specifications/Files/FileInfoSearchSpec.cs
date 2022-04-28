using Ardalis.Specification;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Core.Specifications
{
    public class FileInfoSearchSpec : Specification<FileInfo>
    {
        public FileInfoSearchSpec(FileInfoFilter filter)
        {
            if (filter.RefId.HasValue)
                Query.Where(m => m.RefId == filter.RefId.Value);

            if (filter.Id.HasValue)
                Query.Where(m => m.Id == filter.Id.Value);

            if (!string.IsNullOrWhiteSpace(filter.FileType))
                Query.Where(m => m.FileType == filter.FileType);

            if (!string.IsNullOrWhiteSpace(filter.FileName))
            {
                var tempArr = filter.FileName.Split(",");
                Query.Where(m => tempArr.Contains(m.FileName));
            }

            if (!string.IsNullOrWhiteSpace(filter.Description))
            {
                var tempArr = filter.Description.Split(",");
                Query.Where(m => tempArr.Contains(m.Description));
            }

            if (!string.IsNullOrWhiteSpace(filter.Status))
                Query.Where(m => m.Status == filter.Status);

            Query.Where(m => m.IsActive == true);
        }
    }

    public class FileInfoFilter
    {
        public Guid? Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid? RefId { get; set; }
    }
}
