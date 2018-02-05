using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car() { name = "bob", doors = 4, mpg = 23.5f, engineType = "v8" };
            Vehicle vehicle = (Vehicle)car;

            Console.WriteLine("{0}, {1}", car, vehicle);
            Console.ReadKey();
        }
    }

    class ChildClass : BaseClass
    {
        public new string ToString()
        {
            return "childclass";
        }
    }

    class BaseClass
    {
        public override string ToString()
        {
            return "baseclass";
        }
    }

    class Car : Vehicle
    {
        public string name;
        public int doors;
        public float mpg;

        public new string ToString()
        {
            return string.Format("{0} has {1} doors and gets {2} mpg and is {3}", name, doors, mpg, base.ToString());
        }

        public override bool Equals(object obj)
        {
            Car cobj = obj as Car;
            if (cobj != null) {
                return this.name == cobj.name;
            } else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.name == "bob" ? 1 : 0;
        }
    }

    class Vehicle
    {
        public string engineType;

        public override string ToString()
        {
            return string.Format("{0}", engineType);
        }
    }
}
