using System;
using System.Collections.Generic;

namespace Objects
{
    public class Rectangle : Figure
    {
        public Rectangle(Point point0, Point point1, Point point2, Point point3)
        {
            Points = new Point[4];
            Points[0] = point0.Clone();
            Points[1] = point1.Clone();
            Points[2] = point2.Clone();
            Points[3] = point3.Clone();
            SidesLength = GetSidesLength(Points);
        }

        private Rectangle(IReadOnlyList<Point> points) : base(points)
        {
        }

        public static Rectangle GenerateRandomFigure(Random rn)
        {
            var points = new Point[4];
            for (var index = 0; index < 4; index++)
            {
                points[index] = new Point(rn.Next(-10, 10), rn.Next(-10, 10));
            }

            return new Rectangle(points);
        }

        public override double Area()
        {
            var p = Perimeter() / 2.0;
            return Math.Sqrt((p - SidesLength[0]) * (p - SidesLength[1]) * (p - SidesLength[2]) * (p - SidesLength[3]));
        }
    }
}