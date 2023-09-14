using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMS2._0.DTO;
using VMS2._0.Services.IService;

namespace VMS2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;
        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        } // Constructor end

        [HttpPost]
        public async Task<IActionResult> InitiateVisit([FromBody] InitiateVisitDTO initiateVisitDto)
        {
            var visitId = await _visitService.InitiateVisitAsync(initiateVisitDto);
            if (visitId > 0)
            {
                return Ok(new { status = "success", visitID = visitId });
            }
            return BadRequest(new { status = "failure", message = "Could not initiate visit." });
        }//- InitiateVisit end



    }// Controller end
}
