using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiledTest.Services
{
    public interface IPaymentService 
    {
        void MakePayment(EntityModel.PaymentInfo paymentInfo);
        IQueryable<EntityModel.PaymentInfo> GetPayments();
    }
}
