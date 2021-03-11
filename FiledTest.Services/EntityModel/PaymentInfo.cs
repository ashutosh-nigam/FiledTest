using System;
using System.Collections.Generic;

namespace FiledTest.Services.EntityModel
{
    public class PaymentInfo
    {
        public Guid Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public IList<PaymentStatus> PaymentStatus { get; set; }
    }
}
