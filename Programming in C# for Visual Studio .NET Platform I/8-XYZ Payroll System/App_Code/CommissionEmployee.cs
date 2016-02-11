using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommissionEmployee
/// </summary>
/// 

public class CommissionEmployee : Employee
{
        //pay is based upon (commission rate * gross sales) + base salary

        public int baseSalary { get; protected set; }
        public double commissionRate { get; protected set; }
        public int grossSales { get; protected set; }

        public CommissionEmployee(string firstName, string lastName, string employeeID, DateTime hiredDate, int baseSalary, double commissionRate, int grossSales) :
            base(firstName, lastName, employeeID, hiredDate)
        {
            this.baseSalary = baseSalary;
            this.commissionRate = commissionRate;
            this.grossSales = grossSales;
        }

        public double getSalary()
        {
            double result = 0;
            result = (this.commissionRate * this.grossSales) + this.baseSalary;
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}, Base Salary: {1:C}, Commission Rate: {2}, Gross Sales: {3:C} \n", base.ToString(), baseSalary, commissionRate, grossSales);
        }
}
