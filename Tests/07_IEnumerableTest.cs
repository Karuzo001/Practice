using NUnit.Framework;
using System;
using Objects;

namespace Tests
{
    public class EnumerableTest
    {
        [Test]
        public void WorkTest()
        {
            var items = new BaseFigure[10];
            for (var i = 0; i < items.Length; i++)
            {
                items[i] = BaseFigure.GenerateRandomFigure();
            }

            var figures = new Figures(items);
            Console.WriteLine("foreach");
            foreach (var figure in figures)
            {
                figure.InfoToConsole();
            }

            Console.WriteLine("\nWhile");
            var figureEnumerator = figures.GetEnumerator();
            while (figureEnumerator.MoveNext())
            {
                figureEnumerator.Current.InfoToConsole();
            }
        }
    }
}