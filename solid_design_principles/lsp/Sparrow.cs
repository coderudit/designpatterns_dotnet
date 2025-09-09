namespace solid_design_principles.lsp
{
    internal class Sparrow : Bird, IFlyingBird
    {
        public override void Eat()
        {
            Console.WriteLine("Sparrow is eating.");
        }

        public void Fly()
        {
            Console.WriteLine("Sparrow is flying.");
        }
    }
}