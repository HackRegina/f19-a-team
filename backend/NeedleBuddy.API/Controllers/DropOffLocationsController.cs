using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeedleBuddy.DB;
using NeedleBuddy.DB.ViewModels;

namespace NeedleBuddy.API.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        public List<DropOffLocationViewModel> FindAllDropOffLocations()
        {
            List<DropOffLocationViewModel> dropLocsView = new List<DropOffLocationViewModel>();
            //DropOffLocationViewModel temp = new DropOffLocationViewModel();
            List<Dropofflocation> dropLocs = _repository.FindAllDropoffLocations();
            dropLocsView = _mapper.Map<List<DropOffLocationViewModel>>(dropLocs);
            //foreach(Dropofflocation dropLoc in dropLocs)
            //{
            //    temp = _mapper.Map<DropOffLocationViewModel>(dropLocs);
            //    dropLocs.Add(temp);
            //}

            return dropLocsView;
        }
    }
}