using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Example.Data;
using Example.Models;

namespace Example.Controllers
{
    using ViewModels;

    public class MenuController : Controller
    {
        private readonly CheeseDBContext _context;

        public MenuController(CheeseDBContext context)
        {
            _context = context;
        }

        // GET: Menu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menus.ToListAsync());
        }

        // GET: Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .SingleOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }

            var items = await _context.CheeseMenus.Include(i => i.Cheese).Where(cm => cm.MenuID == id).ToListAsync();

            return View(new ViewMenuViewModel { Menu = menu, Items = items });
        }

        // GET: Menu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.SingleOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Menu menu)
        {
            if (id != menu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .SingleOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.SingleOrDefaultAsync(m => m.ID == id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.ID == id);
        }

        public async Task<IActionResult> AddItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .SingleOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }

            var cheeses = await _context.Cheeses.ToListAsync();
            return View(new AddMenuItemViewModel(menu, cheeses));
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddMenuItemViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var cheeseID = vm.CheeseID;
                var menuID = vm.MenuID;

                IList<CheeseMenu> existingItems = await _context.CheeseMenus.Where(cm => cm.CheeseID == cheeseID).Where(cm => cm.MenuID == menuID).ToListAsync();
                if(existingItems.Count == 0)
                {
                    CheeseMenu item = new CheeseMenu
                    {
                        Cheese = await _context.Cheeses.SingleAsync(c => c.ID == cheeseID),
                        Menu = await _context.Menus.SingleAsync(m => m.ID == menuID)
                    };

                    await _context.CheeseMenus.AddAsync(item);
                    await _context.SaveChangesAsync();

                }
                return RedirectToAction(nameof(Details), new { id = menuID });
            }
            return View(vm);
        }
    }
}
