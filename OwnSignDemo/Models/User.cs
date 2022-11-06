using System.ComponentModel.DataAnnotations;

namespace OwnSignDemo.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
    }
}
