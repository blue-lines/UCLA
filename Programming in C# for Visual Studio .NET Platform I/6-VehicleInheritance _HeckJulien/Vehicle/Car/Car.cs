using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleInheritance__HeckJulien
{
    public class Car : Vehicle
    {
        /** Class Fields **/
        public string typeCar { get; protected set; }

        /** Class Constructors **/
        public Car(string company, string model, decimal price, string typeCar): base(company,model,price)
        { this.typeCar = typeCar; }

        public Car(string company) : base(company)
        { typeCar = "None"; }

        public Car()
        { typeCar = "None"; }

        /** Class Methods **/
        public override void typeOfVehicle()
        {
            Console.WriteLine("This is a Car");
        }

        public virtual void updateInfo(string model, decimal price, string typeCar)
        {
            this.Model = model;
            this.MRSP = price;
            this.typeCar = typeCar;
        }

        public override string ToString()
        {
            return string.Format("{0} Type: {1} \n", base.ToString(), typeCar);
        }

    }
}
