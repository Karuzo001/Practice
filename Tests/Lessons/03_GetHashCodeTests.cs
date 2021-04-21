using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Objects;

namespace Tests.Lessons
{
    [TestFixture]
    public class _03_GetHashCodeTests
    {

        private class StaticHashCode : ICloneable<StaticHashCode>
        {
            public override int GetHashCode()
            {
                return 0;
            }

            public StaticHashCode Clone()
            {
                return new StaticHashCode();
            }
        }

        private class DynamicHashCode : ICloneable<DynamicHashCode>
        {
            public DynamicHashCode Clone()
            {
                return new DynamicHashCode();
            }
        }

        [Test]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void GetHashCodeTest(int count)
        {
            Console.WriteLine($"Number of repetitions: {count}");
            Console.WriteLine(
                $"HashCode Dynamic: {GetLeadTime(count, new DynamicHashCode()).ElapsedMilliseconds} ticks");
            Console.WriteLine($"HashCode Static: {GetLeadTime(count, new StaticHashCode()).ElapsedMilliseconds} ticks");
        }

        private static Stopwatch GetLeadTime(int count, DynamicHashCode baseHashCode)
        {
            var people = new Dictionary<object, string>();
            var hashCode = new DynamicHashCode[count];

            for (var i = 0; i < count; i++)
            {
                hashCode[i] = baseHashCode.Clone();
            }

            var sw = new Stopwatch();
            sw.Start();
            foreach (var item in hashCode)
            {
                people.Add(item, "");
            }

            sw.Stop();
            return sw;
        }

        private static Stopwatch GetLeadTime(int count, StaticHashCode baseHashCode)
        {
            var people = new Dictionary<object, string>();
            var hashCode = new StaticHashCode[count];

            for (var i = 0; i < count; i++)
            {
                hashCode[i] = baseHashCode.Clone();
            }

            var sw = new Stopwatch();
            sw.Start();
            foreach (var item in hashCode)
            {
                people.Add(item, "");
            }

            sw.Stop();
            return sw;
        }
    }
}