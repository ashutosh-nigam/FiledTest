using AutoMapper;
using FiledTest.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiledTest.Services
{
    public class ServiceMapper
    {
        public IMapper GetMapper()
        {
            var mp = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EntityModel.PaymentInfo, PaymentInfo>().ForMember(x => x.DateTime, m => m.MapFrom(x => DateTime.Now))
                .ReverseMap();
                cfg.CreateMap<EntityModel.PaymentInfo, FiledTest.PaymentGateway.PaymentRequest>();
            });
            return mp.CreateMapper();
        }
    }
}
