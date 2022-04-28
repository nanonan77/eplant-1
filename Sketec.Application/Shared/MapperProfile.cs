using AutoMapper;
using Sketec.FileReader.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Shared
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CustomerBehaviorExcelReadResult, CustomerBehaviorExcelReadResult>();
        }
    }
}
