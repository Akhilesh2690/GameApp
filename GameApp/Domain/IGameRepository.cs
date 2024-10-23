using GameApp.Models;

namespace GameApp.Domain
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync(int pageNumber, int pageSize);

        Task<Game> GetGameByIdAsync(int id);

        Task<bool> CreateGameAsync(Game game);

        Task<bool> UpdateGameAsync(Game game);

        Task<bool> DeleteGameAsync(int id);
    }
}