using System;
using System.Collections.Generic;
using NUnit.Framework;
using Objects.People;

namespace Tests.Tasks
{
    [TestFixture]
    public class _11ListAndDictionary
    {
        private readonly List<Person> _people = new List<Person>
        {
            new Person(),
            new Person(),
            new Person()
        };

        [Test]
        public void DictionaryTest()
        {
            var database = new PersonCatalog();
            database.Add(_people[0], "123 321");
            database.Add(_people[1]);
            Console.WriteLine(database.Search(_people[0]));
            Console.WriteLine(database.Search(_people[1]));
            Console.WriteLine(database.Search(_people[2]));
            Console.WriteLine("\nDatabase:\n" + database);
        }
    }
}