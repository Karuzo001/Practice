using System;

namespace Objects.People
{
    public class Person : ICloneable<Person>
    {
        private static readonly Random Rn = new Random();
        public string FullName { get; private set; }
        public DateTime BirthDay { get; }
        public string PlaceOfBirth { get; }
        public string PassportId { get; }

        public Person()
        {
            var p = GenerateRandomPerson();
            FullName = p.FullName;
            BirthDay = p.BirthDay;
            PlaceOfBirth = p.PlaceOfBirth;
            PassportId = p.PassportId;
        }
        public Person(string fullName, DateTime birthDay, string placeOfBirth, string passportId)
        {
            if (fullName == "" || birthDay == null || placeOfBirth == "" || passportId == "")
                throw new NullReferenceException("All fields must be filled");
            FullName = fullName;
            BirthDay = birthDay;
            PlaceOfBirth = placeOfBirth;
            PassportId = passportId;
        }


        public void ChangeFullName(string fullName)
        {
            FullName = fullName;
        }

        public override string ToString()
        {
            return ($"Full Name: {FullName}\n" +
                    $"Date of Birth: {BirthDay.ToShortDateString()}\n" +
                    $"Place of Birth: {PlaceOfBirth}\n" +
                    $"Passport ID: {PassportId}\n");
        }

        public static Person GenerateRandomPerson()
        {
            var name = new[]
            {
                "Август", "Иван", "Борис", "Николай", "Григорий",
                "Михаил", "Андрей", "Никита", "Дмитрий", "Олег",
                "Анастасия", "Екатерина", "Кристина", "Наталья", "Надежда",
                "Дарья", "Елена", "Жанна", "Зоя", "Инга",
            };
            var lastname = new[]
            {
                "Иванов", "Борисов", "Николаев", "Григорьев", "Денисов",
                "Михайлов", "Андреев", "Германов", "Дмитриев", "Олегов",
                "Макаров", "Львов", "Карлов", "Захаров", "Евгениев",
                "Михеев", "Моисеев", "Назаров", "Павлов", "Петров"
            };
            var surname = new[]
            {
                "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев",
                "Петров", "Соколов", "Михайлов", "Новиков", "Федоров",
                "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов",
                "Егоров", "Павлов", "Козлов", "Степанов", "Орлов"
            };
            var cities = new[] {"Москва", "Киев", "Тирасполь", "Орел", "Краснодар"};
            var fullname = "";
            switch (Rn.Next(0, 2)) //0 - male 1-female
            {
                case 0:
                {
                    fullname = surname[Rn.Next(0, surname.Length)] + " " + name[Rn.Next(0, name.Length / 2 + 1)] + " " +
                               lastname[Rn.Next(0, lastname.Length)] +
                               "ич";
                    break;
                }
                case 1:
                {
                    fullname = surname[Rn.Next(0, surname.Length)] + "а " + name[Rn.Next(11, name.Length)] + " " +
                               lastname[Rn.Next(0, lastname.Length)] +
                               "на";
                    break;
                }
            }

            var birthdate = new DateTime(1985 + Rn.Next(-15, 16), Rn.Next(1, 13), Rn.Next(1, 29));
            var placeOfBirth = cities[Rn.Next(0, cities.Length)];
            var passportId = "АА " + Rn.Next(0, 10) + Rn.Next(100000, 999999);
            return new Person(fullname, birthdate, placeOfBirth, passportId);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;
            var person = (Person) obj;
            if (PassportId == person.PassportId && !(FullName == person.FullName && BirthDay == person.BirthDay &&
                                                     PlaceOfBirth == person.PlaceOfBirth))
                throw new ArgumentException("Passport number must be unique");
            return (FullName == person.FullName && BirthDay == person.BirthDay && PlaceOfBirth == person.PlaceOfBirth &&
                    PassportId == person.PassportId);
        }

        public bool Equals(string fullName, DateTime birthDay, string placeOfBirth, string passportId)
        {
            return (FullName == fullName && BirthDay == birthDay && PlaceOfBirth == placeOfBirth &&
                    PassportId == passportId);
        }

        public override int GetHashCode()
        {
            return PassportId.GetHashCode();
        }

        public Person Clone()
        {
            var person = new Person(FullName, BirthDay, PlaceOfBirth, PassportId);
            return person;
        }
    }
}