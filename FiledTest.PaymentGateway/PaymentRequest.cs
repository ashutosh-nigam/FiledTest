using System;
using System.Collections.Generic;
using System.Text;

namespace FiledTest.PaymentGateway
{
    public class PaymentRequest
    {
        public Guid Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
    }
}
