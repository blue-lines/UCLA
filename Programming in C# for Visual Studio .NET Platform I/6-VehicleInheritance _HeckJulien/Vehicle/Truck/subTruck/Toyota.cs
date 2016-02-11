using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleInheritance__HeckJulien
{
    class Toyota : Truck
    {
        /** Class Constructors **/
        public Toyota(string model, decimal price, int payloadTruck): base("Toyota", model, price, payloadTruck){ }

        public Toyota(): base("Toyota"){ }

        /** Class Methods **/
        public override List<Truck> getTruck()
        {
            List<Truck> listToyota = new List<Truck>();
            foreach (Truck truckVehicle in base.getTruck())
            {
                if (truckVehicle.Company == "Toyota")
                    listToyota.Add(truckVehicle);
            }
            return listToyota;
        }
    }
}
