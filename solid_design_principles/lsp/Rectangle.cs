namespace solid_design_principles.lsp
{
    internal class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"Width: {Width}, Height: {Height}";
        }
    }
}