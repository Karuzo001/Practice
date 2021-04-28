using System;

namespace Objects
{
    public interface IDoublerPointOut<out T> 
    {
        void Double();
        public delegate void FiguresNotifier(string notify);
    }
    public interface IDoublerPointIn<in T> 
    {
        void Double();
        public delegate void FiguresNotifier(string notify);
    }
    public class DoublerPoint<T> : IDoublerPointOut<T>,IDoublerPointIn<T> where T : Figure
    {
        private readonly T _figure;
        private readonly Random _rn = new Random();
        public delegate void FiguresNotifier(string notify);
        public event FiguresNotifier PointDoubler;
        public DoublerPoint(T figure)
        {
            _figure = figure ?? throw new ArgumentNullException(nameof(figure));
        }
        public void Double()
        {
            var index = _rn.Next(0, _figure.Points.Length);
            _figure.Points[index] = new Point(_figure.Points[index].X * 2, _figure.Points[index].Y * 2);
            _figure.SidesLength = Figure.GetSidesLength(_figure.Points);
            PointDoubler?.Invoke("The coordinates of the point doubts.");
        }
    }
}