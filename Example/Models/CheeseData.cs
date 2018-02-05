using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Models
{
    public class CheeseData
    {
        static private List<Cheese> Cheeses = new List<Cheese>() {
            new Cheese("a cheese", "Just some cheese"),
            new Cheese("more cheese", "Just some more cheese"),
            new Cheese("good cheese", "Is gooood cheese"),
            new Cheese("bad cheese", "Is Naaasty"),
            new Cheese("smooshy cheese", "mmmmmm smooshyyyy"),
            new Cheese("smelly cheese", "Yo, it stank")
        };

        public static List<Cheese> All()
        {
            return Cheeses;
        }

        public static void Add(Cheese newCheese)
        {
            Cheeses.Add(newCheese);
        }

        public static void Remove(int[] cheeseIds)
        {
            Cheeses.RemoveAll(x => cheeseIds.Contains(x.Id));
        }
    }
}
