using AntipaMuseum.Core.Models;
using AntipaMuseum.Services;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntipaMuseum.Controllers
{
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;

        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _visitorService.GetAll());
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int visitorId)
        {
            var existingEntity = _visitorService.GetVisitorById(visitorId);

            if (existingEntity == null)
                return NotFound();

            await _visitorService.DeleteVisitor(visitorId);

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int visitorId, [FromBody] Visitor visitor)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            if (!(await _visitorService.Exists(visitorId)))
            {
                return NotFound();
            }

            _visitorService.UpdateVisitor(visitor);
        }
    }
}
