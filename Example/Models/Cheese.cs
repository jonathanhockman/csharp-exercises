using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Example.Models
{
    public class Cheese
    {
        [BindRequired]
        public string Name { get; set; }
        [BindRequired]
        public string Description { get; set; }
        [BindNever]
        public int Id { get; private set; }
        private static int nextId = 1;

        public Cheese()
        {
            this.Id = nextId;
            nextId++;
        }

        public Cheese(string name, string description) : this()
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
