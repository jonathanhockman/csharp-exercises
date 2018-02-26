using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example.Controllers
{
    using ViewModels;
    using Models;
    using Data;

    public class MenuController : Controller
    {
        private CheeseDBContext context;

        public MenuController(CheeseDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Menus.ToList());
        }

        public IActionResult Add()
        {
            return View(new AddMenuViewModel());
        }

        public IActionResult Add(AddMenuViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu() { Name = viewModel.Name };

                context.Menus.Add(newMenu);
                context.SaveChanges();
            }

        }
    }
}