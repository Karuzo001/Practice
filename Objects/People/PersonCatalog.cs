using System;
using System.Collections.Generic;

namespace Objects.People
{
    public class PersonCatalog
    {
        private readonly List<string> _usedPassportId = new List<string>();
        private readonly Dictionary<Person, string> _database = new Dictionary<Person, string>();

        public override string ToString()
        {
            var s = "";
            foreach (var person in _database)
            {
                s += person.Key;
                s += "Place of work: " + person.Value + "\n\n";
            }

            return s;
        }

        public void Add(Person person, string placeOfWork = "Does not work")
        {
            try
            {
                if (_usedPassportId.Contains(person.PassportId)) throw new Exception("Passport number must be unique");
                _database.Add(person, placeOfWork);
                _usedPassportId.Add(person.PassportId);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This person is already in the database.");
            }
        }

        public void Remove(Person person)
        {
            if (!_database.ContainsKey(person))
                Console.WriteLine("This person is not in the database.");
            _database.Remove(person);
        }

        private static string Search(Dictionary<Person, string> people, Person person)
        {
            return people.ContainsKey(person)
                ? people[person]
                : "This person is not in the database.";
        }

        public string Search(string fullName, DateTime birthDay,
            string placeOfBirth, string passportId)
        {
            var person = new Person(fullName, birthDay, placeOfBirth, passportId);
            return Search(_database, person);
        }

        public string Search(Person person)
        {
            return Search(_database, person);
        }
    }
}