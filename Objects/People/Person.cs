using System;

namespace Objects.People
{
    public class Person : ICloneable<Person>
    {
        private static Random rn = new Random();
        private string FullName { get; set; }
        private DateTime BirthDay { get; }
        private string PlaceOfBirth { get; }
        public string PassportId { get; }
        private readonly IGetHashCode _hashCode;

        public Person()
        {
            var p = GenerateRandomPerson();
            FullName = p.FullName;
            BirthDay = p.BirthDay;
            PlaceOfBirth = p.PlaceOfBirth;
            PassportId = p.PassportId;
            _hashCode = p._hashCode;
        }

        public Person(string fullName, DateTime birthDay, string placeOfBirth, string passportId) : this(fullName,
            birthDay, placeOfBirth, passportId, new GetHashCodeDynamic())
        {
        }
        public Person(string fullName, DateTime birthDay, string placeOfBirth, string passportId, IGetHashCode hashcode)
        {
            if (fullName == "" || birthDay == null || placeOfBirth == "" || passportId == "")
                throw new NullReferenceException("All fields must be filled");
            FullName = fullName;
            BirthDay = birthDay;
            PlaceOfBirth = placeOfBirth;
            PassportId = passportId;
            _hashCode = hashcode;
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
            var name = new string[]
            {
                "Август", "Иван", "Борис", "Николай", "Григорий",
                "Михаил", "Андрей", "Никита", "Дмитрий", "Олег",
                "Анастасия", "Екатерина", "Кристина", "Наталья", "Надежда",
                "Дарья", "Елена", "Жанна", "Зоя", "Инга",
            };
            var lastname = new string[]
            {
                "Иванов", "Борисов", "Николаев", "Григорьев", "Денисов",
                "Михайлов", "Андреев", "Германов", "Дмитриев", "Олегов",
                "Макаров", "Львов", "Карлов", "Захаров", "Евгениев",
                "Михеев", "Моисеев", "Назаров", "Павлов", "Петров"
            };
            var surname = new string[]
            {
                "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев",
                "Петров", "Соколов", "Михайлов", "Новиков", "Федоров",
                "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов",
                "Егоров", "Павлов", "Козлов", "Степанов", "Орлов"
            };
            var cities = new string[] {"Москва", "Киев", "Тирасполь", "Орел", "Краснодар"};
            var fullname = "";
            switch (rn.Next(0, 2)) //0 - male 1-female
            {
                case 0:
                {
                    fullname = name[rn.Next(0, name.Length / 2 + 1)] + " " + lastname[rn.Next(0, lastname.Length)] +
                               "ич " +
                               surname[rn.Next(0, surname.Length)];
                    break;
                }
                case 1:
                {
                    fullname = name[rn.Next(11, name.Length)] + " " + lastname[rn.Next(0, lastname.Length)] +
                               "на " +
                               surname[rn.Next(0, surname.Length)] + "а";
                    break;
                }
            }

            var birthdate = new DateTime(1985 + rn.Next(-15, 16), rn.Next(1, 13), rn.Next(1, 29));
            var placeOfBirth = cities[rn.Next(0, cities.Length)];
            var passportId = "АА " + rn.Next(0, 10) + rn.Next(100000, 999999);
            return new Person(fullname, birthdate, placeOfBirth, passportId);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;
            var person = (Person) obj;
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
            return _hashCode.GetHashCode(PassportId);
        }

        public Person Clone()
        {
            var person = new Person(FullName, BirthDay, PlaceOfBirth, PassportId, _hashCode);
            return person;
        }
    }
}