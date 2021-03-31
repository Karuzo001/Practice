using System;
using NUnit.Framework;
using Objects;

namespace Tests.Tasks
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
            foreach (var figure in triangles)
            {
                Console.WriteLine(figure);
            }
        }
    }
}