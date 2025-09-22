namespace strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Pay with cash
            IPaymentStrategy cashPayment = new CashPaymentStrategy();
            Checkout cashCheckout = new Checkout(cashPayment);
            cashCheckout.ProcessPayment(100);

            // Pay with credit card
            IPaymentStrategy creditCardPayment = new CreditCardPaymentStrategy();
            Checkout creditCardCheckout = new Checkout(creditCardPayment);
            creditCardCheckout.ProcessPayment(200);
        }
    }
}