#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bloodbank_proj.Models;

namespace Bloodbank_proj.Controllers
{
    public class InformationController : Controller
    {
        private readonly BLOODBANKContext _context;

        public InformationController(BLOODBANKContext context)
        {
            _context = context;
        }

        // GET: Information
        public async Task<IActionResult> Index()
        {
            return View(await _context.Information.ToListAsync());
        }

        // GET: Information/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var information = await _context.Information
                .FirstOrDefaultAsync(m => m.Id == id);
            if (information == null)
            {
                return NotFound();
            }

            return View(information);
        }

        // GET: Information/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Information/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Location,Contact")] Information information)
        {
            if (ModelState.IsValid)
            {
                _context.Add(information);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(information);
        }

        // GET: Information/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var information = await _context.Information.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }
            return View(information);
        }

        // POST: Information/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Location,Contact")] Information information)
        {
            if (id != information.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(information);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformationExists(information.Id))
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
            return View(information);
        }

        // GET: Information/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var information = await _context.Information
                .FirstOrDefaultAsync(m => m.Id == id);
            if (information == null)
            {
                return NotFound();
            }

            return View(information);
        }

        // POST: Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var information = await _context.Information.FindAsync(id);
            _context.Information.Remove(information);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformationExists(int id)
        {
            return _context.Information.Any(e => e.Id == id);
        }
    }
}
