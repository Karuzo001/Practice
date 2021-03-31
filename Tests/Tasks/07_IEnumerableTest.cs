using System;
using NUnit.Framework;
using Objects;

namespace Tests.Tasks
{
    public class EnumerableTest
    {
        private readonly BaseFigure[] _figures = new BaseFigure[10];
        private bool _flag;

        [Test]
        public void ForeachTest()
        {
            FillingArray();
            var figures = new Figures(_figures);
            Console.WriteLine("foreach");
            foreach (var figure in figures)
            {
                Console.WriteLine(figure);
            }
        }

        [Test]
        public void WhileTest()
        {
            FillingArray();
            var figures = new Figures(_figures);
            Console.WriteLine("While");
            var figureEnumerator = figures.GetEnumerator();
            while (figureEnumerator.MoveNext())
            {
                Console.WriteLine(figureEnumerator.Current);
            }
        }

        private void FillingArray()
        {
            if (_flag) return;
            for (var i = 0; i < _figures.Length; i++)
            {
                _figures[i] = BaseFigure.GenerateRandomFigure();
            }

            _flag = true;
        }
    }
}