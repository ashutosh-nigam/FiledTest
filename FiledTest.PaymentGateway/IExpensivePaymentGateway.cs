using System;

namespace FiledTest.PaymentGateway
{
    public interface IExpensivePaymentGateway
    {
        PaymentResponse Payment(PaymentRequest paymentInfo);
    }
}
