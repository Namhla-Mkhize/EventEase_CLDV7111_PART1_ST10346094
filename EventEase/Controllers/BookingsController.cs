using EventEase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var bookings = _context.Bookings
        .Include(b => b.Venue)
        .Include(b => b.Event)
        .ToList();
            return View(bookings);
        }

        // GET - shows the create form
        public IActionResult Create()
        {

            ViewBag.Venues = _context.Venues.ToList();
            ViewBag.Events = _context.Events.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }
        public IActionResult Edit(int id)
        {
            var booking = _context.Bookings.Find(id);
            ViewBag.Venues = _context.Venues.ToList();
            ViewBag.Events = _context.Events.ToList();
            return View(booking);
        }

        // POST - handles edit submission
        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Update(booking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET - shows delete confirmation
        public IActionResult Delete(int id)
        {
            var booking = _context.Bookings
        .Include(b => b.Venue)
        .Include(b => b.Event)
        .FirstOrDefault(b => b.BookingId == id);
            return View(booking);
        }

        // POST - handles delete confirmation
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
