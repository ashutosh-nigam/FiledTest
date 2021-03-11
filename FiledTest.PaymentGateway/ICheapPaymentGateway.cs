using System;
using System.Collections.Generic;
using System.Text;

namespace FiledTest.PaymentGateway
{
    public interface ICheapPaymentGateway
    {
        PaymentResponse Payment(PaymentRequest paymentInfo);
    }
}
