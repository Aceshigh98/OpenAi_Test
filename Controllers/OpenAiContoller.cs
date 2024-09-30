
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Cgpt.Services;
using Cgpt.Models;

namespace Cgpt.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class OpenAiController : ControllerBase
    {
        private readonly ILogger<OpenAiController> _logger;
        private readonly OpenAiService _openAiService;

        public OpenAiController(OpenAiService openAiService, ILogger<OpenAiController> logger)
        {
            _openAiService = openAiService;
            _logger = logger;
        }


        /// <summary>
        /// Get completion from OpenAI API
        /// </summary>
        /// <param name="openAiModels"></param>
        /// <returns>The Generated completion text.</returns>
        [HttpPost]
        [Route("GetCompletion")]
        [SwaggerOperation(Summary = "Get completion from OpenAI API")]
        [SwaggerResponse(200, "The generated text completion", typeof(string))]
        [SwaggerResponse(400, "Invalid input parameters")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetCompletion([FromBody] OpenAiModels openAiModels)
        {

            //Console.WriteLine("OpenAiModels: " + openAiModels);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _openAiService.GetCompletionAsync(openAiModels);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}