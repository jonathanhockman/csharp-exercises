using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<CheeseMenu> CheeseMenus { get; set; } = new List<CheeseMenu>();
    }
}
