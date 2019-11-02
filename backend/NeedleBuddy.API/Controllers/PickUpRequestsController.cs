using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeedleBuddy.DB;
using NeedleBuddy.DB.ViewModels;

namespace NeedleBuddy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickUpRequestsController : ControllerBase
    {
        private IRepository _respository;
        private IMapper _mapper;
        public PickUpRequestsController(IRepository repository, IMapper mapper)
        {
            _respository = repository;
            _mapper = mapper;
        }

        [HttpPost()]
        public PickupRequestViewModel CreatePickupRequest(string Phone_Number, string Description, float Location_Lat, float Location_Long)
        {
            var prvm = new PickupRequestViewModel()
            {
                Phone_Number = Phone_Number,
                Description = Description,
                Status = Enums.PickupStatus.Pending,
                Count = 0,
                Location_Lat = Location_Lat,
                Location_Long = Location_Long,
            };

            var pickupRequest = _mapper.Map<Pickuprequest>(prvm);

            var databaseResponse = _respository.CreatePickupRequest(pickupRequest);

            return _mapper.Map<PickupRequestViewModel>(databaseResponse);
        }

        [HttpGet("nearby")]
        public List<PickupRequestViewModel> SortedPickupRequests()
        {
            throw new NotImplementedException();
        }

        [HttpGet("list")]
        public List<PickupRequestViewModel> ListAllPickupRequests()
        {
            
        }

        [HttpPut("update")]
        public PickupRequestViewModel UpdatePickupRequest()
        {
            throw new NotImplementedException();
        }
    }
}