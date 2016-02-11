using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleInheritance__HeckJulien
{
    public class Honda : Car
    {
        /** Class Fields **/
        public bool electric { get; private set; }

        /** Class Constructors **/
        public Honda(string model, decimal price, string typeCar, bool electric): base("Honda", model, price, typeCar)
        { this.electric = electric; }

        public Honda(): base("Honda")
        { this.electric = false; }

        /** Class Methods **/
        public override string ToString()
        {
            return string.Format("{0} \t Electric: {1} \n", base.ToString(), ((this.electric) ? "Yes" : "No"));

        }
    }
}
