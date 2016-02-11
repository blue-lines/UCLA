using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Heck_Part1
{
    public class Student : Person
    {
        public string School{ get; set; }
        public string Major { get; set; }

        public Student(string lastName, string firstName, int age, string School, string Major)
            : base(lastName, firstName, age)
        { this.School = School; this.Major = Major; }

        public Student(string lastName, string firstName, string School) : this(lastName, firstName, 0, School, "Unknown"){}

        public Student()
            : base()
        { this.School = "Unknown"; this.Major = "Unknown"; }

        public bool isEligible()
        {
            bool eligible = false;
            if (this.age < 25) eligible = true;

            return eligible;
        }

        public override string ToString()
        {
            return string.Format("{0} School: {1}, Major: {2} \n", base.ToString(), School, Major);
        }

    }
}
