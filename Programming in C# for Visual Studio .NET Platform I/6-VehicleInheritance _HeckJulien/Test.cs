using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleInheritance__HeckJulien
{
    class Test
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n[INFO] Test Ford class and typeOfVehicle() method \n");
            Ford myCar1 = new Ford("Fiesta",12000, "Sedan", 5);
            myCar1.typeOfVehicle();
            Console.WriteLine(myCar1.ToString());

            Console.WriteLine("\n[INFO] Test Honda class (default constructor) \n");
            Honda myCar2 = new Honda();
            Console.WriteLine(myCar2.ToString());

            Console.WriteLine("\n[INFO] Test Honda class with updateInfo() method \n");
            myCar2.updateInfo("Civic", 16000, "Sedan");
            Console.WriteLine(myCar2.ToString());

            Console.WriteLine("\n[INFO] Test Dodge class \n");
            Dodge myTruck1 = new Dodge("Challenger",34000,500);
            Console.WriteLine(myTruck1.ToString());

            Console.WriteLine("\n[INFO] Test Truck class (default constructor) and typeOfVehicle() method \n");
            Truck myTruck2 = new Truck();
            myTruck2.typeOfVehicle();
            Console.WriteLine(myTruck2.ToString());

            Console.WriteLine("\n[INFO] Test getTruck() method with Dodge object \n");
            Dodge myTruck3 = new Dodge("Challenger II", 48000, 1500);
            List<Truck> listTruck1 = myTruck1.getTruck();
            foreach (Truck vehicle in listTruck1)
                Console.WriteLine(vehicle);

            Console.WriteLine("\n[INFO] Test getTruck() method with Truck object \n");
            List<Truck> listTruck = myTruck2.getTruck();
            foreach (Truck vehicle in listTruck)
                Console.WriteLine(vehicle);

            Console.ReadKey();


        }
    }
}
