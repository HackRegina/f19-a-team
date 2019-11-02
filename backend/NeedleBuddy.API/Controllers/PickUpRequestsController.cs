using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeedleBuddy.API.MessageService;
using NeedleBuddy.DB;
using NeedleBuddy.DB.ViewModels;

namespace NeedleBuddy.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PickUpRequestsController : ControllerBase
    {
        private IRepository _repository;
        private IMapper _mapper;
        private ISMSService _textMessages;
        public PickUpRequestsController(IRepository repository, IMapper mapper, ISMSService textMessages)
        {
            _repository = repository;
            _mapper = mapper;
            _textMessages = textMessages;
        }

        [HttpPost()]
        [AllowAnonymous]
        public ActionResult<PickupRequestViewModel> CreatePickupRequest(string Phone_Number, string Description, float Location_Lat, float Location_Long)
        {
            var prvm = new PickupRequestViewModel()
            {
                Phone_Number = Phone_Number,
                Description = Description,
                Status = PickupStatus.Pending,
                Count = 0,
                Location_Lat = Location_Lat,
                Location_Long = Location_Long,
            };

            var pickupRequest = _mapper.Map<Pickuprequest>(prvm);

            var databaseResponse = _repository.CreatePickupRequest(pickupRequest);

            return Ok(_mapper.Map<PickupRequestViewModel>(databaseResponse));
        }

        [HttpGet("nearby")]
        public List<PickupRequestViewModel> SortedPickupRequests(double Location_Lat, double Location_Long)
        {
            List<Pickuprequest> allRequests = _repository.FindAllPickupRequests();
            allRequests = allRequests.OrderBy(o => HaversineHelper.HaversineDistance(Location_Lat, Location_Long, o.LocationLat, o.LocationLong)).ToList();
            return _mapper.Map<List<PickupRequestViewModel>>(allRequests);
        }

        [HttpGet("list")]
        public List<PickupRequestViewModel> ListAllPickupRequests()
        {
            List<Pickuprequest> allRequests = _repository.FindAllPickupRequests();
            return _mapper.Map<List<PickupRequestViewModel>>(allRequests);
        }

        [HttpPut("update")]
        public PickupRequestViewModel UpdatePickupRequest(int id, int count, string status)
        {
            Pickuprequest item =_repository.UpdatePickupRequest(id, count, status);

            if(status == PickupStatus.Found)
            {
                _textMessages.SendSMSMessage(item.PhoneNumber);
            }

            return _mapper.Map<PickupRequestViewModel>(item);
        }
    }
}