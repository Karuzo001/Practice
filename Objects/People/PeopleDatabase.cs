using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Objects.People
{
    public class PeopleDatabase
    {
        public List<string> UsedPassportId;
        public Dictionary<string, Person> Database = new Dictionary<string, Person>();
        public int Count => Database.Count();

        public override string ToString()
        {
            return Database.Aggregate("", (current, person) => current + person.Value + "\n");
        }

        public PeopleDatabase()
        {
            
        }
        public PeopleDatabase(Person person)
        {
            Add(person);
        }
        public void Add(Person person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));
            if (Database.ContainsKey(person.PassportId)) throw new ArgumentException("Passport number must be unique");
            if (UsedPassportId == null) UsedPassportId = new List<string>();
            UsedPassportId.Add(person.PassportId);
            Database.Add(person.PassportId, person);
        }

        public void Remove(Person person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));
            if (!Database.ContainsValue(person)) throw new ArgumentException("This person is not in the database.");
            Database.Remove(person.PassportId);
        }

        public void Remove()
        {
            Database.Remove(Database.Last().Value.PassportId);
        }

        public void Change(Person p1, Person p2)
        {
            if (p1 == null) throw new ArgumentNullException(nameof(p1));
            if (p2 == null) throw new ArgumentNullException(nameof(p2));
            Remove(p1);
            Add(p2);
        }

        public void Clear()
        {
            Database.Clear();
        }

        private string Search(string passportId)
        {
            return Database.ContainsKey(passportId)
                ? Database[passportId].ToString()
                : "This person is not in the database.";
        }
        public void Save()
        {
            var dataDirectory = Directory.GetCurrentDirectory();
            using (var fileWriter = new StreamWriter(dataDirectory + @"/PersonCatalog.txt"))
                foreach (var person in Database)
                    fileWriter.WriteLine(person.Value);
            Console.WriteLine("Directory: " + dataDirectory);
        } 
        public void Load(string path)
        {
            using (var fileReader = new StreamReader(path))
            {
                var newDataBase = new Dictionary<string, Person>();
                var fileString = fileReader.ReadLine();
                while (fileString != null)
                {
                    var field = new string[4];
                    for (var j = 0; j < 4; j++)
                    {
                        if (fileString == null) continue;
                        var value = fileString.Split(':');
                        field[j] = value[1].Trim();
                        fileString = fileReader.ReadLine();
                    }
                    var person = new Person(
                        field[0] ,Convert.ToDateTime(field[1]),
                        field[2],
                        field[3]
                    );
                    newDataBase.Add(person.PassportId, person);
                    fileString = fileReader.ReadLine();
                }
                Database = newDataBase;
            }
        }
    }
}