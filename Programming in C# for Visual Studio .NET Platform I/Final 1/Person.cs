using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Heck_Part1
{
     public abstract class Person
    {

        private static int numPerson = 0;
        public string lastName { get; protected set; }
        public string firstName { get; protected set; }
        public int age { get; protected set; }


        public Person(string lastName, string firstName, int age)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.age = age;
            numPerson++;
        }

        public Person() : this("Unknown", "Unknown", 0) { }

        public override string ToString()
        {
            return string.Format("Number of Person created: {0} \nName: {1} {2}, age: {3} ", numPerson, firstName, lastName, age);
        }

   }
}
