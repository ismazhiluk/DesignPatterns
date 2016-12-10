using Visitor.Visitors;

namespace Visitor.Figures
{
    public class Circle : FigureBase
    {
        public override string Name => nameof(Circle);

        public readonly double Radius;

        public Circle(double radius)
        {
            Radius = radius;
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
