using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Heck_Part1
{
    public class Employee
    {
        private static int numEmployee = 0;
        public string lastName { get; protected set; }
        public string firstName { get; protected set; }
        public string Company { get; protected set; }
        public DateTime hiredDate{ get; protected set; }
        public int Salary { get; protected set; }
        public string jobTitle { get; protected set; }

        public Employee(string lastName, string firstName, string Company, DateTime hiredDate, int Salary, string jobTitle)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.Company = Company;
            this.hiredDate = hiredDate;
            this.Salary = Salary;
            this.jobTitle = jobTitle;
            numEmployee++;
        }

        public Employee() : this("Unknown", "Unknown", "Unknown", new DateTime(2000,1,1), 0, "Unknown") { }

        public override string ToString()
        {
            return string.Format("Number of Employee created: {0} \nName: {1} {2}, Company: {3}, Hire Date: {4}, Salary: {5:C}, Job Title: {6}\n",
                numEmployee, firstName, lastName, Company, hiredDate.ToShortDateString(), Salary, jobTitle);
        }

    }
}
