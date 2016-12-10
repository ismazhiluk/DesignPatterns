using Visitor.Visitors;

namespace Visitor.Figures
{
    public abstract class FigureBase
    {
        public abstract string Name { get; }

        public abstract void Draw(IVisitor visitor, int x, int y);
        public abstract double GetArea(IVisitor visitor);
        public abstract double GetPerimeter(IVisitor visitor);
    }
}
