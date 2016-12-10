using Visitor.Figures;

namespace Visitor.Visitors
{
    public interface IVisitor
    {
        void Draw(Circle figure, int x, int y);
        void Draw(Triangle figure, int x, int y);
        void Draw(Rectangle figure, int x, int y);

        double GetArea(Circle figure);
        double GetArea(Triangle figure);
        double GetArea(Rectangle figure);

        double GetPerimeter(Circle figure);
        double GetPerimeter(Triangle figure);
        double GetPerimeter(Rectangle figure);
    }
}
