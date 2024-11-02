using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDll.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDll.Services
{
    public interface IGameServices
    {
        int Add(Game game);                  // Add a new game
        void Update(Game game);              // Update an existing game
        void Delete(int gameId);             // Delete a game by ID
        Game Get(int gameId);                // Get a game by ID
        List<Game> GetAll();                // Get all Games
    }

    public class GameServices : IGameServices
    {
        private readonly GameDbContext _context;

        public GameServices(GameDbContext context)
        {
            _context = context;
        }


        // Add a new game
        public int Add(Game game)
        {
            var gameEntity = new Game
            {
                GameName = game.GameName,
                Price = game.Price
            };

            _context.Games.Add(gameEntity);
            _context.SaveChanges();
            return gameEntity.GameId;
        }

        // Update an existing game

        public void Update(Game game)
        {
            var gameEntity = _context.Games.FirstOrDefault(g => g.GameId == game.GameId);

            if (gameEntity == null)
            {
                throw new Exception("Game not found to update.");
            }

            gameEntity.GameName = game.GameName;
            gameEntity.Price = game.Price;

            _context.SaveChanges();
        }

        // Get a specific game by ID
        public Game Get(int gameId)
        {
            var gameEntity = _context.Games.FirstOrDefault(g => g.GameId == gameId);

            if (gameEntity == null)
            {
                throw new Exception("Game not found.");
            }

            return gameEntity;
        }
        // Delete a game by ID
        public void Delete(int gameId)
        {
            var gameEntity = _context.Games.Find(gameId);

            if (gameEntity == null)
            {
                throw new Exception("Game not found.");
            }

            _context.Games.Remove(gameEntity);
            _context.SaveChanges();
        }

        // Get all games
        public List<Game> GetAll()
        {
            return _context.Games.ToList();
        }

        
    }

}

