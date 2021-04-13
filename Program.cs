using Bogus;
using System;
using System.Collections.Generic;

namespace Task4
{
    public class Person
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);

            Faker<Person> generatorPerson = GetPersonGenerator(args[1]);

            List<Person> persons = generatorPerson.Generate(count);

            PrintPersons(persons);
        }

        private static Faker<Person> GetPersonGenerator(string reg)
        {
            return new Faker<Person>(reg)
            .RuleFor(x => x.FullName, f => f.Name.FullName())
            .RuleFor(x => x.Phone, f => f.Phone.PhoneNumberFormat())
            .RuleFor(x => x.Adress, f => f.Address.FullAddress());
        }
        private static void PrintPersons(List<Person> persons)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine($"{persons[i].FullName};+{persons[i].Phone};{persons[i].Adress}");
            }
        }
    }
}
