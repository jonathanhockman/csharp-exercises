using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.ViewModels
{
    using Models;

    public class ViewMenuViewModel
    {
        public Menu Menu { get; set; }
        public IList<CheeseMenu> Items { get; set; }
    }
}
