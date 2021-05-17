using AntipaMuseum.Core.Models;
using AntipaMuseum.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntipaMuseum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService _visitorService;
        private readonly IHttpContextAccessor _httpContext;
        public VisitorController(IVisitorService visitorService, IHttpContextAccessor httpContext)
        {
            _visitorService = visitorService;
            _httpContext = httpContext;
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

        [HttpPatch("{visitorId:int}")]
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

            await _visitorService.UpdateVisitor(visitorId, visitor);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Visitor visitor)
        {
            if (!ModelState.IsValid) return UnprocessableEntity();

            int id = await _visitorService.CreateVisitor(visitor);
            var uri = new Uri(new Uri(_httpContext.HttpContext.Request.Host.Value), $"/visitor/{id}");

            return Created(uri.AbsoluteUri, null);
        }
    }
}
