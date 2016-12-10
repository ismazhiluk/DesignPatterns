using System;
using Visitor.Figures;
using Visitor.Visitors;

namespace Visitor
{
    class Program
    {
        static void Main()
        {
            FigureBase[] figures = {
                new Circle(1),
                new Rectangle(2, 3),
                new Triangle(4, 5, 6)
            };

            var euclideanGeometryVisitor = new EuclideanGeometryVisitor();
            var hyperbolicGeometryVisitor = new HyperbolicGeometryVisitor();

            foreach (var figure in figures)
            {
                Console.WriteLine(figure.Name);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(nameof(EuclideanGeometryVisitor));

                figure.Draw(euclideanGeometryVisitor, 1, 2);
                Console.WriteLine("Area: " + figure.GetArea(euclideanGeometryVisitor));
                Console.WriteLine("Perimeter: " + figure.GetPerimeter(euclideanGeometryVisitor));

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(nameof(HyperbolicGeometryVisitor));

                figure.Draw(hyperbolicGeometryVisitor, 1, 2);
                Console.WriteLine("Area: " + figure.GetArea(hyperbolicGeometryVisitor));
                Console.WriteLine("Perimeter: " + figure.GetPerimeter(hyperbolicGeometryVisitor));

                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}