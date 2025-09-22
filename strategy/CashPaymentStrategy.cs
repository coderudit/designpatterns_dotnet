namespace strategy
{
    internal class CashPaymentStrategy : IPaymentStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine($"{amount} paid with cash");
        }
    }
}