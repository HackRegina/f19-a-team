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
    public class ReportsController : ControllerBase
    {
        private IRepository _repository;
        private IMapper _mapper;
        public ReportsController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        public List<PickupRequestViewModel> ReportWithinDateRange(DateTime StartDate, DateTime EndDate)
        {
            List<PickupRequestViewModel> reportsView = new List<PickupRequestViewModel>();
            List<Pickuprequest> reports = _repository.FindPickupRequestsInDateRange(StartDate, EndDate);
            return _mapper.Map<List<PickupRequestViewModel>>(reports);
        }
    }
}