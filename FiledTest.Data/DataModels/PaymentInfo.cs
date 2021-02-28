using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FiledTest.Data.DataModels
{
    public class PaymentInfo
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(maximumLength: 16, MinimumLength = 16)]
        public string CreditCardNumber { get; set; }
        [StringLength(16, MinimumLength = 8)]
        public string CardHolder { get; set; }

        // Can not save as per data security guidelines
        //public string ExpirationDate { get; set; }
        //public string SecurityCode { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        
        public DateTime DateTime { get; set; }
        public ICollection<PaymentStatus> PaymentStatuses { get; set; }
    }
}
