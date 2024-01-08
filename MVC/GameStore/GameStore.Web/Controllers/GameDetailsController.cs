using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Web.Data;
using GameStore.Web.Models;

namespace GameStore.Web.Controllers
{
    public class GameDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameDetails.ToListAsync());
        }

        // GET: GameDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameDetails = await _context.GameDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameDetails == null)
            {
                return NotFound();
            }

            return View(gameDetails);
        }

        // GET: GameDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleasedYear,Price")] GameDetails gameDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameDetails);
        }

        // GET: GameDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameDetails = await _context.GameDetails.FindAsync(id);
            if (gameDetails == null)
            {
                return NotFound();
            }
            return View(gameDetails);
        }

        // POST: GameDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleasedYear,Price")] GameDetails gameDetails)
        {
            if (id != gameDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameDetailsExists(gameDetails.Id))
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
            return View(gameDetails);
        }

        // GET: GameDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameDetails = await _context.GameDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameDetails == null)
            {
                return NotFound();
            }

            return View(gameDetails);
        }

        // POST: GameDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameDetails = await _context.GameDetails.FindAsync(id);
            if (gameDetails != null)
            {
                _context.GameDetails.Remove(gameDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameDetailsExists(int id)
        {
            return _context.GameDetails.Any(e => e.Id == id);
        }
    }
}
