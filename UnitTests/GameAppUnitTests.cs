using GameApp.Controllers;
using GameApp.Domain;
using GameApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests
{
    public class GameAppUnitTests
    {
        private readonly Mock<IGameRepository> _gameRepositoryMock;
        private readonly GamesController _controller;

        public GameAppUnitTests()
        {
            _gameRepositoryMock = new Mock<IGameRepository>();
            _controller = new GamesController(_gameRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllGamesAsync_Test()
        {
            var games = new List<Game>
           {
            new Game { Id = 1, Title = "TestGame1", Genre = "TestGenre 1" },
            new Game { Id = 2, Title = "TestGame2", Genre = "TestGenre 2" }
           };
            _gameRepositoryMock.Setup(repo => repo.GetAllGamesAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(games);

            var result = await _controller.GetGames();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedGames = Assert.IsType<List<Game>>(okResult.Value);
            Assert.Equal(2, returnedGames.Count);
        }

        [Fact]
        public async Task CreateGame_NewGameIsCreated()
        {
            var game = new Game { Id = 1, Title = "Test Game", Genre = "Test Genre" };
            _gameRepositoryMock.Setup(repo => repo.CreateGameAsync(game))
                .ReturnsAsync(true);

            var result = await _controller.CreateGame(game);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(game, createdResult.Value);
        }

        [Fact]
        public async Task UpdateGame_ReturnsSuccess_WhenGameIsModified()
        {
            var game = new Game { Id = 1, Title = "Updated Game", Genre = "Updated Genre" };
            _gameRepositoryMock.Setup(repo => repo.UpdateGameAsync(game))
                .ReturnsAsync(true);

            var result = await _controller.UpdateGame(game.Id, game);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DeleteGame()
        {
            int gameId = 1;
            _gameRepositoryMock.Setup(repo => repo.DeleteGameAsync(gameId))
                .ReturnsAsync(true);

            var result = await _controller.DeleteGame(gameId);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}