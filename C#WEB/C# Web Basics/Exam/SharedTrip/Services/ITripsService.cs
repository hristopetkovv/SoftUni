namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.ViewModels.TripModels;
    using System.Collections.Generic;

    public interface ITripsService
    {
        void Add(TripsInputModel model);

        IEnumerable<AllTripsViewModel> GetAll();

        DetailTripViewModel GetById(string id);

        bool AddUserToTrip(string tripId, string userId);
    }
}
