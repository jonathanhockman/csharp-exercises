using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Example.Models;
using Example.ViewModels;
using Example.Data;
using Microsoft.EntityFrameworkCore;

namespace Example.Controllers
{
    public class ExampleController : Controller
    {
        private CheeseDBContext context;

        public ExampleController(CheeseDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Cheeses.Include(c => c.Category).ToList());
        }

        public IActionResult Add()
        {
            return View(new AddCheeseViewModel(context.Categories.ToList()));
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel cheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                context.Cheeses.Add(new Cheese {
                    Name = cheeseViewModel.Name,
                    Description = cheeseViewModel.Description,
                    Category = context.Categories.Single(x => x.ID == cheeseViewModel.CategoryID)
                });
                context.SaveChanges();
                return Redirect("/Example");
            }

            return View(cheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheese(s)";
            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach(var id in cheeseIds) {
                context.Cheeses.Remove(context.Cheeses.Single(x => x.ID == id));
            }
            context.SaveChanges();
            return Redirect("/Example");
        }

        public IActionResult Category(int id)
        {
            if (id == 0)
            {
                return Redirect("/Category");
            }

            CheeseCategory category = context.Categories.Include(cat => cat.Cheeses).Single(cat => cat.ID == id);
            ViewBag.title = "Cheeses for category " + category.Name;
            return View("Index", category.Cheeses);
        }
    }
}