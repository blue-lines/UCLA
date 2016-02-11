using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleInheritance__HeckJulien
{
    public class Ford : Car
    {
        /** Class Fields **/
        public int numSeat { get; private set; }

        /** Class Constructors **/
        public Ford(string model, decimal price, string typeCar, int numSeat): base("Ford", model, price, typeCar)
        { this.numSeat = numSeat; }

        public Ford(): base("Ford")
        { this.numSeat = 0; }

        /** Class Methods **/
        public override string ToString()
        {
            return string.Format("{0} \t Number of seats: {1} \n", base.ToString(), numSeat);
        }
    }
}
