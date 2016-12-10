using System;
using Visitor.Figures;

namespace Visitor.Visitors
{
    public class HyperbolicGeometryVisitor : IVisitor
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
            Console.WriteLine($"Draw \"{figure.Name}\" on point: ({x}, {y}) in HyperbolicGeometry");
        }

        /// <summary>
        /// Нетривиальная штука! Не стал пробрасывать исключение, чтобы можно было запускать программу
        /// </summary>
        public double GetArea(Circle figure)
        {
            return 0;
        }

        /// <summary>
        /// Нетривиальная штука! Не стал пробрасывать исключение, чтобы можно было запускать программу
        /// </summary>
        public double GetArea(Triangle figure)
        {
            return 0;
        }

        /// <summary>
        /// Нетривиальная штука! Не стал пробрасывать исключение, чтобы можно было запускать программу
        /// </summary>
        public double GetArea(Rectangle figure)
        {
            return 0;
        }

        /// <summary>
        /// Нетривиальная штука! Не стал пробрасывать исключение, чтобы можно было запускать программу
        /// </summary>
        public double GetPerimeter(Circle figure)
        {
            return 0;
        }

        /// <summary>
        /// Нетривиальная штука! Не стал пробрасывать исключение, чтобы можно было запускать программу
        /// </summary>
        public double GetPerimeter(Triangle figure)
        {
            return 0;
        }

        /// <summary>
        /// Нетривиальная штука! Не стал пробрасывать исключение, чтобы можно было запускать программу
        /// </summary>
        public double GetPerimeter(Rectangle figure)
        {
            return 0;
        }
    }
}
