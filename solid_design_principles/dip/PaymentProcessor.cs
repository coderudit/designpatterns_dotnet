namespace solid_design_principles.dip
{
    internal class PaymentProcessor
    {
        private readonly IPaymentGateway _paymentGateway;

        public PaymentProcessor(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }

        public void Pay(decimal amount)
        {
            _paymentGateway.ProcessPayment(amount);
        }
    }
}