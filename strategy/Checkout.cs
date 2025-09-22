namespace strategy
{
    internal class Checkout
    {
        private readonly IPaymentStrategy _paymentStrategy;

        public Checkout(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void ProcessPayment(int amount)
        {
            _paymentStrategy.Pay(amount);
        }
    }
}