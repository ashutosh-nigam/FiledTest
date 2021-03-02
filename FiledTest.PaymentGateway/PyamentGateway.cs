using System;
using System.Collections.Generic;
using System.Text;

namespace FiledTest.PaymentGateway
{
    public class PyamentGateway : ICheapPaymentGateway, IExpensivePaymentGateway
    {
        PaymentResponse ICheapPaymentGateway.Payment(PaymentRequest paymentInfo)
        {
            throw new NotImplementedException();
        }

        PaymentResponse IExpensivePaymentGateway.Payment(PaymentRequest paymentInfo)
        {
            throw new NotImplementedException();
        }
    }
}
