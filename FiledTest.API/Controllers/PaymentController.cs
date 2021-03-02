using AutoMapper;
using FiledTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService paymentService;
        ILogger<PaymentController> logger;
        IMapper mapper;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger, IMapper mapper)
        {
            this.paymentService = paymentService;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet("{guid}")]
        public string Get(string guid)
        {
            return "Hello World";
        }

        [HttpGet]
        public IList<Models.PaymentDTO> GetAll()
        {
            return mapper.Map<IList<Models.PaymentDTO>>(paymentService.GetPayments());
        }
    }
}
