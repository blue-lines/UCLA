using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleInheritance__HeckJulien
{
    class Dodge : Truck
    {
        /** Class Constructors **/
        public Dodge(string model, decimal price, int payloadTruck): base("Dodge", model, price, payloadTruck){ }

        public Dodge(): base("Dodge"){ }

        /** Class Methods **/
        public override List<Truck> getTruck()
        {
            List<Truck> listDodge = new List<Truck>();
            foreach (Truck truckVehicle in base.getTruck()) {
                if (truckVehicle.Company == "Dodge")
                    listDodge.Add(truckVehicle);
            }
            return listDodge;
        }

    }
}
