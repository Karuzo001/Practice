using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using Objects.People;

namespace Tests.Lessons
{
    [TestFixture]
    public class DatabaseTests
    {
        private readonly PeopleDatabase _database = new PeopleDatabase();
        private const int Length = 10;

        private static void FillDatabase(PeopleDatabase data)
        {
            if (data.Count == Length) return;
            for (var i = data.Count; i < Length; i++)
            {
                data.Add(Person.GenerateRandomPerson());
            }
        }

        private void FillDatabase()
        {
            FillDatabase(_database);
        }

        [Test]
        public void AddRemoveTest()
        {
            FillDatabase();
            Assert.AreEqual(Length, _database.Count);
            _database.Remove();
            _database.Remove();
            Assert.AreEqual(Length - 2, _database.Count);
        }

        [Test]
        public void SaveLoadTest()
        {
            FillDatabase();
            _database.Save();
            _database.Load(Directory.GetCurrentDirectory() + @"/PersonCatalog.txt");
            Assert.AreEqual(Length, _database.Count);
        }


        [Test]
        public void HtmlPersonInfoTest()
        {
            var p = Person.GenerateRandomPerson();
            p.HtmlDoc();
            using (var fileStream = File.OpenRead(Directory.GetCurrentDirectory() +
                                                  @"/" + p.FullName + ".html"))
            {
                var htmlCode = new byte[fileStream.Length];
                fileStream.Read(htmlCode, 0, htmlCode.Length);
                var dataFromHtml = Encoding.Default.GetString(htmlCode);
                Assert.IsFalse(p.ToString() == dataFromHtml);
            }
        }

        [Test]
        public void HtmlDatabaseTest()
        {
            var database = new PeopleDatabase();
            FillDatabase(database);
            database.HtmlDoc();
            using (var fileStream = File.OpenRead(Directory.GetCurrentDirectory() +
                                                  @"/database.html"))
            {
                var htmlCode = new byte[fileStream.Length];
                fileStream.Read(htmlCode, 0, htmlCode.Length);
                Assert.IsFalse(database.ToString() == Encoding.Default.GetString(htmlCode));
            }
        }
    }
}