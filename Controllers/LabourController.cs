using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zbs_gp_project.Interfaces;
using zbs_gp_project.Models;

namespace zbs_gp_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabourController : Controller
    {
        private readonly ILabourRepository _labourRepository;

        public LabourController(ILabourRepository labourRepository)
        {
            _labourRepository = labourRepository;
        }

        public record LabourDto( string Title, string Description);

        [Authorize]
        [HttpGet("getLabours")]
        [ProducesResponseType(200, Type = typeof(ICollection<Labour>))]
        public async Task<IActionResult> GetBudgets(CancellationToken ct)
        {
            var budgets =  await _labourRepository.GetLaboursAsync(ct);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(budgets);
        }

        [Authorize]
        [HttpPost("addLabour")]
         public async Task<IActionResult> AddLabour([FromBody] LabourDto labour, CancellationToken ct)
        {
            int laboursMaxCount = 5;
            var currentRecodsCount = await _labourRepository.GetUsersLabourCountAsync(ct);

            if (laboursMaxCount > currentRecodsCount)
            {
                Labour lab = new Labour() { Id = $"taskid-{Guid.NewGuid().ToString("N")}", Title = labour.Title, Description = labour.Description, TimeStamp = DateTime.UtcNow };
                await _labourRepository.AddLabourAsync(lab, ct);
                return Ok("User was successfully added");
            }
            else if(laboursMaxCount <= currentRecodsCount) return BadRequest("Riched max amount of tasks");
            else return BadRequest("Something went wrong...");
        }

        [Authorize]
        [HttpDelete("deleteLabour")]
        public async Task<IActionResult> DeleteLabour([FromQuery] string id, CancellationToken ct)
        {
            if (!await _labourRepository.DeleteLabourAsync(id, ct)) { return BadRequest(ModelState); }
            else return Ok("was successfully removed");
        }
    }
}
