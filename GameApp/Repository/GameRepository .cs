using GameApp.Domain;
using GameApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync(int pageNumber, int pageSize)
        {
            return await _context.Games
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<bool> CreateGameAsync(Game game)
        {
            try
            {
                await _context.Games.AddAsync(game);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateGameAsync(Game game)
        {
            try
            {
                _context.Games.Update(game);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured while updating records: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            try
            {
                var game = await GetGameByIdAsync(id);
                if (game != null)
                {
                    _context.Games.Remove(game);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured while Deleting records: {ex.Message}");
                throw;
            }
        }
    }
}