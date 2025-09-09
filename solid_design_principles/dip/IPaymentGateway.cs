namespace solid_design_principles.dip
{
    internal interface IPaymentGateway
    {
        void ProcessPayment(decimal amount);
    }
}