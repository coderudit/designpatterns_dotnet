namespace solid_design_principles.dip
{
    internal class StripeGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount) => Console.WriteLine($"Processing payment of {amount} via Stripe.");
    }
}