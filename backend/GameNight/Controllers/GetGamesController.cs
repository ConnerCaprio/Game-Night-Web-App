using GameNight.DTOs.Models;
using GameNight.DTOs.Responses;
using GameNight.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameNight.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetGamesController : ControllerBase
    {

        private readonly ILogger<GetGamesController> _logger;
        private readonly IGetGamesService _getGamesService;

        public GetGamesController(ILogger<GetGamesController> logger, IGetGamesService getGamesService)
        {
            _logger = logger;
            _getGamesService = getGamesService;
        }

        [HttpGet(Name = "GetGames")]
        public async Task<ActionResult<IEnumerable<GetGamesResponse>>> Get()
        {
            var games = await _getGamesService.GetGamesAsync();

            if (games == null)
                return StatusCode(500, "An unexpected error occurred");

            return Ok(games);
        }

        [HttpGet("{gameName}", Name = "GetGameByName")]
        public async Task<ActionResult<GameWithPieces>> GetGameByName(string gameName)
        {
            var game = await _getGamesService.GetGameByNameAsync(gameName);

            if (game == null)
                return NotFound($"Game '{gameName}' not found");

            return Ok(game);
        }
    }
}
