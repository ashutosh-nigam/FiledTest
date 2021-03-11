using System;

namespace FiledTest.Services.EntityModel
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public Guid PaymentInfoId { get; set; }

        public DateTime DateTime { get; set; }
        public virtual PaymentInfo PaymentInfo { get; set; }
        public string Status { get; set; }
    }
}
