using Microsoft.AspNetCore.Mvc;
using MaximTasks.Services;

namespace MaximTasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StringProcessingController : ControllerBase
    {
        private readonly StringProcessingService _stringProcessingService;
        private readonly SemaphoreSlim _semaphore;

        public StringProcessingController()
        {
            _stringProcessingService = StringProcessingService.Instance;
            _semaphore = new SemaphoreSlim(AppSettings.ParallelLimit);
        }

        [HttpGet("process")]
        public IActionResult ProcessString([FromQuery] string input, [FromQuery] string sortType)
        {
            if (!_semaphore.Wait(0))
            {
                return StatusCode(503, "Service is unavailable");
            }

            if (string.IsNullOrEmpty(input))
            {
                return BadRequest(new { message = "Input string is required" });
            }

            var validSortTypes = new[] { "quick", "tree" }; 
            if (string.IsNullOrEmpty(sortType) || !validSortTypes.Contains(sortType.ToLower()))
            {
                return BadRequest(new
                {
                    message = "Invalid sort type. Allowed values are 'quick' or 'tree'.",
                    providedSortType = sortType
                });
            }

            try
            {
                var response = _stringProcessingService.ProcessString(input, sortType);

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }

}