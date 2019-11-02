using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ReportsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public List<PickupRequestViewModel> ReportWithinDateRange(DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }
    }
}