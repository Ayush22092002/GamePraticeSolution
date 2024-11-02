using GameDll.Services;
using GameDll.Models;

namespace GameWebApi.DataServices
{
    public class GameDataService
    {
        private readonly IGameServices _gameServices;

        public GameDataService(IGameServices gameServices)
        {
            _gameServices = gameServices;
        }

        // Asynchronous method to get a specific game
        public Task<Game> GetGameAsync(int gameId)
        {
            return Task.Run(() => _gameServices.Get(gameId));
        }

        // Asynchronous method to add a new game
        public Task<int> AddGameAsync(Game game)
        {
            return Task.Run(() => _gameServices.Add(game));
        }

        // Asynchronous method to delete a game
        public Task DeleteGameAsync(int gameId)
        {
            return Task.Run(() => _gameServices.Delete(gameId));
        }

        // Asynchronous method to get all games
        public Task<List<Game>> GetAllGamesAsync()
        {
            return Task.Run(() => _gameServices.GetAll());
        }

        // Asynchronous method to update a game
        public Task UpdateGameAsync(Game game)
        {
            return Task.Run(() => _gameServices.Update(game));
        }
    }
}

