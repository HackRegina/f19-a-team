using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NeedleBuddy.DB.ViewModels;
using NeedleBuddy.DB;
using System.Linq;

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

        public Pickuprequest CreatePickupRequest(Pickuprequest prm)
        {
            Pickuprequest dbResponse = new Pickuprequest();


            _context.Add(prm);
            _context.SaveChanges();
            dbResponse = _context.Pickuprequest.Find(prm.Id);

            return dbResponse;
        }

        public List<Dropofflocation> FindAllDropoffLocations()
        {
            List<Dropofflocation> dropLocs = new List<Dropofflocation>();
            dropLocs = _context.Dropofflocation.ToListAsync().Result;
            return dropLocs;

        }

        public List<Pickuprequest> FindAllPickupRequests()
        {
            List<Pickuprequest> allPickUps = new List<Pickuprequest>();
            allPickUps = _context.Pickuprequest.ToListAsync().Result;
            return allPickUps;
        }

        public List<Pickuprequest> FindPickupRequestsInDateRange(DateTime start, DateTime end)
        {
            List<Pickuprequest> rangedPickups = new List<Pickuprequest>();
            rangedPickups = _context.Pickuprequest.Where(record => record.LastModified >= start && record.LastModified <= end).ToList(); 
            return rangedPickups;
        }

        public Pickuprequest UpdatePickupRequest(int id, int count, string status)
        {
            Pickuprequest item = _context.Pickuprequest.FirstOrDefault(x => x.Id == id);

            if(item != null)
            {
                item.Count = count;
                item.Status = status;

                _context.Pickuprequest.Update(item);

                _context.SaveChanges();
            }
            return item;
        }

        public Adminusers GetAdminUserByUsernameAndHashedPassword(string username, string password)
        {
            return _context.Adminusers.Where(au => au.Username == username && au.Password == password).FirstOrDefault();
        }

        public Adminusers GetAdminUserById(int id)
        {
            return _context.Adminusers.Where(au => au.Id == id).FirstOrDefault();
        }
    }
}
