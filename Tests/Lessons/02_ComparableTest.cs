using System;
using System.Linq;
using NUnit.Framework;
using Objects;

namespace Tests.Lessons
{
    [TestFixture]
    public class _02_ComparableTest
    {
        private readonly Figures _figures = new Figures(15);

        [Test]
        public void SortByAreaTest()
        {
            var figuresSorted = _figures.BaseFigures.OrderBy(figure => figure).ToArray();
            for (var index = figuresSorted.Length - 1; index > 0; index--)
            {
                if (figuresSorted[index - 1].Area() > figuresSorted[index].Area())
                    throw new Exception("False");
            }

            Console.WriteLine("Figures are sorted by area:");
            foreach (var figure in figuresSorted)
            {
                Console.WriteLine(figure);
            }
        }

        [Test]
        public void SortByPerimeterTest()
        {
            Array.Sort(_figures.BaseFigures, BaseFigure.SortPerimeter());
            for (var index = _figures.BaseFigures.Length - 1; index > 0; index--)
            {
                if (_figures.BaseFigures[index - 1].Perimeter() > _figures.BaseFigures[index].Perimeter())
                    throw new Exception("False");
            }

            Console.WriteLine("Figures are sorted by perimeter:");
            foreach (var figure in _figures)
            {
                Console.WriteLine(figure);
            }
        }
    }
}