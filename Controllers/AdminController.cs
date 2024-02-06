using Event_Mangement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class AdminController : Controller
    {
        private EventModel dbContext = new EventModel();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Bookings()
        {
            return View();
        }
        

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

        [HttpPost]
        public ActionResult AddVenue(AddVenue addvenue)
        {
              
                 // Generate unique file name
            string fileName = Path.GetFileNameWithoutExtension(addvenue.ImageFile.FileName);
            string extension = Path.GetExtension(addvenue.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                 // Update the VenueImage property with the correct relative path
                addvenue.VenueImage = "../Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("../Image/"), fileName);
                // Save the file to the server
                addvenue.ImageFile.SaveAs(fileName);
            using ( EventModel evmodel = new EventModel())
            {
                evmodel.AddVenues.Add(addvenue);
                evmodel.SaveChanges();
            }
            ModelState.Clear();
            return View();
            
        }


        public ActionResult Venues()
        {
            
            var venues = dbContext.AddVenues.ToList();
            // Pass the list of venues to the view
            return View(venues);
        }
        public ActionResult AddVenue()
        {
            return View();
        }
        

    }
}
