namespace Objects
{
    

    public class Point : ICloneable<Point>
    {
        public double X { get; }
        public double Y { get; }
        public override string ToString() => $"({X:0.###};{Y:0.###})";

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point Clone()
        {
            return new Point(X, Y);
        }
    }
}