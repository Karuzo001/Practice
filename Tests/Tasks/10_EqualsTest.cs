using System;
using System.Collections.Generic;
using NUnit.Framework;
using Objects.People;

namespace Tests.Tasks
{
    [TestFixture]
    public class EqualTest
    {
        private readonly List<Person> _people = new List<Person>
        {
            new Person(),
            new Person()
        };

        [Test]
        public void ValueEqualsTest()
        {
            var person = _people[0].Clone();
            Assert.True(_people[0].Equals(person));
        }

        [Test]
        public void ValueNoEqualsTest()
        {
            Assert.False(_people[0].Equals(_people[1]));
        }

        [Test]
        public void HashCodeEqualsTest()
        {
            var person = _people[0].Clone();
            Assert.True(_people[0].GetHashCode().Equals(person.GetHashCode()));
        }

        [Test]
        public void HashCodeNoEqualsTest()
        {
            Assert.False(_people[0].GetHashCode().Equals(_people[1].GetHashCode()));
        }
    }
}