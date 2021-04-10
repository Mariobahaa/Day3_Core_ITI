using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day3_Core_ITI;
using Day3_Core_ITI.Models;
using ServiceStack;
using Microsoft.AspNetCore.Authorization;

namespace Day3_Core_ITI.Controllers
{
    [Authenticate]
    [Authorize]

    public class TraineesController : Controller
    {
        private readonly TracksContext _context;

        public TraineesController(TracksContext context)
        {
            _context = context;
        }

        // GET: Trainees
        public async Task<IActionResult> Index()
        {
            var tracksContext = _context.Students.Include(t => t.Track);
            return View(await tracksContext.ToListAsync());
        }

        // GET: Trainees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await _context.Students
                .Include(t => t.Track)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainees/Create
        public IActionResult Create()
        {
            ViewData["TrackId"] = new SelectList(_context.Tracks, "ID", "ID");
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Gender,Email,MobileNo,Birthdate,TrackId")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrackId"] = new SelectList(_context.Tracks, "ID", "ID", trainee.TrackId);
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await _context.Students.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }
            ViewData["TrackId"] = new SelectList(_context.Tracks, "ID", "ID", trainee.TrackId);
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Gender,Email,MobileNo,Birthdate,TrackId")] Trainee trainee)
        {
            if (id != trainee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.ID))
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
            ViewData["TrackId"] = new SelectList(_context.Tracks, "ID", "ID", trainee.TrackId);
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await _context.Students
                .Include(t => t.Track)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainee = await _context.Students.FindAsync(id);
            _context.Students.Remove(trainee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
