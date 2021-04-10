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


    public class CourseTracksController : Controller
    {
        private readonly TracksContext _context;

        public CourseTracksController(TracksContext context)
        {
            _context = context;
        }

        // GET: CourseTracks
        public async Task<IActionResult> Index()
        {
            var tracksContext = _context.CourseTracks.Include(c => c.Course);
            return View(await tracksContext.ToListAsync());
        }

        // GET: CourseTracks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTrack = await _context.CourseTracks
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.TackId == id);
            if (courseTrack == null)
            {
                return NotFound();
            }

            return View(courseTrack);
        }

        // GET: CourseTracks/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "ID", "ID");
            return View();
        }

        // POST: CourseTracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,TackId")] CourseTrack courseTrack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseTrack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "ID", "ID", courseTrack.CourseId);
            return View(courseTrack);
        }

        // GET: CourseTracks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTrack = await _context.CourseTracks.FindAsync(id);
            if (courseTrack == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "ID", "ID", courseTrack.CourseId);
            return View(courseTrack);
        }

        // POST: CourseTracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,TackId")] CourseTrack courseTrack)
        {
            if (id != courseTrack.TackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseTrack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseTrackExists(courseTrack.TackId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "ID", "ID", courseTrack.CourseId);
            return View(courseTrack);
        }

        // GET: CourseTracks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTrack = await _context.CourseTracks
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.TackId == id);
            if (courseTrack == null)
            {
                return NotFound();
            }

            return View(courseTrack);
        }

        // POST: CourseTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseTrack = await _context.CourseTracks.FindAsync(id);
            _context.CourseTracks.Remove(courseTrack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseTrackExists(int id)
        {
            return _context.CourseTracks.Any(e => e.TackId == id);
        }
    }
}
