using System.ComponentModel.DataAnnotations;

namespace ApiFilms.Models.Dtos;

public class CreateUserDTO
{ 
    //The user just needs to give this information to be registered
    [Required(ErrorMessage = "The field {0} is required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "The field {1} is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "The field {2} is required")]
    public string Password { get; set; }
    [Required(ErrorMessage = "The field {3} is required")]
    public string Role { get; set; }
}