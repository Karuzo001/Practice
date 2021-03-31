using System;
using NUnit.Framework;
using Objects;
using Objects.Collections;

namespace Tests.Lessons
{
    [TestFixture]
    public class GenericTypeTests
    {
        private FiguresCollection<Triangle> _collection = new FiguresCollection<Triangle>(15);
        Random rn = new Random();

        [Test]
        public void SortByAreaTest()
        {
            for (var i = 0; i < _collection.Length; i++)
            {
                _collection.Collection[i] = Triangle.GenerateRandomFigure(rn);
            }
            string message = null;
            _collection.FiguresAreSorted += delegate(string notify) { message = notify; };
            _collection.SortByArea();
            
            Assert.AreEqual(message,"Figures sorted by area.");
        }

        [Test]
        public void SortByPerimeterTest()
        {
            for (var i = 0; i < _collection.Length; i++)
            {
                _collection.Collection[i] = Triangle.GenerateRandomFigure(rn);
            }

            string message = null;
            _collection.FiguresAreSorted += delegate(string notify) { message = notify; };
            _collection.SortByPerimeter();
            Assert.AreEqual(message,"Figures are sorted by perimeter.");
        }
    }
}