using AutoMapper;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.Application.Resources
{
    public class FileInfoProfile : Profile
    {
        public FileInfoProfile()
        {
            CreateMap<FileInfo, FileInfoDto>();
        }
    }
    public class FileInfoDto
    {
        public Guid Id { get; set; }
        public int? Sequence { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
        public Guid? RefId { get; set; }
        public string Path { get; set; }
        public byte[] Base64 { get; set; }
    }


}
