using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Example.Models;
using Example.ViewModels;

namespace Example.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View(CheeseData.All());
        }

        public IActionResult Add()
        {
            return View(new AddCheeseViewModel());
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel cheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                CheeseData.Add(new Cheese {
                    Name = cheeseViewModel.Name,
                    Description = cheeseViewModel.Description,
                    Type = cheeseViewModel.Type
                });
                return Redirect("/Example");
            }

            return View(cheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheese(s)";
            ViewBag.cheeses = CheeseData.All();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            CheeseData.Remove(cheeseIds);
            return Redirect("/Example");
        }
    }
}