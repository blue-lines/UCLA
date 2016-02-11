using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SalariedEmployee
/// </summary>
/// 

public class SalariedEmployee : Employee
{
        //weekly salary
        public int weeklySalary { get; protected set; }

        public SalariedEmployee(string firstName, string lastName, string employeeID, DateTime hiredDate, int weeklySalary) :
            base(firstName, lastName, employeeID, hiredDate)
        { this.weeklySalary = weeklySalary; }

        public SalariedEmployee()
            : base()
        { this.weeklySalary = 0; }

        public double getSalary()
        {
            double result = 0;
            result = System.Convert.ToDouble(this.weeklySalary);
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}, Weekly Salary: {1:C} \n", base.ToString(), weeklySalary);
        }
}
