using System;

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
    }
}
