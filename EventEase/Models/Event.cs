namespace EventEase.Models
{
    public class Event 
    { 
        public int EventId { get; set; } 
         
        public string? EventName { get; set; } 
         
        public DateTime EventDate { get; set; } 
         
        public string? Description { get; set; } 
         
        // Foreign Key 
        public int VenueId { get; set; } 
         
        // allows us to access the Venue object 
        public Venue? Venue { get; set; }
    }
}
