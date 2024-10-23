using GameApp.Domain;
using GameApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public GamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        /// <summary>
        /// Retrieves a paginated list of games based on the specified page number and page size.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetGames(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var games = await _gameRepository.GetAllGamesAsync(pageNumber, pageSize);
                return Ok(games);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                         $"Error occurred while fetching records: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves particular game  by its unique Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            try
            {
                var game = await _gameRepository.GetGameByIdAsync(id);
                return game != null ? Ok(game) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                         $"Error occurred while fetching records: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new game with the specified parameters.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] Game game)
        {
            if (game == null)
            {
                return BadRequest(new { message = "Game data is required." });
            }
            try
            {
                var created = await _gameRepository.CreateGameAsync(game);
                if (!created)
                {
                    return StatusCode(500, new { message = "An  unexpected error occurred while creating the game." });
                }

                return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                         $"An unexpected error occurred. {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the details of an existing gameby the using Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="game"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] Game game)
        {
            try
            {
                if (id != game.Id)
                {
                    return BadRequest(new { message = "Game Id mismatch." });
                }
                var updated = await _gameRepository.UpdateGameAsync(game);
                if (updated)
                {
                    return Ok(new { message = $"Game with Id {id} updated successfully." });
                }
                else
                {
                    return NotFound(new { message = $"Game with Id {id} not found or could not be updated." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                         $"Error occurred while updating records: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete particular game by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var deleted = await _gameRepository.DeleteGameAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = $"Game with Id {id} not found." });
            }
            return Ok(new { message = $"Game with Id {id} deleted successfully." });
        }
    }
}