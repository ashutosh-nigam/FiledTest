using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.API.Models
{
    public class PaymentDTO
    {
        [StringLength(16, MinimumLength = 16), DataType(DataType.CreditCard), Required]
        [RegularExpression("\\d{16}")]
        public string CreditCardNumber { get; set; }
        [StringLength(15, MinimumLength = 8), Required]
        public string CardHolder { get; set; }
        [DataType(DataType.Text), Required]
        [RegularExpression(@"\d{2}\/\d{2}")]
        public string ExpirationDate { get; set; }
        [Required, MaxLength(3), MinLength(3)]
        [RegularExpression(@"\d{3}")]
        public string SecurityCode { get; set; }
        [DataType(DataType.Currency), Required]
        public decimal Amount { get; set; }
    }
}
