using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Event_Mangement.Models
{
    public partial class EventModel : DbContext
    {
        public EventModel()
            : base("name=EventModel")
        {
        }

        public virtual DbSet<AddEvent> AddEvents { get; set; }
        public virtual DbSet<AddVenue> AddVenues { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddEvent>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.AddEvent)
                .HasForeignKey(e => e.EventId);

            modelBuilder.Entity<AddEvent>()
                .HasMany(e => e.Payments)
                .WithOptional(e => e.AddEvent)
                .HasForeignKey(e => e.EventId);

            modelBuilder.Entity<AddVenue>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.AddVenue)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AddVenue>()
                .HasMany(e => e.Payments)
                .WithOptional(e => e.AddVenue)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Payments)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();
        }
    }
}
