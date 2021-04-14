using System;
using System.Collections.Generic;
using System.Linq;

namespace Objects
{
    public abstract class Figure : BaseFigure
    {
        public Point[] Points { get; protected set; }
        public double[] SidesLength{ get; set; }

        protected Figure(IReadOnlyList<Point> points)
        {
            if (points == null) throw new ArgumentNullException(nameof(points));
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

        public override string ToString()
        {
            if (Points == null) throw new ArgumentNullException(nameof(Points));
            var info = GetType()+"\n";
            for (var index = 0; index < Points.Length; index++)
            {
                info += $"Point{index}: {Points[index]}\n";
            }

            info += $"Area: {Area():0.###}\n" +
                    $"Perimeter: {Perimeter():0.###}\n";
            return info;
        }

        public static double[] GetSidesLength(IReadOnlyList<Point> points)
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