using Visitor.Visitors;

namespace Visitor.Figures
{
    public class Rectangle : FigureBase
    {
        public override string Name => nameof(Rectangle);

        public readonly double Height;
        public readonly double Width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override void Draw(IVisitor visitor, int x, int y)
        {
            visitor.Draw(this, x, y);
        }

        public override double GetArea(IVisitor visitor)
        {
            return visitor.GetArea(this);
        }

        public override double GetPerimeter(IVisitor visitor)
        {
            return visitor.GetPerimeter(this);
        }
    }
}
