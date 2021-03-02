using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.API.Models
{
    public class PaymentStatusDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual PaymentDTO PaymentInfo { get; set; }
        public string Status { get; set; }
    }
}
