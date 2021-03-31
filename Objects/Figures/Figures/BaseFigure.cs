using System;
using System.Collections;

namespace Objects
{
    public abstract class BaseFigure : IComparable
    {
        private static readonly Random Rn = new Random();
        public abstract double Area();
        public abstract double Perimeter();

        private enum NamesFigures
        {
            Triangle,
            Rectangle,
            Circle
        }

        public static BaseFigure GenerateRandomFigure()
        {
            switch ((NamesFigures) Rn.Next(0, 3))
            {
                case NamesFigures.Triangle:
                {
                    return Triangle.GenerateRandomFigure(Rn);
                }
                case NamesFigures.Rectangle:
                {
                    return Rectangle.GenerateRandomFigure(Rn);
                }
                case NamesFigures.Circle:
                {
                    return Circle.GenerateRandomFigure(Rn);
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case null:
                    return 1;
                case BaseFigure otherFigure:
                    return Area().CompareTo(otherFigure.Area());
                default:
                    throw new ArgumentException("Object is not a Figure");
            }
        }

        public static IComparer SortPerimeter()
        {
            return new SortPerimeterHelper();
        }

        private class SortPerimeterHelper : IComparer
        {
            int IComparer.Compare(object objOne, object objTwo)
            {
                if (!(objTwo is BaseFigure p2) || !(objOne is BaseFigure p1))
                    throw new ArgumentException("Object is not a Figure");
                if (p1.Perimeter() > p2.Perimeter())
                    return 1;
                if (p2.Perimeter() > p1.Perimeter())
                    return -1;
                return 0;
            }
        }
    }
}