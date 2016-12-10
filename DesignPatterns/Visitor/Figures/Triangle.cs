using Visitor.Visitors;

namespace Visitor.Figures
{
    public class Triangle : FigureBase
    {
        public override string Name => nameof(Triangle);

        public readonly double A;
        public readonly double B;
        public readonly double C;

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
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
