using AutoMapper;
using AutoMapper.QueryableExtensions;
using FiledTest.Data.DataModels;
using FiledTest.PaymentGateway;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FiledTest.Services
{
    public class PaymentService : IPaymentService
    {
        ILogger<PaymentService> logger;
        FiledTest.Data.FiledTestDataContext dataContext;
        IExpensivePaymentGateway expensivePaymentGateway;
        ICheapPaymentGateway cheapPaymentGateway;
        IMapper mapper;
        public PaymentService(ILogger<PaymentService> logger, FiledTest.Data.FiledTestDataContext dataContext, IMapper mapper, IExpensivePaymentGateway expensivePaymentGateway, ICheapPaymentGateway cheapPaymentGateway)
        {
            this.logger = logger;
            this.dataContext = dataContext;
            this.expensivePaymentGateway = expensivePaymentGateway;
            this.cheapPaymentGateway = cheapPaymentGateway;
            this.mapper = mapper;
        }

        public IQueryable<EntityModel.PaymentInfo> GetPayments()
        {
            var payinfo = dataContext.PaymentsInfo.AsQueryable().ProjectTo<EntityModel.PaymentInfo>(mapper.ConfigurationProvider).AsQueryable();
            return payinfo;
        }

        public async Task<EntityModel.PaymentStatus> MakePayment(EntityModel.PaymentInfo paymentInfo)
        {
            PaymentStatus paymentStatus = null;
            try
            {
                logger.LogInformation("PaymentService.MakePayment: Starting Payment Processing");

                var dbPaymentInfo = mapper.Map<Data.DataModels.PaymentInfo>(paymentInfo);
                this.dataContext.PaymentsInfo.Add(dbPaymentInfo);
                this.dataContext.SaveChanges();
                PaymentStatusUpdate(dbPaymentInfo.Id, Status.Initialized);
                paymentStatus = new PaymentStatus() { PaymentInfoId = dbPaymentInfo.Id };
                var paymentReqInfo = mapper.Map<FiledTest.PaymentGateway.PaymentRequest>(dbPaymentInfo);
                //If the amount to be paid is less than £20, use ICheapPaymentGateway
                if (paymentInfo.Amount < 20)
                {
                    PaymentLessThan20(paymentReqInfo);
                }
                //If the amount to be paid is £21-500, use IExpensivePaymentGateway if available. Otherwise, retry only once with ICheapPaymentGateway.
                else if (paymentInfo.Amount > 20 && paymentInfo.Amount <= 500)
                {
                    PaymentBetween21To500(paymentReqInfo);
                }
                //c) If the amount is > £500, try only PremiumPaymentService and retry up to 3 times in case payment does not get processed
                else if (paymentInfo.Amount > 500)
                {
                    var retryPolicy = Policy
                            .Handle<HttpRequestException>()
                            .RetryAsync(3);

                    await retryPolicy.ExecuteAsync(async () =>
                    {
                        this.expensivePaymentGateway.Payment(paymentReqInfo);
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError("PaymentService.MakePayment: " + ex.Message);
            }
            finally
            {
                logger.LogInformation("PaymentService.MakePayment:");                
            }
            var status = dataContext.PaymentsStatuses.Where(x => x.PaymentInfoId == paymentStatus.PaymentInfoId).OrderByDescending(x => x.DateTime).AsQueryable()
                    .ProjectTo<EntityModel.PaymentStatus>(mapper.ConfigurationProvider).FirstOrDefault();
            return status;

        }

        private void PaymentBetween21To500(PaymentRequest paymentRequest)
        {
            try
            {
                this.expensivePaymentGateway.Payment(paymentRequest);
                PaymentStatusUpdate(paymentRequest.Id, Status.Success);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("PaymentService.PaymentBetween21To500: " + ex.Message);
                PaymentStatusUpdate(paymentRequest.Id, Status.Error);
                PaymentLessThan20(paymentRequest);
            }

        }

        private void PaymentLessThan20(PaymentRequest paymentRequest)
        {
            try
            {
                this.cheapPaymentGateway.Payment(paymentRequest);
                PaymentStatusUpdate(paymentRequest.Id, Status.Success);
            }
            catch (Exception ex)
            {
                logger.LogError("PaymentService.PaymentLessThan20: " + ex.Message);
                PaymentStatusUpdate(paymentRequest.Id, Status.Failed);
            }
        }


        private void PaymentStatusUpdate(Guid paymentId, Status status)
        {
            this.dataContext.PaymentsStatuses.Add(new PaymentStatus()
            {
                PaymentInfoId = paymentId,
                Status = status,
                DateTime = DateTime.Now
            });
            this.dataContext.SaveChanges();
        }
    }
}
