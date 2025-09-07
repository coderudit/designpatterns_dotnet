namespace solid_design_principles.lsp
{
    internal class Square : Rectangle
    {
        public Square(int size) : base(size, size)
        {
        }

        public override int Width
        {
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override int Height
        {
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}