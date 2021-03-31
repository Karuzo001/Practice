using System;
using System.Collections.Generic;

namespace Objects
{
    public class Triangle : Figure
    {

        public Triangle(Point point0, Point point1, Point point2)
        {
            if (point0 == null || point1 == null || point2 == null)
                throw new ArgumentNullException(nameof(Points));
            Points = new Point[3];
            Points[0] = point0.Clone();
            Points[1] = point1.Clone();
            Points[2] = point2.Clone();
            SidesLength = GetSidesLength(Points);
        }

        public Triangle(IReadOnlyList<Point> points) : base(points)
        {
        }

        public static Triangle GenerateRandomFigure(Random rn)
        {
            var points = new Point[3];
            double[] sideLength;
            do
            {
                for (var index = 0; index < points.Length; index++)
                {
                    points[index] = new Point(rn.Next(-10, 10), rn.Next(-10, 10));
                }

                sideLength = GetSidesLength(points);
            } while (!(sideLength[0] + sideLength[1] > sideLength[2]) ||
                     !(sideLength[0] + sideLength[2] > sideLength[1]) ||
                     !(sideLength[1] + sideLength[2] > sideLength[0]));

            return new Triangle(points);
        }

        public override double Area()
        {
            return 1 / 2.0 * Math.Abs((Points[1].X - Points[0].X) * (Points[2].Y - Points[0].Y) -
                                      (Points[2].X - Points[0].X) * (Points[1].Y - Points[0].Y));
        }
    }
}