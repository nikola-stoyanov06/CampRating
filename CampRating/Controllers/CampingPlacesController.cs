using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampRating.Data;
using CampRating.Entities;

namespace CampRating.Controllers
{
    public class CampingPlacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampingPlacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CampingPlaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.CampingPlace.ToListAsync());
        }

        // GET: CampingPlaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campingPlace = await _context.CampingPlace
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campingPlace == null)
            {
                return NotFound();
            }

            return View(campingPlace);
        }

        // GET: CampingPlaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CampingPlaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CampingPlace campingPlace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campingPlace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campingPlace);
        }

        // GET: CampingPlaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campingPlace = await _context.CampingPlace.FindAsync(id);
            if (campingPlace == null)
            {
                return NotFound();
            }
            return View(campingPlace);
        }

        // POST: CampingPlaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Latitude,Longitude,PhotoUrl")] CampingPlace campingPlace)
        {
            if (id != campingPlace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campingPlace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampingPlaceExists(campingPlace.Id))
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
            return View(campingPlace);
        }

        // GET: CampingPlaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campingPlace = await _context.CampingPlace
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campingPlace == null)
            {
                return NotFound();
            }

            return View(campingPlace);
        }

        // POST: CampingPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campingPlace = await _context.CampingPlace.FindAsync(id);
            if (campingPlace != null)
            {
                _context.CampingPlace.Remove(campingPlace);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampingPlaceExists(int id)
        {
            return _context.CampingPlace.Any(e => e.Id == id);
        }
    }
}
