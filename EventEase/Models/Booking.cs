namespace EventEase.Models
{
    public class Booking
    {  
        public int BookingId { get; set; } 
         
        public int VenueId { get; set; }  // Foreign Key from Venue table {class}
         
        public Venue? Venue { get; set; } // allows us to revoke the Venue object 
         
        public int EventId { get; set; }  //Foreign Key from Event table {class}
         
        public Event? Event { get; set; } 
         
        public DateTime BookingDate { get; set; }
    }
}
