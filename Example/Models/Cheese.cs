using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Example.Models
{
    public class Cheese
    {
        public enum CheeseType { Hard, Soft, Smelly, Aged }

        [BindRequired]
        public string Name { get; set; }
        [BindRequired]
        public string Description { get; set; }
        public CheeseType Type { get; set; }
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
