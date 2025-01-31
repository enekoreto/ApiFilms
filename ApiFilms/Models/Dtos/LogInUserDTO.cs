using System.ComponentModel.DataAnnotations;

namespace ApiFilms.Models.Dtos;

public class LogInUserDTO
{ 
    //The user just needs to give this information to log in
    [Required(ErrorMessage = "The field {0} is required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "The field {2} is required")]
    public string Password { get; set; }
}