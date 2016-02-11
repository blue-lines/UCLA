using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HourlyEmployee
/// </summary>
/// 

public class HourlyEmployee : Employee
{
        //pay is based upon hourly pay rate * hours worked. If an hourly employee works over 40 hours, 
        //the pay should be based on normal pay plus 1.5 the hourly rate * number of hours over 40 hours.

        public double payRate { get; protected set; }
        public int hoursWorked { get; protected set; }

        public HourlyEmployee(string firstName, string lastName, string employeeID, DateTime hiredDate, double payRate, int hoursWorked) :
            base(firstName, lastName, employeeID, hiredDate)
        {
            this.payRate = payRate;
            this.hoursWorked = hoursWorked;
        }

        public HourlyEmployee()
            : base()
        {
            this.payRate = 0;
            this.hoursWorked = 0;
        }

        public double getSalary()
        {
            double result = 0;
            if (this.hoursWorked > 40) result = (40 * this.payRate) + (((this.hoursWorked - 40) * 1.5) * this.payRate);
            else result = this.hoursWorked * this.payRate;
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}, Pay Rate: {1:C}, Hours Worked: {2} \n", base.ToString(), payRate, hoursWorked);
        }
}
