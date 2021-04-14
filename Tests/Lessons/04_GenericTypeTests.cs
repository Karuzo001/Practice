using System;
using NUnit.Framework;
using Objects;

namespace Tests.Lessons
{
    [TestFixture]
    public class _04_GenericTypeTests
    {
        [Test]
        public void DoublePointCovarianceTest()
        {
            var random = new Random();
            var triangle = new DoublerPointOut<Triangle>(Triangle.GenerateRandomFigure(random));
            string message = null;
            triangle.PointDoubler += delegate(string notify) { message = notify; };
            IDoublerPointOut<Figure> doublerPointOut = triangle;
            doublerPointOut.Double();
            Assert.IsNotNull(message);
            Assert.AreEqual("The coordinates of the point doubts.", message);
        }

        [Test]
        public void DoublePointContrVarianceTest()
        {
            var random = new Random();
            var triangle = new DoublerPointOut<Figure>(Triangle.GenerateRandomFigure(random));
            string message = null;
            triangle.PointDoubler += delegate(string notify) { message = notify; };
            IDoublerPointIn<Triangle> doublerPoint = triangle;
            doublerPoint.Double();
            Assert.IsNotNull(message);
            Assert.AreEqual("The coordinates of the point doubts.", message);
        }
    }
}