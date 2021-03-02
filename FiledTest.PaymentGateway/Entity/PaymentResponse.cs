using System;
using System.Collections.Generic;
using System.Text;

namespace FiledTest.PaymentGateway
{
    public class PaymentResponse
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
    }
}
