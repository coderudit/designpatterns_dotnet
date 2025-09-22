namespace strategy
{
    internal class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine($"{amount} paid with credit/debit card");
        }
    }
}