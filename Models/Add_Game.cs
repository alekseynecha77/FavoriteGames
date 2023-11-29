using System.ComponentModel.DataAnnotations;

namespace FavGames.Models
{
    public class AddGameModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }

        public string Platforms { get; set; }
    }
}
