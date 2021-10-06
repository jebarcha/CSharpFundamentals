using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._14_Predicates
{
    public static class PredicateDemoThree
    {
        public class Person
        {
            public int Age { get; set; }
        }

        public static void PredicateThree()
        {
            foreach (Person person in OlderThan(18))
            {
                Console.WriteLine(person.Age);
            }
        }

        static IEnumerable<Person> OlderThan(int age)
        {
            Predicate<Person> isOld = x => x.Age > age;
            Person[] persons = { new Person { Age = 10 }, new Person { Age = 20 }, new Person { Age = 19 } };

            foreach (Person person in persons)
                if (isOld(person)) yield return person;
        }

    }
}
