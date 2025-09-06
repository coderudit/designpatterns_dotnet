namespace solid_design_principles.ocp
{
    internal class Product
    {
        public string Name { get; }
        public Color Color { get; }
        public Size Size { get; }

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }
}