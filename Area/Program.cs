using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area
{
    class Program
    {
        static void Main(string[] args)
        {
            Complete();
        }

        static void Complete() {
            float r;
            string input;

            do
            {
                Console.Write("Enter a radius: ");
                input = Console.ReadLine();
                if (float.TryParse(input, out r) && r > 0)
                {
                    Console.WriteLine(string.Format("The area of a circle with radius {0} is: {1:0.000}", r, Math.PI * r * r));
                }
                else
                {
                    Console.WriteLine("Please enter a positve number.");
                }
            } while (input != "q" && input != "quit");
        }
    }
}
