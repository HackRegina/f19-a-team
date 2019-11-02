using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NeedleBuddy.DB.ViewModels;

namespace NeedleBuddy.DB
{
    public class Repository : IRepository
    {
        private NeedleBuddyContext _context;
        public static Repository CreateRepository(string connectionString)
        {
            return new Repository(connectionString);
        }

        private Repository(string connectionString)
        {
            var contextBuilder = new DbContextOptionsBuilder<NeedleBuddyContext>();
            contextBuilder.UseNpgsql(connectionString);
            _context = new NeedleBuddyContext(contextBuilder.Options);
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
