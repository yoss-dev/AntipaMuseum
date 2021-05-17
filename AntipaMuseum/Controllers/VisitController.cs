using AntipaMuseum.Services;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntipaMuseum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitController: ControllerBase
    {
        private readonly IVisitsService _visitsService;
        private readonly IVisitorService _visitorService;
        public VisitController(IVisitsService visitsService, IVisitorService visitorService)
        {
            _visitsService = visitsService;
            _visitorService = visitorService;
        }

        [HttpGet("/visits/last/{visitorId:int}")]
        public async Task<IActionResult> GetLastVisit(int visitorId)
        {
            if (!(await _visitorService.Exists(visitorId))) return NotFound();

            return Ok(_visitsService.GetLastVisit(visitorId));
        }

        [HttpGet]
        public async Task<IActionResult> GetLastVisitsFor(int lastNMonths, int visitorId)
        {
            if (!(await _visitorService.Exists(visitorId))) return NotFound();


            return Ok(await _visitsService.GetLastNMonthVisits(visitorId, lastNMonths));
        }
    }
}
