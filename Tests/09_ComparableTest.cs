using NUnit.Framework;
using System;
using Objects;

namespace Tests
{
    public class ComparableTest
    {
        [Test]
        public void WorkTest()
        {
            var triangles = new Triangle[10];
            var rn = new Random();
            for (var i = 0; i < triangles.Length; i++)
            {
                triangles[i] = Triangle.GenerateRandomFigure(rn);
            }

            Array.Sort(triangles);
            Array.Reverse(triangles);
            foreach (var item in triangles)
            {
                item.InfoToConsole();
            }
        }
    }
}