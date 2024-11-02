using System.ComponentModel.DataAnnotations;

namespace GameUi.Models
{
    public class Game
    {
        
        public int GameId { get; set; } // Primary key

        public string GameName { get; set; } = string.Empty; // Name of the game

        public decimal Price { get; set; } // Price of the game
    }
}

