using System.ComponentModel.DataAnnotations;

namespace EPizzaHub.UI.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter Username")]
        [EmailAddress(ErrorMessage ="Email Address is not in Correct Format")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
