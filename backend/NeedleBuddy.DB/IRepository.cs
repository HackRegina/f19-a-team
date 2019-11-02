using NeedleBuddy.DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedleBuddy.DB
{
    public interface IRepository
    {
        public Pickuprequest CreatePickupRequest(Pickuprequest prm);
        public List<Pickuprequest> FindAllPickupRequests();
        public List<Dropofflocation> FindAllDropoffLocations();
        public Pickuprequest UpdatePickupRequest(int id, int count, string status);
        public List<Pickuprequest> FindPickupRequestsInDateRange(DateTime start, DateTime end);
        public Adminusers GetAdminUserByUsernameAndHashedPassword(string username, string password);
        public Adminusers GetAdminUserById(int id);
        public Clientsecret GetClientsecret();
    }
}
