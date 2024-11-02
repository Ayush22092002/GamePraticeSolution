using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDll.Models
{
    [Table("GameTbl")]
    public class Game
    {
        [Key]
        public int GameId { get; set; } // Primary key

        public string GameName { get; set; } = string.Empty; // Name of the game

        public decimal Price { get; set; } // Price of the game
    }
    public class GameDbContext : DbContext
    {
        public GameDbContext() { }

        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

    }
}
