using System;

namespace Objects
{
    public sealed class Line
    {
        private readonly Point[] _points = new Point[2];

        public Line(Point start, Point end)
        {
            _points[0] = start;
            _points[1] = end;
        }

        private double Length()
        {
            return Math.Sqrt(Math.Pow((_points[1].X - _points[0].X), 2) + Math.Pow((_points[1].Y - _points[0].Y), 2));
        }

        public static double Length(Point point1, Point point2)
        {
            if (point1 == null) throw new ArgumentNullException(nameof(point1));
            if (point2 == null) throw new ArgumentNullException(nameof(point2));
            return Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2));
        }

        public override string ToString()
        {
            var info = GetType()+"\n";
            for (var index = 0; index < 2; index++)
            {
                info += $"Point{index}: {_points[index]}\n";
            }

            info += $"Length: {Length():0.###}\n";
            return info;
        }
    }
}