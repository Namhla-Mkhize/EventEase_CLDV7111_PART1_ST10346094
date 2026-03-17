using EventEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{
    public class VenuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VenuesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var venues = _context.Venues.ToList();
            return View(venues);
        }

        // GET - shows the create form
        public IActionResult Create()
        {
            return View();
        }

        // POST - handles form submission
        [HttpPost]
        public IActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Venues.Add(venue);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venue);
        }

        // GET - shows edit form
        public IActionResult Edit(int id)
        {
            var venue = _context.Venues.Find(id);
            return View(venue);
        }

        // POST - handles edit submission
        [HttpPost]
        public IActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Venues.Update(venue);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venue);
        }

        // GET - shows delete confirmation
        public IActionResult Delete(int id)
        {
            var venue = _context.Venues.Find(id);
            return View(venue);
        }

        // POST - handles delete confirmation
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var venue = _context.Venues.Find(id);
            if (venue != null)
            {
                _context.Venues.Remove(venue);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var venue = _context.Venues.Find(id);
            return View(venue);
        }
    }
}
