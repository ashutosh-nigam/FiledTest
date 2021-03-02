using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiledTest.Services
{
    public interface IPaymentService 
    {
        Task<EntityModel.PaymentStatus> MakePayment(EntityModel.PaymentInfo paymentInfo);
        IQueryable<EntityModel.PaymentInfo> GetPayments();
    }
}
