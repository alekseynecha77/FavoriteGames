using FavGames.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FavGames.Models
{
    public class ContactFormModel
    {
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string? Email { get; set; }
        public string? Message { get; set; }
    }
    

}
