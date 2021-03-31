using System;
using NUnit.Framework;
using Objects;

namespace Tests.Tasks
{
    [TestFixture]
    public class OopTests
    {
        [Test]
        public void WorkTest()
        {
            var line = new Line(new Point(0, 0), new Point(3, 4));
            Console.WriteLine(line);
            var triangle = new Triangle(new Point(0, 0), new Point(3, 0),
                new Point(0, 4));
            var rectangle = new Rectangle(new Point(0, 0), new Point(3, 0),
                new Point(3, 4), new Point(0, 4));
            var circle = new Circle(new Point(0, 0), 5);
            var figures = new BaseFigure[] {triangle, rectangle, circle};
            foreach (var figure in figures)
            {
                Console.WriteLine(figure);
            }
        }
    }
}