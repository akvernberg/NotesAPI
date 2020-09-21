using System.Threading.Tasks;
using DataAccess.Client;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly ISQLiteClient _client;
        private readonly ILogger<NotesController> _logger;

        public NotesController(ILogger<NotesController> logger, ISQLiteClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            var result = await _client.GetAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _client.GetAsync(id);
            if(result == null)
            {
                _logger.LogInformation($"Could not find any notes with Id {id}");
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] Note note)
        {
            var result = await _client.InsertAsync(note);
            return new CreatedAtActionResult(nameof(Get), $"notes", new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Consumes("application/json")]
        public async Task<IActionResult> Put(int id, [FromBody] Note note)
        {
            note.Id = id;
            await _client.UpdateAsync(note);

            return Ok();
        }
    }
}
