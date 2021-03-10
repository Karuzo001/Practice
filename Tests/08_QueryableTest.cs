using NUnit.Framework;
using System;
using Objects;
using System.Linq;

namespace Tests
{
    public class QueryableTest
    {
        [Test]
        public void WorkTest()
        {
            /* var figures = new BaseFigure[100];
             for (var i = figures.Length - 1; i > -1; i--)
             {
                 figures[i] = BaseFigure.GenerateRandomFigure();
             }*/
            var figures = new Figures(15);
            Console.WriteLine("Figures are sorted by area:");
            var figuresSorted = figures.BaseFigures.OrderBy(figure => figure);
            foreach (var figure in figuresSorted)
            {
                figure.InfoToConsole();
            }

            Console.WriteLine("Figures are sorted by perimeter:");
            Array.Sort(figures.BaseFigures, BaseFigure.SortPerimeter());
            foreach (var figure in figures)
            {
                figure.InfoToConsole();
            }

            Console.WriteLine("\n\n Figures with an area greater than 15:");
            var figuresAreaGreater15 =
                figures.BaseFigures.Where(figure => figure.Area() > 15).OrderBy(figure => figure);
            foreach (var figure in figuresAreaGreater15)
            {
                figure.InfoToConsole();
            }

            var minArea = figures.BaseFigures.Min(figure => figure.Area());
            var maxPerimeter = figures.BaseFigures.Max(figure => figure.Perimeter());
            var sumArea = figures.BaseFigures.Sum(figure => figure.Area());
            var allFiguresWithAreaGreater15 = figures.BaseFigures.All(figure => figure.Area() > 40);
            var anyFiguresWithAreaGreater75 = figures.BaseFigures.Any(figure => figure.Area() > 75);
            Console.WriteLine($"min area: {minArea:0.###}\n" +
                              $"max perimeter: {maxPerimeter:0.###}\n" +
                              $"sum area: {sumArea:0.###}\n" +
                              $"Do all the figures have an area greater than 15? {allFiguresWithAreaGreater15}\n" +
                              $"Are there figures with an area greater than 75? {anyFiguresWithAreaGreater75}");
        }
    }
}