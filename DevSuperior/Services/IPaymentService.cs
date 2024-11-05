using Course.Entities;

namespace Course.Services
{
    interface IPaymentService
    {
        public double Interest(double value, int quota);

        public double PaymentFee(double value);

    }
}