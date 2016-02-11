using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
/// 
public abstract class Employee
{
        protected static List<Employee> listEmployee = new List<Employee>();
        public string employeeID { get; private set; }
        public string lastName { get; private set; }
        public string firstName { get; private set; }
        public DateTime hiredDate { get; private set; }

        public Employee(string firstName, string lastName, string employeeID, DateTime hiredDate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.employeeID = employeeID;
            this.hiredDate = hiredDate;
        }

        public Employee() : this("Unknow", "Unknow", "Unknow", new DateTime(2000, 1, 1)) { }

        private void addItem(Employee E)
        {
            listEmployee.Add(E);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}, Hired Date: {3} ", employeeID, firstName, lastName, hiredDate.ToShortDateString());
        }
}
