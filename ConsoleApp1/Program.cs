using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class ShouldHaveSentThreeException : Exception
    {
        public ShouldHaveSentThreeException(string message) : base(message)
        {
        }
    }

    class Program
    {
        enum VehicleType : byte { Car = 1, Truck = 2, Plane = 4, Boat = 8, Bike = 16, Trike = 32, Skate = 64 }

        static void Main(string[] args)
        {
            while (true)
            {
                    string input = Console.ReadLine();
                    TryToAcceptThreesOnly(input);
                
            }
        }

        private static void TryToAcceptThreesOnly(string three)
        {
            try
            {
                AcceptThreesOnly(three);
            }
            catch(ShouldHaveSentThreeException e)
            {
                throw new Exception(e.Message, e);
            }
        }

        private static void AcceptThreesOnly(string three)
        {
            if (three != "3" && three != "three")
            {
                throw new ShouldHaveSentThreeException("Should have sent a 3");
            }
        }

        //    static void Main(string[] args)
        //    {
        //        VehicleType vtype = VehicleType.Car;
        //        Console.WriteLine((byte)vtype);
        //        vtype = VehicleType.Car | VehicleType.Truck | VehicleType.Plane;

        //        Console.WriteLine((byte)vtype);

        //        //Car car = new Car() { name = "bob", doors = 4, mpg = 23.5f, engineType = "v8" };
        //        //Vehicle vehicle = (Vehicle)car;

        //        //Console.WriteLine("{0}, {1}", car, vehicle);
        //        Console.ReadKey();
        //    }
        //}

        //class ChildClass : BaseClass
        //{
        //    public new string ToString()
        //    {
        //        return "childclass";
        //    }
        //}

        //class BaseClass
        //{
        //    public override string ToString()
        //    {
        //        return "baseclass";
        //    }
        //}

        //class Car : Vehicle
        //{
        //    public string name;
        //    public int doors;
        //    public float mpg;

        //    public new string ToString()
        //    {
        //        return string.Format("{0} has {1} doors and gets {2} mpg and is {3}", name, doors, mpg, base.ToString());
        //    }

        //    public override bool Equals(object obj)
        //    {
        //        Car cobj = obj as Car;
        //        if (cobj != null) {
        //            return this.name == cobj.name;
        //        } else
        //        {
        //            return false;
        //        }
        //    }

        //    public override int GetHashCode()
        //    {
        //        return this.name == "bob" ? 1 : 0;
        //    }
        //}

        //class Vehicle
        //{
        //    public string engineType;

        //    public override string ToString()
        //    {
        //        return string.Format("{0}", engineType);
            //}
    }
}
