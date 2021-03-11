using System;
using System.Collections.Generic;
using System.Text;

namespace FiledTest.Data.DataModels
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public Guid PaymentInfoId { get; set; }

        public DateTime DateTime { get; set; }
        public virtual PaymentInfo PaymentInfo { get; set; }

        public Status Status { get; set; }
        
    }
    public enum Status
    {
        Initialized,
        Success,
        Invalid,
        Error,
        Failed
    }
}
