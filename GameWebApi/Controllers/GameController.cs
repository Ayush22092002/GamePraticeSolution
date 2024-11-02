using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameDll.Models;
using GameWebApi.DataServices;
using Microsoft.AspNetCore.Cors;

namespace GameWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors")]
    public class GameController : ControllerBase
    {
        private readonly GameDataService _gameDataServices;

        public GameController(GameDataService gameDataServices)
        {
            _gameDataServices = gameDataServices;
        }

        // POST: api/game
        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] Game game)
        {
            try
            {
                await _gameDataServices.AddGameAsync(game);
                return Ok(new { Message = "Game added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET: api/game/{id}
        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetGame(int gameId)
        {
            try
            {
                var game = await _gameDataServices.GetGameAsync(gameId);
                return Ok(game);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // DELETE: api/game/{id}
        [HttpDelete("{gameId}")]
        public async Task<IActionResult> DeleteGame(int gameId)
        {
            try
            {
                await _gameDataServices.DeleteGameAsync(gameId);
                return Ok(new { Message = "Game deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET: api/game
        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            try
            {
                var games = await _gameDataServices.GetAllGamesAsync();
                return Ok(games);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PUT: api/game
        [HttpPut]
        public async Task<IActionResult> UpdateGame([FromBody] Game game)
        {
            try
            {
                await _gameDataServices.UpdateGameAsync(game);
                return Ok(new { Message = "Game updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}

