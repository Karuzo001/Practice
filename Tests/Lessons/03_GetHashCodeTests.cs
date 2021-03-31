using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Objects.People;

namespace Tests.Lessons
{
    [TestFixture]
    public class GetHashCodeTests
    {
        private readonly List<Person> _people = new List<Person>
        {
            new Person("Ivanov Ivan Ivanovich", new DateTime(1973, 04, 25), "Tiraspol", "1-ПР № 3295761"),
            new Person("Petrov Petr Petrovich", new DateTime(1985, 02, 13), "Moscow", "1-ПР № 1155167",
                new GetHashCodeStatic())
        };

        private readonly int[] _countOfRepetitions = {100, 10000, 100000};

        [Test]
        public void GetHashCodeDynamicTest()
        {
            for (var number = 0; number < 3; number++)
            {
                var people = new List<Person>();
                var sw = new Stopwatch();
                sw.Start();
                for (var index = 0; index < _countOfRepetitions[number]; index++)
                {
                    people.Add(_people[0]);
                }

                sw.Stop();
                Console.WriteLine(
                    $"Number of repetitions: {_countOfRepetitions[number]}\nNumber of Ticks: {sw.ElapsedTicks}\n");
            }
        }

        [Test]
        public void GetHashCodeStaticTest()
        {
            for (var number = 0; number < 3; number++)
            {
                var people = new Dictionary<int, Person>();
                var sw = new Stopwatch();
                sw.Start();
                for (var index = 0; index < _countOfRepetitions[number]; index++)
                {
                    people.Add(index, _people[1]);
                }

                sw.Stop();
                Console.WriteLine(
                    $"Number of repetitions: {_countOfRepetitions[number]}\nNumber of Ticks: {sw.ElapsedTicks}\n");
            }
        }
    }
}