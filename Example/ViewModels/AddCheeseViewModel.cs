using Example.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using Example.ViewModels.Validation;

namespace Example.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        //[ContainsAngry]
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public List<SelectListItem> CheeseCategories { get; set; }

        public AddCheeseViewModel() { }

        public AddCheeseViewModel(List<CheeseCategory> categories)
        {
            CheeseCategories = new List<SelectListItem>();

            foreach(var cat in categories)
            {
                CheeseCategories.Add(new SelectListItem {
                    Value = cat.ID.ToString(),
                    Text = cat.Name
                });
            }
        }
    }
}
