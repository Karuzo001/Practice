using System;

namespace Objects
{
    public class Circle : BaseFigure
    {
        private Point Center { get; }
        private double R { get; }

        public Circle(Point center, double r)
        {
            if (r < 0) throw new ArgumentException("The radius must not be zero.");
            Center = center.Clone() ?? throw new ArgumentNullException(nameof(Center));
            R = r;
        }

        public static Circle GenerateRandomFigure(Random rn)
        {
            return new Circle(new Point(rn.Next(-10, 10), rn.Next(-10, 10)), rn.Next(1, 10));
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(R, 2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * R;
        }

        public override void InfoToConsole()
        {
            Console.WriteLine(GetType());
            Console.WriteLine("Center: {0}\nR={1:0.###}", Center, R);
            Console.WriteLine("Area: {0:0.###}", Area());
            Console.WriteLine("Perimeter: {0:0.###}\n", Perimeter());
        }
    }
}