using EventEase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var events = _context.Events.Include(e => e.Venue).ToList();
            return View(events);
        }

        // GET - shows the create form
        public IActionResult Create()
        {
            ViewBag.Venues = _context.Venues.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(newEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newEvent);
        }
        public IActionResult Edit(int id)
        {
            var newEvent = _context.Events.Find(id);
            ViewBag.Venues = _context.Venues.ToList();
            return View(newEvent);
        }

        // POST - handles edit submission
        [HttpPost]
        public IActionResult Edit(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Update(newEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newEvent);
        }

        // GET - shows delete confirmation
        public IActionResult Delete(int id)
        {
            var newEvent = _context.Events.Find(id);
            return View(newEvent);
        }

        // POST - handles delete confirmation
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var newEvent = _context.Events.Find(id);
            if (newEvent != null)
            {
                _context.Events.Remove(newEvent);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
    
}
