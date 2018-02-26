using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Example.ViewModels
{
    using Models;

    public class AddMenuItemViewModel
    {
        public Menu Menu { get; set; }
        public List<SelectListItem> Cheeses { get; set; }

        public int MenuID { get; set; }
        public int CheeseID { get; set; }

        public AddMenuItemViewModel() { }

        public AddMenuItemViewModel(Menu menu, IList<Cheese> cheeses)
        {
            Cheeses = new List<SelectListItem>();

            foreach(var c in cheeses)
            {
                Cheeses.Add(new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });
            }

            Menu = menu;
        }
    }
}
