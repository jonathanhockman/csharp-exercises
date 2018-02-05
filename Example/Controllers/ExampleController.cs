using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Example.Models;

namespace Example.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.All();
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Cheese newCheese)
        {
            CheeseData.Add(newCheese);
            return Redirect("/Example");
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