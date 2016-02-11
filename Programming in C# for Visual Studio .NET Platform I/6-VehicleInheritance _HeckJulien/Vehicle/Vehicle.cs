using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInheritance__HeckJulien
{
    public abstract class Vehicle
    {
        /** Class Fields **/
        private static int numVehicles = 0;
        public string Company { get; private set; }
        public string Model { get; protected set; }
        public decimal MRSP { get; protected set; }

        /** Class Constructors **/
        public Vehicle(string company, string model, decimal price)
        {
            this.Company = company;
            this.Model = model;
            this.MRSP = price;
            numVehicles++;
        }

        public Vehicle(string company) : this(company,  "None", 0) { }

        public Vehicle() : this("None", "None", 0) { }

        /** Class Methods **/
        public abstract void typeOfVehicle();

        public override string ToString()
        {
            return string.Format("Number of Vehicles created: {0} \nCompany: {1}\n\t Model: {2} \n\t MRSP: {3:C} \n\t", numVehicles, Company, Model, MRSP);
        }

    }
}
