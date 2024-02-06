namespace Event_Mangement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public int BookingId { get; set; }

        [StringLength(240, ErrorMessage = "Name must be at most 240 characters")]
        public string Name { get; set; }

        [StringLength(240, ErrorMessage = "EventName must be at most 240 characters")]
        public string EventName { get; set; }

        [StringLength(240, ErrorMessage = "VenueName must be at most 240 characters")]
        public string VenueName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Cost must be a non-negative value")]
        public int? Cost { get; set; }
        public int? VenueId { get; set; }

        public int? EventId { get; set; }

        public int? UserId { get; set; }

        public virtual AddEvent AddEvent { get; set; }

        public virtual AddVenue AddVenue { get; set; }

        public virtual User User { get; set; }
    }
}
