using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Example.Models
{
    public class Cheese
    {
        public int ID { get; set; }
        [BindRequired]
        public string Name { get; set; }
        [BindRequired]
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public CheeseCategory Category { get; set; }
    }
}
