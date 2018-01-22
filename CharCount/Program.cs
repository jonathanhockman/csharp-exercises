using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CharCount
{
    class TestClass
    {
        public float someNum = 0.0f;
        public TestClass(float someNum)
        {
            this.someNum = someNum;
        }

        public int SomeFunction(int number)
        {
            number += 16;
            return this.TimesTwo(number);
        }

        private int TimesTwo(int number)
        {
            return number * 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complete();
        }

        static void Complete()
        {
            #region STRING LITERAL
            //string mainString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.";
            #endregion

            #region READ FROM USER INPUT
            //string mainString = Console.ReadLine();
            #endregion

            #region READ FROM FILE
            // @ tells C# to read this string as a literal string using the exact characters that are in it.
            // If we don't do this then we would need to escape the '\' to tell C# to use the '\' as in "C:\\some\\path"
            string mainString = File.ReadAllText(@"C:\Users\Temporary\Source\Repos\csharp-exercises\CharCount\my_text.txt");
            #endregion

            // Dictionary to store our count results using the letter as the key and the count as the value
            Dictionary<char, int> c_count = new Dictionary<char, int>();

            // Loop through each character in the string
            // Declaring c as var will result in the type being set as Char at compile time
            foreach (var c in mainString)
            {
                // Remember if only one line is executed after an if or else statement you don't need braces
                if (!Char.IsLetter(c))
                    continue; // Skip the remaining code in this iteration and move to the next iteration. Similar to break, but will only break out of this one iteration instead of the whole
                
                // Make case-insensitive by making everything uppercase (or lowercase)
                char key = Char.ToUpper(c);

                // If the key already exists in the dictionary then just add one to the current value
                // else add it to the dictionary with a value of 1 since this would be the first occurrence
                if (c_count.ContainsKey(key))
                    c_count[key] += 1;
                else
                    c_count.Add(key, 1);
            }

            // Using a System.Linq (google it) extension method (google that too) to sort alphabetically
            // count will be a KeyValuePair<Char, int> type
            foreach (var count in c_count.OrderBy(x => x.Key))
            {
                Console.WriteLine(string.Format("{0}: {1}", count.Key, count.Value));
            }

            // Wait for key press before ending the program so we have time to read the results
            Console.ReadKey();

            // Something to store our radius input from user
            string input;
            // something to store our parsed integer from user input
            float r;

            do
            {
                // Prompt user to input radius
                Console.Write("Enter a radius: ");
                // Read user input
                input = Console.ReadLine();
                // TryParse will return true if the string can be parsed to integer else false
                // the out keyword will assign a value to the proceeding variable inside the method being called (in this case that method is TryParse)
                /*
                 * r in the second part of this condition is valid because the comparison will be evaluated after the
                 * TryParse method has been executed and r assigned a value, or it will be skipped entirely if TryParse returns false
                 */
                if (float.TryParse(input, out r) && r > 0)
                {
                    // {1:0.000} in the string.Format method tells it to print only 3 decimal places
                    Console.WriteLine(string.Format("The area of a circle with radius {0} is: {1:0.000}", r, Math.PI * r * r));
                }
                else
                {
                    Console.WriteLine("Please enter a positve number.");
                }
            // Stop the loop if the user has input either "q" or "quit"
            } while (input != "q" && input != "quit");
        }
    }
}
