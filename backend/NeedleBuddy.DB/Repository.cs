using System;
using System.Collections.Generic;
using NeedleBuddy.DB.ViewModels;

namespace NeedleBuddy.DB
{
    public class Repository : IRepository
    {
        public Repository()
        {
            // TODO
        }

        public PickupRequestViewModel CreatePickupRequest(PickupRequestViewModel prvm)
        {
            throw new NotImplementedException();
        }

        public List<DropOffLocationViewModel> FindAllDropoffLocations()
        {
            throw new NotImplementedException();
        }

        public List<PickupRequestViewModel> FindAllPickupRequests()
        {
            throw new NotImplementedException();
        }

        public List<PickupRequestViewModel> FindPickupRequestsInDateRange(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public PickupRequestViewModel UpdatePickupRequest(int id, int count, Enums.PickupStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
