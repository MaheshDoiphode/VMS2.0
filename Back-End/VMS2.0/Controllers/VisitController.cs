using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VMS2._0.DTO;
using VMS2._0.Services.IService;

namespace VMS2._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpPost]
        public async Task<IActionResult> InitiateVisit([FromBody] InitiateVisitDTO initiateVisitDTO)
        {
            // Logic will be implemented in the service layer
            var result = await _visitService.InitiateVisitAsync(initiateVisitDTO);

            if (result.Status == "success")
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }//- InitiateVisit






        // Update Visit Status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateVisitStatus(int id, [FromBody] string visitStatus)
        {
            return Ok();
        }

        // Get All Visits for a Host
        [HttpGet("host/{hostEmail}")]
        public async Task<IActionResult> GetAllVisitsByHost(string hostEmail)
        {
            return Ok();
        }

        // Delete a Visit
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            return Ok();
        }

        // Get Visit by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVisitById(int id)
        {
            return Ok();
        }
    }
}
