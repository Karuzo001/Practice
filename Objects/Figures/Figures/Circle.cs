using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Objects.Annotations;

namespace Objects
{
    public class Circle : BaseFigure, INotifyPropertyChanged
    {
        private Point Center { get; set; }
        private double R { get; set; }

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

        public void ChangeR(double r)
        {
            R = r;
            OnPropertyChanged(nameof(R));
        }

        public void ChangeCenter(Point point)
        {
            Center = point.Clone();
            OnPropertyChanged(nameof(Center));
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(R, 2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * R;
        }

        public override string ToString()
        {
            return GetType() + $"\nCenter: {Center}\nR={R:0.###}\n" +
                   $"Area: {Area():0.###}\n" +
                   $"Perimeter: {Perimeter():0.###}\n";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}