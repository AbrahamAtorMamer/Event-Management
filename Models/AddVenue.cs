namespace Event_Mangement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("AddVenue")]
    public partial class AddVenue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AddVenue()
        {
            Bookings = new HashSet<Booking>();
            Payments = new HashSet<Payment>();
        }

        [Key]
        public int VenueId { get; set; }

        [Required(ErrorMessage = "VenueName is required")]
        [StringLength(100, ErrorMessage = "VenueName must be at most 100 characters")]
        public string VenueName { get; set; }

        [Required(ErrorMessage = "LocationAddress is required")]
        [StringLength(240, ErrorMessage = "LocationAddress must be at most 240 characters")]
        public string LocationAddress { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Capacity must be a non-negative value")]
        public int? Capacity { get; set; }

        [Required(ErrorMessage = "VenueImage is required")]
        public string VenueImage { get; set; }

        [Display(Name = "Event")]
        public int? EventId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Cost must be a non-negative value")]
        public int? Cost { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Image file is required")]
        public HttpPostedFileBase ImageFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
