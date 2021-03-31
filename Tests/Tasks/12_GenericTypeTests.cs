using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using NUnit.Framework;
using Objects;
using Objects.People;

namespace Tests.Tasks
{
    [TestFixture]
    public class GenericType
    {
        [Test]
        public void GenerateCollectionUniquePersonsTest()
        {
            const int countOfElements = 100;
            var uniqueCollection = new UniqueCollection<Person>();

            for (var i = 0; i < countOfElements; i++)
            {
                var p = new Person();
                while (uniqueCollection.Contains(p))
                    p = new Person();
                uniqueCollection.Add(p);
            }
            Assert.AreEqual(countOfElements, uniqueCollection.Count);
            CollectionAssert.AllItemsAreUnique(uniqueCollection);
        }
        [Test]
        public void GenerateCollectionWithNotUniquePersonsTest()
        {
            const int countOfElements = 10;
            var uniqueCollection = new UniqueCollection<Person>();
            for (var i = 0; i < countOfElements; i++)
            {
                uniqueCollection.Add(new Person());
            }
            Assert.Throws<ArgumentException>(() => uniqueCollection.Add(uniqueCollection.First()));
            Assert.AreEqual(countOfElements,  uniqueCollection.Count);
            CollectionAssert.AllItemsAreUnique(uniqueCollection);
        }
    }
}