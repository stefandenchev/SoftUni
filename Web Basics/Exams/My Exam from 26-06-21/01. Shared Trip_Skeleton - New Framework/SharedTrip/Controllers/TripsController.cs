namespace SharedTrip.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;
    using SharedTrip.Models.Trips;
    using SharedTrip.Services;
    using SharedTrip.Data;
    using System.Linq;
    using SharedTrip.Data.Models;
    using System;

    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext db;

        public TripsController(
            IValidator validator,
            ApplicationDbContext db)
        {
            this.validator = validator;
            this.db = db;
        }

        [Authorize]
        public HttpResponse All()
        {
            var tripsQuery = this.db
               .Trips
               .AsQueryable();

            var trips = tripsQuery
                .Select(x => new TripListViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = x.Seats,
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", null),
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description,
            };

            db.Trips.Add(trip);

            db.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var tripDetails = this.db
               .Trips
               .Where(i => i.Id == tripId)
               .Select(x => new TripDetailsViewModel
               {
                   Id = x.Id,
                   StartPoint = x.StartPoint,
                   EndPoint = x.EndPoint,
                   DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                   ImagePath = x.ImagePath,
                   Seats = x.Seats,
                   Description = x.Description,
               })
               .FirstOrDefault();

            return View(tripDetails);
        }


        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var userTrip = this.db.UserTrips
                .Where(x => x.TripId == tripId && x.UserId == User.Id)
                .FirstOrDefault();

            if (userTrip != null)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            var newUserTrip = new UserTrip
            {
                UserId = User.Id,
                TripId = tripId,
            };

            var trip = this.db.Trips
                .Find(tripId);
            trip.Seats--;

            this.db.UserTrips.Add(newUserTrip);

            this.db.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
