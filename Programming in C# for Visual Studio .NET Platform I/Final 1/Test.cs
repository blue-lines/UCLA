using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Heck_Part1
{
    class Test
    {
        static void Main(string[] args)
        {
            Student aStudent1 = new Student("Student", "Sally", 19, "UCLA", "Computer Science" );
            Console.WriteLine(aStudent1.ToString());

            Student aStudent2 = new Student();
            Console.WriteLine(aStudent2.ToString());

            Student aStudent3 = new Student("Garcia", "Jose", "USC");
            Console.WriteLine(aStudent3.ToString());

            Employee aEmployee1 = new Employee("Smith", "Carol", "Kaiser Hospital", new DateTime(2003, 12, 2), 190000, "Doctor");
            Console.WriteLine(aEmployee1.ToString());

            Employee aEmployee2 = new Employee("Duke", "Bill", "Boeing", new DateTime(2012, 3, 16), 25000, "Janitor");
            Console.WriteLine(aEmployee2.ToString());

        }
    }
}
