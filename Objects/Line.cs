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

        public void InfoToConsole()
        {
            Console.WriteLine("Line");
            for (var index = 0; index < 2; index++)
            {
                Console.WriteLine("Point{0}: {1}", index, _points[index]);
            }

            Console.WriteLine("Length: {0:0.###}\n", Length());
        }
    }
}