using Event_Mangement.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private EventModel dbContext = new EventModel();
        [HttpGet]
        public ActionResult Venues(int? venueId)
        {
            // Check if venueId has a value
            if (venueId.HasValue)
            {
                var venue = dbContext.AddVenues.Find(venueId.Value);

                if (venue == null)
                {
                    return HttpNotFound();
                }

                return View(venue);
            }
            else
            {
                // Handle the case where venueId is not provided
                // For example, return a list of all venues or redirect to another action
                var venues = dbContext.AddVenues.ToList();
                //var venues = dbContext.AddVenues;
                return View("Venues", venues);
            }
        }
        [HttpGet]
        public ActionResult BookingStatus()
        {
            if (Session["Id"] != null)
            {
                // Get bookings for the logged-in user
                var userId = (int)Session["Id"];
                var bookings = dbContext.Bookings.Where(b => b.UserId == userId).ToList();

                return View(bookings);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult SubmitBooking(int venueId)
        {
            
            
            var venueDetails = GetVenueDetails(venueId);
            
            // Pass the venue details to the OrderView
            return RedirectToAction("OrderDetails",venueDetails);
        }

        
        public ActionResult OrderDetails(int venueId)
        {
            // Retrieve venue details based on the venueId
            AddVenue venueDetails = GetVenueDetails(venueId);

            // Check if the venueDetails is not null before passing it to the view
            if (venueDetails != null)
            {
                return View(venueDetails);
            }
            else
            {
                // Handle the case where venue details are not found
                return RedirectToAction("Venues");
            }
        }


        private AddVenue GetVenueDetails(int venueId)
        {
            try
            {
                
                    // Retrieve venue details from the database based on venueId
                    var venueDetails = dbContext.AddVenues.SingleOrDefault(v => v.VenueId == venueId);

                    if (venueDetails != null)
                    {
                        // Return the retrieved venue details
                        return venueDetails;
                    }
                    else
                    {
                        return new AddVenue
                        {
                            VenueName = "Default Venue Name",
                            LocationAddress = "Default Venue Address",
                            Capacity = 100,
                            Cost = 200
                        };
                    }
                
            }
            catch (Exception ex)
            {
                // Log the exception or handle accordingly
                return new AddVenue
                {
                    VenueName = "Default Venue Name",
                    LocationAddress = "Default Venue Address",
                    Capacity = 100,
                    Cost = 200
                };
            }
        }



        [HttpGet]
        public ActionResult Payment(int eventId, int venueId)
        {
            if (Session["Id"] != null)
            {
                var userId = (int)Session["Id"];

                // Fetch additional details from the database based on the provided IDs
                var eventDetails = dbContext.AddEvents.FirstOrDefault(e => e.Id == eventId);
                var venueDetails = dbContext.AddVenues.FirstOrDefault(v => v.VenueId == venueId);

                if (eventDetails != null && venueDetails != null)
                {
                    var viewModel = new Payment
                    {
                        EventId = eventId,
                        VenueId = venueId,
                        UserId = userId,
                        UserName = "", 
                        Cost = (int?)CalculateCost(venueDetails), 
                        EventName = eventDetails.EventName,
                        VenueName = venueDetails.VenueName,
                      
                    };

                    return View(viewModel);
                }
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Payment(Payment paymentModel)
        {
            // Handle payment logic, e.g., save payment details to the database
            // Redirect to a confirmation page or perform other necessary actions
            return RedirectToAction("CardDetails");
        }

        // Helper method to calculate the cost based on event and venue details
        private decimal CalculateCost(AddVenue venueDetails)
        {

            return (decimal)venueDetails.Cost;
        }



        [HttpGet]
        public ActionResult PersonalDetails()
        {
            if (Session["Id"] != null)
            {
                // Fetch the user's details based on the session ID
                var userId = (int)Session["Id"];
                var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    
                    var personalDetailsViewModel = new User
                    {
                        Id = user.Id,
                        Name = user.Name,
                        //Name = user.Name,
                        Email = user.Email,
                        Phone = user.Phone,
                        Address = user.Address,
                        
                    };

                    return View(personalDetailsViewModel);
                }
            }

            return View();
        }


        
        
        [HttpPost]
        public ActionResult UpdatePersonalDetails(User model)
        {
            if (ModelState.IsValid)
            {
                // Fetch the user's details based on the provided model
                var user = dbContext.Users.FirstOrDefault(u => u.Id == model.Id);

                if (user != null)
                {
                    // Update user details based on the model
                    user.Name = model.Name;
                    user.Name = model.Name;
                    user.Email = model.Email;

                    // Save changes to the database
                    dbContext.SaveChanges();

                    ViewBag.SuccessMessage = "Personal details updated successfully!";
                    return View("PersonalDetails", model);
                }
                else
                {
                    ViewBag.ErrorMessage = "User not found";
                }
            }

            // If model state is not valid, return the view with validation errors
            return View("PersonalDetails", model);
        }
        public ActionResult Events()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult Venues()
        {
            return View();
        }
    }
}