using System;
using System.Collections.Generic;
using NeedleBuddy.DB.ViewModels;
using Microsoft.EntityFrameworkCore;
using NeedleBuddy.DB;

namespace NeedleBuddy.DB
{
    public class Repository : IRepository
    {
        public Repository()
        {
            // TODO
        }
        
        public Pickuprequest CreatePickupRequest(Pickuprequest prm)
        {
            Pickuprequest dbResponse = new Pickuprequest();
            using(var _context = new NeedleBuddyContext())
            {
                _context.Add(prm);
                _context.SaveChanges();
                dbResponse = _context.Pickuprequest.Find(prm.Id);
            }
            return dbResponse;
        }

        public List<DropOffLocation> FindAllDropoffLocations()
        {
            List<Dropofflocation> dropLocs = new List<Dropofflocation>();
            using (var _context = new )
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
