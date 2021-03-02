
using AutoMapper;
using FiledTest.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiledTest.Services
{
    public class ServiceEntityMappingProfile : Profile
    {
        
       public ServiceEntityMappingProfile()
        {

            CreateMap<EntityModel.PaymentInfo, PaymentInfo>() //.ForMember(x => x.DateTime, m => m.MapFrom(x => DateTime.Now))
                .ReverseMap();
            CreateMap<EntityModel.PaymentStatus, PaymentStatus>().ReverseMap();
            CreateMap<EntityModel.PaymentInfo, FiledTest.PaymentGateway.PaymentRequest>().ReverseMap();
            CreateMap<PaymentInfo, FiledTest.PaymentGateway.PaymentRequest>().ReverseMap();
        }
    }
}
