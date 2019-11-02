using NeedleBuddy.DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedleBuddy.DB
{
    public interface IRepository
    {
        public PickupRequestViewModel CreatePickupRequest(PickupRequestViewModel prvm);
        public List<PickupRequestViewModel> FindAllPickupRequests();
        public List<DropOffLocationViewModel> FindAllDropoffLocations();
        public PickupRequestViewModel UpdatePickupRequest(int id, int count, Enums.PickupStatus status);
        public List<PickupRequestViewModel> FindPickupRequestsInDateRange(DateTime start, DateTime end);
    }
}
