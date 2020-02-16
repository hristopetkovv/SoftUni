using SharedTrip.Models;
using SharedTrip.ViewModels.TripModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(TripsInputModel model)
        {
            var trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();

        }

        public bool AddUserToTrip(string tripId, string userId)
        {
            var trip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            if (!this.db.UserTrips.Any(x => x.TripId == userTrip.TripId && x.UserId == userTrip.UserId))
            {
                if (trip.Seats <= 0)
                {
                    return false;
                }
                else
                {
                    trip.UserTrips.Add(userTrip);
                    trip.Seats--;
                }

                this.db.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<AllTripsViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new AllTripsViewModel
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Seats = x.Seats,
            }).ToArray();

            return trips;
        }

        public DetailTripViewModel GetById(string id)
        {
            var trip = this.db.Trips
                .Where(x => x.Id == id)
                .Select(x => new DetailTripViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = x.Seats,
                    Description = x.Description,
                    ImagePath = x.ImagePath
                })
                .FirstOrDefault();

            return trip;
        }
    }
}
