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
    public class DropOffLocationsController : ControllerBase
    {
        private IRepository _repository;
        private IMapper _mapper;
        public DropOffLocationsController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        public List<DropOffLocationViewModel> FindAllDropOffLocations()
        {
            List<DropOffLocationViewModel> dropLocsView
            List<Dropofflocation> dropLocs = _repository.FindAllDropoffLocations();
            _mapper.Map<List<PickupRequestViewModel>>(dropLocs)
        }
    }
}