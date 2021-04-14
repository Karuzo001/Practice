using System;
using System.Linq;
using NUnit.Framework;
using Objects;

namespace Tests.Tasks
{
    public class _08_QueryableTest
    {//prepare
        private readonly Figures _figures = new Figures(15);

        [Test]
        public void OrderByTest()
        {
            //act
            var figuresSorted = _figures.BaseFigures.OrderBy(figure => figure).ToArray();
            var flag = true;
            //test
            for (var index = figuresSorted.Length - 1; index > 0; index--)
            {
                if (figuresSorted[index - 1].Area() > figuresSorted[index].Area())
                    flag = false;
            }

            Assert.True(flag);
        }

        [Test]
        public void WhereTest()
        {
            const int value = 15;
            var flag = true;
            //act
            var figuresAreaGreater15 =
                _figures.BaseFigures.Where(figure => figure.Area() > value).ToArray();
            //test
            var index = 0;
            foreach (var figure in figuresAreaGreater15)
            {
                while (index < _figures.BaseFigures.Length && !(_figures.BaseFigures[index].Area() > 15))
                    index++;
                if (figure != _figures.BaseFigures[index])
                    flag = false;
                index++;
            }
            Assert.True(flag);
        }

        [Test]
        public void LinqTest()
        {
            var minArea = _figures.BaseFigures.Min(figure => figure.Area());
            var maxPerimeter = _figures.BaseFigures.Max(figure => figure.Perimeter());
            var sumArea = _figures.BaseFigures.Sum(figure => figure.Area());
            var allFiguresWithAreaGreater15 = _figures.BaseFigures.All(figure => figure.Area() > 40);
            var anyFiguresWithAreaGreater75 = _figures.BaseFigures.Any(figure => figure.Area() > 75);

            Console.WriteLine($"min area: {minArea:0.###}\n" +
                              $"max perimeter: {maxPerimeter:0.###}\n" +
                              $"sum area: {sumArea:0.###}\n" +
                              $"Do all the figures have an area greater than 15? {allFiguresWithAreaGreater15}\n" +
                              $"Are there figures with an area greater than 75? {anyFiguresWithAreaGreater75}");
        }
    }
}