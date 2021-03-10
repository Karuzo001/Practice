using System;
using System.Collections.Generic;
using System.Linq;

namespace Objects
{
    public abstract class Figure : BaseFigure
    {
        protected Point[] Points;
        protected double[] SidesLength;

        protected Figure(IReadOnlyList<Point> points)
        {
            Points = new Point[points.Count];
            for (var i = points.Count - 1; i > -1; i--)
            {
                Points[i] = points[i].Clone();
            }

            SidesLength = GetSidesLength(Points);
        }

        protected Figure()
        {
        }

        public override double Perimeter()
        {
            if (Points == null) throw new ArgumentNullException(nameof(Points));
            return SidesLength.Sum();
        }

        public override void InfoToConsole()
        {
            if (Points == null) throw new ArgumentNullException(nameof(Points));
            Console.WriteLine(GetType());
            for (var index = 0; index < Points.Length; index++)
            {
                Console.WriteLine("Point{0}: {1}", index, Points[index]);
            }

            Console.WriteLine("Area: {0:0.###}", Area());
            Console.WriteLine("Perimeter: {0:0.###}\n", Perimeter());
        }

        protected static double[] GetSidesLength(IReadOnlyList<Point> points)
        {
            if (points == null) throw new ArgumentNullException(nameof(points));
            var sides = new double[points.Count];
            for (var i = 0; i < points.Count - 1; i++)
            {
                sides[i] = Line.Length(points[i], points[i + 1]);
            }

            sides[sides.Length - 1] = Line.Length(points[0], points[points.Count - 1]);
            return sides;
        }
    }
}