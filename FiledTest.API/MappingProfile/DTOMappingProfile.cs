using AutoMapper;
using FiledTest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.API.MappingProfile
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            CreateMap<Services.EntityModel.PaymentInfo, PaymentDTO>()
            .ReverseMap();
        }
    }
}
