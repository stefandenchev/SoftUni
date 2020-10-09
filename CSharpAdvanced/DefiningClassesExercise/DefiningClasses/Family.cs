using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember() => People.OrderByDescending(x => x.Age).First();

        public Person[] GetPeople()
        {
            var people = People.Where(x => x.Age > 30).OrderBy(x => x.Name).ToArray();
            return people;
        }



        /*{int maxAge = int.MinValue;
        Person oldest = null;

        foreach (var person in People)
        {
            var currAge = person.Age;
            if (currAge > maxAge)
            {
                maxAge = currAge;
                oldest = person;
            }
        }
        return oldest;}*/

        //Person oldest = People.OrderByDescending(x => x.Age).First();
        //return oldest;

    }
}