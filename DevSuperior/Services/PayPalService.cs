using Course.Services;
using Course.Entities;

namespace Course.Services
{
    class PayPalService : IPaymentService
    {
        public double Interest(double value, int quota)
        {
            double interest = (value * 0.01)  * quota;

            return interest;
        }

        public double PaymentFee(double value)
        {
            double paymentFee = value * 0.02;

            return paymentFee;
        }
    }
}