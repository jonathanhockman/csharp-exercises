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
        [ContainsAngry]
        public string Description { get; set; }
        public Cheese.CheeseType Type { get; set; }
        public List<SelectListItem> CheeseTypes { get; set; }

        public AddCheeseViewModel()
        {
            CheeseTypes = new List<SelectListItem>();

            foreach(int k in Enum.GetValues(typeof(Cheese.CheeseType)))
            {
                CheeseTypes.Add(new SelectListItem {
                    Value = k.ToString(),
                    Text = ((Cheese.CheeseType)k).ToString()
                });
            }
        }
    }
}
