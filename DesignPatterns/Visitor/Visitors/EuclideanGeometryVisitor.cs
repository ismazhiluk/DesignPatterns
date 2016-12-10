using System;
using Visitor.Figures;

namespace Visitor.Visitors
{
    public class EuclideanGeometryVisitor : IVisitor
    {
        public void Draw(Circle figure, int x, int y)
        {
            DrawBase(figure, x, y);
        }

        public void Draw(Triangle figure, int x, int y)
        {
            DrawBase(figure, x, y);
        }

        public void Draw(Rectangle figure, int x, int y)
        {
            DrawBase(figure, x, y);
        }

        private void DrawBase(FigureBase figure, int x, int y)
        {
            Console.WriteLine($"Draw \"{figure.Name}\" on point: ({x}, {y}) in EuclideanGeometry");
        }

        public double GetArea(Circle figure)
        {
            return Math.PI*figure.Radius*figure.Radius;
        }

        public double GetArea(Triangle figure)
        {
            var p = GetPerimeter(figure);
            return Math.Sqrt(p * (p - figure.A) * (p - figure.B) * (p - figure.C));
        }

        public double GetArea(Rectangle figure)
        {
            return figure.Height * figure.Width;
        }

        public double GetPerimeter(Circle figure)
        {
            return 2 * Math.PI * figure.Radius;
        }

        public double GetPerimeter(Triangle figure)
        {
            return figure.A + figure.B + figure.C;
        }

        public double GetPerimeter(Rectangle figure)
        {
            return 2 * (figure.Height + figure.Width);
        }
    }
}
