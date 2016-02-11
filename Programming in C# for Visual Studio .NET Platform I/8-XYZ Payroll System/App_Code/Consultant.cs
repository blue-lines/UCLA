using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Consultant
/// </summary>
/// 

public class Consultant
{

        public string lastName { get; private set; }
        public string firstName { get; private set; }
        public DateTime startDate { get; private set; }
        public DateTime terminationDate { get; private set; }
        public int payment { get; private set; }

        public Consultant(string firstName, string lastName, DateTime startDate, DateTime terminationDate, int payment)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.startDate = startDate;
            this.terminationDate = terminationDate;
            this.payment = payment;
        }

        public Consultant() : this("Unknow", "Unknow", new DateTime(2000, 1, 1), new DateTime(2000, 1, 1), 0) { }

        public double getSalary()
        {
            return System.Convert.ToDouble(this.payment);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, Start Date: {2}, Termination Date: {3}, Payment: {4:C} ", firstName, lastName, 
                startDate.ToShortDateString(), terminationDate.ToShortDateString(), payment);
        }
}
