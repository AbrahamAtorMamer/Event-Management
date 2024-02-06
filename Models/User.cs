namespace Event_Mangement.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Bookings = new HashSet<Booking>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [StringLength(70)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [NotMapped] // Exclude from database mapping
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [StringLength(70)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
