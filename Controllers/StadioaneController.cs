using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StadioaneDeFotbal.Data;
using StadioaneDeFotbal.Models;
using System.Threading.Tasks;

namespace StadioaneDeFotbal.Controllers
{
    public class StadioaneController : Controller
    {
        private readonly StadioaneDeFotbalContext _context;

        public StadioaneController(StadioaneDeFotbalContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Stadioane.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Oras,Capacitate")] Stadion stadion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stadion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stadion);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadion = await _context.Stadioane.FindAsync(id);
            if (stadion == null)
            {
                return NotFound();
            }
            return View(stadion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Oras,Capacitate")] Stadion stadion)
        {
            if (id != stadion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stadion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StadionExists(stadion.Id))
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
            return View(stadion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stadion = await _context.Stadioane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stadion == null)
            {
                return NotFound();
            }

            return View(stadion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stadion = await _context.Stadioane.FindAsync(id);
            _context.Stadioane.Remove(stadion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StadionExists(int id)
        {
            return _context.Stadioane.Any(e => e.Id == id);
        }
    }
}


