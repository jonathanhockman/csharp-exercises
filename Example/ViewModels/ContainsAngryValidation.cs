using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Example.ViewModels.Validation
{
    public class ContainsAngry : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            AddCheeseViewModel vm = (AddCheeseViewModel)validationContext.ObjectInstance;

            if (vm.Description != null && !vm.Description.Contains("angry")){
                return new ValidationResult("This failed big time!");
            } else
            {
                return ValidationResult.Success;
            }
        }
    }
}
