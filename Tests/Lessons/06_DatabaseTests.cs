using System.IO;
using System.Text;
using NUnit.Framework;
using Objects.People;

namespace Tests.Lessons
{
    [TestFixture]
    public class _06_DatabaseTests
    {

        private static PeopleDatabase GetDatabase()
        {
            var data=new PeopleDatabase();
            for (var i = data.Count; i < 10; i++)
            {
                data.Add(Person.GenerateRandomPerson());
            }

            return data;
        }

        [Test]
        public void AddRemoveTest()
        {
            var database = GetDatabase();
            database.Remove();
            database.Remove();
            Assert.AreEqual(database.Count - 2, database.Count);
        }

        [Test]
        public void SaveLoadTest()
        {
            var database = GetDatabase();
            var length = database.Count;
            database.Save();
            database.Load(Directory.GetCurrentDirectory() + @"/PersonDatabase.txt");
            Assert.AreEqual(length, database.Count);
        }


        [Test]
        public void HtmlPersonInfoTest()
        {
            var p = Person.GenerateRandomPerson();
            p.HtmlFile();
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
            var database = GetDatabase();
            database.HtmlFile();
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