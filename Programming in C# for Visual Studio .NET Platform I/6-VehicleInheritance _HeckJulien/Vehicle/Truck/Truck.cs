using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleInheritance__HeckJulien
{
    public class Truck : Vehicle
    {
        /** Class Fields **/
        public int payloadTruck{ get; private set; }
        private static List<Truck> listTruck= new List<Truck>();

        /** Class Constructors **/
        public Truck(string company, string model, decimal price, int payloadTruck): base(company,model,price)
        { 
          this.payloadTruck = payloadTruck;
          addItem(this);
        }

        public Truck(string company) : base(company)
        { 
          payloadTruck = 0;
          addItem(this);       
        }

        public Truck()
        { 
          payloadTruck = 0;
          addItem(this);
        }

        /** Class Methods **/
        public override void typeOfVehicle()
        {
            Console.WriteLine("This is a Truck");
        }

        private void addItem(Truck T)
        {
            listTruck.Add(T);
        }
             
        public virtual List<Truck> getTruck()
        {
            return listTruck;
        }
   
        public override string ToString()
        {
            return string.Format("{0} Payload: {1} \n\n", base.ToString(), payloadTruck);
        }
    }
}
