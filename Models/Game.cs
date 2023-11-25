using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
namespace FavGames.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        // This should have a drop down on the add screen, but should be validated if the user can type in it
        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }
        [Required]
        public string? Genre { get; set; }
        public string? Platforms { get; set; }
    }
}
