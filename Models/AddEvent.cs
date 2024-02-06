namespace Event_Mangement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AddEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AddEvent()
        {
            Bookings = new HashSet<Booking>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "EventName is required")]
        [StringLength(100, ErrorMessage = "EventName must be at most 100 characters")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "EventImage is required")]
        public string EventImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
